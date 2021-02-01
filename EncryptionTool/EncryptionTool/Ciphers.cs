using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionTool
{
    abstract class CipherBase
    {
        public abstract string Encrypt(string plainText);
        public abstract string Decrypt(string cipherText);
    }

    /// <typeparam name="T">value type of encryption key</typeparam>
    abstract class Cipher<T> : CipherBase
    {
        //min and max values of Unicode
        protected const int MIN_CHAR_VALUE = char.MinValue;
        protected const int MAX_CHAR_VALUE = char.MaxValue;

        protected T _key;

        public Cipher(T key)
        {
            _key = key;
        }

    }

    /// <summary>
    /// Transposes the characters in the message by a set value
    /// </summary>
    internal class CaesarCipher : Cipher<int>
    {

        public CaesarCipher(int key) : base(key) { }

        public override string Encrypt(string plainText)
        {
            string cipherText;
            IEnumerable<int> charUnicodeVals;

            //converts each char to Unicode value
            charUnicodeVals = plainText.Select(x => (int)x);
            //adds key value to each Unicode char
            charUnicodeVals = charUnicodeVals.Select(x => (x + _key) % MAX_CHAR_VALUE);
            //convert back into a string
            cipherText = String.Concat(charUnicodeVals.Select(x => (char)x));

            return cipherText;
        }

        public override string Decrypt(string cipherText)
        {
            string plainText;
            IEnumerable<int> charUnicodeVals;

            //converts each char to Unicode value
            charUnicodeVals = cipherText.Select(x => (int)x);
            //subtracts key value from each Unicode char
            charUnicodeVals = charUnicodeVals.Select(x => (x - _key) % MAX_CHAR_VALUE);
            //convert back into a string
            plainText = String.Concat(charUnicodeVals.Select(x => (char)x));

            return plainText;
        }
    }

    /// <summary>
    /// Reorders the characters in the message through matrix manipulation
    /// </summary>
    internal class ColumnarTransposition : Cipher<string>
    {
        public ColumnarTransposition(string key) : base(key) { }

        public override string Encrypt(string plainText)
        {
            StringBuilder cipherTextBuilder;
            string cipherText;
            char[,] encodeMatrix;
            IEnumerable<int> keyCharUnicodeVals;

            encodeMatrix = CreateNewMatrix(out keyCharUnicodeVals, plainText);
            encodeMatrix = LoadKeyIntoMatrix(keyCharUnicodeVals, encodeMatrix);
            encodeMatrix = LoadPlainMessageIntoMatrix(plainText, encodeMatrix);

            Logger.LogMatrix<char>(encodeMatrix);

            cipherTextBuilder = new StringBuilder();
            
            int minValue = int.MaxValue;
            int indexOfMinValue;

            //find smallest value in the key and remove that key value
            for (int j = 0; j < encodeMatrix.GetLength(1); j++)
            {
                if (encodeMatrix[0, j] < minValue)
                {
                    minValue = encodeMatrix[0, j];
                    indexOfMinValue = j;
                    encodeMatrix[0, j] = (char)MAX_CHAR_VALUE;
                }

                //add rest of column to the cipherText
                for (int i = 1; i < encodeMatrix.GetLength(0); i++)
                {
                    cipherTextBuilder.Append(encodeMatrix[i, j]);
                }
            }

            cipherText = cipherTextBuilder.ToString();
            return cipherText;
        }

        public override string Decrypt(string cipherText)
        {
            StringBuilder plainTextBuilder;
            string plainText;
            char[,] decodeMatrix;
            IEnumerable<int> keyCharUnicodeVals;

            decodeMatrix = CreateNewMatrix(out keyCharUnicodeVals, cipherText);
            decodeMatrix = LoadKeyIntoMatrix(keyCharUnicodeVals, decodeMatrix);
            decodeMatrix = LoadCipherMessageIntoMatrix(cipherText, decodeMatrix);

            Logger.LogMatrix<char>(decodeMatrix);

            plainTextBuilder = new StringBuilder();

            //read each char left-to-right and insert into plainTextBuilder
            for (int i = 1; i < decodeMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < decodeMatrix.GetLength(1); j++)
                {
                    //skip nulls added from encryption
                    if (decodeMatrix[i, j] == '\u0000') continue;

                    plainTextBuilder.Append(decodeMatrix[i, j]);
                }
            }

            plainText = plainTextBuilder.ToString();
            return plainText;
        }

        private char[,] CreateNewMatrix(out IEnumerable<int> keyCharUnicodeVals, string message)
        {
            keyCharUnicodeVals = _key.Select(a => (int)a);

            //columns = number of chars in key
            int y = keyCharUnicodeVals.Count();

            //first row used for key, as add one extra row
            //want to round up if result is not a whole number
            int x = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(message.Length) / Convert.ToDouble(y))) + 1;

            return new char[x, y];
        }

        private char[,] LoadKeyIntoMatrix(IEnumerable<int> keyCharUnicodeVals, char[,] matrix)
        {
            //load 1st row with the key values
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[0, j] = Convert.ToChar(keyCharUnicodeVals.ElementAt(j));
            }

            return matrix;
        }

        private char[,] LoadPlainMessageIntoMatrix(string message, char[,] matrix)
        {
            int indexOfText = 0;
            //load rest of rows with the plaintext message
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++, indexOfText++)
                {
                    //fill empty spaces with nulls
                    if (indexOfText >= message.Length)
                    {
                        matrix[i, j] = '\u0000';
                    }
                    else
                    {
                        matrix[i, j] = message.ElementAt(indexOfText);
                    }
                }
            }

            return matrix;
        }

        private char[,] LoadCipherMessageIntoMatrix(string message, char[,] matrix)
        {
            int indexOfText = 0;
            //load rest of rows with the ciphertext message
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 1; j < matrix.GetLength(0); j++, indexOfText++)
                {
                    if (indexOfText >= message.Length) break;

                    matrix[j, i] = message.ElementAt(indexOfText);
                }
            }

            return matrix;
        }
    }

    /// <summary>
    /// Xor's each character in the text by the character key
    /// </summary>
    internal class XorCipher : Cipher<char>
    {
        public XorCipher(char key) : base(key) { }

        public override string Encrypt(string plainText)
        {
            string cipherText;
            StringBuilder cipherTextBuilder = new StringBuilder();

            //do an xor on each character in the text
            for (int i = 0; i < plainText.Length; i++)
            {
                cipherTextBuilder.Append(char.ToString((char)(plainText[i] ^ _key)));
            }

            cipherText = cipherTextBuilder.ToString();
            return cipherText;
        }

        public override string Decrypt(string cipherText)
        {
            //encrypt and decrypt use the same code
            return Encrypt(cipherText);
        }
    }
}
