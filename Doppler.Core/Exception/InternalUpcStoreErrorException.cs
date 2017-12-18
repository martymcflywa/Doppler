namespace Doppler.Core.Exception
{
    public class InternalUpcStoreErrorException : System.Exception
    {
        public InternalUpcStoreErrorException()
            : base("Internal upc store server error, try again later.")
        {

        }
    }
}