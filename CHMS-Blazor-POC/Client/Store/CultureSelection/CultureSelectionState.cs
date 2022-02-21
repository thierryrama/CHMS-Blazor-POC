using System.Globalization;

namespace StatCan.Chms.Client.Store.CultureSelection;

public record CultureSelectionState
{
    public CultureInfo[] SupportedCultures { get; init; }
    
    public CultureInfo CurrentCulture { get; init; }
}