using Fluxor.DependencyInjection;

namespace StatCan.Chms.Client.Store.CultureSelection;

public static class FluxorOptionsExtensions
{
    public static FluxorOptions UseCultureSelection(this FluxorOptions options)
    {
        options.AddMiddleware<CultureSelectionMiddleware>();
        return options;
    }
}