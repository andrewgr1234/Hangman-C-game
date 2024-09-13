using System;
using System.Collections.Generic;
using System.Threading;

namespace Hangman_Game
{
    internal class Program
    {
        static int incorrectGuesses = 0;
        static string[] words = {
            "apple", "brave", "chase", "drift", "earth", "flame", "grape", "heart", "judge", "laugh",
            "artist", "basket", "choice", "dragon", "future", "gather", "heroic", "island", "jungle", "mother",
            "blanket", "captain", "destroy", "fearless", "history", "journey", "kingdom", "machine", "nervous", "problem",
            "ambition", "building", "creation", "disaster", "fragment", "graceful", "hospital", "imaginary", "musician", "triangle",
            "adventure", "beautiful", "discovery", "education", "fantastic", "important", "marvelous", "professor", "revolution", "telescope"
        };

        static string word = getWord();
        static int heart = 7;
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            List<char> lines = new List<char>();


            for (int i = 0; i < word.Length; i++)
            {
                lines.Add('_');
            }

            intro();
            // Console.WriteLine(word);

            while (heart > 0)
            {
                printLines(lines);
                char input = prompt();
                List<int> result = checkLetter(word, input, lines);

                if (result.Count == 0)
                {
                    heart--;
                    incorrectGuesses++;
                    if (heart <= 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nYou have " + heart + " hearts left!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nYou have " + heart + " hearts left!");
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;

                    drawHangman(incorrectGuesses);
                }
                else
                {
                    foreach (int index in result)
                    {
                        lines[index] = input;
                    }
                }

                if (checkWin(lines) == 1)
                {
                    break;
                }
            }

            if (heart > 0)
            {
                Console.Clear();
                Console.WriteLine("You win :D");
                DancingStickmanAnimation();
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("You lost :(");
                //Console.SetCursorPosition(0, 2);
                drawHangman(7);

            }
        }

        public static void intro()
        {
            Console.WriteLine("  Welcome to the Hangman game I wanted to do for some reason");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("| Its a " + word.Length + " letter word, good Luck!");
            Console.WriteLine("| " + heart + " hearts left!");
            Console.WriteLine("-------------------------------------------------------------\n");
        }

        public static char prompt()
        {
            Console.WriteLine("\nPlease enter a char:");
            char s = Console.ReadLine()[0];
            return s;
        }

        public static string getWord()
        {
            Random rnd = new Random();
            int x = rnd.Next(words.Length);
            return words[x];
        }

        public static List<int> checkLetter(string word, char x, List<char> lines)
        {
            List<int> indices = new List<int>();

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == x && lines[i] != x)
                {
                    indices.Add(i);
                }
            }

            return indices;
        }

        public static int checkWin(List<char> lines)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i] == '_')
                {
                    return -1;
                }
            }
            return 1;
        }

        public static void printLines(List<char> lines)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + " ");
            }
            Console.WriteLine();
        }

        public static void drawHangman(int stage)
        {
            Console.WriteLine();
            switch (stage)
            {
                case 1:
                    Console.WriteLine("     ____");
                    break;
                case 2:
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("     ____");
                    break;
                case 3:
                    Console.WriteLine(" ________");
                    Console.WriteLine(" |      |");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("     ____");
                    break;
                case 4:
                    Console.WriteLine(" ________");
                    Console.WriteLine(" |      |");
                    Console.WriteLine(" O      |");
                    Console.WriteLine("        |");
                    Console.WriteLine("        |");
                    Console.WriteLine("     ____");
                    break;
                case 5:
                    Console.WriteLine(" ________");
                    Console.WriteLine(" |      |");
                    Console.WriteLine(" O      |");
                    Console.WriteLine(" |      |");
                    Console.WriteLine("        |");
                    break;
                case 6:
                    Console.WriteLine(" ________");
                    Console.WriteLine(" |      |");
                    Console.WriteLine(" O      |");
                    Console.WriteLine("/|\\     |");
                    Console.WriteLine("        |");
                    break;
                case 7:
                    Console.WriteLine(" ________");
                    Console.WriteLine(" |      |");
                    Console.WriteLine(" O      |");
                    Console.WriteLine("/|\\     |");
                    Console.WriteLine("/ \\     |");
                    Console.WriteLine("        |");
                    break;
            }
            Console.WriteLine();
        }

        public static void DancingStickmanAnimation()
        {
            string[] pose1 = {
                " O ",
                "/|\\",
                "/ \\"
            };

            string[] pose2 = {
                " O ",
                "\\|/",
                "/ \\"
            };

            int delay = 300;

            Console.CursorVisible = false;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Yay I'm saved!!!");
            Console.SetCursorPosition(0, 2);

            DateTime endTime = DateTime.Now.AddSeconds(5);

            while (DateTime.Now < endTime)
            {
                Console.SetCursorPosition(0, 2);
                DrawStickman(pose1);
                Thread.Sleep(delay);
                ClearScreen();
                Console.SetCursorPosition(0, 2);
                DrawStickman(pose2);
                Thread.Sleep(delay);
                ClearScreen();
            }

            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("Game is done!");
        }

        public static void DrawStickman(string[] pose)
        {
            foreach (string line in pose)
            {
                Console.WriteLine(line);
            }
        }

        public static void ClearScreen()
        {
            Console.Clear();
            Console.WriteLine("Yay I'm saved!!!");
            Console.SetCursorPosition(0, 2);
        }
    }
}
