using Fluxor;

namespace StatCan.Chms.Client.Store.CultureSelection;

public static class Reducers
{
    [ReducerMethod]
    public static CultureSelectionState OnChangeResult(CultureSelectionState state, CultureSelectionChangeCultureResultAction action)
    {
        return state with
        {
            CurrentCulture = action.NewCulture
        };
    }
}