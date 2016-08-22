using NASAapp.Views;
using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.EntityFrameworkCore;
using NASAapp.DAL;

namespace NASAapp
{
    sealed partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.Migrate();
            }
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            ShellView mainView = Window.Current.Content as ShellView;

            if (mainView == null)
            {
                mainView = new ShellView();
                mainView.RootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    
                }

                Window.Current.Content = mainView;
            }

            if (e.PrelaunchActivated == false)
            {
                if (mainView.RootFrame.Content == null)
                {
                    mainView.RootFrame.Navigate(typeof(APODView), e.Arguments);
                }
                
                Window.Current.Activate();
            }
        }

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            deferral.Complete();
        }
    }
}
