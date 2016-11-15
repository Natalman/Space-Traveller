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

            Form1 f2 = new Form1();     //Accessing the form1
            TripSummary = lstSummary;   //loading trips to the summary listbox
        }

        private ListBox tripSummary;    //Initialyzing value to be gotten

        //Creating a getter and setter for it
        public ListBox TripSummary { get { return tripSummary; } set { tripSummary = value; } }

        private void TripsNPayment_Load(object sender, EventArgs e)
        {
            string[] cardType = { "Card Type", "American Express", "Visa", "Master Card" };//Array of card type
            Caller.ComboCheck(cboType, cardType);//calling the Combocheck method to load the array into the ComboBox

            //creating array of month 
            string[] Month = { "Month", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sept", "Oct", "Nov", "Dec" };
            Caller.ComboCheck(cboMonth, Month);//calling the Combocheck method to load the array into the ComboBox

            int year = DateTime.Today.Year;         //initialyzing the current year
            int endYear = year + 10;                //Adding 10 more years to it
            cboYear.Items.Add("Year");              //setting (year) as first index of th comboBox
            while (year < endYear)
            {
                cboYear.Items.Add(year);
                year++;
            }
            cboYear.SelectedIndex = 0;
        }

        //Clicking the add button will send you back to the main menu and ask you to add a trip
        private void btnAdd_Click(object sender, EventArgs e)
        {       //Sending you to main menu and ask the user to add a trip by selecting a planet
            MessageBox.Show(" you will be back to a main menu. Please select a planet to add a trip", "New Trip");
            this.Hide();    //hide the form
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Caller.DeleteTrip(lstSummary);  //Deleting the item selected in the trip summary
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstSummary.Items.Clear();       //Clearing the whole trip summary items in the listbox
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tbInfo.SelectTab(TabCustomerInfo);//this is to open the next tab
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tbInfo.SelectTab(TabTrip);      //This is to go back to the previous tab
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidData())      //Doing data validation check on controls
                {
                    lbFirst.Text = txtFirst.Text;   //Changing the label text proprety into the textbox text proprety
                    lbLast.Text = txtLast.Text;     //Changing the label text proprety into the textbox text proprety
                    lbEmail.Text = txtEmail.Text;   //Changing the label text proprety into the textbox text proprety
                    lbTel.Text = txtTel.Text;       //Changing the label text proprety into the textbox text proprety
                    lbType.Text = cboType.Text;     //Changing the label text proprety into the textbox text proprety
                    lbNumber.Text = txtNumber.Text; //Changing the label text proprety into the textbox text proprety
                    lbExpDate.Text = cboMonth.Text + "/" + cboYear.Text;//Changing the label text proprety into the textbox text proprety
                    lbCSC.Text = txtCSC.Text;

                    tbInfo.SelectTab(tabConfirmation);//Going to the next tab
                }
                
            }
            catch (FormatException)     //Handling the format exception
            {
                MessageBox.Show("ivalid Numeric Data, Please check your data", "Error Occur");
            }

            catch (OverflowException)   //Handling overflow exception
            {
                MessageBox.Show("Overflow error occurs, Please enter small values", "Error Occur");
            }

            catch (Exception ev)        //Handling all other exception that are not handled before
            {
                MessageBox.Show(ev.Message, ev.GetType().ToString());
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            tbInfo.SelectTab(TabCustomerInfo);  //Going to the previous tab
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            //Setting the label to display message to the user when button is clicked
            lbEnding.Text = " Thank you for your business with us " + txtFirst.Text + " " + txtLast.Text + "." +
                "\r\n" + " We hope to see you for the next trip." + "\r\n" + " Please Don't forget to like our App";
            tbInfo.SelectTab(tabBye);       //Moving to the next tab
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Hide();    //hiding the form
        }

        private void pcbLike_Click(object sender, EventArgs e)
        {
            pcbThanks.Visible = true;   //Showing a picture when user like page/ or pictureBox is clicked
        }

        private void pcbDislike_Click(object sender, EventArgs e)
        {       //Showing message when the user Dislikes the page/ or pictureBox is clicked
            MessageBox.Show("Thank you for your honesty. We will make it better the next time");
        }

        //checking if the user enter something
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

        //Checking if data entered by the user is a integer
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

        //Checking if the user selects a valid item from the comboBox
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

        //Checking if the user enter the valid card number
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

        //Checking for the valid CSC number by counting character
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
                IsPresent(txtFirst, "First Name") &&        //data validation on first name textbox
                IsPresent(txtLast, "Last Name") &&           //data validation on last name textbox
                IsPresent(txtEmail, "Email") &&              //data validation on email textbox
                IsSelected(cboType, "Card Type") &&         //data validation on card type ComboBox

                //Data validation on Card number textBox
                IsPresent(txtNumber, "Card Number") &&
                IsInt(txtNumber, "Card Number") &&
                IsValidCard(cboType, txtNumber, "Card Number") &&

                //Data validation on expriration date
                IsSelected(cboMonth, "Month") &&
                IsSelected(cboYear, "Year") &&

                //Data validation of CSC textbox
                IsPresent(txtCSC, "CSC") &&
                IsInt(txtCSC, "CSC") &&
                IsCount(txtCSC, "CSC", 3);
        }
    }
}
