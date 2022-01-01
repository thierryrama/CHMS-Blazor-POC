using Microsoft.Extensions.Options;
using System.Globalization;

namespace StatCan.Chms.Client.Services;

/// <summary>
/// A manager to centrally manage the culture. It is used to:
/// <list type="bullet">
///     <item>Set a default culture for the applcation.</item>
///     <item>Set a list of supported cultures by the application.</item>
///     <item>Change the culture and notify listeners of the change.</item>
/// </list>
/// The point of using this manager is to be able to communicate the culture change to different decoupled components.
/// </summary>
/// <remarks>It forces the same culture for the <see cref="CultureInfo.CurrentCulture"/> and the <see cref="CultureInfo.CurrentUICulture"/>.</remarks>
public class CultureManager
{
    private readonly CultureManagerOptions _options;

    private readonly ILogger<CultureManager> _logger;

    public CultureManager(IOptions<CultureManagerOptions> options, ILogger<CultureManager> logger)
    {
        _options = options.Value;
        _logger = logger;

        ChangeCulture(this, _options.DefaultCulture);
    }

    /// <summary>
    /// The supported cultures.
    /// </summary>
    public CultureInfo[] SupportedCultures { get => _options.SupportedCultures; }

    /// <summary>
    /// The current culture.
    /// </summary>
    public CultureInfo CurrentCulture => CultureInfo.CurrentCulture;

    /// <summary>
    /// Event handler triggered when the culture was changed by this manager.
    /// </summary>
    public event EventHandler<CultureChangedArgs>? CultureChanged;

    /// <summary>
    /// Change the culture and notify the <see cref="CultureChanged"/> event listeners of the change.
    /// 
    /// A culture that isn't supported will be ignored.
    /// </summary>
    /// <param name="sender">The source of the change</param>
    /// <param name="culture">The new culture</param>
    public void ChangeCulture(object sender, CultureInfo culture)
    {
        if (!SupportedCultures.Contains(culture))
        {
            _logger.LogDebug("Trying to change to a unsupported culture: {Culture}", culture);

            return;
        }

        if (!CurrentCulture.Equals(culture))
        {
            _logger.LogDebug("Changing culture from {Current} to {Requested} - Requested by {Sender}", CurrentCulture, culture, sender);

            var cultureChangedArts = new CultureChangedArgs(CurrentCulture, culture);

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            CultureChanged?.Invoke(sender, cultureChangedArts);
        }
    }
}
