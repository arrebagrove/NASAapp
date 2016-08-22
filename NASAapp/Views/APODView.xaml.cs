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
        IPictureOfDayService pictureService;

        public APODView()
        {
            InitializeComponent();

            Loaded += APODView_Loaded;
            pictureService = new PictureOfDayService();
        }

        private void APODView_Loaded(object sender, RoutedEventArgs e)
        {
            DateBlock.Date = DateTime.Now;
        }

        private async void Get_Clicked(object sender, RoutedEventArgs e)
        {
            // see picture in database
            // 
            try
            {
                var picture = await pictureService.GetTodayPicture();

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
