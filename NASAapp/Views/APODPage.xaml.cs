using NASAapp.DAL;
using NASAapp.Models;
using NASAapp.Services;
using NASASDK.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using System.Threading;
using NASAapp.ViewModels;

namespace NASAapp.Views
{
    public sealed partial class APODPage : Page
    {
        APODPageViewModel ViewModel = new APODPageViewModel();
       
        INavigationService navigationService;

        public APODPage()
        {
            InitializeComponent();
            navigationService = NavigationService.Instance;
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await ViewModel.GetPicture();
        }

        private async void Get_Clicked(object sender, RoutedEventArgs e)
        {
            await ViewModel.GetPicture();
        }

        private void ShowDownloadedButton_Click(object sender, RoutedEventArgs e)
        {
            navigationService.Navigate(typeof(AstronomyPicturesPage), null);
        }
    }
}
