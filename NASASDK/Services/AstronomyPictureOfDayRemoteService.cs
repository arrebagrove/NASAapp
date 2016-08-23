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
    public class AstronomyPictureOfDayRemoteService : IAstronomyPictureOfDayRemoteService
    {
        /// <summary>
        /// Get picture of the day
        /// </summary>
        /// <param name="date">The date of the APOD image to retrieve</param>
        /// <returns>Picture object</returns>
        public async Task<IRemoteResult> GetPicture(DateTime date)
        {
            string dateValue = string.Format("{0:0000}-{1:00}-{2:00}", date.Year, date.Month, date.Day);

            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append(Constants.BASE_URL);
            queryBuilder.Append(Constants.APOD_URL);
            queryBuilder.Append("?" + Constants.DATE + "=" + dateValue);
            queryBuilder.Append("&" + Constants.API_KEY_PARAM + "=" + Constants.API_KEY);
            string requestUrl = queryBuilder.ToString();
            string stringResult;

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage responseMessage = await client.GetAsync(requestUrl))
                {
                    if (!responseMessage.IsSuccessStatusCode)
                    {
                        return new RemoteResult(false, errorMessage: responseMessage.ReasonPhrase);
                    }
                    stringResult = await responseMessage.Content.ReadAsStringAsync();
                }
            }

            if (string.IsNullOrWhiteSpace(stringResult))
            {
                return new RemoteResult(false, errorMessage: "Empty response");
            }

            PictureOfDay pictureOfDay = JsonConvert.DeserializeObject<PictureOfDay>(stringResult);
            return new RemoteResult(true, data: pictureOfDay);
        }

        /// <summary>
        /// Get today's picture
        /// </summary>
        /// <returns>Picture object</returns>
        public async Task<IRemoteResult> GetTodayPicture()
        {
            string stringResult;
            string requestUrl = $"{Constants.BASE_URL}{Constants.APOD_URL}?{Constants.API_KEY_PARAM}={Constants.API_KEY}";
            
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage responseMessage = await client.GetAsync(requestUrl))
                {
                    if (!responseMessage.IsSuccessStatusCode)
                    {
                        return new RemoteResult(false, errorMessage: responseMessage.ReasonPhrase);
                    }
                    stringResult = await responseMessage.Content.ReadAsStringAsync();
                }
            }

            if (string.IsNullOrWhiteSpace(stringResult))
            {
                return new RemoteResult(false, errorMessage: "Empty response");
            }

            PictureOfDay pictureOfDay = JsonConvert.DeserializeObject<PictureOfDay>(stringResult);
            return new RemoteResult(true, data: pictureOfDay);
        }
    }

    /// <summary>
    /// Service for getting astronomy picture of the day from NASA server
    /// </summary>
    public interface IAstronomyPictureOfDayRemoteService
    {
        /// <summary>
        /// Get today's picture
        /// </summary>
        /// <returns>Picture object</returns>
        Task<IRemoteResult> GetTodayPicture();

        /// <summary>
        /// Get picture of the day
        /// </summary>
        /// <param name="date">The date of the APOD image to retrieve</param>
        /// <returns>Picture object</returns>
        Task<IRemoteResult> GetPicture(DateTime date);
    }
}
