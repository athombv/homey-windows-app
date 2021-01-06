using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homey
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Resize += new System.EventHandler(this.Form_Resize);
            webView.Size = this.ClientSize;
            webView.CoreWebView2Ready += WebView_CoreWebView2Ready;
        }

        private void WebView_CoreWebView2Ready(object sender, EventArgs e)
        {
            webView.CoreWebView2.DocumentTitleChanged += CoreWebView2_DocumentTitleChanged;
        }

        private void CoreWebView2_DocumentTitleChanged(object sender, object e)
        {
            this.Text = webView.CoreWebView2.DocumentTitle;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form_Resize(object sender, EventArgs e)
        {
            webView.Size = this.ClientSize;
        }

        private void webView_Click(object sender, EventArgs e)
        {

        }
    }
}
