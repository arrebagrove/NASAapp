using NASAapp.Models;
using NASASDK.Models;
using NASASDK.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;

namespace NASAapp.Views
{
    public sealed partial class NEOPage : Windows.UI.Xaml.Controls.Page
    {
        public NEOPage()
        {
            this.InitializeComponent();
        }

        private async void NEOButton_Click(object sender, RoutedEventArgs e)
        {
            INearEarthObjectsService service = new NearEarthObjectsService();
            NEOFeed feed = await service.GetAsteroidList(new DateTime(2015, 1, 1), new DateTime(2015, 1, 7));
            ElementCountBlock.Text = feed.ElementCount.ToString();

            List<ObjectListItem> itemSource = new List<ObjectListItem>();
            foreach (var elem in feed.NearEarthObjects)
            {
                itemSource.Add(new ObjectListItem
                {
                    Key = elem.Key,
                    ListObjects = elem.Value,
                });
            }
            MainListView.ItemsSource = itemSource;
        }
    }
}
