using NASAapp.Models;
using NASAapp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace NASAapp.ViewModels
{
    public class APODPageViewModel : ViewModelBase
    {
        IAstronomyPictureOfDayService pictureService;

        public APODPageViewModel()
        {
            pictureService = AstronomyPictureOfDayService.Instance;
        }

        #region Public Properties

        private ImageSource imageSource = new BitmapImage(new Uri("ms-appx:///Assets/placeholder.png"));

        public ImageSource ImageSource
        {
            get { return imageSource; }
            set
            {
                imageSource = value;
                OnPropertyChanged(nameof(ImageSource));
            }
        }

        private string title = "Title";

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string explanation = "Explanation";

        public string Explanation
        {
            get { return explanation; }
            set
            {
                explanation = value;
                OnPropertyChanged(nameof(Explanation));
            }
        }

        private string copyright = "Copyright";

        public string Copyright
        {
            get { return copyright; }
            set
            {
                copyright = value;
                OnPropertyChanged(nameof(Copyright));
            }
        }

        private DateTimeOffset date = DateTimeOffset.Now;

        public DateTimeOffset Date
        {
            get { return date; }
            set
            {
                if (date == value)
                {
                    return;
                }
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        private bool isLoading = false;

        public bool IsLoading
        {
            get { return isLoading; }
            set
            {
                isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        #endregion

        #region Actions

        public async Task GetPicture()
        {
            IsLoading = true;

            try
            {
                AstronomyPictureOfDay picture = await pictureService.GetPicture(Date.Date);

                ImageSource = new BitmapImage(new Uri(picture.Url));
                Title = picture.Title;
                Explanation = picture.Explanation;
                Copyright = picture.Copyright != null ? picture.Copyright : "";
            }
            finally
            {
                IsLoading = false;
            }
        }

        public async Task GetPicture(DateTime date)
        {
            IsLoading = true;

            try
            {
                AstronomyPictureOfDay picture = await pictureService.GetPicture(date);

                ImageSource = new BitmapImage(new Uri(picture.Url));
                Title = picture.Title;
                Explanation = picture.Explanation;
                Copyright = picture.Copyright != null ? picture.Copyright : "";
            }
            finally
            {
                IsLoading = false;
            }
        }

        #endregion
    }
}
