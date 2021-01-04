using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Irsaliye
{
    public partial class FormGoruntuleyici : Form
    {
        public FormGoruntuleyici(string documentText)
        {
            InitializeComponent();
            webBrowser1.DocumentText = documentText;
        }

        private void FormGoruntuleyici_Load(object sender, EventArgs e)
        {

        }
    }
}
