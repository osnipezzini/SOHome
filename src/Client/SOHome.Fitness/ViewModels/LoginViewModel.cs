using Acr.UserDialogs;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Microsoft.Extensions.Logging;

using SOHome.Common.DataModels;
using SOHome.Common.RefitServices;
using SOHome.Fitness.Models;
using SOHome.Fitness.Pages;

namespace SOHome.Fitness.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    private readonly IAuthAPI authAPI;
    private readonly ILogger<LoginViewModel> logger;
    private readonly UserProvider userProvider;
    [ObservableProperty]
    private LoginModel model;

    public LoginViewModel(IAuthAPI authAPI, ILogger<LoginViewModel> logger, UserProvider userProvider)
    {
        this.authAPI = authAPI;
        this.logger = logger;
        this.userProvider = userProvider;
        Model = new LoginModel();
    }

    [RelayCommand]
    async Task Authenticate()
    {
        try
        {
#if !WINDOWS
            //using var loading = UserDialogs.Instance.Loading("Autenticando usuário");
#endif
            var userDto = await authAPI.Authenticate(Model);
            userProvider.User = userDto;
            await Shell.Current.GoToAsync($"///{nameof(MainPage)}");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
        }
    }
}
