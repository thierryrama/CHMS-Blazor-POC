using System.Globalization;

namespace StatCan.Chms.Client.Store.CultureSelection;

public class CultureSelectionChangeCultureResultAction
{
    public CultureInfo NewCulture { get; }

    public CultureSelectionChangeCultureResultAction(CultureInfo newCulture)
    {
        NewCulture = newCulture;
    }
}