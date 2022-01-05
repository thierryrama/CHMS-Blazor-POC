using StatCan.Chms.Client.Models;

namespace StatCan.Chms.Client.Services;

public class AppStateInitializer
{
    private readonly AppState _appState;

    public AppStateInitializer(AppState appState)
    {
        _appState = appState;
    }

    public async Task InitializeState()
    {
        await Task.Run(() =>
        {
            _appState.SignedInUser = new SignedInUser
            {
                FirstName = "Thierry",
                LastName = "Ramanampanoharana"
            };
        });
    }
}