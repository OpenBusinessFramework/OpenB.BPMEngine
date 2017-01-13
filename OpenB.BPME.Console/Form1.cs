using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenB.BPM.Core;

namespace OpenB.BPME.Console
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ProcessService processService = ProcessService.GetInstance();

            IList<ProcessDefinition> availableDefinitions = processService.GetActiveProcessDefinitions();

            var configurationTreeNode = configurationTreeView.Nodes.Add("Configuration");

            foreach (var definition in availableDefinitions)
            {
                TreeNode definitionNode = configurationTreeNode.Nodes.Add(definition.Key, definition.Name);
            }
        }
    }
}
