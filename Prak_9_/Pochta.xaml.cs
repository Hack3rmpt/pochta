using ImapX;
using ImapX.Collections;
using Prak_9_;
using Spire.Doc.Formatting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Prak_9_
{
    /// <summary>
    /// Логика взаимодействия для Mail.xaml
    /// </summary>
    public partial class Pochta : Window
    {
        public static Message Message;
        public static string name;
        public static string theme;
        public Pochta()
        {
            InitializeComponent();
            Read_message("INBOX");
        }
        void Read_message(string folder) => frame.Content = new read(folder);
        private void Button_Click(object sender, RoutedEventArgs e) => Read_message((sender as Button).Content.ToString());
        private void Button_Click_1(object sender, RoutedEventArgs e) => frame.Content = new SendMessage();
        private void Window_Closed(object sender, EventArgs e)
        {
            Hide();
            ImappHelper.Logout();
            new MainWindow().Show();
        }
    }
}
