using NASAapp.DAL;
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
            LoadingIndicator.Visibility = Visibility.Collapsed;
        }

        private async void Get_Clicked(object sender, RoutedEventArgs e)
        {
            AstronomyPictureOfDayDAL picture = null;
            LoadingIndicator.Visibility = Visibility.Visible;

            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    picture = db.Pictures.FirstOrDefault(p =>
                        p.Date.Year == DateTime.Now.Year && p.Date.Month == DateTime.Now.Month && p.Date.Day == DateTime.Now.Day);
                    if (picture == null)
                    {
                        var remotePicture = await pictureService.GetTodayPicture();

                        // TODO Save picture and hdpicture to local storage and write their new urls to appropriate properties
                        // 

                        picture = new AstronomyPictureOfDayDAL
                        {
                            Copyright = remotePicture.Copyright,
                            Date = remotePicture.Date,
                            Explanation = remotePicture.Explanation,
                            HdUrl = remotePicture.HdUrl,
                            Title = remotePicture.Title,
                            Url = remotePicture.Url,
                        };
                        db.Add(picture);
                        await db.SaveChangesAsync();
                    }

                    Img.Source = new BitmapImage(new Uri(picture.Url));
                    TitleBlock.Text = picture.Title;
                    ExplanationBlock.Text = picture.Explanation;
                    CopyrightBlock.Text = picture.Copyright;
                }
            }
            finally
            {
                LoadingIndicator.Visibility = Visibility.Collapsed;
            }
        }
    }
}
