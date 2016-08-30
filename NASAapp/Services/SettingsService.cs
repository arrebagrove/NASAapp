using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using NASAapp.Constants;

namespace NASAapp.Services
{
    public class SettingsService : ISettingsService
    {
        #region Singleton

        private SettingsService() { }

        private static ISettingsService instance;
        private static object lockObject = new object();

        public static ISettingsService Instance
        {
            get
            {
                lock (lockObject)
                {
                    if(instance == null)
                    {
                        instance = new SettingsService();
                    }
                    return instance;
                }
            }
        }

        #endregion

        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        public bool SavePictures
        {
            get
            {
                object val = localSettings.Values[SettingsConstants.SAVE_PICTURES_SETTING];
                if (val == null)
                {
                    // this setting is not set yet, set it to default
                    localSettings.Values[SettingsConstants.SAVE_PICTURES_SETTING] = SettingsConstants.SAVE_PICTURES_SETTING_DEFAULT;
                    return SettingsConstants.SAVE_PICTURES_SETTING_DEFAULT;
                }
                return (bool)val;
            }

            set
            {
                localSettings.Values[SettingsConstants.SAVE_PICTURES_SETTING] = value;
            }
        }

        public bool SaveHdPictures
        {
            get
            {
                object val = localSettings.Values[SettingsConstants.SAVE_HD_PICTURES_SETTING];
                if (val == null)
                {
                    // this setting is not set yet, set it to default
                    localSettings.Values[SettingsConstants.SAVE_HD_PICTURES_SETTING] = SettingsConstants.SAVE_HD_PICTURES_SETTING_DEFAULT;
                    return SettingsConstants.SAVE_HD_PICTURES_SETTING_DEFAULT;
                }
                return (bool)val;
            }

            set
            {
                localSettings.Values[SettingsConstants.SAVE_HD_PICTURES_SETTING] = value;
            }
        }
    }

    public interface ISettingsService
    {
        bool SavePictures { get; set; }
        bool SaveHdPictures { get; set; }
    }
}
