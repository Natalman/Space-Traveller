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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //initialyzing arrays of activities that will be use in a different planets
        string[] VenusArr = { "Volcano Bath", "Tanning", "Hoverboard Heatwave Surfing" };
        string[] MoonArr = { "Gravity Walking", "Exloring Dark Side of Moon", "Collecting Rocks" };
        string[] MarsArr = { "Marsian Party", "Collecting Rocks", "Marsian Museum" };
        string[] JupiterArr = { "Storm Chasing", "'Great Red Spot' Shooting Gallery", "High Gravity Crossfit" };
        string[] SaturnArr = { "Ice skating rings", "Ring Toss", "Yeti Limbo" };

        public List<string> summary = new List<string>();//Initialyzing array of trips sign-up for

        private void pcbMercury_Click(object sender, EventArgs e)
        {       //Showing that to notify the user that there is no available trip to that planet
            MessageBox.Show("Traveling to Mercury is not available now, It will be in Future", "Mercury Trip");
        }

        private void pcbVenus_Click(object sender, EventArgs e)
        {
            planning Planning1 = new planning();    //Creating the planning form

            //Changing the background picture because we are using the same form for all planet
            Planning1.BackgroundImage = Properties.Resources.somewhere;

            //Calling the boxcheker method of caller to change the text proprities of all checkboxes
            Caller.boxChecker(VenusArr, Planning1.Activity1, Planning1.Activity2, Planning1.Activity3);
            Planning1.ShowDialog();     //Show form

            //getting price and date from the plannnig form and adding it to the summary array
            summary.Add (Planning1.TripDate + "\r\t" + "Trip to Venus" + "\r\t" + Planning1.Price);
        }

        private void pcbMars_Click(object sender, EventArgs e)
        {
            planning Planning2 = new planning();    //Creating the planning form

            //Changing the background picture because we are using the same form for all planet
            Planning2.BackgroundImage = Properties.Resources.l1;

            //Calling the boxcheker method of caller to change the text proprities of all checkboxes 
            Caller.boxChecker(MarsArr, Planning2.Activity1, Planning2.Activity2, Planning2.Activity3);
            Planning2.ShowDialog();     //Show form

            //getting price and date from the plannnig form and adding it to the summary array
            summary.Add(Planning2.TripDate + "\r\t" + "Trip to Mars" + "\r\t" + Planning2.Price);
        }

        private void pcbEarth_Click(object sender, EventArgs e)
        {           //Showing that to notify the user that there is no available trip to that planet
            MessageBox.Show("We are on Earth Choose another planet to travel to", "Earth trip");
        }

        private void pcbMoon_Click(object sender, EventArgs e)
        {
            planning Planning3 = new planning();    //Creating the planning form

            //Changing the background picture because we are using the same form for all planet
            Planning3.BackgroundImage = Properties.Resources.moon_ins;

            //Calling the boxcheker method of caller to change the text proprities of all checkboxes
            Caller.boxChecker(MoonArr, Planning3.Activity1, Planning3.Activity2, Planning3.Activity3);
            Planning3.ShowDialog();

            //getting price and date from the plannnig form and adding it to the summary array
            summary.Add(Planning3.TripDate + "\r\t" + "Trip to Moon" + "\r\t" + Planning3.Price);
        }

        private void pcbJupiter_Click(object sender, EventArgs e)
        {
            planning Planning4 = new planning();    //Creating the planning form

            //Changing the background picture because we are using the same form for all planet
            Planning4.BackgroundImage = Properties.Resources.l5;

            //Calling the boxcheker method of caller to change the text proprities of all checkboxes
            Caller.boxChecker(JupiterArr, Planning4.Activity1, Planning4.Activity2, Planning4.Activity3);
            Planning4.ShowDialog();     //Show form

            //getting price and date from the plannnig form and adding it to the summary array
            summary.Add(Planning4.TripDate + "\r\t" + "Trip to Jupiter" + "\r\t" + Planning4.Price);
        }

        private void pcbSaturn_Click(object sender, EventArgs e)
        {
            planning Planning5 = new planning();    //Creating the planning form

            //Changing the background picture because we are using the same form for all planet
            Planning5.BackgroundImage = Properties.Resources.l4;

            //Calling the boxcheker method of caller to change the text proprities of all checkboxes
            Caller.boxChecker(SaturnArr, Planning5.Activity1, Planning5.Activity2, Planning5.Activity3);
            Planning5.ShowDialog();     //Show form

            //getting price and date from the plannnig form and adding it to the summary array
            summary.Add(Planning5.TripDate + "\r\t" + "Trip to Saturn" + "\r\t" + Planning5.Price);
        }

        private void pcbUranus_Click(object sender, EventArgs e)
        {       //Showing that to notify the user that there is no available trip to that planet
            MessageBox.Show("Traveling to Uranus is not available now, It will be in Future", "Uranus Trip");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {       //Closing the app
            this.Close();
        }

        //Clicking on this button opens up the trip and payment and initialyze the summary array as your trips
        private void btnSaveData_Click(object sender, EventArgs e)
        {
            TripsNPayment Trip = new TripsNPayment();   //creating the new form
            Caller.ShowList(Trip.TripSummary, summary); //Calling the showlist method to add trip summary to a list
            Trip.ShowDialog();                          //Showing the form
        }
    }
}
