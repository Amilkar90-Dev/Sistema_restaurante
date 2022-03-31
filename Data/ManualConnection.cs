using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Sistema_restaurante.Data
{
    public partial class ManualConnection : Form
    {
        private Logic.Encryption encryption = new Logic.Encryption();
        public ManualConnection()
        {
            InitializeComponent();
        }

        private void SavetoXML(object dbcnString)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("ConnectionString.xml");
            XmlElement root = doc.DocumentElement;
            root.Attributes[0].Value = Convert.ToString(dbcnString);
            XmlTextWriter writer = new XmlTextWriter("ConnectionString.xml", null);
            writer.Formatting = Formatting.Indented;
            doc.Save(writer);
            writer.Close();
        }

        String dbcnString;
        public void ReadfromXML()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("ConnectionString.xml");
                XmlElement root = doc.DocumentElement;
                dbcnString = root.Attributes[0].Value;
                txtCnString.Text = (encryption.Decrypt(dbcnString, Logic.Decrypted.appPwdUnique, int.Parse("256")));
            }
            catch (System.Security.Cryptography.CryptographicException ex)
            {

            }

        }
        private void ManualConnection_Load(object sender, EventArgs e)
        {
            ReadfromXML();           

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            SavetoXML(encryption.Encrypt(txtCnString.Text, Logic.Decrypted.appPwdUnique, int.Parse("256")));
        }
    }
}
