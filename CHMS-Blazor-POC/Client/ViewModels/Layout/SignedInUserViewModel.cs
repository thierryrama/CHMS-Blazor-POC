using StatCan.Chms.Client.Models;

namespace StatCan.Chms.Client.ViewModels.Layout;

public class SignedInUserViewModel
{
    private readonly AppState _appState;
    
    public SignedInUserViewModel(AppState appState)
    {
        _appState = appState;
    }
    
    public string? FirstName
    {
        get => _appState?.SignedInUser?.FirstName;
    }

    public String? LastName
    {
        get => _appState.SignedInUser.LastName;
    }
}