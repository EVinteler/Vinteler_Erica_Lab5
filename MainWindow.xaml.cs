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

namespace Vinteler_Erica_Lab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
     enum ActionState
     {
         New,
         Edit,
         Delete,
         Nothing
     }
public partial class MainWindow : Window
    {

        ActionState action = ActionState.Nothing;
        PhoneNumbersDataSet phoneNumbersDataSet = new PhoneNumbersDataSet();
        PhoneNumbersDataSetTableAdapters.PhoneNumbersTableAdapter tblPhoneNumbersAdapter = new PhoneNumbersDataSetTableAdapters.PhoneNumbersTableAdapter();
        Binding txtPhoneNumberBinding = new Binding();
        Binding txtSubscriberBinding = new Binding();

        public MainWindow()
        {
            InitializeComponent();

            grdMain.DataContext = phoneNumbersDataSet.PhoneNumbers;
            txtPhoneNumberBinding.Path = new PropertyPath("Phonenum");
            txtSubscriberBinding.Path = new PropertyPath("Subscriber");
            txtPhoneNumber.SetBinding(TextBox.TextProperty, txtPhoneNumberBinding);
            txtSubscriber.SetBinding(TextBox.TextProperty, txtSubscriberBinding);

        }
        private void lstPhonesLoad()
        {
            tblPhoneNumbersAdapter.Fill(phoneNumbersDataSet.PhoneNumbers);
        }
    }
}
