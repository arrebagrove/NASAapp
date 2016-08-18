using NASASDK.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NASASDK.Services
{
    /// <summary>
    /// Service for getting astronomy picture of the day
    /// </summary>
    public class PictureOfDayService : IPictureOfDayService
    {
        /// <summary>
        /// Get picture of the day
        /// </summary>
        /// <param name="date">The date of the APOD image to retrieve</param>
        /// <returns>Picture object</returns>
        public async Task<PictureOfDay> GetPicture(DateTime date)
        {
            string dateValue = string.Format("{0:0000}-{1:00}-{2:00}", date.Year, date.Month, date.Day);

            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append(Constants.BASE_URL);
            queryBuilder.Append(Constants.APOD_URL);
            queryBuilder.Append("?" + Constants.DATE + "=" + dateValue);
            queryBuilder.Append("&" + Constants.API_KEY_PARAM + "=" + Constants.API_KEY);
            string queryUrl = queryBuilder.ToString();

            string result = "";
            using (HttpClient client = new HttpClient())
            {
                result = await client.GetStringAsync(queryUrl);
            }

            if (string.IsNullOrWhiteSpace(result))
            {
                return null;
            }
            PictureOfDay pictureOfDay = JsonConvert.DeserializeObject<PictureOfDay>(result);

            return pictureOfDay;
        }

        /// <summary>
        /// Get today's picture
        /// </summary>
        /// <returns>Picture object</returns>
        public async Task<PictureOfDay> GetTodayPicture()
        {
            string queryUrl = Constants.BASE_URL + Constants.APOD_URL + 
                "?" + Constants.API_KEY_PARAM + "=" + Constants.API_KEY;
            string result = "";
            using (HttpClient client = new HttpClient())
            {
                result = await client.GetStringAsync(queryUrl);
            }

            if (string.IsNullOrWhiteSpace(result))
            {
                return null;
            }
            PictureOfDay pictureOfDay = JsonConvert.DeserializeObject<PictureOfDay>(result);

            return pictureOfDay;
        }
    }

    public interface IPictureOfDayService
    {
        Task<PictureOfDay> GetTodayPicture();
        Task<PictureOfDay> GetPicture(DateTime date);
    }
}
