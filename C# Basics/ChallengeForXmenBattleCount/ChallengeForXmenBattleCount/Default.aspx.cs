using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeForXmenBattleCount
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Results should show:
            // Wolverine fewest battles
            // Pheonix most battles

            string[] names = new string[] { "Professor X", "Iceman", "Angel", "Beast", "Pheonix",
                "Cyclops", "Wolverine", "Nightcrawler", "Storm", "Colossus" };
            int[] numbers = new int[] { 7, 9, 12, 15, 17, 13, 2, 6, 8, 13 };

            string result = "";


            //variables to save indexes
            int maximum = 0;
            int minimum = 0;

            //for loop to move through arrays and locate indexes
            for (int i = 0; i < numbers.Length; i++)
            {
                //this if statement continues to change the index stored in maximum
                //until it points to the highest value in the array
                if (numbers[i] > numbers[maximum])
                {
                    maximum = i;
                }

                //this if statement continues to change the index stored in mimimum
                //until it points to the lowest value in the array
                if (numbers[i] < numbers[minimum])
                {
                    minimum = i;
                }
            }

            result = String.Format("Most battles belong to: {0} (Value: {1})"
                + "<br />Least battles belong to: {2} (Value: {3})", names[maximum], 
                numbers[maximum], names[minimum], numbers[minimum]);

            resultLabel.Text = result;
        }
    }
}