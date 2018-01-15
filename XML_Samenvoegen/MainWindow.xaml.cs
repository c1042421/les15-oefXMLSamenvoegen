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

namespace XML_Samenvoegen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<String> BookXMLList = new List<String>();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnMerge_Click(object sender, RoutedEventArgs e)
        {

            string book2Pad = Environment.CurrentDirectory + @"\xmlbooks2.xml";
            string book1Pad = Environment.CurrentDirectory + @"\xmlbooks1.xml";

            XmlDocument document1 = new XmlDocument();
            XmlDocument document2 = new XmlDocument();

            document1.Load(book1Pad);
            document2.Load(book2Pad);

            XmlNode books = document1.ChildNodes[1];

            int amountOfBooks = books.ChildNodes.Count;

            for (int i = 0; i < amountOfBooks; i++)
            {
                XmlNode book = books.ChildNodes[i];

                XmlNode doc1Node = document1.ImportNode(book, true);

                document1.DocumentElement.AppendChild(doc1Node);
            }

            document1.Save("allxmlbooks.xml");

            wbXML.Navigate(Environment.CurrentDirectory + @"\allxmlbooks.xml");
        }

    }
}
