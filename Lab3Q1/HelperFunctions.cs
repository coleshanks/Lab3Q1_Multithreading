using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.IO;


namespace Lab3Q1
{
    public class HelperFunctions
    {
        /**
         * Counts number of words, separated by spaces, in a line.
         * @param line string in which to count words
         * @param start_idx starting index to search for words
         * @return number of words in the line
         */
        public static int WordCount(ref string line, int start_idx)
        {
            // YOUR IMPLEMENTATION HERE
            int count = 0;
            int i = start_idx;

            while (i <= line.Length - 1)
            {
                //if (line[i] == ' ' || line[i] == '\n' || line[i] == '\t')
                  if (line[i] == ' ')
                        count++;
                i++;
            }

                return count;


        }



        /**
        * Reads a file to count the number of words each actor speaks.
        *
        * @param filename file to open
        * @param mutex mutex for protected access to the shared wcounts map
        * @param wcounts a shared map from character -> word count
        */
        public static void CountCharacterWords(string filename,
                                 Mutex mutex,
                                 Dictionary<string, int> wcounts)
        {

            //===============================================
            //  IMPLEMENT THIS METHOD INCLUDING THREAD SAFETY
            //===============================================

            string line;  // for storing each line read from the file
            string character = "";  // empty character to start
            System.IO.StreamReader file = new System.IO.StreamReader(filename);

            while ((line = file.ReadLine()) != null)
            {
                //=================================================
                // YOUR JOB TO ADD WORD COUNT INFORMATION TO MAP
                //=================================================

                // Is the line a dialogueLine?
                //    If yes, get the index and the character name.
                //      if index > 0 and character not empty
                //        get the word counts
                //          if the key exists, update the word counts
                //          else add a new key-value to the dictionary
                //    reset the character

                //line = file.ReadLine();
                int count = 0;

                int dialogue_index = IsDialogueLine(line, ref character);
                    if (dialogue_index >= 0)
                    {
                        if (dialogue_index > 0 && character != " ")
                        {
                        mutex.WaitOne();
                            count = WordCount(ref line, dialogue_index);
                            if (wcounts.ContainsKey(character))
                            {
                            wcounts[character] = wcounts[character] + count;
                            }
                            else
                            {
                            wcounts.Add(character, count);
                            }
                            //character =" "; reset character
                        mutex.ReleaseMutex();
                        }
                    }


            }
            //Console.WriteLine(character+wcounts[character]);

            /*foreach (KeyValuePair<string, int> pairItem in wcounts)
            {
                Console.WriteLine("Key = {0}, Value = {1}",
                    pairItem.Key, pairItem.Value);
            }*/

           // SortCharactersByWordcount(wcounts);
            // Close the file
            //file = StreamReader.Close(filename);
            file.Close();
        }



        /**
         * Checks if the line specifies a character's dialogue, returning
         * the index of the start of the dialogue.  If the
         * line specifies a new character is speaking, then extracts the
         * character's name.
         *
         * Assumptions: (doesn't have to be perfect)
         *     Line that starts with exactly two spaces has
         *       CHARACTER. <dialogue>
         *     Line that starts with exactly four spaces
         *       continues the dialogue of previous character
         *
         * @param line line to check
         * @param character extracted character name if new character,
         *        otherwise leaves character unmodified
         * @return index of start of dialogue if a dialogue line,
         *      -1 if not a dialogue line
         */
        static int IsDialogueLine(string line, ref string character)
        {

            // new character
            if (line.Length >= 3 && line[0] == ' '
                && line[1] == ' ' && line[2] != ' ')
            {
                // extract character name

                int start_idx = 2;
                int end_idx = 3;
                while (end_idx <= line.Length && line[end_idx - 1] != '.')
                {
                    ++end_idx;
                }

                // no name found
                if (end_idx >= line.Length)
                {
                    return 0;
                }

                // extract character's name
                character = line.Substring(start_idx, end_idx - start_idx - 1);
                return end_idx;
            }

            // previous character
            if (line.Length >= 5 && line[0] == ' '
                && line[1] == ' ' && line[2] == ' '
                && line[3] == ' ' && line[4] != ' ')
            {
                // continuation
                return 4;
            }

            return 0;
        }

        /**
         * Sorts characters in descending order by word count
         *
         * @param wcounts a map of character -> word count
         * @return sorted vector of {character, word count} pairs
         */
        public static List<Tuple<int, string>> SortCharactersByWordcount(Dictionary<string, int> wordcount)
        {

            // Implement sorting by word count here
            var sortedByValueList = new List<Tuple<int, string>> { };
            foreach (KeyValuePair<string,int>pairItem in wordcount.OrderByDescending(key=>key.Value))
            {
                Console.WriteLine("{0}\t{1}",pairItem.Key, pairItem.Value);
                sortedByValueList.Add(Tuple.Create(pairItem.Value, pairItem.Key));
            }

            PrintListofTuples(sortedByValueList);

            return sortedByValueList;

        }


        /**
         * Prints the List of Tuple<int, string>
         *
         * @param sortedList
         * @return Nothing
         */
        public static void PrintListofTuples(List<Tuple<int, string>> sortedList)
        {

            // Implement printing here
            Console.WriteLine("{0}", sortedList);


        }
    }
}
