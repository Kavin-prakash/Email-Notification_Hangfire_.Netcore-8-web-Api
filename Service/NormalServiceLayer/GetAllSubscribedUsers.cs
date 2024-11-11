using Hangfire_EmailNotification.Common;
using Hangfire_EmailNotification.Context;
using Microsoft.EntityFrameworkCore;

public class GetAllSubscribedUsers
{

    private readonly HangfileContext _hangfileContext;

    public GetAllSubscribedUsers(HangfileContext hangfileContext)
    {
        _hangfileContext = hangfileContext;
    }

    public async Task GetAllSubscribed()
    {
        var customers = await _hangfileContext.CustomerInformation.Where(x => x.IsSubscribed == true).ToListAsync();

        foreach (var customer in customers)
        {
            SubscribeEmail.SendEmail(customer.UserEmail,customer.UserName);
        }
    }
}