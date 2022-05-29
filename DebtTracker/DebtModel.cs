using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtTracker
{
    public class Debt
    {
        public string Content { get; set; }
        public string FromWho { get; set; }
        public string ToWhom { get; set; }
        public string Time { get; set; }
        public Debt(string content, string from_who, string to_whom, string time)
        {
            Content = content;
            FromWho = from_who;
            ToWhom = to_whom;
            Time = time;
        }

    }
}
