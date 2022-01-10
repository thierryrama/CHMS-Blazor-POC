namespace StatCan.Chms.QueryResolvers;

public class Query
{
    /// <summary>
    /// This is to simulate a namespace called <c>booking</c> under the Query root. The actual queries for the <c>booking</c> namespace
    /// are found in <see cref="BookingResolver"/>.
    ///
    /// The schema will look like:
    /// <code>
    /// type Query {
    ///     booking {
    ///         appointments
    ///         ...
    ///     }
    /// }
    /// </code>
    /// </summary>
    /// <remarks>This has the drawback that the actual queries -- like "appointments" -- are no longer query types but object types.</remarks>
    /// <returns>the booking namespace</returns>
    public Booking GetBooking() => Booking.Instance;
}