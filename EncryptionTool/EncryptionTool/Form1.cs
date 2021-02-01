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

namespace EncryptionTool
{
    public partial class Form1 : Form
    {
        private const string ENCRYPT_EXTENSION = ".enc";

        private const string KEY_INVALID = "Key is invalid!";
        private const string CIPHER_INVALID = "Cipher Option is invalid!";
        private const string FILE_EXT_INVALID = "File extension is invalid!";
        private const string ENCRYPT_SUCCESS = "File encrypted successfully!";
        private const string DECRYPT_SUCCESS = "File decrypted successfully!";

        FormPopup formSuccessPopup;
        FormPopup formFailPopup;

        public Boolean toRestart = false;

        private enum CryptOptions
        {
            Encrypt = 1,
            Decrypt
        }

        public string[] cipherOptions = { nameof(CaesarCipher), nameof(ColumnarTransposition), nameof(XorCipher) };

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
                    int parsedKeyInt;
                    if (!int.TryParse(key, out parsedKeyInt))
                    {
                        HandleException(new Exception(KEY_INVALID));
                    }
                    cipher = new CaesarCipher(parsedKeyInt);
                    break;
                case nameof(ColumnarTransposition):
                    cipher = new ColumnarTransposition(key);
                    break;
                case nameof(XorCipher):
                    char parsedKeyChar;
                    if (!char.TryParse(key, out parsedKeyChar))
                    {
                        HandleException(new Exception(KEY_INVALID));
                    }
                    cipher = new XorCipher(parsedKeyChar);
                    break;
                default:
                    cipher = new CaesarCipher(0);
                    HandleException(new Exception(CIPHER_INVALID));
                    break;
            }

            if (!CheckFileExtension(cryptOption, fileName))
            {
                HandleException(new Exception(FILE_EXT_INVALID));
            }

            switch (cryptOption)
            {
                case (int)CryptOptions.Encrypt:
                    outputFileContents = cipher.Encrypt(inputFileContents);
                    File.WriteAllText(filePath + fileName + ENCRYPT_EXTENSION, outputFileContents);
                    formSuccessPopup = new FormPopup(ENCRYPT_SUCCESS);
                    break;

                case (int)CryptOptions.Decrypt:
                    outputFileContents = cipher.Decrypt(inputFileContents);
                    File.WriteAllText(filePath + fileName.Substring(0, fileName.LastIndexOf(".")), outputFileContents);
                    formSuccessPopup = new FormPopup(DECRYPT_SUCCESS);
                    break;

                default:                   
                    formSuccessPopup = new FormPopup("");
                    HandleException(new Exception(CIPHER_INVALID));
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
