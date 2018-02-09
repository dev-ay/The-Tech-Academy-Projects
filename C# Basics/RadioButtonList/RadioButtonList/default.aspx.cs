using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RadioButtonList
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void okayButton_Click(object sender, EventArgs e)
        {
            if (pencil.Checked)
            {
                resultLabel.Text = "You selected Pencil";
                resultImage.ImageUrl = "./pencil.png";
            }
            else if (pen.Checked)
            {
                resultLabel.Text = "You selected Pen";
                resultImage.ImageUrl = "./pen.png";
            }
            else if (phone.Checked)
            {
                resultLabel.Text = "You selected Phone";
                resultImage.ImageUrl = "./phone.png";
            }
            else if (tablet.Checked)
            {
                resultLabel.Text = "You selected Tablet";
                resultImage.ImageUrl = "./tablet.png";
            }
            else 
            {
                resultLabel.Text = "Please select an option";
            }
        }
    }
}