using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SlotMachine
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) // executes this code if the page is loading for the first time
            {
                ViewState.Add("Money", 100); // putting this value into the viewstate
                Random random = new Random();
                int value1 = random.Next(1, 12);
                int value2 = random.Next(1, 12);
                int value3 = random.Next(1, 12);
                Image1.ImageUrl = "/images/" + value1 + ".png";
                Image2.ImageUrl = "/images/" + value2 + ".png";
                Image3.ImageUrl = "/images/" + value3 + ".png";
            }
            else
            {
                return;
            }
        }

        protected void pullButton_Click(object sender, EventArgs e)
        {
            randomGenerator();
        }

        private void randomGenerator()
        {
            Random random = new Random();
            int value1 = random.Next(1, 12);
            int value2 = random.Next(1, 12);
            int value3 = random.Next(1, 12);
            insertImages(value1, value2, value3);
        }

        private void insertImages(int value1, int value2, int value3)
        {
            Image1.ImageUrl = "/images/" + value1 + ".png";
            Image2.ImageUrl = "/images/" + value2 + ".png";
            Image3.ImageUrl = "/images/" + value3 + ".png";
            countSevens(value1, value2, value3);
        }

        private void countSevens(int value1, int value2, int value3)
        {
            //10.png is 7
            if (value1 == 10 && value2 == 10 && value3 == 10)
            {
                jackpotMoney();
            }
            else
            {
                countBars(value1, value2, value3);
            }
        }

        private void countBars(int value1, int value2, int value3)
        {
            //1.png is BAR
            if (value1 == 1 || value2 == 1 || value3 == 1)
            {
                barMoney();
            }
            else
            {
                countCherries(value1, value2, value3);
            }
        }

        private void countCherries(int value1, int value2, int value3)
        {
            //3.png is CHERRY
            int multiplier = 1;
            //int howManyCherries = 1;
            if (value1 == 3)
            {
                multiplier += 1;
            }

            if (value2 == 3)
            {
                multiplier += 1;
            }

            if (value3 == 3)
            {
                multiplier += 1;
            }


            playerMoney(multiplier);
        }

        private void playerMoney(int multiplier)
        {
            int bet = 0;
            int money = 0;
            int.TryParse(ViewState["Money"].ToString(), out money);
            int.TryParse(betTextBox.Text, out bet);


            if (multiplier > 1)
            {
                money = money + (bet * multiplier);
                ViewState["Money"] = money;
                moneyLabel.Text = String.Format("Player's Money: {0:C}", money);
                wonMoney(bet, multiplier);
            }
            else 
            {
                money -= bet;
                ViewState["Money"] = money;
                moneyLabel.Text = String.Format("Player's Money: {0:C}", money);
                lostMoney(bet);
            }

        }

        private void barMoney()
        {
            int bet = 0;
            int money = 0;
            int.TryParse(ViewState["Money"].ToString(), out money);
            int.TryParse(betTextBox.Text, out bet);

            resultLabel.Text = String.Format("Sorry, you lost {0:C}. Better luck next time.", bet);
            money -= bet;
            ViewState["Money"] = money;

            moneyLabel.Text = String.Format("Player's Money: {0:C}", money);
        }

        private void jackpotMoney()
        {
            int bet = 0;
            int money = 0;
            int.TryParse(ViewState["Money"].ToString(), out money);
            int.TryParse(betTextBox.Text, out bet);

            resultLabel.Text = String.Format("You bet {0:C} and won {1:C}!", bet, bet*100);
            money += (bet * 100);
            ViewState ["Money"] = money;

            moneyLabel.Text = String.Format("Player's Money: {0:C}", money);
        }

        private void wonMoney(int bet, int multiplier)
        {
            resultLabel.Text = String.Format("You bet {0:C} and won {1:C}!", bet, bet * multiplier);
        }

        private void lostMoney(int bet)
        {
            resultLabel.Text = String.Format("Sorry, you lost {0:C}. Better luck next time.", bet);
        }
    }
}