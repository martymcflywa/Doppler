namespace Doppler.Core.Exception
{
    public class MovieStoreRequestLimitExceededException : System.Exception
    {
        public MovieStoreRequestLimitExceededException()
            : base("You have exceeded the upc store request limit, try again later.")
        {

        }
    }
}