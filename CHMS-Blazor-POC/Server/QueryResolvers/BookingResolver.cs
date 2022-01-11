using StatCan.Chms.Dtos.Booking;
using StatCan.Chms.Services;

namespace StatCan.Chms.QueryResolvers;

/// <summary>
/// Query Resolvers for Booking functionalities
/// </summary>
public class Booking
{
    public static readonly Booking Instance = new();

    /// <summary>
    /// Get first appoint. Useless method but for proof of concept only
    /// </summary>
    /// <param name="businessService"></param>
    /// <returns></returns>
    public AppointmentData GetFirstAppointment([Service] BookingBusinessService businessService)
    {
        return new AppointmentData
        {
            Time = DateTime.Now,
            DurationMinute = 120,
            RespondentName = "Jane Doe",
            RespondentPhoneNumber = "613-123-4567",
            SiteId = "Ottawa"
        };
    }

    /// <summary>
    /// Get the list of appointments from one site between start and end
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="businessService"></param>
    /// <returns></returns>
    public IEnumerable<AppointmentData> GetAppointments(
        string site, 
        DateTime start, 
        DateTime end,
        [Service] BookingBusinessService businessService)
    {
        return businessService.GetSiteAppointmentsByDateRange(site, start, end);
    }
}