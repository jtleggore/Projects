using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

//todo: add error checking
namespace EncryptionTool
{
    public partial class Form1 : Form
    {
        //todo: change  to enum if using multiple
        private const string ENCRYPT_EXTENSION = ".enc";

        FormPopup formSuccessPopup;
        FormPopup formFailPopup;

        public Boolean toRestart = false;

        private enum CryptOptions
        {
            Encrypt = 1,
            Decrypt
        }

        public string[] cipherOptions = { nameof(CaesarCipher), nameof(ColumnarTransposition) };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cipherComboBox.Items.AddRange(cipherOptions);
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            Cipher((int)CryptOptions.Encrypt);
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            Cipher((int)CryptOptions.Decrypt);
        }

        private void Cipher(int cryptOption)
        {//todo: use properties of a file to determine which encryption used on the file
            //CaesarCipher caesarCipher;
            CipherBase cipher;

            string inputFileContents = "";
            string outputFileContents = "";

            string filePath = "";
            string fileName = "";

            string key = "";
            string cipherChoice = "";

            try
            {
                PathParser.ParseFilePath(inputFileTextBox.Text, out filePath, out fileName);

                key = keyTextBox.Text;
                cipherChoice = cipherComboBox.Text;

                inputFileContents = File.ReadAllText(filePath + fileName);
            }
            catch(Exception e)
            {
                HandleException(e);
            }

            switch (cipherChoice) 
            {
                case nameof(CaesarCipher)://todo find a better way
                    int parsedKey;
                    if (!int.TryParse(key, out parsedKey))
                    {
                        HandleException(new Exception("Key is invalid!"));
                    }
                    cipher = new CaesarCipher(parsedKey);
                    break;
                case nameof(ColumnarTransposition):
                    cipher = new ColumnarTransposition(key);
                    break;
                default:
                    cipher = new CaesarCipher(0);
                    HandleException(new Exception("Cipher Option is invalid!"));
                    break;
            }

            if (!CheckFileExtension(cryptOption, fileName))
            {
                HandleException(new Exception("File extension is invalid!"));
            }

            switch (cryptOption)
            {
                case (int)CryptOptions.Encrypt:
                    outputFileContents = cipher.Encrypt(inputFileContents);
                    File.WriteAllText(filePath + fileName + ENCRYPT_EXTENSION, outputFileContents);
                    formSuccessPopup = new FormPopup("File encrypted successfully!");
                    break;

                case (int)CryptOptions.Decrypt:
                    outputFileContents = cipher.Decrypt(inputFileContents);
                    File.WriteAllText(filePath + fileName.Substring(0, fileName.LastIndexOf(".")), outputFileContents);
                    formSuccessPopup = new FormPopup("File decrypted successfully!");
                    break;

                default:                   
                    formSuccessPopup = new FormPopup("");
                    HandleException(new Exception("Crypt Option is invalid!"));
                    break;
            }

            formSuccessPopup.ShowDialog();
        }

        /// <summary>
        /// Confirms that the file is the correct type for running cypher
        /// </summary>
        /// <param name="cryptOption">encrypt or decrypt</param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private bool CheckFileExtension(int cryptOption, string fileName)
        {
            string fileNameNoExtension;
            string fileExtension;

            try
            {
                PathParser.ParseFileName(fileName, out fileNameNoExtension, out fileExtension);
            }
            catch(Exception e)
            {
                return false;
            }

            switch (cryptOption)
            {
                //file must not end in .enc
                case (int)CryptOptions.Encrypt:
                    if (fileExtension == ENCRYPT_EXTENSION)
                    {
                        return false;
                    }
                    break;
                
                //file must end in .enc
                case (int)CryptOptions.Decrypt:
                    if (fileExtension != ENCRYPT_EXTENSION)
                    {
                        return false;
                    }
                    break;

                default:
                    //todo: throw error
                    return false;
            }
            return true;
        }

        private void HandleException(Exception e)
        {
            Logger.LogException(e);
            formFailPopup = new FormPopup(e.Message);
            formFailPopup.ShowDialog();

            //System.Diagnostics.Process.Start(Application.ExecutablePath);

            toRestart = true;
            this.Close();
        }
    }
}
