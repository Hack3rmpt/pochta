using Spire.Doc;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cb.SelectedItem != null && login.Text != "" && password.Password != "")
            {

                ImappHelper.Initialize((cb.SelectedItem as ComboBoxItem).Tag.ToString());
                try
                {
                    if (ImappHelper.Login(login.Text, password.Password))
                    {
                        Hide();
                        new Pochta().Show();
                    }
                    else MessageBox.Show("Ошибка входа!");
                }
                catch { }
            }
        }
    }
}
