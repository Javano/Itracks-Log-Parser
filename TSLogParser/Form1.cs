using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItracksLogParser
{
    public partial class Form1 : Form
    {
        private string START_PTRN = @"\[(\d{2}\/\d{2}\/\d{4})\s(\d{2}\:\d{2}\:\d{2}\.\d{3})\s(AM|PM)\](\[.+\])?";
        private string END_PTRN = @"\[LogId=(\w{8}-\w{4}-\w{4}-\w{4}-\w{12})\]\r";
        private TreeNode mainTest = new TreeNode("Log");
        private ImageList imageList = new ImageList();
        private TreeNode m_OldSelectNode;
        private List<string> lstItems = new List<string>();
        private List<string> serverNames = new List<string>();
        private Dictionary<string, List<string>> serverDic = new Dictionary<string, List<string>>();

        private BindingList<string> lstLogStrs = new BindingList<string>();
        public Form1()
        {
            InitializeComponent();
            serverDic.Add("iaf", new List<string>() { "iaf1", "iaf2", "iaf3", "iaf4" });
            serverDic.Add("pre", new List<string>() { "pre-iaf1" });
            serverDic.Add("pre-rack", new List<string>() { "pre-iaf3", "pre-iaf4" });
            Text = "Log Parser (Pre-Rack)";
            serverNames = serverDic["pre-rack"];
            treeView.Nodes.Add(mainTest);
            treeView.TreeViewNodeSorter = new LogNodeSorter();
            lstLogs.DataSource = lstLogStrs;
            lstLogs.ClearSelected();
            updateLogList();
            treeView.Nodes.Clear();
            treeView.Enabled = false;
            treeView.Nodes.Add("Select a log to view.");
            treeView.Update();
            pREIAF1ToolStripMenuItem.Visible = true;
            iAF1ToolStripMenuItem.Visible = true;
            switchToPreRackToolStripMenuItem.Visible = false;
        }

        private void toolLoadClip_Click(object sender, EventArgs e)
        {
            loadFromClipboard();
        }
        private void loadFromFile(string logName)
        {
            if (logName.Contains(".log"))
            {
                treeView.Nodes.Clear();
                treeView.Nodes.Add("LOADING...");
                treeView.Enabled = false;
                treeView.Update();
                Enabled = false;
                Update();
                List<List<string>> logLinesLists = new List<List<string>>();
                int counter = 0;
                foreach (string serverName in serverNames)
                {

                    string path = @"\\" + serverNames[counter] + @"\GoLogs\" + logName;
                    try
                    {
                        string input = File.ReadAllText(path);
                        if (!String.IsNullOrEmpty(input))
                        {
                            logLinesLists.Add(new List<string>(input.Split('\n')));
                            mainTest.Text = "Log (" + logName + ")";
                        }
                    }
                    catch (Exception ex)
                    {
                        logLinesLists.Add(default(List<string>));
                        Console.WriteLine("Error loading from file. Could not find " + path + " file. [" + ex.InnerException + "]");
                    }
                    counter++;
                }
                parseItems(logLinesLists);
            }
        }
        private void loadFromClipboard()
        {

        }

        private bool canLoadFromClipboard()
        {
            return false;
        }


        private void parseItems(List<List<string>> lstLogLines)
        {
            List<LogEntry> newLogs = new List<LogEntry>();

            for (int i = 0; i < serverNames.Count; i++)
            {

                Regex startRegex = new Regex(START_PTRN);
                Regex endRegex = new Regex(END_PTRN);
                Match startMatch = null;
                Match endMatch = null;
                string message = "";
                int count = 1;
                List<string> logLines = lstLogLines[i];

                while (logLines != null && logLines.Count > 0)
                {

                    string line = logLines.First();
                    logLines.RemoveAt(0);

                    if (startMatch == null || !startMatch.Success)
                    {
                        startMatch = startRegex.Match(line);
                    }
                    else if (endMatch == null || !endMatch.Success)
                    {
                        endMatch = endRegex.Match(line);
                        if (endMatch.Success)
                        {

                            DateTime timestamp = DateTime.Parse(startMatch.Groups[1].Value + " " + startMatch.Groups[2].Value + " " + startMatch.Groups[3].Value);
                            LogEntry newLogEntry = new LogEntry(timestamp, message, endMatch.Groups[1].Value, serverNames[i], new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("attribs", startMatch.Groups[4].Value) });
                            newLogs.Add(newLogEntry);

                            startMatch = null;
                            endMatch = null;
                            message = "";
                            count++;
                        }
                        else
                        {
                            message += line + "\n";
                        }
                    }
                }

            }

            treeView.Nodes.Clear();
            treeView.Nodes.AddRange(newLogs.ToArray());
            treeView.Enabled = true;
            Enabled = true;
            Update();
            lstLogs.Update();
            treeView.Update();
        }
        private void toolTraceError_Click(object sender, EventArgs e)
        {
            bool done = false;
            TreeNode node = treeView.SelectedNode;
            while (!done)
            {
                done = true;
                foreach (TreeNode child in node.Nodes)
                {
                    if (child.ForeColor == Color.Red)
                    {
                        if (child.Nodes.Count > 0)
                        {
                            node = child;
                            child.Expand();
                            done = false;
                        }
                        else
                        {

                            treeView.SelectedNode = child;
                            done = true;
                        }
                    }
                }
            }
        }

        private void toolExpandAll_Click(object sender, EventArgs e)
        {
            treeView.SelectedNode.ExpandAll();
        }

        private void treeView_MouseUp(object sender, MouseEventArgs e)
        {
            // Show menu only if the right mouse button is clicked.
            if (e.Button == MouseButtons.Right)
            {

                // Point where the mouse is clicked.
                Point p = new Point(e.X, e.Y);

                // Get the node that the user has clicked.
                TreeNode node = treeView.GetNodeAt(p);
                if (node != null)
                {

                    // Select the node the user has clicked.
                    // The node appears selected until the menu is displayed on the screen.
                    m_OldSelectNode = treeView.SelectedNode;
                    treeView.SelectedNode = node;

                    // Find the appropriate ContextMenu depending on the selected node.

                    contextNodeMenu.Show(treeView, p);


                    // Highlight the selected node.
                    treeView.SelectedNode = m_OldSelectNode;
                    m_OldSelectNode = null;
                }
            }
        }

        private void contextNodeMenu_Opening(object sender, CancelEventArgs e)
        {
            if (treeView.SelectedNode.ForeColor == Color.Red)
            {
                toolTraceError.Visible = true;
            }
            else
            {

                toolTraceError.Visible = false;
            }

            /* if (treeView.SelectedNode.Nodes.Count > 0)
             {
                 toolExpandAll.Visible = true;
             }
             else
             {

                 toolExpandAll.Visible = false;
             }*/
        }

        private void lstLogs_SelectedValueChanged(object sender, EventArgs e)
        {
            ListBox lstSender = (ListBox)sender;
            if (lstSender.SelectedIndex >= 0)
            {
                loadFromFile(lstSender.SelectedItem.ToString());
            }
        }

        private void iAF1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iAF1ToolStripMenuItem.Visible = false;
            pREIAF1ToolStripMenuItem.Visible = true;
            switchToPreRackToolStripMenuItem.Visible = true;
            serverNames = serverDic["iaf"];
            Text = "Log Parser (Production)";
            updateLogList();
        }

        private void pREIAF1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pREIAF1ToolStripMenuItem.Visible = false;
            iAF1ToolStripMenuItem.Visible = true;
            switchToPreRackToolStripMenuItem.Visible = true;
            serverNames = serverDic["pre"];
            Text = "Log Parser (Pre-Production)";
            updateLogList();
        }
        private void switchToPreRackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pREIAF1ToolStripMenuItem.Visible = true;
            iAF1ToolStripMenuItem.Visible = true;
            switchToPreRackToolStripMenuItem.Visible = false;
            serverNames = serverDic["pre-rack"];
            Text = "Log Parser (Pre-Rack)";
            updateLogList();
        }
        private void updateLogList()
        {
            lstLogStrs.Clear();
            lstLogStrs.Add("LOADING...");
            lstLogs.Enabled = false;
            lstLogs.Update();
            lstLogs.ClearSelected();
            treeView.Nodes.Clear();
            treeView.Update();
            string[] fileEntries = Directory.GetFiles(@"\\" + serverNames.First() + @"\GoLogs\", "*.log");

            lstLogStrs.Clear();
            foreach (string fileName in fileEntries)
            {
                string finalFileName = fileName;
                if (fileName.Contains("\\"))
                {
                    finalFileName = fileName.Substring(fileName.LastIndexOf('\\') + 1);
                }
                lstLogStrs.Add(finalFileName);
            }

            lstLogs.Enabled = true;

            treeView.Enabled = false;
            treeView.Nodes.Add("Select a log to view.");
            lstLogs.Update();
            lstLogs.ClearSelected();

        }


    }
}
