namespace StatCan.Chms.Dtos.Booking;

/// <summary>
/// Transfer object representing an appointment. While we can use record for this, being able to use a resolver inside
/// any graphql class, for a performance reason, requires using class.
/// </summary>
public class AppointmentData
{
    // Identifier of the site
    public string SiteId { get; set; }

    // Date and Time of the appointment
    public DateTime Time { get; set; }

    // Duration in minutes of the appointment
    public int DurationMinute { get; set; }

    // Full name of the respondent
    public string RespondentName { get; set; }

    // Phone number of the respondent
    public string RespondentPhoneNumber { get; set; }
}