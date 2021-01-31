using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace EncryptionTool
{
    /// <summary>
    /// Logs to file only if it's a debug build
    /// </summary>
    public static class Logger
    {
        private static string _filePath;
        private static string _fileName;

        public static string FilePath { get { return _filePath; } }
        public static string FileName { get { return _fileName; } }

        static Logger(/*string filePath*/)
        {
            //_filePath = @".\Log\Log.txt";
            PathParser.ParseFilePath(@".\Log\Log.txt", out _filePath, out _fileName);
        }

        public static void LogMessage(string message)
        {
#if DEBUG
            Directory.CreateDirectory(FilePath);            
            File.AppendAllText(FilePath + FileName, BuildLoggingData(message));
#endif
        }

        public static void LogException(Exception exception)
        {
#if DEBUG
            Directory.CreateDirectory(FilePath);
            File.AppendAllText(FilePath + FileName, BuildLoggingData(exception));
#endif
        }

        /// <summary>
        /// Logs a 2 dimensional array
        /// </summary>
        /// <typeparam name="T">type of array, if using char, will convert control chars to unicode</typeparam>
        /// <param name="encodeMatrix"></param>
        public static void LogMatrix<T>(T[,] encodeMatrix)
        {
#if DEBUG
            //holds amount of digits in larger dimension for pretty printing
            int amountOfDigits;
            StringBuilder zeros = new StringBuilder();

            amountOfDigits = Math.Max(CalculateAmountOfDigits(encodeMatrix.GetLength(0)), 
                CalculateAmountOfDigits(encodeMatrix.GetLength(1)));

            for (int i = 0; i < amountOfDigits; i++)
            {
                zeros.Append("0");
            }

            StringBuilder message = new StringBuilder();
            string toPrint;

            message.AppendLine();

            for (int i = 0; i < encodeMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < encodeMatrix.GetLength(1); j++)
                {
                    if (typeof(T) == typeof(char))
                    {
                        //convert control chars into unicode representation
                        toPrint = char.IsControl((char)(object)encodeMatrix[i, j]) ?
                            @"\u" + ((int)(char)(object)encodeMatrix[i, j]).ToString("X4") :
                            encodeMatrix[i, j].ToString();                       
                    }
                    else
                    {
                        toPrint = ((object)encodeMatrix[i, j]).ToString();
                    }

                    message.Append(string.Format("[{0}][{1}] = {2},", i.ToString(zeros.ToString()), 
                        j.ToString(zeros.ToString()), toPrint));
                }

                message.AppendLine();
            }

            Logger.LogMessage(message.ToString());
#endif
        }

        private static string BuildLoggingData(string message)
        {
            string loggingData;
            DateTime dateTime = DateTime.Now;

            loggingData = string.Format("<<{0}>> {1}\r\n", dateTime, message);
            return loggingData;
        }

        private static string BuildLoggingData(Exception e)
        {
            return BuildLoggingData(e.Message + "\n" + e.StackTrace);
        }

        /// <summary>
        /// Calculates amount of digits in any given integer
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int CalculateAmountOfDigits(int num)
        {
            if (num != 0)
            {
                return (int)Math.Floor(Math.Log10(Math.Abs(num)) + 1);
            }
            else
            {
                return 1;
            }
            
            /*if (num > 0)
            {
                int numDigits = 0;

                numDigits = (int)TestRecursive(num, numDigits);
                return numDigits;
            }
            else
            {
                return 0;
            }*/
        }

        private static decimal TestRecursive(decimal num, int digitCounter)
        {
            if (num > 1)
            {
                return TestRecursive(num / 10, digitCounter + 1);
            }
            else
            {
                return digitCounter;
            }
        }
    }
}
