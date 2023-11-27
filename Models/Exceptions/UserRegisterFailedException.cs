using Models.ErrorModel;

namespace Models.Exceptions
{
    public class UserRegisterFailedException : Exception
    {
        public UserRegisterFailedException(ErrorResponse response) : base($"Status Code = {response.StatusCode}\nDescription = {response.Description}")
        {
        }
    }
}
