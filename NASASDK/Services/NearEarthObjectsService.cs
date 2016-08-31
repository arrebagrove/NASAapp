using NASASDK.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static NASASDK.Constants;

namespace NASASDK.Services
{
    /// <summary>
    /// Provide information about newr Earth asteroids
    /// </summary>
    public class NearEarthObjectsService : INearEarthObjectsService
    {
        /// <summary>
        /// Retrieve a list of Asteroids based on their closest approach date to Earth
        /// </summary>
        /// <param name="startDate">Starting date for asteroid search</param>
        /// <param name="endDate">Ending date for asteroid search</param>
        /// <returns>NEO Feed</returns>
        public async Task<NEOFeed> GetAsteroidList(DateTime startDate, DateTime endDate)
        {
            string startDateValue = $"{startDate.Year:0000}-{startDate.Month:00}-{startDate.Day:00}";
            string endDateValue = $"{endDate.Year:0000}-{endDate.Month:00}-{endDate.Day:00}";

            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append(BaseUrl);
            queryBuilder.Append(NeoFeedUrl);
            queryBuilder.Append($"?{StartDate}={startDateValue}");
            queryBuilder.Append($"&{EndDate}={endDateValue}");
            queryBuilder.Append($"&{ApiKeyParam}={ApiKey}");
            string requestUrl = queryBuilder.ToString();

            string result = "";

            using (HttpClient httpClient = new HttpClient())
            {
                result = await httpClient.GetStringAsync(requestUrl);
            }

            NEOFeed neoFeed = JsonConvert.DeserializeObject<NEOFeed>(result,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            return neoFeed;
        }

        /// <summary>
        /// Retieve a Near Earth Objects with a given id
        /// </summary>
        /// <param name="id">ID of Near Earth Object - (ex: 3729835)</param>
        /// <returns>Near Earth object</returns>
        public Task<NearEarthObject> GetObject(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retieve a paginated list of Near Earth Objects
        /// </summary>
        /// <param name="page">Page</param>
        /// <param name="size">Size</param>
        /// <returns>List of objects</returns>
        public Task<NEOBrowse> GetObjects(int page = 0, int size = 20)
        {
            // TODO Response messages
            // 200 - OK
            // 401 - Unauthorized
            // 403 - Forbidden
            // 404 - Not Found
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieve current neo statistics
        /// </summary>
        /// <returns>Stats</returns>
        public Task<NEOStats> GetStatistics()
        {
            throw new NotImplementedException();
        }
    }

    public interface INearEarthObjectsService
    {
        Task<NEOFeed> GetAsteroidList(DateTime startDate, DateTime endDate);
        Task<NearEarthObject> GetObject(string id);
        Task<NEOBrowse> GetObjects(int page = 0, int size = 20);
        Task<NEOStats> GetStatistics();
    }
}
