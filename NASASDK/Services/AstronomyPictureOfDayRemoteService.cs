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
    /// Service for getting astronomy picture of the day from NASA server
    /// </summary>
    public class AstronomyPictureOfDayRemoteService : IAstronomyPictureOfDayRemoteService
    {
        /// <summary>
        /// Get picture of the day
        /// </summary>
        /// <param name="date">The date of the APOD image to retrieve</param>
        /// <returns>Server response</returns>
        public async Task<IRemoteResult> GetPicture(DateTime date)
        {
            if (date.Date > DateTime.Now.Date)
            {
                throw new ArgumentException("Date should be not later than today");
            }

            #region Form query url

            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append(Constants.BASE_URL);
            queryBuilder.Append(Constants.APOD_URL);
            queryBuilder.Append($"?{Constants.DATE}={date.Year:0000}-{date.Month:00}-{date.Day:00}");
            queryBuilder.Append($"&{Constants.API_KEY_PARAM}={Constants.API_KEY}");
            string requestUrl = queryBuilder.ToString();

            #endregion

            string jsonResponse;

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage responseMessage = await client.GetAsync(requestUrl))
                {
                    if (!responseMessage.IsSuccessStatusCode)
                    {
                        return new RemoteResult(false, errorMessage: responseMessage.ReasonPhrase);
                    }
                    jsonResponse = await responseMessage.Content.ReadAsStringAsync();
                }
            }

            if (string.IsNullOrWhiteSpace(jsonResponse))
            {
                return new RemoteResult(false, errorMessage: "Response is empty.");
            }

            PictureOfDay pictureOfDay = JsonConvert.DeserializeObject<PictureOfDay>(jsonResponse);

            return new RemoteResult(true, data: pictureOfDay);
        }
    }

    /// <summary>
    /// Service for getting astronomy picture of the day from NASA server
    /// </summary>
    public interface IAstronomyPictureOfDayRemoteService
    {
        /// <summary>
        /// Get picture of the day
        /// </summary>
        /// <param name="date">The date of the APOD image to retrieve</param>
        /// <returns>Server response</returns>
        Task<IRemoteResult> GetPicture(DateTime date);
    }
}
