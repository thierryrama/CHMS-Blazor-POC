using StatCan.Chms.DataTransfer.Booking;

namespace StatCan.Chms.QueryResolvers;
/// <summary>
/// Query Resolvers for Booking functionalities
/// </summary>
[ExtendObjectType("Query")]
public class BookingResolver
{
    public AppointmentDetailData GetFirstAppointment()
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