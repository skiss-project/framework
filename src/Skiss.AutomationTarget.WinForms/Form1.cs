namespace Skiss.AutomationTarget.WinForms
{
    using System;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InvokeClick(object sender, EventArgs e)
        {
            results.Text = (int.Parse(firstOperand.Text) + int.Parse(secondOperand.Text)).ToString();
        }
    }
}
