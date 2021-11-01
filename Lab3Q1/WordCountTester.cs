using System;
using System.Collections.Generic;
namespace Lab3Q1
{
    public class WordCountTester
    {
        //static int Main()
        static void Main()
        {
            try
            {


                //=================================================
                // Implement your tests here. Check all the edge case scenarios.
                // Create a large list which iterates over WCTester
                //=================================================

                string test1 = "There was a brown dog who jumped over the black cat";
                int startIdx1 = 0;
                int expectedResults1 = 10;

                string test2 = "There was a brown dog who jumped over the black cat";
                int startIdx2 = 7;
                int expectedResults2 = 3;

                string test3 = "There was a   brown dog who jumped over the black cat";
                int startIdx3 = 0;
                int expectedResults3 = 10;

                string test4 = "     There was a brown dog who jumped over the black cat";
                int startIdx4 = 0;
                int expectedResults4 = 10;

                string test5 = "There was a brown dog who jumped over the black cat";
                int startIdx5 = 9;
                int expectedResults5 = 1;

                WCTester(test1, startIdx1, expectedResults1);
                WCTester(test2, startIdx2, expectedResults2);
                WCTester(test3, startIdx3, expectedResults3);
                WCTester(test4, startIdx4, expectedResults4);
                WCTester(test5, startIdx5, expectedResults5);

            }
            catch (UnitTestException e)
            {
                Console.WriteLine(e);
            }

        }


        /**
         * Tests word_count for the given line and starting index
         * @param line line in which to search for words
         * @param start_idx starting index in line to search for words
         * @param expected expected answer
         * @throws UnitTestException if the test fails
         */
        static void WCTester(string line, int start_idx, int expected)
        {

            //=================================================
            // Implement: comparison between the expected and
            // the actual word counter results
            //=================================================
            int result = 0;
            result = HelperFunctions.WordCount(ref line, start_idx);

            if (result != expected)
            {
                throw new Lab3Q1.UnitTestException(ref line, start_idx, result, expected, String.Format("\nUnitTestFailed: result:{0} expected:{1}, line: {2} starting from index {3}\n", result, expected, line, start_idx));
            }

        }
    }
}
