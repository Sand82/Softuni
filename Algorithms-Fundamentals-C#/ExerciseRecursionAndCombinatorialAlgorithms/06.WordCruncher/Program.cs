using System;

namespace WordCruncher
{
    public class Program
    {
        private static string target;
        private static Dictionary<int, List<string>> wordsBiIndex;
        private static Dictionary<string, int> wordsCount;
        private static LinkedList<string> usedWords;

        public static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(", ");
            target = Console.ReadLine();

            wordsBiIndex = new Dictionary<int, List<string>>();
            wordsCount = new Dictionary<string, int>();
            usedWords = new LinkedList<string>();

            foreach (var word in words)
            {
                var index = target.IndexOf(word);

                if (index == -1)
                {
                    continue;
                }

                if (wordsCount.ContainsKey(word))
                {
                    wordsCount[word] += 1;
                    continue;
                }

                wordsCount[word] = 1;

                while (index != -1)
                {
                    if (!wordsBiIndex.ContainsKey(index))
                    {
                        wordsBiIndex[index] = new List<string>();
                    }

                    wordsBiIndex[index].Add(word);

                    index = target.IndexOf(word, index + 1);
                }                
            }

            GenSolutions(0);
        }

        private static void GenSolutions(int index)
        {

            if (index == target.Length)
            {
                Console.WriteLine(string.Join(" ", usedWords));
                return;
            }

            if (!wordsBiIndex.ContainsKey(index))
            {
                return;
            }

            foreach (var word in wordsBiIndex[index])
            {
                if (wordsCount[word] == 0)
                {
                    continue;
                }

                wordsCount[word] -= 1;
                usedWords.AddLast(word);

                GenSolutions(index + word.Length);

                wordsCount[word] += 1;
                usedWords.RemoveLast();
            }
        }
    }
}