using NASAapp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASAapp.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        private ISettingsService settingsService;

        public SettingsPageViewModel()
        {
            // TODO maybe in future inject dependency in constructor using some DI framework
            settingsService = SettingsService.Instance;
        }

        #region Public Properties

        public bool ArePicturesSaved
        {
            get { return settingsService.SavePictures; }
            set
            {
                settingsService.SavePictures = value;
                OnPropertyChanged(nameof(ArePicturesSaved));
            }
        }

        public bool ArePicturesHd
        {
            get { return settingsService.SaveHdPictures; }
            set
            {
                settingsService.SaveHdPictures = value;
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
