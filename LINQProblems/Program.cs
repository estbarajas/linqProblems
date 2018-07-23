using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            List<string> words = new List<string>() { "the", "bike", "this", "it", "tenth", "mathematics" };
            List<string> names = new List<string>() { "Mike", "Dan", "Scott", "Nick", "Mike" };
            List<string> classGrades = new List<string>()
            {
                "80,100,92,89,65","93,81,78,84,69","73,88,83,99,64","98,100,66,74,55"
            };

            //program.FindPhraseInString(words, "th");
            //program.CreateNonDuplicateNamesList(names);
            //program.CreateAlphabeticalStringFrequency("terrill");
            //
            program.FindingAverageGrades(classGrades);

            Console.ReadLine();
        }
        public void FindPhraseInString(List<string> words, string phrase)
        {
            var resultList = words.Where(w => w.Contains(phrase));
            foreach (string result in resultList)
            {
                Console.WriteLine(result);
            }
        }
        public void CreateNonDuplicateNamesList(List<string> names)
        {
            List<string> resultList = names.Distinct().ToList();
            foreach (string result in resultList)
            {
                Console.WriteLine(result);
            }
        }
        public void CreateAlphabeticalStringFrequency(String theString)
        {
            var counts = theString.ToUpper().GroupBy(c => c).OrderBy(c => c.Key).ToDictionary(grp => grp.Key, grp => grp.Count());
            string finalString = "";
            var counts2 = counts.OrderBy(c => c.Key);
            foreach (KeyValuePair<char, int> compression in counts2)
            {
                finalString += compression.Key.ToString() + compression.Value;
            }
            Console.WriteLine(finalString);
        }
        public void FindingAverageGrades(List<string> passedGrades)
        {
            var overallAverage = passedGrades.Select(grades => grades.Split(',')).Select(grades => Array.ConvertAll(grades, double.Parse)).Select(grades => (grades.Sum() - grades.Min()) / (grades.Count() - 1)).Average();
            Console.WriteLine(overallAverage);
        }
    }
}
