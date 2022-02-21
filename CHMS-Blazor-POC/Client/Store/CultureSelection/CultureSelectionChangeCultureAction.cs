using System.Globalization;

namespace StatCan.Chms.Client.Store.CultureSelection;

public class CultureSelectionChangeCultureAction
{
    public CultureInfo NewCulture { get; }

    public CultureSelectionChangeCultureAction(CultureInfo newCulture)
    {
        NewCulture = newCulture;
    }
}