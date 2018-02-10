using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Challenge16
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void okButton_Click(object sender, EventArgs e)
        {
            DateTime firstDate = Calendar1.SelectedDate;
            DateTime secondDate = Calendar2.SelectedDate;

            TimeSpan mySpan = firstDate.Subtract(secondDate);
            double difference = Math.Abs(mySpan.TotalDays); // refactored two steps into one, taking date spans and getting absolute value

            resultLabel.Text = "That makes " + difference.ToString() + " days.";
        }
    }
}