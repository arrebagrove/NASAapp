using NASASDK.Models;
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
using Windows.UI.Xaml.Navigation;

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
        }
    }
}
