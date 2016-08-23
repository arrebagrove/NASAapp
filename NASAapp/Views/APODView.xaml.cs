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
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace NASAapp.Views
{
    public sealed partial class APODView : Page
    {
        IAstronomyPictureOfDayService pictureService;

        public APODView()
        {
            InitializeComponent();

            Loaded += APODView_Loaded;
            pictureService = new AstronomyPictureOfDayService();
        }

        private void APODView_Loaded(object sender, RoutedEventArgs e)
        {
            DateBlock.Date = DateTime.Now;
            LoadingIndicator.Visibility = Visibility.Collapsed;
        }

        private async void Get_Clicked(object sender, RoutedEventArgs e)
        {
            AstronomyPictureOfDay picture = null;
            LoadingIndicator.Visibility = Visibility.Visible;

            try
            {
                picture = await pictureService.GetTodayPicture();

                Img.Source = new BitmapImage(new Uri(picture.Url));
                TitleBlock.Text = picture.Title;
                ExplanationBlock.Text = picture.Explanation;
                CopyrightBlock.Text = picture.Copyright;
            }
            finally
            {
                LoadingIndicator.Visibility = Visibility.Collapsed;
            }
        }
    }
}
