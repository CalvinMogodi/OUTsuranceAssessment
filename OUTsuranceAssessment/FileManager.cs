using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUTsuranceAssessment
{
    public class FileManager
    {
        #region Members

        #region Constructors
        /// <summary>
        /// Initializes the instance
        /// </summary>
        public FileManager() {
        }
        #endregion

        #region Methods

        /// <summary>
        /// Read CSV and write to a text file
        /// </summary>
        public bool ReadCSVAndWriteTextFile()
        {
            bool isComplete = false;
            string filePath = @"C:\Users\Admin\Downloads\data.csv";
            try
            {
                // Read from a csv file and skip header
                using (var reader = new StreamReader(filePath))
                {
                    List<string> firstList = new List<string>();
                    List<string> secondList = new List<string>();
                    bool isHeader = true;

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (!isHeader)
                        {
                            var values = line.Split(',');
                            firstList.Add(values[0]);
                            firstList.Add(values[1]);
                            secondList.Add(values[2]);
                        }
                        isHeader = false;
                    }

                    // Order names by frequency descending and then alphabetically ascending.
                    List<string> orderedNames = firstList.GroupBy(s => s).Select(g => new { Name = g.Key, Frequency = g.Count() }).OrderByDescending(c => c.Frequency).ThenBy(c => c.Name).Select( c =>  (string) string.Format("{0}, {1}", c.Name, c.Frequency.ToString())).ToList();
                    
                    // Write to the first file
                    string firstFilePath = @"C:\Users\Admin\Downloads\First File.txt";
                    WriteToTextFile(firstFilePath, orderedNames);

                    // order list and write to the first file
                    string secondFilePath = @"C:\Users\Admin\Downloads\Second File.txt";
                    List<string> orderedAddresses = SortListAlphabetically(secondList);
                    WriteToTextFile(secondFilePath, orderedAddresses);
                    isComplete = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred: " + ex.Message);
            }
            return isComplete;
        }

        /// <summary>
        /// Write data to a text file
        /// </summary>
        /// <param name="filePathAndName"></param>
        /// <param name="lines"></param>
        /// <returns>pass or fail</returns>
        public bool WriteToTextFile(string filePathAndName, List<string> lines)
        {

            bool isDone = false;
            try
            {
                File.WriteAllLines(filePathAndName, lines);
                isDone = true;
                return isDone;
            }
            catch (Exception ex)
            {
                return isDone;
                throw;
            }
        }

        /// <summary>
        /// Sort the list alphabetically. This will affect the performance if the list is longer
        /// </summary>
        /// <param name="unSortedList"></param>
        /// <returns>List<string></returns>
        public List<string> SortListAlphabetically(List<string> unSortedList) {

            List<SortItem> listToSort = new List<SortItem>();
            List<string> sortedList = new List<string>();

            foreach (var item in unSortedList)
            {
                foreach (char character in item)
                {
                    if (Char.IsLetter(character))
                    {
                        var result = item.Substring(item.IndexOf(character));
                        SortItem Sort = new SortItem() { Character = result, Index = unSortedList.IndexOf(item) };
                        listToSort.Add(Sort);
                        break;
                    }
                }
            }

            var addresses = listToSort.OrderBy(a => a.Character);

            // get the ordinal string by position
            foreach (var item in addresses)
            {
                sortedList.Add(unSortedList.ElementAt(item.Index));
            }

            return sortedList;
        }
        #endregion
        #endregion
    }
}
