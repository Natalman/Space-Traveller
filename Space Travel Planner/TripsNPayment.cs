using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Travel_Planner
{
    public partial class TripsNPayment : Form
    {
        public TripsNPayment()
        {
            InitializeComponent();

            Form1 f2 = new Form1();
            TripSummary = lstSummary;
        }

        private ListBox tripSummary;

        public ListBox TripSummary { get { return tripSummary; } set { tripSummary = value; } }

        private void TripsNPayment_Load(object sender, EventArgs e)
        {
            string[] cardType = { "Card Type", "American Express", "Visa", "Master Card" };
            Caller.ComboCheck(cboType, cardType);

            string[] Month = { "Month", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sept", "Oct", "Nov", "Dec" };
            Caller.ComboCheck(cboMonth, Month);

            int year = DateTime.Today.Year;
            int endYear = year + 10;
            cboYear.Items.Add("Year");
            while (year < endYear)
            {
                cboYear.Items.Add(year);
                year++;
            }
            cboYear.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" you will be back to a main menu. Please select a planet to add a trip", "New Trip");
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Caller.DeleteTrip(lstSummary);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstSummary.Items.Clear();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tbInfo.SelectTab(TabCustomerInfo);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tbInfo.SelectTab(TabTrip);
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidData())
                {
                    lbFirst.Text = txtFirst.Text;
                    lbLast.Text = txtLast.Text;
                    lbEmail.Text = txtEmail.Text;
                    lbTel.Text = txtTel.Text;
                    lbType.Text = cboType.Text;
                    lbNumber.Text = txtNumber.Text;
                    lbExpDate.Text = cboMonth.Text + "/" + cboYear.Text;
                    lbCSC.Text = txtCSC.Text;

                    tbInfo.SelectTab(tabConfirmation);
                }
                
            }
            catch (FormatException)
            {
                MessageBox.Show("ivalid Numeric Data, Please check your data", "Error Occur");
            }

            catch (OverflowException)
            {
                MessageBox.Show("Overflow error occurs, Please enter small values", "Error Occur");
            }

            catch (Exception ev)
            {
                MessageBox.Show(ev.Message, ev.GetType().ToString());
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            tbInfo.SelectTab(TabCustomerInfo);
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            lbEnding.Text = " Thank you for your business with us " + txtFirst.Text + " " + txtLast.Text + "." +
                "\r\n" + " We hope to see you for the next trip." + "\r\n" + " Please Don't forget to like our App";
            tbInfo.SelectTab(tabBye);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pcbLike_Click(object sender, EventArgs e)
        {
            pcbThanks.Visible = true;
        }

        private void pcbDislike_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you for your honesty. We will make it better the next time");
        }

        public bool IsPresent(TextBox text, string Name)
        {
            if (text.Text == "")
            {
                MessageBox.Show(Name + " is a required field. Please enter a data");
                text.Focus();
                return false;
            }
            return true;
        }

        public bool IsInt(TextBox text, string Name)
        {
            long num = 0;
            if (Int64.TryParse(text.Text, out num)) { return true; }

            else
            {
                MessageBox.Show(Name + "'s field requires a number like 1.");
                text.Focus();
                return false;
            }
        }

        public bool IsSelected(ComboBox select, string Name)
        {
            if (select.SelectedIndex == -1 || select.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a " + Name);
                select.Focus();
                return false;
            }
            return true;
        }

        public bool IsValidCard(ComboBox Card, TextBox number, string Name)
        {
            if (Card.SelectedIndex == 1 && number.Text.StartsWith("3") && number.Text.Length == 15) { return true; }

            if (Card.SelectedIndex == 2 && number.Text.StartsWith("4") && number.Text.Length == 16) { return true; }

            if (Card.SelectedIndex == 3 && number.Text.StartsWith("5") && number.Text.Length == 16) { return true; }
            else
            {
                MessageBox.Show( Name + " is incorrect, Please enter a valid card number");
                number.Focus();
                return false;
            }
        }

        public bool IsCount(TextBox text, string Name, int max)
        {
            if (text.Text.Length != max)
            {
                MessageBox.Show(Name + " is Incorrect, Please enter the right one");
                text.Focus();
                return false;
            }
            return true;
        }

        public bool IsValidData()
        {
            return
                IsPresent(txtFirst, "First Name") &&
                IsPresent(txtLast, "Last Name") &&
                IsPresent(txtEmail, "Email") &&
                IsSelected(cboType, "Card Type") &&

                IsPresent(txtNumber, "Card Number") &&
                IsInt(txtNumber, "Card Number") &&
                IsValidCard(cboType, txtNumber, "Card Number") &&

                IsSelected(cboMonth, "Month") &&
                IsSelected(cboYear, "Year") &&

                IsPresent(txtCSC, "CSC") &&
                IsInt(txtCSC, "CSC") &&
                IsCount(txtCSC, "CSC", 3);
        }
    }
}
