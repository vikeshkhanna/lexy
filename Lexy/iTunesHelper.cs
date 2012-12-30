using iTunesLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixPackApps.Lexy
{
    internal static class iTunesHelper
    {
        internal static string LYRICS_MISSING = "Missing Lyrics.";
        internal static string LYRICS_AVAILABLE = "Lyrics Available.";
        
        internal static string LYRICS_UPDATED()
        {
            return "Lyrics updated: " + DateTime.Now.ToShortTimeString(); 
        }

        internal static string LYRICS_FETCHED()
        {
            return "Lyrics fetched: " + DateTime.Now.ToShortTimeString();
        }



        internal static ObservableCollection<Song> GetLibrary()
        {
            iTunesAppClass itunes = new iTunesAppClass();
            IITLibraryPlaylist library = itunes.LibraryPlaylist;
            IITTrackCollection tracks = library.Tracks;
            
            ObservableCollection<Song> songs = new ObservableCollection<Song>();

            foreach (IITFileOrCDTrack track in tracks)
            {
                Song song = new Song()
                {
                    Title = track.Name,
                    Album = track.Album,
                    Artist = track.Artist,
                    Location = track.Location,
                    Lyrics = track.Lyrics,
                    LyricsStatus = LYRICS_AVAILABLE
                };

                if(song.IsLyricsMissing)
                {
                    song.LyricsStatus = LYRICS_MISSING;
                }

                if (songs.Count > 500)
                {
                    break;
                }

                songs.Add(song);
            }

            return songs;
        }
    }

    public class Song : INotifyPropertyChanged
    {
        private string artwork;
        private string title;
        private string album;
        private string artist;
        private string lyricsStatus;
        private string location;
        private string lyrics;

        public bool IsLyricsMissing
        {
            get
            {
                if (String.IsNullOrEmpty(this.lyrics) || String.IsNullOrWhiteSpace(this.lyrics))
                {
                    return true;
                }

                return false;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }
            set
            {
                if (value != this.location)
                {
                    this.location = value;
                    NotifyPropertyChanged("Location");
                }
            }
        }

        public string Artwork
        {
            get
            {
                return this.artwork;
            }
            set
            {
                if (value != this.artwork)
                {
                    this.artwork = value;
                    NotifyPropertyChanged("Artwork");
                }
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                if (value != this.title)
                {
                    this.title = value;
                    NotifyPropertyChanged("Title");
                }
            }
        }

        public string Artist
        {
            get
            {
                return this.artist;
            }
            set
            {
                if (value != this.artist)
                {
                    this.artist = value;
                    NotifyPropertyChanged("Artist");
                }
            }
        }


        public string LyricsStatus
        {
            get
            {
                return this.lyricsStatus;
            }
            set
            {
                if (value != this.lyricsStatus)
                {
                    this.lyricsStatus = value;
                    NotifyPropertyChanged("LyricsStatus");
                }
            }
        }

        public string Album
        {
            get
            {
                return this.album;
            }
            set
            {
                if (value != this.album)
                {
                    this.album = value;
                    NotifyPropertyChanged("Album");
                }
            }
        }

        public string Lyrics
        {
            get
            {
                return this.lyrics;
            }
            set
            {
                if (value != this.lyrics)
                {
                    this.lyrics = value;
                    NotifyPropertyChanged("Lyrics");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
