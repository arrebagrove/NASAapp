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

namespace NASAapp.Views
{
    public sealed partial class APODPage : Page
    {
        IAstronomyPictureOfDayService pictureService;

        public APODPage()
        {
            InitializeComponent();

            Loaded += APODView_Loaded;
            pictureService = AstronomyPictureOfDayService.Instance;
        }

        private void APODView_Loaded(object sender, RoutedEventArgs e)
        {
            DateBlock.Date = DateTime.Now;
            LoadingIndicator.Visibility = Visibility.Collapsed;

            getPicture();
        }

        private async void Get_Clicked(object sender, RoutedEventArgs e)
        {
            DateTime chosenDate = DateBlock.Date.Date;

            AstronomyPictureOfDay picture = null;
            LoadingIndicator.Visibility = Visibility.Visible;

            try
            {
                picture = await pictureService.GetPicture(chosenDate);

                Img.Source = new BitmapImage(new Uri(picture.Url));
                TitleBlock.Text = picture.Title;

                ExplanationRichBlock.Blocks.Clear();
                string[] paragraphs = picture.Explanation.Split(new string[] { "  " }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string p in paragraphs)
                {
                    Paragraph paragraph = new Paragraph();
                    Run run = new Run();
                    run.Text = p;
                    paragraph.Inlines.Add(run);

                    ExplanationRichBlock.Blocks.Add(paragraph);
                }

                CopyrightBlock.Text = picture.Copyright != null ? picture.Copyright : "";
            }
            finally
            {
                LoadingIndicator.Visibility = Visibility.Collapsed;
            }
        }

        private async void getPicture()
        {
            AstronomyPictureOfDay picture = null;
            LoadingIndicator.Visibility = Visibility.Visible;

            try
            {
                picture = await pictureService.GetTodayPicture();

                Img.Source = new BitmapImage(new Uri(picture.Url));
                TitleBlock.Text = picture.Title;

                ExplanationRichBlock.Blocks.Clear();
                string[] paragraphs = picture.Explanation.Split(new string[] { "  " }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string p in paragraphs)
                {
                    Paragraph paragraph = new Paragraph();
                    Run run = new Run();
                    run.Text = p.Trim();
                    paragraph.Inlines.Add(run);

                    ExplanationRichBlock.Blocks.Add(paragraph);
                }

                CopyrightBlock.Text = picture.Copyright != null ? picture.Copyright : "";
            }
            finally
            {
                LoadingIndicator.Visibility = Visibility.Collapsed;
            }
        }
    }
}
