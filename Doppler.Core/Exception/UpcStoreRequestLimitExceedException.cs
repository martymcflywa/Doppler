namespace Doppler.Core.Exception
{
    public class UpcStoreRequestLimitExceededException : System.Exception
    {
        public UpcStoreRequestLimitExceededException()
            : base("You have exceeded the upc store request limit, try again later.")
        {

        }
    }
}