using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace SixPackApps.Lexy
{
    public static class Utils
    {
        internal const string API_KEY =  "FILDTEOIK2HBORODV";
        internal const string SongNotIdentifiedException = "Song could not be identified. Ensure that the song file is not corrupt, too short or noisy.";
        internal const string FingerprintException = "Fingerprint could not be generated. Ensure you have read-access to the file and ffmpeg.exe, codegen.windows.exe and codegen.dll are present in the executing directory or system path.";

        internal static string HttpGet(string url)
        {
            WebRequest request = WebRequest.Create(url);
            Stream stream = request.GetResponse().GetResponseStream();
            StreamReader streamReader = new StreamReader(stream);

            string response = streamReader.ReadToEnd();
            return response;
        }
     }

    public static class LyricsHelper
    {
        private static FingerprintResponse GetFingerprint(string songPath)
        {
            Process proc = new Process();
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"codegen.windows.exe");
           
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = path;
            startInfo.Arguments = songPath + " 0 40";
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.CreateNoWindow = true;

            proc.StartInfo = startInfo;
            proc.Start();

            string fingerprintResponseJson = proc.StandardOutput.ReadToEnd().Trim(new char[] { '[', ']', '\r', '\n' });
            FingerprintResponse fingerprintResponse = new JavaScriptSerializer().Deserialize<FingerprintResponse>(fingerprintResponseJson);
            return fingerprintResponse;
        }

        private static IdentifyResponse GetIdentity(FingerprintResponse fingerprintResponse)
        {
            string identify_base = "http://developer.echonest.com/api/v4/song/identify";

            string identifyUrl = String.Format("{0}?api_key={1}&code={2}", identify_base, Utils.API_KEY, fingerprintResponse.code);
            string identifyResponseJson = Utils.HttpGet(identifyUrl);
            IdentifyResponse identifyResponse = new JavaScriptSerializer().Deserialize<IdentifyResponse>(identifyResponseJson);
            return identifyResponse;
        }

        private static WikiaResponse GetLyricsWikia(IdentifySong song)
        {
            string wikia_base = "http://lyrics.wikia.com/api.php";
            string wikiaUrl = String.Format("{0}?artist={1}&song={2}&fmt=json", wikia_base, song.artist_name, song.title);

            string wikiaJson = Utils.HttpGet(wikiaUrl);
            WikiaResponse wikiaResponse = new JavaScriptSerializer().Deserialize<WikiaResponse>(wikiaJson.Split(new char[] { '=' })[1]);
            return wikiaResponse;
        }

        private static string ExtractLyricsFromWikia(WikiaResponse wikiaResponse)
        {
            string wikiaHtml = Utils.HttpGet(wikiaResponse.url);
            HtmlDocument htmlDoc = new HtmlDocument();
            MemoryStream mStrm = new MemoryStream(Encoding.UTF8.GetBytes(wikiaHtml));
            htmlDoc.Load(mStrm);

            HtmlNode lyricsNode = htmlDoc.DocumentNode.SelectNodes("//div[@class='lyricbox']")[0];
            string innerHTML = HttpUtility.HtmlDecode(lyricsNode.InnerHtml);
            string lyrics = innerHTML.Replace("<br>", "\n");

            string tagPattern = @"<.*?>.*</?.*?>";
            Regex regex = new Regex(tagPattern);
            lyrics = regex.Replace(lyrics, "");

            string commentPattern = @"<\s*!--.*--\s*>";
            regex = new Regex(commentPattern, RegexOptions.Singleline);
            lyrics = regex.Replace(lyrics, "");
            return lyrics;
        }

        public static string GetLyrics(string songPath)
        {
            FingerprintResponse fingerprintResponse;
            IdentifyResponse identifyResponse;

            fingerprintResponse = GetFingerprint(songPath);

            if (fingerprintResponse.code == null)
            {
                throw new FingerprintException(Utils.FingerprintException);
            }

            identifyResponse = GetIdentity(fingerprintResponse);

            if(identifyResponse.response == null || identifyResponse.response.songs.Count < 1)
            {
                throw new SongNotIdentifiedException(Utils.SongNotIdentifiedException);
            }

            WikiaResponse wikiaResponse = GetLyricsWikia(identifyResponse.response.songs[0]);
            return ExtractLyricsFromWikia(wikiaResponse);
        }
    }

    public class Song
    {
        public string SongPath { get; set; }
        private TagLib.File tagFile;

        public Song(string songPath)
        {
            this.SongPath = songPath;
            this.tagFile = TagLib.File.Create(this.SongPath);
        }

        /// <summary>
        /// Add lyrics to the song given the lyrics string
        /// </summary>
        /// <param name="lyrics"></param>
        public void AddLyrics(string lyrics)
        {
            this.tagFile.Tag.Lyrics = lyrics;
            this.tagFile.Save();
        }

        /// <summary>
        /// Add lyrics without any argument would fetch and add lyrics. This is an overloaded method
        /// </summary>
        public void AddLyrics()
        {
            this.tagFile.Tag.Lyrics = LyricsHelper.GetLyrics(this.SongPath);
            this.tagFile.Save();
        }
    }

    #region FingerprintResponse
    internal class FingerprintResponse
    {
        public FingerprintMetadata metadata { get; set; }
        public string code { get; set; }
    }

    internal class FingerprintMetadata
    {
        public string artist { get; set; }
        public string release { get; set; }
        public string title { get; set; }
        public string genre { get; set; }
        public int bitrate { get; set; }
        public int sample_rate { get; set; }
        public int duration { get; set; }
        public string filename { get; set; }
        public int samples_decoded { get; set; }
        public int given_duration { get; set; }
        public string version { get; set; }
    }
    #endregion

    #region IdentifyResponse
    internal class IdentifyResponse
    {
        public IdentiyResponseInternal response { get; set; }
    }

    internal class IdentiyResponseInternal
    {
        public IdentifyStatus status { get; set; }
        public List<IdentifySong> songs { get; set; }
    }

    internal class IdentifyStatus
    {
        public int code { get; set; }
        public string message { get; set; }
        public string version { get; set; }
    }

    internal class IdentifySong
    {
        public string title { get; set; }
        public string artist_name { get; set; }
        public string artist_id { get; set; }
        public int score { get; set; }
        public string message { get; set; }
        public string id { get; set; }
    }
    #endregion

    #region WikiaResponse
    internal class WikiaResponse
    {
        public string artist { get; set; }
        public string song  { get; set; }
        public string lyrics { get; set; }
        public string url { get; set; }
    }
    #endregion

    #region CustomExceptions
    internal class SongNotIdentifiedException : Exception
    {
        public SongNotIdentifiedException(string message) : base(message)
        {
        }
    }

    internal class FingerprintException : Exception 
    {
        public FingerprintException(string message)
            : base(message)
        { 
        
        }
    }

    internal class WikiaException : Exception 
    {
        public WikiaException(string message)
            : base(message)
        { 
        
        }
    }
    #endregion
}
