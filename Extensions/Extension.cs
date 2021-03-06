using Ivvy.Extensions.Configure;
using Ivvy.Extensions.Setup;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ivvy.Extensions
{
    /// <summary>
    /// The primary class used to call the extension endpoints.
    /// </summary>
    public class Extension : IExtension
    {
        public string SetupVerifyUrl { get; set; }
        public string SetupConfigureUrl { get; set; }
        public string EventSetupVerifyUrl { get; set; }
        public string EventSetupConfigureUrl { get; set; }
        public string VenueSetupVerifyUrl { get; set; }
        public string VenueSetupConfigureUrl { get; set; }

        private static HttpClient httpClient = new HttpClient();

        public Extension()
        {
        }

        /// <summary>
        /// Verifies an iVvy client's request to add the extension to their account.
        /// </summary>
        public async Task<ResultOrError<VerifySetupResponse>> VerifySetupAsync(string accountId, string setupKey)
        {
            var dataMap = new Dictionary<string, string> {
                { "accountId", accountId },
                { "setupKey", setupKey }
            };
            return await this.CallAsync<VerifySetupResponse>(SetupVerifyUrl, dataMap);
        }

        /// <summary>
        /// This method is used by an extension to inform iVvy that it has been configured.
        /// </summary>
        public async Task<ResultOrError<VerifyConfigureResponse>> ConfigureAsync(string accountId, string setupKey)
        {
            var dataMap = new Dictionary<string, string> {
                { "accountId", accountId },
                { "setupKey", setupKey }
            };
            return await this.CallAsync<VerifyConfigureResponse>(SetupConfigureUrl, dataMap);
        }

        /// <summary>
        /// Verifies an iVvy client's request to add the extension to an event in their account.
        /// </summary>
        public async Task<ResultOrError<EventVerifySetupResponse>> EventVerifySetupAsync(
                string accountId, string eventId, string setupKey)
        {
            var dataMap = new Dictionary<string, string> {
                { "accountId", accountId },
                { "eventId", eventId },
                { "setupKey", setupKey }
            };
            return await this.CallAsync<EventVerifySetupResponse>(EventSetupVerifyUrl, dataMap);
        }

        /// <summary>
        /// This method is used by an extension to inform iVvy that it has been configured within an event.
        /// </summary>
        public async Task<ResultOrError<VerifyConfigureResponse>> EventConfigureAsync(
                string accountId, string eventId, string setupKey)
        {
            var dataMap = new Dictionary<string, string> {
                { "accountId", accountId },
                { "eventId", eventId },
                { "setupKey", setupKey }
            };
            return await this.CallAsync<VerifyConfigureResponse>(EventSetupConfigureUrl, dataMap);
        }

        /// <summary>
        /// Verifies an iVvy client's request to add the extension to a venue in their account.
        /// </summary>
        public async Task<ResultOrError<VenueVerifySetupResponse>> VenueVerifySetupAsync(
                string accountId, string venueId, string setupKey)
        {
            var dataMap = new Dictionary<string, string> {
                { "accountId", accountId },
                { "venueId", venueId },
                { "setupKey", setupKey }
            };
            return await this.CallAsync<VenueVerifySetupResponse>(VenueSetupVerifyUrl, dataMap);
        }

        /// <summary>
        /// This method is used by an extension to inform iVvy that it has been configured within a venue.
        /// </summary>
        public async Task<ResultOrError<VerifyConfigureResponse>> VenueConfigureAsync(
                string accountId, string venueId, string setupKey)
        {
            var dataMap = new Dictionary<string, string> {
                { "accountId", accountId },
                { "venueId", venueId },
                { "setupKey", setupKey }
            };
            return await this.CallAsync<VerifyConfigureResponse>(VenueSetupConfigureUrl, dataMap);
        }

        private async Task<ResultOrError<T>> CallAsync<T>(
            string requestUri, Dictionary<string, string> dataMap)
        {
            var httpContent = new FormUrlEncodedContent(dataMap);
            HttpResponseMessage httpResponse = await httpClient.PostAsync(
                requestUri, httpContent
            );
            string data = await httpResponse.Content.ReadAsStringAsync();
            var result = new ResultOrError<T>();
            JsonConvert.PopulateObject(data, result);
            return result;
        }
    }
}