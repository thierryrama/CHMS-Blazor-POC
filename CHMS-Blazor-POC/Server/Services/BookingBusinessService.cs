using StatCan.Chms.DataTransfer.Booking;
using StatCan.Chms.Dtos.Booking;

namespace StatCan.Chms.Services;

/// <summary>
/// Class implementing business rules around booking appointments
/// </summary>
public class BookingBusinessService
{
    private List<AppointmentData> _appointments;

    public BookingBusinessService()
    {
        _appointments = new List<AppointmentData>();
        SetUpFakeSiteData("Ottawa");
        SetUpFakeSiteData("Edmonton");
        SetUpFakeSiteData("Vancouver");
        SetUpFakeSiteData("Halifax");
        SetUpFakeSiteData("Quebec");
    }

    public IEnumerable<AppointmentData> GetSiteAppointmentsByDateRange(string siteName, DateTime start, DateTime end)
    {
        return _appointments.Where(
            t => t.SiteId.Equals(siteName, StringComparison.InvariantCultureIgnoreCase) &&
                 (t.Time >= start && t.Time < end))
            .OrderBy(t => t.Time);
    }

    private void SetUpFakeSiteData(string site)
    {
        _appointments.AddRange(GetUpFakeAppointDayData(site, -7));
        _appointments.AddRange(GetUpFakeAppointDayData(site, -6));
        _appointments.AddRange(GetUpFakeAppointDayData(site, -5));
        _appointments.AddRange(GetUpFakeAppointDayData(site, -4));
        _appointments.AddRange(GetUpFakeAppointDayData(site, -3));
        _appointments.AddRange(GetUpFakeAppointDayData(site, -2));
        _appointments.AddRange(GetUpFakeAppointDayData(site, -1));
        _appointments.AddRange(GetUpFakeAppointDayData(site, 0));
        _appointments.AddRange(GetUpFakeAppointDayData(site, 1));
        _appointments.AddRange(GetUpFakeAppointDayData(site, 2));
        _appointments.AddRange(GetUpFakeAppointDayData(site, 3));
        _appointments.AddRange(GetUpFakeAppointDayData(site, 4));
        _appointments.AddRange(GetUpFakeAppointDayData(site, 5));
        _appointments.AddRange(GetUpFakeAppointDayData(site, 6));
        _appointments.AddRange(GetUpFakeAppointDayData(site, 7));
    }
    
    private IList<AppointmentData> GetUpFakeAppointDayData(string site, int dayOffset = 0)
    {
        var random = new Random();

        var firstStart = random.Next(8, 10);
        var secondStart = random.Next(13, 15);
        return new List<AppointmentData>
        {
            new AppointmentData
            {
                SiteId = site,
                Time = DateTime.Today.AddDays(dayOffset).AddHours(firstStart).AddMinutes(0),
                DurationMinute = 120,
                RespondentPhoneNumber = "613-123-4567",
                RespondentName = "John Smith"
            },
            new AppointmentData
            {
                SiteId = site,
                Time = DateTime.Today.AddDays(dayOffset).AddHours(firstStart).AddMinutes(30), 
                DurationMinute = 120,
                RespondentPhoneNumber = "613-123-4567",
                RespondentName = ""
            },
            new AppointmentData
            {
                SiteId = site,
                Time = DateTime.Today.AddDays(dayOffset).AddHours(firstStart + 1).AddMinutes(0), 
                DurationMinute = 120,
                RespondentPhoneNumber = "613-123-4567",
                RespondentName = ""
            },
            new AppointmentData
            {
                SiteId = site,
                Time = DateTime.Today.AddDays(dayOffset).AddHours(firstStart + 1).AddMinutes(30), 
                DurationMinute = 120,
                RespondentPhoneNumber = "613-123-4567",
                RespondentName = "Jane Doe"
            },
            new AppointmentData
            {
                SiteId = site,
                Time = DateTime.Today.AddDays(dayOffset).AddHours(firstStart + 2).AddMinutes(0), 
                DurationMinute = 120,
                RespondentPhoneNumber = "613-123-4567",
                RespondentName = ""
            },
            new AppointmentData
            {
                SiteId = site,
                Time = DateTime.Today.AddDays(dayOffset).AddHours(secondStart).AddMinutes(30), 
                DurationMinute = 120,
                RespondentPhoneNumber = "613-123-4567",
                RespondentName = "Dragon Feet"
            },
            new AppointmentData
            {
                SiteId = site,
                Time = DateTime.Today.AddDays(dayOffset).AddHours(secondStart + 1).AddMinutes(0),
                DurationMinute = 120,
                RespondentPhoneNumber = "613-123-4567",
                RespondentName = ""
            },
            new AppointmentData
            {
                SiteId = site,
                Time = DateTime.Today.AddDays(dayOffset).AddHours(secondStart + 1).AddMinutes(30), 
                DurationMinute = 120,
                RespondentPhoneNumber = "613-123-4567",
                RespondentName = "Hello Poker"
            },
            new AppointmentData
            {
                SiteId = site,
                Time = DateTime.Today.AddDays(dayOffset).AddHours(secondStart + 2).AddMinutes(0), 
                DurationMinute = 120,
                RespondentPhoneNumber = "613-123-4567",
                RespondentName = ""
            },
            new AppointmentData
            {
                SiteId = site,
                Time = DateTime.Today.AddDays(dayOffset).AddHours(secondStart + 2).AddMinutes(30),
                DurationMinute = 120,
                RespondentPhoneNumber = "613-123-4567",
                RespondentName = "World Trade"
            },
            new AppointmentData
            {
                SiteId = site,
                Time = DateTime.Today.AddDays(dayOffset).AddHours(secondStart + 3).AddMinutes(0), 
                DurationMinute = 120,
                RespondentPhoneNumber = "613-123-4567",
                RespondentName = ""
            },
            new AppointmentData
            {
                SiteId = site,
                Time = DateTime.Today.AddDays(dayOffset).AddHours(secondStart + 3).AddMinutes(30), 
                DurationMinute = 120,
                RespondentPhoneNumber = "613-123-4567",
                RespondentName = "Pat Well"
            },
        };
    }
}
