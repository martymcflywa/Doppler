using Doppler.Core.Type;

namespace Doppler.Core.Exception
{
    public class UpcNotFoundException : System.Exception
    {
        public UpcNotFoundException(string id)
            : base($"Upc {id} not found.")
        {

        }
    }
}