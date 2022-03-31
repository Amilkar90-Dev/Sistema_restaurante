using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace Sistema_restaurante.Logic
{
    public class Decrypted
    {
        static private  Encryption  encryption = new Encryption();
        static public string CnString;
        static string dbcnString;
        static public string appPwdUnique = "SistemaRestaurante.system.BASERESTAURANTE.Hola_//@ñÑ";


        public static object checkServer()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("ConnectionString.xml");
            XmlElement root = doc.DocumentElement;
            dbcnString = root.Attributes[0].Value;
            CnString = (encryption.Decrypt(dbcnString, appPwdUnique, int.Parse("256")));
            return CnString;

        }

        internal class label
        {

        }
        public static object UsuariosEncryp()
        {
            XmlDocument doc = new XmlDocument();
            label root = new label();

            dbcnString = root.ToString();
            CnString = (encryption.Decrypt(dbcnString, appPwdUnique, int.Parse("256")));
            return CnString;

        }
    }
}
