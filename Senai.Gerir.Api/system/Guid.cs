using Senai.Gerir.Api.Dominios;

namespace system
{
    internal class Guid : Usuario
    {
        private string value;

        public Guid(string value)
        {
            this.value = value;
        }
    }
}