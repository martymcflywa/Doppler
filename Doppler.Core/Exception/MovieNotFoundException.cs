namespace Doppler.Core.Exception
{
    public class MovieNotFoundException : System.Exception
    {
        public MovieNotFoundException(string title)
            : base ($"Movie {title} not found.")
        {

        }
    }
}