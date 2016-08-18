using NASAapp.Models;
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
    public sealed partial class MainView : Windows.UI.Xaml.Controls.Page
    {
        public MainView()
        {
            InitializeComponent();

            PageList.ItemsSource = new List<MenuItem>
            {
                new MenuItem { Glyph = (char)59667, Label = "Picture Of A Day", Destination = typeof(APODView) },
                new MenuItem { Glyph = (char)59421, Label = "Near Earth Objects", Destination = typeof(NEOPage) },
            };
        }

        private void PageList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = sender as ListView;
            MenuItem menuItem = (MenuItem)listView.SelectedItem;
            //MenuItem menuItem = (MenuItem)listView.ItemFromContainer(listViewItem);

            if (menuItem != null && menuItem.Destination != null && menuItem.Destination != RootFrame.CurrentSourcePageType)
            {
                RootFrame.Navigate(menuItem.Destination);
                if (RootSplit.DisplayMode == SplitViewDisplayMode.Overlay)
                {
                    RootSplit.IsPaneOpen = false;
                }
            }
        }
    }
}
