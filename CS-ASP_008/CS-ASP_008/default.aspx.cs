using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_008
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void goButton_Click(object sender, EventArgs e)
        {
            int firstNumber = 2000000000;
            int secondNumber = 2000000000;
            int resultNumber = firstNumber * secondNumber;

            resultLabel.Text = resultNumber.ToString();
        }
    }
}