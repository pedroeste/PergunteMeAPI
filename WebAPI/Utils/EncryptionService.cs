using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Utils
{
    public class EncryptionService
    {
        private static RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
        private RSAParameters _public;
        private RSAParameters _private;
        public static IConfigurationRoot Configuration;

        public EncryptionService()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            _public = DeserializeKey(Configuration["PublicKey"]);
            _private = DeserializeKey(Configuration["RsaKey"]);
        }

        //public void SerializeRsaKey()
        //{
        //    string publicKey = JsonConvert.SerializeObject(new RSAParametersSerializable(csp.ExportParameters(false)));
        //    string privateKey = JsonConvert.SerializeObject(new RSAParametersSerializable(csp.ExportParameters(true)));
        //}

        public RSAParameters DeserializeKey(string serializedParam)
        {
            return JsonConvert.DeserializeObject<RSAParametersSerializable>(serializedParam).RSAParameters;
        }

        public string Encrypt(string text)
        {
            csp = new RSACryptoServiceProvider();
            csp.ImportParameters(_public);

            var data = Encoding.Unicode.GetBytes(text);
            var cypher = csp.Encrypt(data, false);

            return Convert.ToBase64String(cypher);
        }

        public string Decrypt(string cypherText)
        {
            var dataBytes = Convert.FromBase64String(cypherText);
            csp.ImportParameters(_private);
            var text = csp.Decrypt(dataBytes, false);

            return Encoding.Unicode.GetString(text);
        }
    }
}
