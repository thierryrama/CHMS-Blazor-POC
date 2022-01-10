using StatCan.Chms.DataTransfer.Booking;
using StatCan.Chms.Services;

namespace StatCan.Chms.QueryResolvers;
/// <summary>
/// Query Resolvers for Booking functionalities
/// </summary>
public class Booking
{
    public static readonly Booking Instance = new();
    
    public AppointmentDetailData GetFirstAppointment([Service] BookingBusinessService businessService)
    {
        return new AppointmentDetailData
        (
            Time : DateTime.Now,
            DurationMinute : 120,
            RespondentName : "Jane Doe",
            RespondentPhoneNumber : "613-123-4567",
            SiteId : "Ottawa"
        );
    }
}