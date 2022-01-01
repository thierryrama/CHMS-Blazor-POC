using System.Globalization;

namespace StatCan.Chms.Client.Services;

/// <summary>
/// Options for the <see cref="CultureManager"/>.
/// </summary>
public class CultureManagerOptions
{
    /// <summary>
    /// The default culture to set a the start of the application.
    /// </summary>
    public CultureInfo DefaultCulture { get; set; } = new CultureInfo("en-CA");

    /// <summary>
    /// The supported cultures by the application.
    /// </summary>
    public CultureInfo[] SupportedCultures { get; set; } = new CultureInfo[] { new CultureInfo("en-CA"), new CultureInfo("fr-CA") };
}
