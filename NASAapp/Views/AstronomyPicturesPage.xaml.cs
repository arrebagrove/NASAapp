using NASAapp.DAL;
using NASAapp.Models;
using NASAapp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace NASAapp.Views
{
    public sealed partial class AstronomyPicturesPage : Page
    {
        private INavigationService navigationService;

        public AstronomyPicturesPage()
        {
            InitializeComponent();
            Loaded += AstronomyPicturesPage_Loaded;

            navigationService = NavigationService.Instance;
        }

        private void AstronomyPicturesPage_Loaded(object sender, RoutedEventArgs e)
        {
            List<AstronomyPictureListItem> model = new List<AstronomyPictureListItem>();

            using (ApplicationContext db = new ApplicationContext())
            {
                List<AstronomyPictureOfDayDAL> pictures = db.Pictures.ToList();

                foreach (var picture in pictures)
                {
                    model.Add(new AstronomyPictureListItem
                    {
                        ImageUri = picture.Url,
                        Title = picture.Title,
                    });
                }
            }

            pictureList.ItemsSource = model;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SystemNavigationManager systemNavigationManager = SystemNavigationManager.GetForCurrentView();
            systemNavigationManager.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            systemNavigationManager.BackRequested += SystemNavigationManager_BackRequested;
        }

        private void SystemNavigationManager_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (navigationService.CanGoBack())
            {
                navigationService.GoBack();
            }
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            SystemNavigationManager.GetForCurrentView().BackRequested -= SystemNavigationManager_BackRequested;
        }
    }
}
