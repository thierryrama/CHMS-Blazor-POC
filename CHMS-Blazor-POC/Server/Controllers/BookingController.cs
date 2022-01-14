using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StatCan.Chms.DataTransfer.Booking;
using StatCan.Chms.Services;

namespace CHMS.Server.Controllers;

/// <summary>
/// Endpoints enabling the management and viewing of clinic appointments.
/// </summary>
[Route("api/booking-reservation")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly BookingBusinessService _bookingBusinessService;

    public BookingController(BookingBusinessService bookingBusinessService)
    {
        _bookingBusinessService = bookingBusinessService;
    }

    /// <summary>
    /// Get all appointments at a given site within the given time range
    /// </summary>
    /// <param name="site">Site Identifiter</param>
    /// <param name="from">Start of the date time range. If not provided, today at start of day is assumed</param>
    /// <param name="to">End of the date time range. If not provided, today at the end of day is assumed</param>
    /// <returns>A list of existing appointments at the given site within the given time range</returns>
    [HttpGet]
    [Route("appointments")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AppointmentDetailData>>> GetAppointments([Required] string site, DateTimeOffset? from, DateTimeOffset? to)
    {
        // Question: which date time data type is the correct one to use?
        //   DateTime?
        //     The Kind can be: Local, UTC, Unspecified
        //   DateTimeOffset?
        //     Always with an offset relative to UTC
        //
        // The API can be called with all sorts of date time format.
        return await Task.FromResult
        (
            Ok(_bookingBusinessService.GetSiteAppointmentsByDateRange(site, from?.LocalDateTime ?? DateTime.Today, to?.LocalDateTime ?? DateTime.Today.AddDays(1)))
        );
    }
}

