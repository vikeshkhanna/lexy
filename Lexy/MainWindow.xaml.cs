using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SixPackApps.Lexy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LexyModel lexyModel;
        private BackgroundWorker modelBackgroundWorker = new BackgroundWorker();
        private Song currentSong;
        private int fetchCount;
        private int fetchStatus;

        private object syncObject = new object();

        public MainWindow()
        {
            InitializeComponent();
            this.modelBackgroundWorker.RunWorkerCompleted += modelBackgroundWorker_RunWorkerCompleted;
            this.modelBackgroundWorker.DoWork += modelBackgroundWorker_DoWork;
        }

        private void modelBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs args)
        {
            this.DataContext = this.lexyModel;
        }

        private void modelBackgroundWorker_DoWork(object sender, DoWorkEventArgs args)
        {
            this.lexyModel = new LexyModel();
        }

        private void Window_Loaded(object sender, EventArgs e)
        {
            this.modelBackgroundWorker.RunWorkerAsync();
        }

    
        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DataGrid source = e.Source as DataGrid;

            if (source.SelectedItems.Count == 1)
            {
                this.lexyModel.IsMultiSelect = false;
                this.currentSong = source.SelectedItem as Song;
                this.lexyModel.CurrentLyrics = this.currentSong.Lyrics;
            }
            else
            {
                this.lexyModel.IsMultiSelect = (source.SelectedItems.Count > 1 ? true : false);
            }
        }

        private void AddLyricsButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.lexyModel.IsMultiSelect)
            {
                foreach (Song song in this.SongsDataGrid.SelectedItems)
                {
                    Utils.Song utilsSong = new Utils.Song(this.currentSong.Location);
                    utilsSong.AddLyrics(song.Lyrics);
                }
            }
            else
            {
                this.currentSong.Lyrics = this.lexyModel.CurrentLyrics;
                Utils.Song utilsSong = new Utils.Song(this.currentSong.Location);
                utilsSong.AddLyrics(this.currentSong.Lyrics);
                this.currentSong.LyricsStatus = iTunesHelper.LYRICS_UPDATED();
            }
        }

        private void GetLyricsButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.lexyModel.IsFetching = true;
            fetchCount = this.SongsDataGrid.SelectedItems.Count;

            for (int i = 0; i < fetchCount; ++i)
            {
                ThreadPool.QueueUserWorkItem(HandleFetchLyrics, this.SongsDataGrid.SelectedItems[i]);
            }
        }

        private void HandleFetchLyrics(object threadContext)
        {
            if (this.lexyModel.IsFetching)
            {
                Song song = (Song)threadContext;
                    
                try
                {
                    song.Lyrics = Utils.LyricsHelper.GetLyrics(song.Location, song.Title, song.Artist);
                    song.LyricsStatus = iTunesHelper.LYRICS_FETCHED();
                }
                catch (Exception ex)
                {
                    song.LyricsStatus = ex.Message;    
                }
                finally
                {
                    UpdateFetchCount();
                }
            }
        }

        private void UpdateFetchCount()
        {
            lock (syncObject)
            {
                fetchStatus++;
                this.lexyModel.FetchStatus = String.Format("{0}/{1}", fetchStatus, fetchCount);

                if (fetchStatus == fetchCount)
                {
                    this.lexyModel.IsFetching = false;
                    fetchStatus = 0;
                }
            }
        }

        private void SelectAllCheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            this.SongsDataGrid.SelectAll();
        }

        private void SelectMissingCheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            this.SongsDataGrid.UnselectAll();

            foreach (Song song in this.lexyModel.Songs)
            {
                if (song.IsLyricsMissing)
                {
                    this.SongsDataGrid.SelectedItems.Add(song);
                }
            }
        }
      }
}
