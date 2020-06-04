namespace Users.API.Application.Commands.DeleteUser
{
    public class DeleteUserCommand
    {
        public DeleteUserCommand(string userUuid)
        {
            UserUuid = userUuid;
        }

        public string UserUuid { get; }
    }
}