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
    /// Interaction logic for DebtInfoWindow.xaml
    /// </summary>
    public partial class DebtInfoWindow : Window
    {
        public Debt specifiedDebt;
        public DebtInfoWindow(Debt specific_debt)
        {
            InitializeComponent();
            specifiedDebt = specific_debt;
            loadData();
            Closing += DebtInfoWindow_Closing;
        }
        
        private void loadData()
        {
            content_tb.Text = specifiedDebt.Content;
            from_who_tb.Text = specifiedDebt.FromWho;
            to_whom_tb.Text = specifiedDebt.ToWhom;
            time_tb.Text = specifiedDebt.Time;
        }

        private void done_btn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)this.Owner).deleteDebt(specifiedDebt);
            ((MainWindow)this.Owner).Top = this.Top;
            ((MainWindow)this.Owner).Left = this.Left;
            ((MainWindow)this.Owner).Visibility = Visibility.Visible;
            this.Close();
        }

        private void DebtInfoWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (((MainWindow)this.Owner).Visibility == Visibility.Hidden)
            {
                ((MainWindow)this.Owner).Close();
            }
        }

        private void PackIcon_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ((MainWindow)this.Owner).Top = this.Top;
            ((MainWindow)this.Owner).Left = this.Left;
            ((MainWindow)this.Owner).Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
