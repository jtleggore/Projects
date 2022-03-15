using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace CLI_Tool
{
    public class FileDownloader
    {
        private string filePathToUrls;
        private string[,] delimitedTexts;
        private Func<string, string> fileReadMethod;

        public string[,] DelimitedTexts { get => delimitedTexts; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath">Fully qualified path to the urls text file</param>
        public FileDownloader(string filePath)
        {
            filePathToUrls = filePath;
        }

        private string LoadUrlFile(string url)
        {
            AssignFileReadMethod(url);

            return fileReadMethod(url);
        }

        public string[,] LoadAllFiles()
        {
            string currentText = LoadUrlFile(filePathToUrls);
            string[] delimitedUrls = currentText.Replace('\r', ' ').Split('\n');
            delimitedTexts = new string[delimitedUrls.Length, 2];

            ExecuteReadTxtFile(delimitedUrls);

            return delimitedTexts;
        }

        private async void ExecuteReadTxtFile(string[] delimitedUrls)
        {
            List<Task<string[]>> tasks = new List<Task<string[]>>();

            foreach (string url in delimitedUrls)
            {
                tasks.Add(ReadTxtFile(url));
            }

            Task.WaitAll(tasks.ToArray());

            int index = -1;
            foreach (Task<string[]> task in tasks)
            {
                index++;
                string[] tempArray = await task;
                delimitedTexts[index, 0] = tempArray[0];
                delimitedTexts[index, 1] = tempArray[1];
                task.Wait();
            }

        }

        private async Task<string[]> ReadTxtFile(string url)
        {
            string[] currentSplitText = new string[2];

            await Task.Run(() =>
            {
                currentSplitText = fileReadMethod(url).Split(new char[] { '\n' }, 2);
            });

            return currentSplitText;
        }

        private void AssignFileReadMethod(string url)
        {
            if (url.StartsWith("http"))
            {
                fileReadMethod = new WebClient().DownloadString;
            }
            else
            {
                fileReadMethod = File.ReadAllText;
            }
        }
    }
}
