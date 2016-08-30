using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASAapp.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        public SettingsPageViewModel()
        {

        }

        #region Public Properties

        private bool arePicturesSaved;

        public bool ArePicturesSaved
        {
            get { return arePicturesSaved; }
            set
            {
                if (arePicturesSaved == value)
                {
                    return;
                }
                arePicturesSaved = value;
                OnPropertyChanged(nameof(ArePicturesSaved));
            }
        }

        private bool arePicturesHd;

        public bool ArePicturesHd
        {
            get { return arePicturesHd; }
            set
            {
                if (arePicturesHd == value)
                {
                    return;
                }
                arePicturesHd = value;
                OnPropertyChanged(nameof(ArePicturesHd));
            }
        }

        #endregion

        #region Actions

        public void DeleteAllPictures()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
