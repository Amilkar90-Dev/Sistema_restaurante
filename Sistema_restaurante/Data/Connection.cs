using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_restaurante.Data
{
    class Connection
    {
        public static string conecction = Convert.ToString(Logic.Decrypted.checkServer());
    }
}
