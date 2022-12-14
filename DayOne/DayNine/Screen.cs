using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayNine
{
    internal class Screen
    {
        public int WindowPadding;
        public int WindowHeader;
        public int WindowMapSize;
        private char EMPTY_SPACE = ' ';

        public Screen(int windowPadding = 20, int windowHeader = 3)
        {
            WindowPadding = windowPadding;
            WindowHeader = windowHeader;
            WindowMapSize = windowPadding * 2 +1;

            Console.SetWindowSize(WindowMapSize, WindowMapSize + WindowHeader);
            Console.SetBufferSize(WindowMapSize, WindowMapSize + WindowHeader);
            Console.CursorVisible = false;
        }

        public void Print(Coordinate head, Coordinate tail, string command, LinkedList<Coordinate> list)
        {
            Console.ResetColor();
            Console.SetCursorPosition(0, 0);

            var header = $"{command} {head.x}:{head.y} {tail.x}:{tail.y}";

            for(var i = 0; i < WindowMapSize; i++)
            {
                Console.Write($"=");
            }

            Console.SetCursorPosition(5, 0);
            Console.Write(header);

            Console.SetCursorPosition(0, 2);

            var knots = list.ToList();

            for (var y = knots[5].y + WindowPadding; y > knots[5].y - WindowPadding; y--)
            {
                for (var x = knots[5].x - WindowPadding; x < knots[5].x +20; x++)
                {
                    if (head.x == x && head.y == y)
                    {
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.Write("■");
                    }
                    else if (x == 0 && y == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("≡");
                    }
                    else
                    {
                        var currentNode = list.First;
                        var knotHere = 0;
                        for (var i = 1; i <= list.Count; i++)
                        {
                            if (currentNode.Value.PositionsLog.Last().Equals($"{x}:{y}"))
                            {
                                knotHere = i;
                                break;
                            }

                            currentNode = currentNode.Next;
                        }
                        if (knotHere > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            string target = "█";

                            if (knotHere == 9)
                            {

                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                target = "■";
                            }
                            else if (knotHere > 6)
                            {
                                target = "▒";
                            } else if(knotHere > 3)
                            {

                                target = "▓";
                            } 
                            Console.Write(target);
                        }
                        else if (tail.PositionsLog.Contains($"{x}:{y}"))
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("■");
                        }
                        else
                        {
                            Console.Write(EMPTY_SPACE);
                        }

                    }

                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
