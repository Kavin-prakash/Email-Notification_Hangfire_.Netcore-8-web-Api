using Hangfire_EmailNotification.ViewModels;

public  interface  IUserRegistrationService{

     Task AddUser(UserRegistrationViewModel userRegistrationViewModel);
}