namespace Models.Exceptions
{
    public class NotFoundUserException : NotFoundException
    {
        public NotFoundUserException() : base($"The user doesn't exists.")
        {
        }
    }
}
