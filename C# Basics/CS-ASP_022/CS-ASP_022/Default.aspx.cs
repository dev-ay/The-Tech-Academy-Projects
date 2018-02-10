using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_022
{
    public partial class Default : System.Web.UI.Page
    {
        double[,] priceGrid;

        protected void Page_Load(object sender, EventArgs e)
        {
            //this is indicating that our array is two dementional
            priceGrid = new double[3, 3];
            priceGrid[0, 1] = 350; //chicago to newyork
            priceGrid[0, 2] = 750; //chicago to london
            priceGrid[1, 0] = 400;
            priceGrid[1, 2] = 700;
            priceGrid[2, 0] = 800;
            priceGrid[2, 1] = 805;

        }

        protected void okButton_Click(object sender, EventArgs e)
        {
            int fromCity;
            int toCity;


            if (fromChicagoRadio.Checked) fromCity = 0;
            else if (fromNewYorkRadio.Checked) fromCity = 1;
            else fromCity = 2;

            if (toChicagoRadio.Checked) toCity = 0;
            else if (toNewYorkRadio.Checked) toCity = 1;
            else toCity = 2;

            if (fromCity == toCity)
            {
                resultLabel.Text = "";
                return;
            }

            string myTrip = priceGrid[fromCity, toCity].ToString("C", CultureInfo.CurrentCulture);
            resultLabel.Text = myTrip;

        }
    }
}