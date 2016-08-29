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

            navigationService = NavigationService.Instance;
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
