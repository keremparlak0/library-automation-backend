namespace Models.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string email) : base($"The user with '{email}' doesn't exists.")
        {
        }
    }
}
