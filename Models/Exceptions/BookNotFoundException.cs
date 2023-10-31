namespace Models.Exceptions
{
    public sealed class BookNotFoundException : NotFoundException
    {
        public BookNotFoundException(int id) : base($"The book with {id} doesn't exists.")
        {
        }
    }
}
