using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatCan.Chms.DataTransfer.Booking;

/// <summary>
/// Data representing one appointment
/// </summary>
public record AppointmentDetailData(
    // Identifier of the site
    string SiteId,

    // Date and Time of the appointment
    DateTime Time,

    // Duration in minutes of the appointment
    int DurationMinute,

    // Full name of the respondent
    string RespondentName,

    // Phone number of the respondent
    string RespondentPhoneNumber
);
