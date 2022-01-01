using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StatCan.Chms.DataTransfer.Booking;

namespace CHMS.Server.Controllers;

/// <summary>
/// Endpoints enabling the management and viewing of clinic appointments.
/// </summary>
[Route("api/booking-reservation")]
[ApiController]
public class BookingController : ControllerBase
{
    /// <summary>
    /// Get all appointments at a given site within the given time ramge
    /// </summary>
    /// <param name="site">Site Identifiter</param>
    /// <param name="from">Start of the date time range. If not provided, today at start of day is assumed</param>
    /// <param name="to">End of the date time range. If not provided, today at the end of day is assuemd</param>
    /// <returns>A list of existing appointments at the given site within the given time range</returns>
    [HttpGet]
    [Route("appointments")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AppointmentDetailData>>> GetAppointments(string site, DateTime? from, DateTime? to)
    {
        return this.Ok();
    }
}

