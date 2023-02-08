using System.Collections.Specialized;
using System.ComponentModel.Design;

namespace Provodnik
{
    internal class Program
    {
        static DriveInfo[] AllInfo = DriveInfo.GetDrives();
        static int pos = 1;
        static string disk;

        static void Main(string[] args)
        {
            int i = 1;
            do
            {
                if (i == 1)
                {
                    Arrows Arrow = new Arrows(1, AllInfo.Length);
                    pos = Arrow.ArrowCh();
                }
                else
                {
                    int lenght = PodMenu();
                    Console.Clear();
                    Arrows Arr = new Arrows(1, lenght);
                    pos = Arr.ArrowCh();
                }
                if (pos != -1)
                {
                    i++;
                }
                else if (pos == -1 && i != 1)
                {
                    i--;
                }
                else
                {
                    Console.Clear();
                    Console.Write("Вы вышли из программы!\nВсего доброго)");
                    break;
                }
            } while (i != 0);
        }

        public static void Menu()
        {
            Console.WriteLine("Выберите диск");
            int i = 1;
            foreach (DriveInfo d in AllInfo)
            {
                Console.SetCursorPosition(3, i);
                Console.WriteLine(d.Name);
                Console.SetCursorPosition(9, i);
                Console.WriteLine("Свободных бит: {0}", d.AvailableFreeSpace);
                i++;
            }
        }

        public static int PodMenu()
        {
            string disk = Convert.ToString(AllInfo[pos].Name);
            string[] DiskInf = Directory.GetDirectories(disk);
            int i = 1;
            Console.Clear();
            foreach (string Info in DiskInf)
            {
                FileInfo Direct = new FileInfo(Info);
                Console.SetCursorPosition(3, i);
                Console.WriteLine($"{Direct.Name}   {Direct.CreationTime}");
                i++;
            }
            string[] FileInf = Directory.GetFiles(disk);
            foreach (string file in FileInf)
            {
                FileInfo fileInfo = new FileInfo(file);
                Console.SetCursorPosition(3, i);
                Console.WriteLine($"{fileInfo.Name}   {fileInfo.CreationTimeUtc}");
                i++;
            }
            return DiskInf.Length + FileInf.Length;
        }
    }
}