using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Automation.Text;

namespace BrawlhallaReader
{
    public class Class1
    {
        private void dostuff()
        {
            Process proc = Process.GetProcessesByName("Brawlhalla").FirstOrDefault();
            if (proc == null)
                return;

            AutomationElement element = AutomationElement.FromHandle(proc.MainWindowHandle);
            AutomationElementCollection elements = null;
            bool check = true;
            int count = 0;
            do
            {
                elements = element.FindAll(TreeScope.Descendants, Condition.TrueCondition);
                if (elements != null)
                {
                    if (elements.Count > 0)
                    {
                        check = false;
                    }
                }
                if (check)
                {
                    if (count > 100) // > 100 sec
                    {
                        return;
                    }
                    System.Threading.Thread.Sleep(1000);
                    count++;
                }
            } while (check);

            List<string> strings = new List<string>();

            foreach (AutomationElement item in elements)
            {
                strings.Add(item.Current.Name);

                Console.WriteLine(item.Current.Name);
            }

            Console.ReadKey();
        }
    }
}
