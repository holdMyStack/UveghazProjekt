using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UveghazProjekt
{
    internal class Logger
    {
        private int maxHistory;
        private bool stitchToGroup;
        private List<int> groupLengths;
        private List<string> logs;

        public List<string> Logs { get => logs; }
        public string Output { get => string.Join("\n", logs); }

        public Logger(int maxHistory)
        {
            this.maxHistory = maxHistory;
            this.stitchToGroup = false;
            this.logs = new List<string>();
            this.groupLengths = new List<int>();
        }

        public void BeginGroup(string group)
        {
            WriteLine(group);
            stitchToGroup = true;
            groupLengths.Add(group.Length);
        }

        public void EndGroup()
        {
            if (groupLengths.Count > 0)
            {
                groupLengths.RemoveAt(groupLengths.Count - 1);
            }
        }

        public void WriteLine(string line)
        {
            if (stitchToGroup)
            {
                logs[logs.Count - 1] += " " + line;
                stitchToGroup = false;
            }
            else
            {
                logs.Add(new string(' ', groupLengths.Sum() + groupLengths.Count) + line);

                if (logs.Count > maxHistory)
                {
                    logs.RemoveAt(0);
                }
            }
        }
    }
}
