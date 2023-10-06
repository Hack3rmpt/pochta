using HtmlRtf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
using System.IO;

namespace Prak_9_
{
    /// <summary>
    /// Логика взаимодействия для SendMessage.xaml
    /// </summary>
    public partial class SendMessage : Page
    {
        public SendMessage()
        {
            InitializeComponent();
            text_2.Text = Pochta.name;
            text_3.Text = Pochta.theme;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (text_2.Text != "" && text_3.Text != "")
            {
                var user = ImappHelper.GetCredentials();
                var range = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                HtmlRtfConverter.ToHtml(range);
                MailMessage mail = new MailMessage(user.Email, text_2.Text, text_3.Text, File.ReadAllText("send.html"));
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient(user.SmtpHost);
                smtp.Credentials = new NetworkCredential(user.Email, user.Pass);
                smtp.EnableSsl = true;
                try
                {
                    smtp.Send(mail);
                }
                catch
                {
                    MessageBox.Show("Возникла ошибка при отправки сообщения - оно не было отправлено!");
                }
                text_2.Text = string.Empty;
                text_3.Text = string.Empty;
                range.Text = string.Empty;
                Pochta.name = string.Empty;
                Pochta.theme = string.Empty;
            }
        }
    }
}
