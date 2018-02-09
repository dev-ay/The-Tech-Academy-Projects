using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Challenge10
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string a = firstValue.Text;
            double c = double.Parse(a);

            string b = secondValue.Text;
            double d = double.Parse(b);

            double result = c + d;
            resultLabel.Text = result.ToString();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string a = firstValue.Text;
            double c = double.Parse(a);

            string b = secondValue.Text;
            double d = double.Parse(b);

            double result = c - d;
            resultLabel.Text = result.ToString();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string a = firstValue.Text;
            double c = double.Parse(a);

            string b = secondValue.Text;
            double d = double.Parse(b);

            double result = c * d;
            resultLabel.Text = result.ToString();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string a = firstValue.Text;
            double c = double.Parse(a);

            string b = secondValue.Text;
            double d = double.Parse(b);

            double result = c / d;
            resultLabel.Text = result.ToString();
        }
    }
}