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
using Windows.UI.Xaml.Media.Imaging;
using Windows.Web.Http;

namespace NASAapp.Services
{
    public class AstronomyPictureOfDayService : IAstronomyPictureOfDayService
    {
        public async Task<AstronomyPictureOfDay> GetTodayPicture()
        {
            AstronomyPictureOfDay picture = null;
            IPictureOfDayService pictureService = new PictureOfDayService();

            using (ApplicationContext db = new ApplicationContext())
            {
                var dbPicture = db.Pictures.FirstOrDefault(p =>
                    p.Date.Year == DateTime.Now.Year && p.Date.Month == DateTime.Now.Month && p.Date.Day == DateTime.Now.Day);
                if (dbPicture == null)
                {
                    PictureOfDay remotePicture = await pictureService.GetTodayPicture();

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
            await FileIO.WriteBytesAsync(imgFile, new byte[] { });
            /// TODO write byte array of image to this file

            return localUrl;
        }
    }

    public interface IAstronomyPictureOfDayService
    {
        Task<AstronomyPictureOfDay> GetTodayPicture();
    }
}
