using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace NASAapp.Controls
{
    public sealed partial class NearEarthObjectControl : UserControl
    {
        public NearEarthObjectControl()
        {
            this.InitializeComponent();

            Loaded += NearEarthObjectControl_Loaded;
        }

        #region Dependency Properties

        public static readonly DependencyProperty NeoReferenceIdProperty
            = DependencyProperty.Register("Id", typeof(int), typeof(NearEarthObjectControl), null);

        public static readonly DependencyProperty ObjectNameProperty
            = DependencyProperty.Register("ObjectName", typeof(string), typeof(NearEarthObjectControl), null);

        public static readonly DependencyProperty NasaJplUrlProperty
            = DependencyProperty.Register("NasaJplUrl", typeof(string), typeof(NearEarthObjectControl), null);

        public static readonly DependencyProperty AbsoluteMagnitudeProperty
            = DependencyProperty.Register("AbsoluteMagnitude", typeof(float), typeof(NearEarthObjectControl), null);

        public static readonly DependencyProperty IsPotentiallyHazardousAsteroidProperty
            = DependencyProperty.Register("IsPotentiallyHazardousAsteroid", typeof(bool), typeof(NearEarthObjectControl), null);

        #endregion

        #region Public Properties

        public int NeoReferenceId
        {
            get { return (int)GetValue(NeoReferenceIdProperty); }
            set { SetValue(NeoReferenceIdProperty, value); }
        }

        public string ObjectName
        {
            get { return (string)GetValue(ObjectNameProperty); }
            set { SetValue(ObjectNameProperty, value); }
        }

        public string NasaJplUrl
        {
            get { return (string)GetValue(NasaJplUrlProperty); }
            set { SetValue(NasaJplUrlProperty, value); }
        }

        public float AbsoluteMagnitude
        {
            get { return (float)GetValue(AbsoluteMagnitudeProperty); }
            set { SetValue(AbsoluteMagnitudeProperty, value); }
        }

        public bool IsPotentiallyHazardousAsteroid
        {
            get { return (bool)GetValue(IsPotentiallyHazardousAsteroidProperty); }
            set { SetValue(IsPotentiallyHazardousAsteroidProperty, value); }
        }

        #endregion

        private void NearEarthObjectControl_Loaded(object sender, RoutedEventArgs e)
        {
            NeoReferenceIdTextBlock.Text = NeoReferenceId.ToString();
            ObjectNameTextBlock.Text = ObjectName;
            NasaJplButton.NavigateUri = new Uri(NasaJplUrl);
            AbsoluteMagnitudeTextBlock.Text = AbsoluteMagnitude.ToString("0.0000");
            NeoObjectGrid.Background = IsPotentiallyHazardousAsteroid ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.Green);
        }

        private void NasaJplButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
