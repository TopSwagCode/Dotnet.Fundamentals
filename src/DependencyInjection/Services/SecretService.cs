using DependencyInjection.Options;
using Microsoft.Extensions.Options;
using System;

namespace DependencyInjection.Services
{
    public class SecretService : ISecretService
    {
        public SecretService(IOptions<SecretOptions> secretOptions)
        {
            // Use secret options to connect to some secret store like HashiCorp Vault
            // https://www.vaultproject.io/
        }

        public string GetConnectionString()
        {
            return $"Some external stored connectionstring: {Guid.NewGuid().ToString()}";
        }
    }
}
