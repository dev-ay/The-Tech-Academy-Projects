using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Challenge23
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //creates the array for elections in view state
                double[] elections = new double[0];
                ViewState.Add("Elections", elections);

                //creates the array for subterfuge in view state
                double[] subterfuge = new double[0];
                ViewState.Add("Subterfuge", subterfuge);
            }
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            //pull user input and set variables
            string newAsset = nameBox.Text;
            double newElections = Convert.ToDouble(electionsBox.Text);
            double newSubterfuge = Convert.ToDouble(actsBox.Text);

            //pull election array from view state and extend the array
            double[] elections = (double[])ViewState["Elections"];
            Array.Resize(ref elections, elections.Length + 1);

            //add newest user value to ellection array and store back in view state
            int newest = elections.GetUpperBound(0);
            elections[newest] = newElections;
            ViewState["Elections"] = elections;

            //pull subterfuge array from view state and extend the array
            double[] subterfuge = (double[])ViewState["Subterfuge"];
            Array.Resize(ref subterfuge, subterfuge.Length + 1);

            //add newest user value to subterfuge array and store back in view state
            int newest2 = subterfuge.GetUpperBound(0);
            subterfuge[newest2] = newSubterfuge;
            ViewState["Subterfuge"] = subterfuge;

            resultLabel.Text = String.Format("Total Elections Rigged: {0}" +
                "<br />Average Acts of Subterfuge per Asset: {1:N2}<br />(Last Asset Added: {2})",
               elections.Sum(), subterfuge.Average(), newAsset);

            //Resets user input text boxes after returning reslts
            nameBox.Text = "";
            electionsBox.Text = "";
            actsBox.Text = "";

        }
    }
}