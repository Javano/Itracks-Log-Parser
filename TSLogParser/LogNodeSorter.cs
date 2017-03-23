using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItracksLogParser
{
    class LogNodeSorter : IComparer
        {
        public int Compare(object x, object y)
        {


            if (x is LogEntry && y is LogEntry)
            {

                LogEntry lx = (LogEntry)x;
                LogEntry ly = (LogEntry)y;

                if (lx.Timestamp < ly.Timestamp)
                {
                    return 1;
                }

                if (lx.Timestamp > ly.Timestamp)
                {
                    return -1;
                }
            }
            else if (x is TreeNode && y is TreeNode)
            {

                TreeNode nx = (TreeNode)x;
                TreeNode ny = (TreeNode)y;

                if (nx.Index < ny.Index)
                {
                    return -1;
                }
                if (nx.Index > ny.Index)
                {
                    return 1;
                }
            }
            return 0;
        }
     }
}
