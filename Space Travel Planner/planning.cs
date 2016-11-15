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
    public partial class planning : Form
    {
        public planning()
        {
            InitializeComponent();

            rbFive.Checked = true;      //Initialyzing the hotel five stars to be checked when the form is opened

            Form1 F1 = new Form1();
            Activity1 = chbActivity1;//Changing the text proprety of the activity1 based on the planet selected
            Activity2 = chbActivity2;//Changing the text proprety of the activity2 based on the planet selected
            Activity3 = chbActivity3;//Changing the text proprety of the activity3 based on the planet selected
        }

        //initialyzing value to be gotten in the first form
        private CheckBox activity1;
        private CheckBox activity2;
        private CheckBox activity3;
        private string price;
        private string tripDate;

        //initialyzing the getters and setters for values that are to be gotten
        public CheckBox Activity1{get { return activity1; }set { activity1 = value; }}
        public CheckBox Activity2{get { return activity2; }set { activity2 = value; }}
        public CheckBox Activity3{get { return activity3; }set { activity3 = value; }}
        public string Price { get { return price; } set { price = value; } }
        public string TripDate { get { return tripDate; } set { tripDate = value; } }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();    //Calling to hide the form
        }

        private void btnSave_Click(object sender, EventArgs e)
        { 

            if (rbFive.Checked)
            {   //Calling the Pricing method that calculates price, tax, and get the summary
                this.rbFive.TextChanged += new System.EventHandler(ClearValue);//Clearing the textboxes
                Caller.pricing("Five Stars Hotel", 1000.00, chbActivity1, chbActivity2, chbActivity3,
                    txtSummary, txtSubtotal, txtTax, txtFinalPrice,dtpTripDate);
            }

            if (rbThree.Checked)
            {   //Calling the Pricing method that calculates price, tax, and get the summary
                Caller.pricing("Three Stars Hotel", 500.00, chbActivity1, chbActivity2, chbActivity3,
                    txtSummary, txtSubtotal, txtTax, txtFinalPrice,dtpTripDate);
            }

            if (rbTwo.Checked)
            {   //Calling the Pricing method that calculates price, tax, and get the summary
                Caller.pricing("Two Stars Hotel", 250.00, chbActivity1, chbActivity2, chbActivity3,
                    txtSummary, txtSubtotal, txtTax, txtFinalPrice,dtpTripDate);
            }

            Price = txtFinalPrice.Text;     //Getting the value of the final price textbox
            TripDate = dtpTripDate.Value.ToString("MMMM dd, yyyy"); //Getting the value of date seleted
        }

        //Method to clear all textboxes when the radio button has been unchecked
        private void ClearValue(object sender, EventArgs e)
        {
            txtFinalPrice.Text = "";    //setting the textbox to zero
            txtSubtotal.Text = "";      //setting the textbox to zero
            txtTax.Text = "";           //setting the textbox to zero
            txtSummary.Text = "";       //setting the textbox to zero

            chbActivity1.Checked = false;    //setting the checkbox to empty
            chbActivity2.Checked = false;    //setting the checkbox to empty
            chbActivity3.Checked = false;    //setting the checkbox to empty
        }
    }
}
