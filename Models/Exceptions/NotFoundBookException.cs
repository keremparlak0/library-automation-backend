namespace Models.Exceptions
{
    public sealed class NotFoundBookException : NotFoundException
    {
        public NotFoundBookException(int id) : base($"The book with {id} doesn't exists.")
        {
        }
    }
}
