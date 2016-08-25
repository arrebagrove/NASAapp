using NASAapp.DAL;
using NASAapp.Models;
using NASASDK.Models;
using NASASDK.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Web.Http;

namespace NASAapp.Services
{
    public class AstronomyPictureOfDayService : IAstronomyPictureOfDayService
    {
        private IAstronomyPictureOfDayRemoteService remotePictureService;

        private static object lockObject = new object();
        private static IAstronomyPictureOfDayService instance;

        private AstronomyPictureOfDayService()
        {
            // TODO inject here service
            remotePictureService = new AstronomyPictureOfDayRemoteService();
        }

        public static IAstronomyPictureOfDayService Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new AstronomyPictureOfDayService();
                    }
                    return instance;
                }
            }
        }

        public async Task<AstronomyPictureOfDay> GetPicture(DateTime date)
        {
            AstronomyPictureOfDay picture = null;

            using (ApplicationContext db = new ApplicationContext())
            {
                var dbPicture = db.Pictures.FirstOrDefault(p => 
                    p.Date.Year == date.Year && p.Date.Month == date.Month && p.Date.Day == date.Day);
                if (dbPicture == null)
                {
                    IRemoteResult result = await remotePictureService.GetPicture(date);
                    PictureOfDay remotePicture = result.Data as PictureOfDay;

                    string localUrl = await SaveImageToLocalFolderAsync(remotePicture.Url, "Images");
                    string localHdUrl = await SaveImageToLocalFolderAsync(remotePicture.HdUrl, "HdImages");

                    dbPicture = new AstronomyPictureOfDayDAL
                    {
                        Copyright = remotePicture.Copyright,
                        Date = remotePicture.Date,
                        Explanation = remotePicture.Explanation,
                        HdUrl = localHdUrl,
                        Title = remotePicture.Title,
                        Url = localUrl,
                    };
                    db.Add(dbPicture);
                    await db.SaveChangesAsync();
                }
                picture = new AstronomyPictureOfDay
                {
                    Copyright = dbPicture.Copyright,
                    Date = dbPicture.Date,
                    Explanation = dbPicture.Explanation,
                    HdUrl = dbPicture.HdUrl,
                    Title = dbPicture.Title,
                    Url = dbPicture.Url,
                };

                return picture;
            }
        }

        private async Task<string> SaveImageToLocalFolderAsync(string url, string folderName)
        {
            string[] parameters = url.Split(new char[] { '/' });
            string imgName = parameters[parameters.Length - 1];

            string localUrl = $"ms-appdata:///local/{folderName}/{imgName}";

            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFolder imgFolder;
            try
            {
                imgFolder = await localFolder.GetFolderAsync(folderName);
            }
            catch (FileNotFoundException)
            {
                imgFolder = await localFolder.CreateFolderAsync(folderName);
            }

            StorageFile imgFile = await imgFolder.CreateFileAsync(imgName, CreationCollisionOption.ReplaceExisting);
            
            using (HttpClient httpClient = new HttpClient())
            {
                IBuffer buffer = await httpClient.GetBufferAsync(new Uri(url));
                await FileIO.WriteBufferAsync(imgFile, buffer);
            }

            return localUrl;
        }
    }

    public interface IAstronomyPictureOfDayService
    {
        Task<AstronomyPictureOfDay> GetPicture(DateTime date);
    }
}
