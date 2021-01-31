using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionTool
{
    /// <summary>
    /// Collection of static methods for parsing the parts of a file path
    /// </summary>
    public static class PathParser
    {
        /// <summary>
        /// Splits file path from file name of input text
        /// </summary>
        /// <param name="input"></param>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        public static void ParseFilePath(string input, out string filePath, out string fileName)
        {
            int fileNameStartIndex = input.LastIndexOf(@"\");

            filePath = input.Substring(0, fileNameStartIndex + 1);
            fileName = input.Substring(fileNameStartIndex, input.Length - fileNameStartIndex);
        }

        /// <summary>
        /// Splits file name from file extension
        /// </summary>
        /// <param name="input"></param>
        /// <param name="fileName"></param>
        /// <param name="fileExt"></param>
        public static void ParseFileName(string input, out string fileName, out string fileExt)
        {
            int fileExtStartIndex = input.LastIndexOf(@".");

            fileName = input.Substring(0, fileExtStartIndex + 1);
            fileExt = input.Substring(fileExtStartIndex, input.Length - fileExtStartIndex);
        }
    }
}
