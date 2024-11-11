using Hangfire_EmailNotification.Context;
using Hangfire_EmailNotification.Models;
using Hangfire_EmailNotification.ViewModels;
using System.Threading.Tasks;

public class UserRegistrationService : IUserRegistrationService
{
    private readonly HangfileContext _hangfileContext;

    public UserRegistrationService(HangfileContext hangfileContext)
    {
        _hangfileContext = hangfileContext;
    }

    public async Task AddUser(UserRegistrationViewModel userRegistrationViewModel)
    {
        if (userRegistrationViewModel == null)
        {
            throw new ArgumentNullException(nameof(userRegistrationViewModel));
        }

        var userModel = new UserModel
        {
            UserName = userRegistrationViewModel.UserName,
            UserEmail = userRegistrationViewModel.UserEmail,
            UserPassword = userRegistrationViewModel.UserPassword,
            UserMobileNumber = userRegistrationViewModel.UserMobileNumber,
            IsSubscribed = true
        };

        await _hangfileContext.CustomerInformation.AddAsync(userModel);
        await _hangfileContext.SaveChangesAsync();
    }
}