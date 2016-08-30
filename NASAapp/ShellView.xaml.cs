using NASAapp.Models;
using NASAapp.Services;
using NASAapp.Views;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace NASAapp
{
    public sealed partial class ShellView : Windows.UI.Xaml.Controls.Page
    {
        public ShellView()
        {
            InitializeComponent();

            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem { Glyph = (char)59667, Label = "Picture Of A Day", Destination = typeof(APODPage) },
                new MenuItem { Glyph = (char)59959, Label = "List Of Pictures", Destination = typeof(AstronomyPicturesPage) },
            };

            List<MenuItem> optionItems = new List<MenuItem>
            {
                new MenuItem { Glyph = (char)59155, Label = "Settings", Destination = typeof(SettingsPage) },
            };

            HamburgerMenuControl.ItemsSource = menuItems;
            HamburgerMenuControl.OptionsItemsSource = optionItems;

            NavigationService.RegisterFrame(RootFrame);
        }

        private void OnMenuItemClick(object sender, ItemClickEventArgs e)
        {
            MenuItem menuItem = e.ClickedItem as MenuItem;
            if (menuItem != null && menuItem.Destination != null && menuItem.Destination != RootFrame.CurrentSourcePageType)
            {
                RootFrame.Navigate(menuItem.Destination);
            }
            if (HamburgerMenuControl.DisplayMode == SplitViewDisplayMode.Overlay ||
                   HamburgerMenuControl.DisplayMode == SplitViewDisplayMode.CompactOverlay)
            {
                HamburgerMenuControl.IsPaneOpen = false;
            }
        }
    }
}
