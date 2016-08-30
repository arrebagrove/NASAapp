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
        IAstronomyPictureOfDayService pictureService;
        INavigationService navigationService;

        public APODPage()
        {
            InitializeComponent();

            Loaded += APODView_Loaded;

            pictureService = AstronomyPictureOfDayService.Instance;
            navigationService = NavigationService.Instance;
        }

        private async void APODView_Loaded(object sender, RoutedEventArgs e)
        {
            await getPicture(DateTime.Now.Date);
        }

        private async void Get_Clicked(object sender, RoutedEventArgs e)
        {
            DateTime chosenDate = ViewModel.Date.Date;
            await getPicture(chosenDate);
        }

        private async Task getPicture(DateTime date)
        {
            AstronomyPictureOfDay picture = null;
            ViewModel.IsLoading = true;

            try
            {
                picture = await pictureService.GetPicture(date);

                ViewModel.ImageSource = new BitmapImage(new Uri(picture.Url));
                ViewModel.Title = picture.Title;
                ViewModel.Explanation = picture.Explanation;
                ViewModel.Copyright = picture.Copyright != null ? picture.Copyright : "";
            }
            finally
            {
                ViewModel.IsLoading = false;
            }
        }

        private void ShowDownloadedButton_Click(object sender, RoutedEventArgs e)
        {
            navigationService.Navigate(typeof(AstronomyPicturesPage), null);
        }
    }
}
