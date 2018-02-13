using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Challenge34
{
    public partial class _default : System.Web.UI.Page
    {
        // set variables

        double volume = 0;
        double shipping = 0;
        double width = 0;
        double height = 0;
        double length = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void checkValues()
        {
            if (Double.TryParse(widthTextBox.Text, out width)) {
                if (Double.TryParse(heightTextBox.Text, out height))
                {
                    Double.TryParse(lengthTextBox.Text, out length);
                    calculateVolume(width, height, length);
                }
            }
        }

        private void calculateVolume(double width = 0, double height = 0, double length = 0)
        {
            
            if (width == 0 || height == 0)
            {
                resultLabel.Text = "You must enter a width and height to calculate.";
            } 
            else {
                if (length == 0)
                {
                    volume = width * height;
                    calculateShipping(volume);
                }
                else
                {
                    volume = length * width * height;
                    calculateShipping(volume);
                }
            }
        }

        private void calculateShipping(double volume)
        {
            //takes in volume and calulates shipping
            if (groundButton.Checked)
            {
                shipping = volume * 0.15;
                printResults(shipping);
            }
            else if (airButton.Checked)
            {
                shipping = volume * 0.25;
                printResults(shipping);
            }
            else if (nextDayButton.Checked)
            {
                shipping = volume * 0.45;
                printResults(shipping);
            }
            else return; 
        }

        private void printResults(double shipping)
        {
            resultLabel.Text = String.Format("Your parcel will cost {0:C} to ship.", shipping);
        }

        protected void widthTextBox_TextChanged(object sender, EventArgs e)
        {
            checkValues();
        }

        protected void heightTextBox_TextChanged(object sender, EventArgs e)
        {
            checkValues();
        }

        protected void lengthTextBox_TextChanged(object sender, EventArgs e)
        {
            checkValues();
        }

        protected void groundButton_CheckedChanged(object sender, EventArgs e)
        {
            checkValues();
        }

        protected void airButton_CheckedChanged(object sender, EventArgs e)
        {
            checkValues();
        }

        protected void nextDayButton_CheckedChanged(object sender, EventArgs e)
        {
            checkValues();
        }
    }
}