using HtmlRtf;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Prak_9_
{
    /// <summary>
    /// Логика взаимодействия для ReadMessage.xaml
    /// </summary>
    public partial class ReadMessage : Page
    {
        public ReadMessage()
        {
            InitializeComponent();
            text_2.Text = Pochta.Message.From.DisplayName;
            if (Pochta.Message.To[0].Address.ToString().Length > 0)
                text_1.Text = Pochta.Message.To[0].Address.ToString();
            string them = string.Empty;
            if (Pochta.Message.Subject == null)
                text_3.Text = "<Без темы>";
            else
            {
                foreach (var s in Pochta.Message.Subject)
                {
                    them += s;
                    if (them.Count() == 47)
                    {
                        them += "...";
                        break;
                    }
                }
                text_3.Text = them;
            }
            try
            {
                string a = Pochta.Message.Body.Html;
                HtmlRtfConverter.ToRtf(a);
                var text = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                FileStream fs = new FileStream("msg.rtf", FileMode.Open);
                text.Load(fs, DataFormats.Rtf);
                fs.Close();
                File.Delete("msg.rtf");
            }
            catch { }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Pochta.name = text_1.Text;
            Pochta.theme = text_3.Text;
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("SendMessage.xaml", UriKind.Relative));
        }
    }
}
