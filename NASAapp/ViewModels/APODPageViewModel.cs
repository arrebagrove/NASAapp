using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace NASAapp.ViewModels
{
    public class APODPageViewModel : ViewModelBase
    {
        private ImageSource imageSource;
        private string title;
        private string explanation;
        private string copyright;
        private DateTimeOffset date;

        public APODPageViewModel()
        {
            date = DateTimeOffset.Now;
        }

        public ImageSource ImageSource
        {
            get { return imageSource; }
            set
            {
                imageSource = value;
                OnPropertyChanged(nameof(ImageSource));
            }
        }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public string Explanation
        {
            get { return explanation; }
            set
            {
                explanation = value;
                OnPropertyChanged(nameof(Explanation));
            }
        }

        public string Copyright
        {
            get { return copyright; }
            set
            {
                copyright = value;
                OnPropertyChanged(nameof(Copyright));
            }
        }

        public DateTimeOffset Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
    }
}
