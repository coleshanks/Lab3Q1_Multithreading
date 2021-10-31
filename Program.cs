using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace Lab3Q1
{
    class Program
    {
        static void Main(string[] args)
        {
          // map and mutex for thread safety
          Mutex mutex = new Mutex();
          Dictionary<string, int> wcountsSingleThread = new Dictionary<string, int>();


          var filenames = new List<string> {
                "C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_antony_cleopatra.txt",
                "C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_hamlet.txt",
                "C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_julius_caesar.txt",
                "C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_king_lear.txt",
                "C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_macbeth.txt",
                "C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_merchant_of_venice.txt",
                "C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_midsummer_nights_dream.txt",
                "C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_much_ado.txt",
                "C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_othello.txt",
                "C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_romeo_and_juliet.txt",
                "C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/Test_String.txt",
           };

            //=============================================================
            // YOUR IMPLEMENTATION HERE TO COUNT WORDS IN SINGLE THREAD
            //=============================================================
            List<Tuple<int, string>> sortedByValueList = new List<Tuple<int, string>> { };
            /*HelperFunctions.CountCharacterWords("C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_antony_cleopatra.txt", mutex, wcountsSingleThread);
            HelperFunctions.CountCharacterWords("C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_hamlet.txt", mutex, wcountsSingleThread);
            HelperFunctions.CountCharacterWords("C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_julius_caesar.txt", mutex, wcountsSingleThread);
            HelperFunctions.CountCharacterWords("C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_king_lear.txt", mutex, wcountsSingleThread);
            HelperFunctions.CountCharacterWords("C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_macbeth.txt", mutex, wcountsSingleThread);
            HelperFunctions.CountCharacterWords("C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_merchant_of_venice.txt", mutex, wcountsSingleThread);
            HelperFunctions.CountCharacterWords("C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_midsummer_nights_dream.txt", mutex, wcountsSingleThread);
            HelperFunctions.CountCharacterWords("C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_much_ado.txt", mutex, wcountsSingleThread);
            HelperFunctions.CountCharacterWords("C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_othello.txt", mutex, wcountsSingleThread);
            HelperFunctions.CountCharacterWords("C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_romeo_and_juliet.txt", mutex, wcountsSingleThread);
            
            sortedByValueList = HelperFunctions.SortCharactersByWordcount(wcountsSingleThread);
            HelperFunctions.PrintListofTuples(sortedByValueList);



            Console.WriteLine( "SingleThread is Done!\n\n");*/
            //=============================================================
            // YOUR IMPLEMENTATION HERE TO COUNT WORDS IN MULTIPLE THREADS
            //=============================================================

            Thread Thread1 = new Thread(() => HelperFunctions.CountCharacterWords("C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_antony_cleopatra.txt", mutex, wcountsSingleThread));
            Thread Thread2 = new Thread(() => HelperFunctions.CountCharacterWords("C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_hamlet.txt", mutex, wcountsSingleThread));
            Thread Thread3 = new Thread(() => HelperFunctions.CountCharacterWords("C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_julius_caesar.txt", mutex, wcountsSingleThread));
            Thread Thread4 = new Thread(() => HelperFunctions.CountCharacterWords("C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_king_lear.txt", mutex, wcountsSingleThread));
            Thread Thread5 = new Thread(() => HelperFunctions.CountCharacterWords("C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_macbeth.txt", mutex, wcountsSingleThread));
            Thread Thread6 = new Thread(() => HelperFunctions.CountCharacterWords("C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_merchant_of_venice.txt", mutex, wcountsSingleThread));
            Thread Thread7 = new Thread(() => HelperFunctions.CountCharacterWords("C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_midsummer_nights_dream.txt", mutex, wcountsSingleThread));
            Thread Thread8 = new Thread(() => HelperFunctions.CountCharacterWords("C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_much_ado.txt", mutex, wcountsSingleThread));
            Thread Thread9 = new Thread(() => HelperFunctions.CountCharacterWords("C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_othello.txt", mutex, wcountsSingleThread));
            Thread Thread10 = new Thread(() => HelperFunctions.CountCharacterWords("C:/Users/cshan/Desktop/Lab3_Final/lab3-main/Lab3Q1/bin/data/shakespeare_romeo_and_juliet.txt", mutex, wcountsSingleThread));

            Thread1.Start();
            Thread2.Start();
            Thread3.Start();
            Thread4.Start();
            Thread5.Start();
            Thread6.Start();
            Thread7.Start();
            Thread8.Start();
            Thread9.Start();
            Thread10.Start();

            Thread1.Join();
            Thread2.Join();
            Thread3.Join();
            Thread4.Join();
            Thread5.Join();
            Thread6.Join();
            Thread7.Join();
            Thread8.Join();
            Thread9.Join();
            Thread10.Join();

            sortedByValueList = HelperFunctions.SortCharactersByWordcount(wcountsSingleThread);
            HelperFunctions.PrintListofTuples(sortedByValueList);




            Console.WriteLine( "MultiThread is Done!");
           //return 0;
        }
    }
}
