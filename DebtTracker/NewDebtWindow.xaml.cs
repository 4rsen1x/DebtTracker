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
using System.Windows.Shapes;

namespace DebtTracker
{
    /// <summary>
    /// Interaction logic for NewDebtWindow.xaml
    /// </summary>
    public partial class NewDebtWindow : Window
    {
        public NewDebtWindow()
        {
            InitializeComponent();
        }

        private void create_debt_button_Click(object sender, RoutedEventArgs e)
        {
            string content = content_tb.Text;
            string from_who = from_who_tb.Text;
            string to_whom = to_whom_tb.Text;
            string time = time_tb.Text;
            ((MainWindow)this.Owner).addNewDebt(content, from_who, to_whom, time);
            this.Close();
        }
    }
}
