using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        PhoneNumbers3DataSet phoneNumbers3DataSet = new PhoneNumbers3DataSet();
        PhoneNumbers3DataSetTableAdapters.PhoneNumbers3TableAdapter tblPhoneNumbers3Adapter = new PhoneNumbers3DataSetTableAdapters.PhoneNumbers3TableAdapter();
        Binding txtPhoneNumberBinding = new Binding();
        Binding txtSubscriberBinding = new Binding();
        Binding txtContactValueBinding = new Binding();
        Binding txtContactDateBinding = new Binding();

        public MainWindow()
        {
            InitializeComponent();

            grdMain.DataContext = phoneNumbers3DataSet.PhoneNumbers3;
            txtPhoneNumberBinding.Path = new PropertyPath("Phonenum");
            txtSubscriberBinding.Path = new PropertyPath("Subscriber");
            txtPhoneNumber.SetBinding(TextBox.TextProperty, txtPhoneNumberBinding);
            txtSubscriber.SetBinding(TextBox.TextProperty, txtSubscriberBinding);
            txtContactValue.SetBinding(TextBox.TextProperty, txtContactValueBinding);
            txtContactDate.SetBinding(TextBox.TextProperty, txtContactDateBinding);

        }
        private void lstPhonesLoad()
        {
            tblPhoneNumbers3Adapter.Fill(phoneNumbers3DataSet.PhoneNumbers3);
        }
        private void grdMain_Loaded(object sender, RoutedEventArgs e)
        {
            lstPhonesLoad();
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Close Application?", "Question", MessageBoxButton.YesNo,
           MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            PhoneNumbers3DataSet phoneNumbers3DataSet = ((PhoneNumbers3DataSet)(this.FindResource("phoneNumbers3DataSet")));
            System.Windows.Data.CollectionViewSource phoneNumbers3ViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("phoneNumbers3ViewSource")));
            phoneNumbers3ViewSource.View.MoveCurrentToFirst();
        }
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.New;
            btnNew.IsEnabled = false;
            btnEdit.IsEnabled = false;
            btnDelete.IsEnabled = false;

            btnSave.IsEnabled = true;
            btnCancel.IsEnabled = true;
            lstPhones.IsEnabled = false;
            btnPrevious.IsEnabled = false;
            btnNext.IsEnabled = false;
            txtPhoneNumber.IsEnabled = true;
            txtSubscriber.IsEnabled = true;
            txtContactValue.IsEnabled = true;
            txtContactDate.IsEnabled = true;
            BindingOperations.ClearBinding(txtPhoneNumber, TextBox.TextProperty);
            BindingOperations.ClearBinding(txtSubscriber, TextBox.TextProperty);
            BindingOperations.ClearBinding(txtContactValue,TextBox.TextProperty);
            BindingOperations.ClearBinding(txtContactDate, TextBox.TextProperty);
            txtPhoneNumber.Text = "";
            txtSubscriber.Text = "";
            txtContactValue.Text = "";
            txtContactDate.Text = "";
            Keyboard.Focus(txtPhoneNumber);
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Edit;
            string tempPhonenum = txtPhoneNumber.Text.ToString();
            string tempSubscriber = txtSubscriber.Text.ToString();
            string tempContactValue = txtContactValue.Text.ToString();
            string tempContactDate = txtContactDate.Text.ToString();
            btnNew.IsEnabled = false;
            btnEdit.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnSave.IsEnabled = true;
            btnCancel.IsEnabled = true;
            lstPhones.IsEnabled = false;
            btnPrevious.IsEnabled = false;
            btnNext.IsEnabled = false;
            txtPhoneNumber.IsEnabled = true;
            txtSubscriber.IsEnabled = true;
            txtContactValue.IsEnabled = true;
            txtContactDate.IsEnabled = true;
            BindingOperations.ClearBinding(txtPhoneNumber, TextBox.TextProperty);
            BindingOperations.ClearBinding(txtSubscriber, TextBox.TextProperty);
            BindingOperations.ClearBinding(txtContactValue, TextBox.TextProperty);
            BindingOperations.ClearBinding(txtContactDate, TextBox.TextProperty);
            txtPhoneNumber.Text = tempPhonenum;
            txtSubscriber.Text = tempSubscriber;
            txtContactValue.Text = tempContactValue;
            txtContactDate.Text = tempContactDate;
            Keyboard.Focus(txtPhoneNumber);
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Delete;
            string tempPhonenum = txtPhoneNumber.Text.ToString();
            string tempSubscriber = txtSubscriber.Text.ToString();
            string tempContactValue = txtContactValue.Text.ToString();
            string tempContactDate = txtContactDate.Text.ToString();
            btnNew.IsEnabled = false;
            btnEdit.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnSave.IsEnabled = true;
            btnCancel.IsEnabled = true;
            lstPhones.IsEnabled = false;
            btnPrevious.IsEnabled = false;
            btnNext.IsEnabled = false;
            BindingOperations.ClearBinding(txtPhoneNumber, TextBox.TextProperty);
            BindingOperations.ClearBinding(txtSubscriber, TextBox.TextProperty);
            BindingOperations.ClearBinding(txtContactValue, TextBox.TextProperty);
            BindingOperations.ClearBinding(txtContactDate, TextBox.TextProperty);
            txtPhoneNumber.Text = tempPhonenum;
            txtSubscriber.Text = tempSubscriber;
            txtContactValue.Text = tempContactValue;
            txtContactDate.Text = tempContactDate;
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Nothing;
            btnNew.IsEnabled = true;
            btnEdit.IsEnabled = true;
            btnEdit.IsEnabled = true;
            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;
            lstPhones.IsEnabled = true;
            btnPrevious.IsEnabled = true;
            btnNext.IsEnabled = true;
            txtPhoneNumber.IsEnabled = false;
            txtSubscriber.IsEnabled = false;
            txtContactValue.IsEnabled = true;
            txtContactDate.IsEnabled = true;
            btnPrevious.IsEnabled = false;
            btnNext.IsEnabled = false;
            txtPhoneNumber.SetBinding(TextBox.TextProperty, txtPhoneNumberBinding);
            txtSubscriber.SetBinding(TextBox.TextProperty, txtSubscriberBinding);
            txtContactValue.SetBinding(TextBox.TextProperty, txtContactValueBinding);
            txtContactDate.SetBinding(TextBox.TextProperty, txtContactDateBinding);
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (action == ActionState.New)
            {
                try
                {
                    DataRow newRow = phoneNumbers3DataSet.PhoneNumbers3.NewRow();
                    newRow.BeginEdit();
                    newRow["Phonenum"] = txtPhoneNumber.Text.Trim();
                    newRow["Subscriber"] = txtSubscriber.Text.Trim();
                    newRow["Contact_value"] = txtContactValue.Text.Trim();
                    newRow["Contact_date"] = txtContactDate.Text.Trim();
                    newRow.EndEdit();
                    phoneNumbers3DataSet.PhoneNumbers3.Rows.Add(newRow);
                    tblPhoneNumbers3Adapter.Update(phoneNumbers3DataSet.PhoneNumbers3);
                    phoneNumbers3DataSet.AcceptChanges();
                }
                catch (DataException ex)
                {
                    phoneNumbers3DataSet.RejectChanges();
                    MessageBox.Show(ex.Message);
                }
                btnNew.IsEnabled = true;
                btnEdit.IsEnabled = true;
                btnSave.IsEnabled = false;
                btnCancel.IsEnabled = false;
                lstPhones.IsEnabled = true;
                btnPrevious.IsEnabled = true;
                btnNext.IsEnabled = true;
                txtPhoneNumber.IsEnabled = false;
                txtSubscriber.IsEnabled = false;
                txtContactValue.IsEnabled = false;
                txtContactDate.IsEnabled = false;
            }
            else
            if (action == ActionState.Edit)
            {
                try
                {
                    DataRow editRow = phoneNumbers3DataSet.PhoneNumbers3.Rows[lstPhones.SelectedIndex];
                    editRow.BeginEdit();
                    editRow["Phonenum"] = txtPhoneNumber.Text.Trim();
                    editRow["Subscriber"] = txtSubscriber.Text.Trim();
                    editRow["Contact_value"] = txtContactValue.Text.Trim();
                    editRow["Contact_date"] = txtContactDate.Text.Trim();
                    editRow.EndEdit();
                    tblPhoneNumbers3Adapter.Update(phoneNumbers3DataSet.PhoneNumbers3);
                    phoneNumbers3DataSet.AcceptChanges();
                }
                catch (DataException ex)
                {
                    phoneNumbers3DataSet.RejectChanges();
                    MessageBox.Show(ex.Message);
                }
                btnNew.IsEnabled = true;
                btnEdit.IsEnabled = true;
                btnDelete.IsEnabled = true;
                btnSave.IsEnabled = false;
                btnCancel.IsEnabled = false;
                lstPhones.IsEnabled = true;
                btnPrevious.IsEnabled = true;
                btnNext.IsEnabled = true;
                txtPhoneNumber.IsEnabled = false;
                txtSubscriber.IsEnabled = false;
                txtContactValue.IsEnabled = false;
                txtContactDate.IsEnabled = false;
                txtPhoneNumber.SetBinding(TextBox.TextProperty, txtPhoneNumberBinding);
                txtSubscriber.SetBinding(TextBox.TextProperty, txtSubscriberBinding);
                txtContactValue.SetBinding(TextBox.TextProperty, txtContactValueBinding);
                txtContactDate.SetBinding(TextBox.TextProperty, txtContactDateBinding);
            }
            else
            if (action == ActionState.Delete)
            {
                try
                {
                    DataRow deleterow = phoneNumbers3DataSet.PhoneNumbers3.Rows[lstPhones.SelectedIndex];
                    deleterow.Delete();

                    tblPhoneNumbers3Adapter.Update(phoneNumbers3DataSet.PhoneNumbers3);
                    phoneNumbers3DataSet.AcceptChanges();
                }
                catch (DataException ex)
                {
                    phoneNumbers3DataSet.RejectChanges(); MessageBox.Show(ex.Message);
                    MessageBox.Show(ex.Message);
                }
                btnNew.IsEnabled = true;
                btnEdit.IsEnabled = true;
                btnDelete.IsEnabled = true;
                btnSave.IsEnabled = false;
                btnCancel.IsEnabled = false;
                lstPhones.IsEnabled = true;
                btnPrevious.IsEnabled = true;
                btnNext.IsEnabled = true;
                txtPhoneNumber.IsEnabled = false;
                txtSubscriber.IsEnabled = false;
                txtContactValue.IsEnabled = false;
                txtContactDate.IsEnabled = false;
                txtPhoneNumber.SetBinding(TextBox.TextProperty, txtPhoneNumberBinding);
                txtSubscriber.SetBinding(TextBox.TextProperty, txtSubscriberBinding);
                txtContactValue.SetBinding(TextBox.TextProperty, txtContactValueBinding);
                txtContactDate.SetBinding(TextBox.TextProperty, txtContactDateBinding);
            }
        }
        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            //using System.ComponentModel
            ICollectionView navigationView = CollectionViewSource.GetDefaultView(phoneNumbers3DataSet.PhoneNumbers3);
            navigationView.MoveCurrentToPrevious();
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView navigationView = CollectionViewSource.GetDefaultView(phoneNumbers3DataSet.PhoneNumbers3);
            navigationView.MoveCurrentToNext();
        }

    }
}
