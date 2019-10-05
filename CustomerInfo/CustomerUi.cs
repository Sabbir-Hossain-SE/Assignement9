using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomerInfo.Manager;
using CustomerInfo.Model;
using System.Text.RegularExpressions;

namespace CustomerInfo
{
    public partial class CustomerUi : Form
    {
        CustomerManager _customerManager = new CustomerManager();
        public CustomerUi()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Customer customer= new Customer();
            string name = nameTextBox.Text, phone = phoneTextBox.Text, address = addressTextBox.Text, code = codeTextBox.Text, district = districtComboBox.Text;
            int districtId = Convert.ToInt32(districtComboBox.SelectedValue);
            bool flagCode = Regex.IsMatch(code, "[0-9a-bA-B]{4,4}$"), flagPhone = Regex.IsMatch(phone, "[0-9]{11,11}$");
            if (name.Length == 0 || phone.Length == 0 || address.Length == 0 || code.Length == 0 || district.Length == 0 || flagCode == false || flagPhone == false)
            {
                if (name.Length == 0)
                {
                    nameLabel.Text = "*Please input the name field.";
                }
                else
                {
                    nameLabel.Text = "";
                }
                if (phone.Length == 0)
                {
                    phoneLabel.Text = "*Please input the contact field, use number only. (Unique)";

                }
                else
                {
                    if (flagPhone == false && phone.Length != 0)
                    {
                        phoneLabel.Text = "*Input incorrect syntax, use number only & use just 11 digits.";

                    }
                    else
                    {
                        phoneLabel.Text = "";
                    }
                }

                //if (districtComboBox.SelectedText == "-select-")
                //{
                //    codeLabel.Text = "*Please choose the option";
                //}
                //else
                //{
                //    codeLabel.Text = "";
                //}

                if (code.Length == 0)
                {
                    codeLabel.Text = "*Please input the Quantity field, use number&Alphabat only. Maximum length 4";
                }
                else
                {
                    codeLabel.Text = "";
                    if (flagCode == false )
                    {
                        codeLabel.Text = "*Input incorrect syntax, use number&Alphabat only.Maximum length 4";
                    }
                    else
                    {
                        codeLabel.Text = "";
                    }
                }

            }
            else
            {
                customer.Name = name;
                customer.Code = code;
                customer.Address = address;
                customer.Phone = phone;
                customer.DistrictId = districtId;
                //Unique
                if (_customerManager.IsCodeExist(customer))
                {
                    MessageBox.Show(codeTextBox.Text + " Already Exist!!");
                    return;
                }
                if (_customerManager.IsPhoneExist(customer))
                {
                    MessageBox.Show(phoneTextBox.Text + " Already Exist!!");
                    return;
                }

                //Add/Insert
                if (_customerManager.Save(customer))
                {
                    MessageBox.Show("Saved");
                    saveButton.Text = "Save";
                }
                else
                {
                    MessageBox.Show("Not Saved");
                }
                nameTextBox.Text = phoneTextBox.Text = addressTextBox.Text = codeTextBox.Text = "";
            }
            //showDataGridView.DataSource = dataTable;
           dataGridView.DataSource = _customerManager.Display();

        }

        private void CustomerUi_Load(object sender, EventArgs e)
        {
           
            districtComboBox.SelectedText = "-select-";
          
            dataGridView.DataSource = _customerManager.Display();
        }
        private void districtComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            districtComboBox.DataSource = _customerManager.DistrictCombo();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(codeTextBox.Text))
            {
                dataGridView.DataSource = _customerManager.Search(codeTextBox.Text,1);
            }
            else if (!String.IsNullOrEmpty(phoneTextBox.Text))
            {
                dataGridView.DataSource = _customerManager.Search(phoneTextBox.Text, 2);
            }

        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                saveButton.Text = "Update";
                dataGridView.CurrentRow.Selected = true;
                codeTextBox.Text = dataGridView.Rows[e.RowIndex].Cells["CustomerCode"].FormattedValue.ToString();
                nameTextBox.Text = dataGridView.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
                addressTextBox.Text = dataGridView.Rows[e.RowIndex].Cells["Address"].FormattedValue.ToString();
                phoneTextBox.Text = dataGridView.Rows[e.RowIndex].Cells["Contact"].FormattedValue.ToString();
                districtComboBox.Text = dataGridView.Rows[e.RowIndex].Cells["District"].FormattedValue.ToString();



            }

        }
    }
}
