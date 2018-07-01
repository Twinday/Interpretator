using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InputForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InputText.Text = "3 + 4 * 5";
        }

        private void buttonCompute_Click(object sender, EventArgs e)
        {
            string str = InputText.Text;
            string s = str.Replace(" ", "");
            Logics.Tree pt = new Logics.Tree();
            try
            {
                if (!CheckOpenBrackets(s))
                    throw new Exception();
                pt.Parse(s);
                int result = pt.Compilation();
                MessageBox.Show(result.ToString(), "Result");
            }
            catch
            {
                MessageBox.Show("Строка имела неверный формат", "Error");
            }
        }

        public bool CheckOpenBrackets(string text)
        {
            int OpenBracket = 0;
            int CloseBracket = 0;
            for(int i = 0; i < text.Length; i++)
            {
                if (text[i] == '(')
                    OpenBracket++;
                else if (text[i] == ')')
                    CloseBracket++;
            }
            if (OpenBracket == CloseBracket)
                return true;
            else
                return false;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
