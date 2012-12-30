using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTunesLib;

namespace SixPackApps.Lexy
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string songPath = @"C:\Users\khann_000\Downloads\ENMFP_codegen\test.m4a";
            Song song = new Song(songPath);
            song.AddLyrics();
            */
            
            iTunesAppClass itunes = new iTunesAppClass();
            IITLibraryPlaylist library = itunes.LibraryPlaylist;
            IITTrackCollection tracks = library.Tracks;

            foreach (IITFileOrCDTrack track in tracks)
            {
                Console.WriteLine(track.Location);
            }
            Console.ReadLine();
            
        }
    }
}
