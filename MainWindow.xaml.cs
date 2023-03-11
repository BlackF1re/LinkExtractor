using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using HtmlAgilityPack;

namespace LinkExtractor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LinkOutput.IsReadOnly = true;
            LinkOutput.Text = "Parsed links will appear here...";
        }

        private void ExtractLinks_Click(object sender, RoutedEventArgs e)
        {
            if (UrlInput.Text != String.Empty)
            {
                LinkOutput.Clear();
                ExtractLinks(UrlInput.Text);
            }

            else
            {
                MessageBox.Show("URL is empty!", "ERROR");
                return;
            }

            void ExtractLinks(string URL)
            {
                HtmlWeb web = new();
                HtmlDocument doc = new();
                doc = web.Load(URL);
                if (doc != null) 
                { 
                    foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
                    {
                        HtmlAttribute att = link.Attributes["href"];

                        if (att.Value.Contains("a"))
                        {
                            LinkOutput.Text += $"{att.Value}\n";
                        }
                    }
                }

                else
                {
                    MessageBox.Show("URL's not received", "ERROR");
                    return;
                }
            }
        }
    }
}
