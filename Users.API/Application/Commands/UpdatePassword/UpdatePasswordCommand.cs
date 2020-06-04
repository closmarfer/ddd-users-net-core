namespace Users.API.Application.Commands.UpdatePassword
{
    public class UpdatePasswordCommand
    {
        public UpdatePasswordCommand(string email, string oldPassword, string newPassword)
        {
            Email = email;
            OldPassword = oldPassword;
            NewPassword = newPassword;
        }

        public string Email { get; }
        public string OldPassword { get; }
        public string NewPassword { get; }
    }
}