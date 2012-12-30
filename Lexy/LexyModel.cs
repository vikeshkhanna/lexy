using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SixPackApps.Lexy
{
    public class LexyModel : INotifyPropertyChanged
    {
        private ObservableCollection<Song> songs;
        private string currentLyrics;
        private bool isMultiSelect;
        private bool isFetching;
        private string fetchStatus;

        public LexyModel()
        {
            this.Songs = iTunesHelper.GetLibrary();
        }

        public ObservableCollection<Song> Songs
        {
            get
            {
                return this.songs;
            }
            set
            {
                if (value != this.songs)
                {
                    this.songs = value;
                    NotifyPropertyChanged("Songs");
                }
            }
        }

        public bool IsMultiSelect
        {
            get
            {
                return this.isMultiSelect;
            }
            set
            {
                if (value != this.isMultiSelect)
                {
                    this.isMultiSelect = value;
                    NotifyPropertyChanged("IsMultiSelect");
                }
            }
        }

        public string CurrentLyrics
        {
            get
            {
                return this.currentLyrics;
            }
            set
            {
                if (value != this.currentLyrics)
                {
                    this.currentLyrics = value;
                    NotifyPropertyChanged("CurrentLyrics");
                }
            }
        }

        public bool IsFetching
        {
            get
            {
                return this.isFetching;
            }
            set
            {
                if (value != this.isFetching)
                {
                    this.isFetching = value;
                    NotifyPropertyChanged("IsFetching");
                }
            }
        }

        public string FetchStatus
        {
            get
            {
                return this.fetchStatus;
            }
            set
            {
                if (value != this.fetchStatus)
                {
                    this.fetchStatus = value;
                    NotifyPropertyChanged("FetchStatus");
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

    [ValueConversion(typeof(bool), typeof(bool))]
    public class InverseBooleanConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(bool))
                throw new InvalidOperationException("The target must be a boolean");

            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
