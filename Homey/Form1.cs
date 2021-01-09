using Microsoft.Web.WebView2.WinForms;
using System;
using System.IO;
using System.Windows.Forms;

namespace Homey
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Resize += new System.EventHandler(this.Form_Resize);

            webView.CreationProperties = new CoreWebView2CreationProperties
            {
                BrowserExecutableFolder = Path.Combine(Environment.CurrentDirectory, @"WebView2"),
                UserDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Athom", @"Homey")
            };
            webView.Size = this.ClientSize;
            webView.Source = new Uri("https://my.homey.app");
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

        private void Form_Resize(object sender, EventArgs e)
        {
            webView.Size = this.ClientSize;
        }
    }
}
