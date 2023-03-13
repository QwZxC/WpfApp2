using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Log.xaml
    /// </summary>
    public partial class Log : Window
    {
        public Log()
        {
            InitializeComponent();

            using(var db = new Entities())
            {
                Singletone.CurrentUser.Jurnal.ToList().ForEach(j => groups.Items.Add(j.Group1));
            }
        }

        private void filterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // очищаем листбокс
            groups.Items.Clear();
            // заполняем листбокс группами, которые подходят по условию
            using (var db = new Entities())
            {
                Singletone.CurrentUser.Jurnal.ToList().ForEach(j => 
                {
                    if (j.Group1.Code.Contains(filterTextBox.Text))
                        groups.Items.Add(j.Group1);
                });
            }
        }

        private void groups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            diciplinies.Items.Clear();
            using (var db = new Entities())
            {
                Singletone.CurrentUser.Jurnal
                    .Where(j => j.Group1 == groups.SelectedItem)
                    .ToList().ForEach(j => diciplinies.Items.Add(j.Discipline1));
            }
        }
    }
}
 