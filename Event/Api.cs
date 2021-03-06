using Ivvy.Event;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ivvy
{
    public partial class Api : IApi
    {
        /// <summary>
        /// Returns a specific event.
        /// </summary>
        public async Task<ResultOrError<Event.Event>> GetEventAsync(int id)
        {
            return await this.CallAsync<Event.Event>(
                "event", "getEvent", new { id = id }
            );
        }

        /// <summary>
        /// Returns a collection of events.
        /// </summary>
        public async Task<ResultOrError<ResultList<Event.Event>>> GetEventListAsync(
            int perPage,
            int start,
            Dictionary<string, object> filterRequest = null,
            Event.GetEventListOptions options = null)
        {
            if (options == null) {
                options = new Event.GetEventListOptions();
            }
            if (filterRequest == null) {
                filterRequest = new Dictionary<string, object>();
            }
            return await this.CallAsync<ResultList<Event.Event>>(
                "event", "getEventList", new {
                    perPage = perPage,
                    start = start,
                    includeVenueDetails = options.IncludeVenueDetails,
                    includeTicketDetails = options.IncludeTicketDetails,
                    includeInformationDetails = options.IncludeInformationDetails,
                    includeHomepageContent = options.IncludeHomePageContent,
                    filter = filterRequest
                }
            );
        }

        /// <summary>
        /// Returns a collection of event attendees.
        /// </summary>
        public async Task<ResultOrError<ResultList<Event.Attendee>>> GetEventAttendeeListAsync(
            int eventId,
            int perPage,
            int start,
            Dictionary<string, object> filterRequest = null)
        {
            return await this.CallAsync<ResultList<Event.Attendee>>(
                "event", "getAttendeeList", new {
                    eventId = eventId,
                    perPage = perPage,
                    start = start,
                    filter = filterRequest
                }
            );
        }

        /// <summary>
        /// Returns a collection of event attendees across many events in the account.
        /// </summary>
        public async Task<ResultOrError<ResultList<Event.Attendee>>> GetAttendeeListForAccountAsync(
            int perPage,
            int start,
            Dictionary<string, object> filterRequest = null)
        {
            return await this.CallAsync<ResultList<Event.Attendee>>(
                "event", "getAttendeeListForAccount", new {
                    perPage = perPage,
                    start = start,
                    filter = filterRequest
                }
            );
        }

        /// <summary>
        /// Returns a collection of invited contact in the account.
        /// </summary>
        /// <param name="perPage">The per page.</param>
        /// <param name="start">The start.</param>
        /// <param name="filterRequest">The filter request.</param>
        /// <returns></returns>
        public async Task<ResultOrError<ResultList<InvitedContact>>> GetInvitedContactListForAccount(
            int perPage, 
            int start, 
            Dictionary<string, object> filterRequest = null)
        {
            return await this.CallAsync<ResultList<InvitedContact>>(
                "event", "getInvitedContactListForAccount", new
                {
                    perPage = perPage,
                    start = start,
                    filter = filterRequest
                }
            );
        }

        /// <summary>
        /// Returns a collection of invited contact of the event.
        /// </summary>
        /// <param name="eventId">The event identifier.</param>
        /// <param name="perPage">The per page.</param>
        /// <param name="start">The start.</param>
        /// <param name="filterRequest">The filter request.</param>
        /// <returns></returns>
        public async Task<ResultOrError<ResultList<InvitedContact>>> GetInvitedContactList(
            int eventId, 
            int perPage, 
            int start, 
            Dictionary<string, object> filterRequest = null)
        {
            return await this.CallAsync<ResultList<InvitedContact>>(
                "event", "getInvitedContactList", new
                {
                    eventId = eventId,
                    perPage = perPage,
                    start = start,
                    filter = filterRequest
                }
            );
        }

        /// <summary>
        /// Returns a collection of event registrations.
        /// </summary>
        public async Task<ResultOrError<ResultList<Event.Registration>>> GetEventRegistrationListAsync(
            int eventId,
            int perPage,
            int start,
            Dictionary<string, object> filterRequest = null)
        {
            return await CallAsync<ResultList<Event.Registration>>(
                "event", "getRegistrationList", new {
                    eventId = eventId,
                    perPage,
                    start,
                    filter = filterRequest
                }
            );
        }

        /// <summary>
        /// Returns a collection of event registrations across many events in the account.
        /// </summary>
        public async Task<ResultOrError<ResultList<Event.Registration>>> GetRegistrationListForAccountAsync(
            int perPage,
            int start,
            Dictionary<string, object> filterRequest = null)
        {
            return await CallAsync<ResultList<Event.Registration>>(
                "event", "getRegistrationListForAccount", new {
                    perPage,
                    start,
                    filter = filterRequest
                });
        }
    }
}