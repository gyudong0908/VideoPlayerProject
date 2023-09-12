using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 유튜브프로젝트
{
    public partial class UrlInputForm : Form
    {
        private string url;
        public UrlInputForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.url = textBox1.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }
        public string getUrl()
        {
            return url;
        }
    }
}
