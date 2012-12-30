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
using System.Windows.Shapes;

namespace SixPackApps.Lexy
{
    /// <summary>
    /// Interaction logic for Preloader.xaml
    /// </summary>
    public partial class Preloader : Window
    {
        private MainWindow mainWindow;
        private BackgroundWorker preloaderBackgroundWorker = new BackgroundWorker();

        public Preloader()
        {
            InitializeComponent();
            preloaderBackgroundWorker.RunWorkerCompleted += preloaderBackgroundWorker_RunWorkerCompleted;
            preloaderBackgroundWorker.DoWork += preloaderBackgroundWorker_DoWork;
        }

        private void preloaderBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs args)
        {
        }

        private void preloaderBackgroundWorker_DoWork(object sender, DoWorkEventArgs args)
        {
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(ThreadMethod);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            //this.preloaderBackgroundWorker.RunWorkerAsync();

        }

        private void ThreadMethod()
        {
            this.mainWindow = new MainWindow();
        }
    }
}
