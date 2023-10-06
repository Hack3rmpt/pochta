using ImapX.Collections;
using ImapX;
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

namespace Prak_9_
{
    /// <summary>
    /// Логика взаимодействия для read.xaml
    /// </summary>
    public partial class read : Page
    {
        MessageCollection messages { get; set; }
        List<string> themes { get; set; } = new List<string>();
        public read(string folders)
        {
            InitializeComponent();
            download(folders);
        }
        async Task download(string folder)
        {
            pb.Visibility = Visibility.Visible;
            lb.Visibility = Visibility.Hidden;
            await Task.Run(() =>
            {
                messages = ImappHelper.GetMessagesForFolder(folder);
            });
            if (messages == null)
                return;
            pb.Visibility = Visibility.Hidden;
            lb.Visibility = Visibility.Visible;
            themes.Clear();
            lb.Items.Clear();
            foreach (Message message in messages)
            {
                if (message.Subject == null)
                    themes.Add("<Без темы>");
                else
                    themes.Add(message.Subject.ToString());
            }
            lb.ItemsSource = themes;
        }

        private void lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pochta.Message = messages[lb.SelectedIndex];
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("ReadMessage.xaml", UriKind.Relative));
        }
    }
}
