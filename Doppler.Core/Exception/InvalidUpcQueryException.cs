namespace Doppler.Core.Exception
{
    public class InvalidUpcQueryException : System.Exception
    {
        public InvalidUpcQueryException(string query)
            : base($"Query to upc store contains invalid parameters {query}")
        {

        }
    }
}