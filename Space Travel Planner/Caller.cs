using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Travel_Planner
{
    class Caller
    {
        //Method to load array items as checkbox name by setting the array indexes into text propreties of checkboxes
        public static void boxChecker(string[] Activities, CheckBox Activity1, CheckBox Activity2, CheckBox Activity3)
        {
            Activity1.Text = Activities[0]; //change the checkbox to use the first index of the array called
            Activity2.Text = Activities[1]; //change the checkbox to use the second index of the array called
            Activity3.Text = Activities[2]; //change the checkbox to use the third index of the array called
        }

        //Method that calculates the trip expenses
        public static void pricing(string Hotel, double price, CheckBox Act1,CheckBox Act2, CheckBox Act3,
            TextBox summary, TextBox Subtotal, TextBox Tax, TextBox STotal, DateTimePicker TripDate)
        {
            List<string> Summary = new List<string>();      //Creating an arraylist of summary of the activities
            Summary.Add("Trip Date: " + TripDate.Value.ToString("MMMM dd, yyyy"));//Adding date as first element of the arraylist
            Summary.Add("Hotel: " + Hotel);    //Adding the name of the main course to the summary list
            Summary.Add("******** Activities **********");
            string Printing = "";

            if (Act1.Checked)
            {
                price += 100;          //Doing calculation when the checkbox is checked
                Summary.Add(Convert.ToString(Act1.Text));//adding the item to the ArrayList
            }

            if (Act2.Checked)
            {
                price += 100;          //Doing calculation when the checkbox is checked
                Summary.Add(Convert.ToString(Act2.Text));//adding the item to the ArrayList
            }

            if (Act3.Checked)
            {
                price += 0.75;          //Doing calculation when the checkbox is checked
                Summary.Add(Convert.ToString(Act3.Text));//adding the item to the ArrayList
            }

            double tax = (price * 7.75) / 100;//Calculating tax
            double Total = tax + price;         //Calculating total

            Subtotal.Text = String.Format("{0:c}", price);  //sending the subtotal to its textbox
            Tax.Text = String.Format("{0:c}", tax);         //Sending the Tax to its textbox
            STotal.Text = String.Format("{0:c}", Total);    //Sending the the Total to it textbox

            Summary.Add("********** Pricing ************");
            Summary.Add("Price: " + Convert.ToString(Subtotal.Text));//Converting the price into currency type 
            Summary.Add("Tax: " + Convert.ToString(Tax.Text));//Converting tax into currency type
            Summary.Add("Final Price: " + Convert.ToString(STotal.Text));//Converting total into currency type
            Summary.Add("");
            Summary.Add("##########################");

            //Going trought the arraylist to print it out
            for (int n = 0; n < Summary.Count; n++)
                Printing += Summary[n] + "\r\n";
            summary.Text = Printing;
        }
        
        //Displaying Trip summary into a listbox
        public static void ShowList(ListBox sum, List<string> ArrSumm)
        {
            for(int m = 0; m < ArrSumm.Count; m++)
            {
                sum.Items.Add(ArrSumm[m]);
            }
        }

        //Method called to add items to comboboxes
        public static void ComboCheck(ComboBox ItemContain, string[] ArrayContain)
        {
            foreach (string Item in ArrayContain)
                ItemContain.Items.Add(Item);
            ItemContain.SelectedIndex = 0;
        }

        //Method called to delete items form a listbox (Trips from trip summary)
        public static void DeleteTrip(ListBox lstdeleted)
        {
            if (lstdeleted.SelectedIndex != -1)
            {
                lstdeleted.Items.RemoveAt(lstdeleted.SelectedIndex);
            }
            else
            {
                MessageBox.Show("please select trip to be delected"); //Show this message when anything is selected
            }
        }
    }
}
