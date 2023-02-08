using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provodnik
{
    internal class Arrows
    {
        static int min, max;
        static Program Prog = new Program();

        public Arrows(int minimum, int maximum)
        {
            min = minimum;
            max = maximum;
        }
        public Arrows()
        {

        }

        public int ArrowCh()
        {
            int pos = min;
            ConsoleKey Tap;
            do
            {
                Tap = Console.ReadKey().Key;
                Console.Clear();
                if (max == 2)
                {
                    Program.Menu();
                }
                else
                {
                    Program.PodMenu();
                }
                switch (Tap)
                {
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.UpArrow:
                        pos++;
                        if (pos > max)
                        {
                            pos = min;
                        }
                        Console.SetCursorPosition(0, pos);
                        Console.WriteLine("-->"); break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.RightArrow:
                        pos--;
                        if (pos == 0)
                        {
                            pos = max;
                        }
                        Console.SetCursorPosition(0, pos);
                        Console.WriteLine("-->"); break;
                    default: break;
                }
                if (Tap == ConsoleKey.Enter)
                {
                    return pos - 1;
                }
            } while (Tap != ConsoleKey.Escape);
            return -1;
        }
    }
}
