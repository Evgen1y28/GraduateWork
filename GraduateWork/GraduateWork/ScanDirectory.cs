using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GraduateWork
{
    public class ScanDirectory
    {
        public IEnumerable<string> ScanFolders(string path)
        {
            string[] dir = new string[0];

            try
            {
                dir = Directory.GetDirectories(path);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            yield return $"{path}";
            foreach (string sDir in dir)
            {
                foreach (string subDir in ScanFolders(sDir))
                {
                    yield return subDir;
                }
            }
        }

        public static EventWaitHandle wait = new EventWaitHandle(false, EventResetMode.ManualReset);

        public static void PathView(object wayOut)
        {
            string path = wayOut as string;
            ScanDirectory finder = new ScanDirectory();

            foreach (string dir in finder.ScanFolders(path))
            {
                wait.WaitOne();
                Console.WriteLine(dir);
                Thread.Sleep(15);
            }

        }
    }
}
