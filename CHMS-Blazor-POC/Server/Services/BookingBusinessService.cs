using StatCan.Chms.DataTransfer.Booking;

namespace StatCan.Chms.Services;

/// <summary>
/// Class implementing business rules around booking appointments
/// </summary>
public class BookingBusinessService
{
    public IEnumerable<AppointmentDetailData> GetSiteAppointmentsByDateRange(string siteName, DateTime start, DateTime end)
    {
        return null;
        //return NullReferenceException 
    }
}
