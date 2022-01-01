using System.Globalization;

namespace StatCan.Chms.Client.Services;

/// <summary>
/// Argument for the event when the culture was changed by the <see cref="CultureManager"/>.
/// </summary>
public class CultureChangedArgs : EventArgs
{
    /// <summary>
    /// The old value.
    /// </summary>
    public CultureInfo OldValue { get; }

    /// <summary>
    /// The new value.
    /// </summary>
    public CultureInfo NewValue { get; }

    public CultureChangedArgs(CultureInfo oldValue, CultureInfo newValue)
    {
        OldValue = oldValue;
        NewValue = newValue;
    }
}
