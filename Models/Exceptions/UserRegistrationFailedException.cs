using Models.ErrorModel;

namespace Models.Exceptions
{
    public class UserRegistrationFailedException : Exception
    {
        public UserRegistrationFailedException(ErrorResponse response) : base($"Status Code = {response.StatusCode}\nDescription = {response.Description}")
        {
        }
    }
}
