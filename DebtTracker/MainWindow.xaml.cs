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

namespace DebtTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            loadDebts();
        }
        List<Debt> listOfDebts = new List<Debt>();
        private void loadDebts()
        {
            Debt first_debt = new Debt("100р", "Я", "ему", "завтра", false);
            Debt second_debt = new Debt("200р", "Я", "ему", "завтра", false);
            
            listOfDebts.Add(first_debt);
            listOfDebts.Add(second_debt);
            refresh_listbox();
        }
        private void refresh_listbox()
        {
            Debts_listbox.Items.Clear();
            foreach (Debt debt in listOfDebts)
            {
                Debts_listbox.Items.Add(debt.Content);
            }
        }
        public void addNewDebt(string content, string from_who, string to_whom, string time)
        {
            Debt new_debt = new Debt(content, from_who, to_whom, time, false);
            listOfDebts.Add(new_debt);
            refresh_listbox();
            
        }
        public void deleteDebt(Debt debt)
        {
            listOfDebts.Remove(debt);
            refresh_listbox();
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private bool find_debt_bool(string content)
        {
            foreach (Debt debt in listOfDebts)
            {
                if (debt.Content == content)
                {
                    return true;
                }
            }
            return false;
        }
        private Debt find_debt(string content)
        {
            foreach (Debt debt in listOfDebts)
            {
                if (debt.Content == content)
                {
                    return debt;
                }
            }
            return listOfDebts[0];
        }

        private void ListBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var item = ItemsControl.ContainerFromElement(sender as ListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
            if (item != null)
            {
                
                if (find_debt_bool(item.Content.ToString()))
                {
                    Debt selectedDebt = find_debt(item.Content.ToString());
                    DebtInfoWindow info_window = new DebtInfoWindow(selectedDebt);
                    info_window.Owner = this;
                    info_window.Top = this.Top;
                    info_window.Left = this.Left;
                    info_window.Show();
                    this.Visibility = Visibility.Hidden;
                }
            }
        }


        private void ItemCreate_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NewDebtWindow window = new NewDebtWindow();
            window.Owner = this;
            window.Show();
        }
    }
}
