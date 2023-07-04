using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Utilities.Settings
{
    public class DbConnectionModel
    {
        public string ServerName { get; set; }

        public string Database { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool TrustedConnection { get; set; }

        public override string ToString()
        {
            return $"Server={ServerName};Database={Database};"
                + (TrustedConnection ? "Trusted_Connection=True;"
                : $"User Id={Username};Password={Password};Encrypt=False");
        }
    }
}
