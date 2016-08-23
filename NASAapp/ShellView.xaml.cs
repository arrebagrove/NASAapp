using NASAapp.Models;
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

            HamburgerMenuControl.ItemsSource = new List<MenuItem>
            {
                new MenuItem { Glyph = (char)59667, Label = "Picture Of A Day", Destination = typeof(APODView) },
                new MenuItem { Glyph = (char)59421, Label = "Near Earth Objects", Destination = typeof(NEOPage) },
                new MenuItem { Glyph = (char)11111, Label = "About", Destination = typeof(AboutView) }
            };
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
