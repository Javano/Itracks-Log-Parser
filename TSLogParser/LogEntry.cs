using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItracksLogParser
{
    class LogEntry : TreeNode
    {
        private DateTime timestamp;
        private string message;
        private List<KeyValuePair<string, string>> attributes = new List<KeyValuePair<string, string>>();
        private string id;

        private string server;
        
        public List<KeyValuePair<string, string>> Attributes
        {
            get
            {
                return attributes;
            }

        }
        public string  Message
        {
            get
            {
                return message;
            }
        }
        public string ID
        {
            get
            {
                return id;
            }
        }
        public string Server
        {
            get
            {
                return server;
            }
        }
        public DateTime Timestamp
        {
            get
            {
                return timestamp;
            }
        }
        public LogEntry()
        {

        }
        public LogEntry(DateTime timestamp, string message, string id , string server, List<KeyValuePair<string,string>> attributes )
        {
            this.timestamp = timestamp;
            this.message = message.Trim();
            this.attributes = attributes;
            this.id = id;
            this.server = server;

            string[] nodeStrs = message.Split('\n');
            if (nodeStrs.Length > 1) {
                foreach (string s in nodeStrs)
                {
                    if (!String.IsNullOrWhiteSpace(s))
                    {
                        Nodes.Add(s.Trim());
                       
                    }

                }
            }

            if(Nodes.Count == 1)
            {
                Nodes.Clear();
            } else
            {
        //        Nodes.Add( nodeStrs[0]);
            }
            Text = "[" + server.ToUpper() + "] [" + timestamp.ToString() + "] ";

           foreach(KeyValuePair<string,string> kv in attributes)
            {
                Text += kv.Value;
            }
                    Text += " " +nodeStrs[0];
        }

        public override bool Equals(object obj)
        {
            bool retVal = false;
            if(obj.GetType() == typeof(LogEntry))
            {
                LogEntry other = (LogEntry)obj;
                if(other.ID == this.ID)
                {
                    retVal = true;
                }
            }
            return retVal;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

    }
}
