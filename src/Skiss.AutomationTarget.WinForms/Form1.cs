using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skiss.AutomationTarget.WinForms
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

        private void invoke_Click(object sender, EventArgs e)
        {
            results.Text = (int.Parse(firstOperand.Text) + int.Parse(secondOperand.Text)).ToString();
        }
    }
}
