using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza
{
    public partial class frmOder : Form
    {
        public frmOder()
        {
            InitializeComponent();
        }

        void UpdateSize()
        {
            UpdateTotalPrice();

            if (rbSmall.Checked)
            {
                lblSizeChange.Text = "Small";
                return;
            }

            if (rbMeduim.Checked)
            {
                lblSizeChange.Text = "Meduim";
                return;
            }

            if (rbLarge.Checked)
            {
                lblSizeChange.Text = "Large";
                return;
            }

        }

        void UpdateToppings()
        {
            UpdateTotalPrice();

            string sToppings = "";

            if (ckbExtraCheese.Checked)
            {
                sToppings += "Extra Cheese";
            }

            if (ckbGreenPeppers.Checked)
            {
                sToppings += ", Green Peppers";
            }

            if (ckbMushrooms.Checked)
            {
                sToppings += ", Mushrooms";
            }

            if (ckbOlives.Checked)
            {
                sToppings += ", Olives";
            }

            if (ckbOnion.Checked)
            {
                sToppings += ", Onion";
            }

            if (ckbTomatoes.Checked)
            {
                sToppings += ", Tomatoes";
            }

            if (sToppings.StartsWith(","))
            {
                sToppings = sToppings.Substring(1, sToppings.Length - 1).Trim();
            }

            if (sToppings == "")
            {
                sToppings = "No Toppings";
            }

            lblTopping.Text = sToppings;

        }

        void UpdateCrust()
        {

            UpdateTotalPrice();

            if (rbThin.Checked)
            {
                lblCrustType.Text = "Thin Crust";
                return;
            }

            if (rbThick.Checked)
            {
                lblCrustType.Text = "Thick Crust";
                return;
            }
        }

        void UpdateWhereToEat()
        {
            UpdateTotalPrice();

            if (rbEatIn.Checked)
            {
                lblWhereToEat.Text = "Eat In.";
                return;
            }
            if (rbTakeOut.Checked)
            {
                lblWhereToEat.Text = "Take Out.";
                return;
            }
        }

        float GetSelectedSizePrice()
        {

            if(rbSmall.Checked)
            {
                return Convert.ToSingle(rbSmall.Tag);
            }
            else if (rbMeduim.Checked)
            {
                return Convert.ToSingle(rbMeduim.Tag);
            }
            else
            {
                return Convert.ToSingle(rbLarge.Tag);
            }
        }

        float CalculateToppingsPrice()
        {

            float ToppinngsTotalPrice = 0.0f;

            if (ckbExtraCheese.Checked)
            {
                ToppinngsTotalPrice += Convert.ToSingle(ckbExtraCheese.Tag);
            }

            if (ckbGreenPeppers.Checked)
            {
                ToppinngsTotalPrice += Convert.ToSingle(ckbGreenPeppers.Tag);
            }

            if (ckbMushrooms.Checked)
            {
                ToppinngsTotalPrice += Convert.ToSingle(ckbMushrooms.Tag);
            }

            if (ckbOlives.Checked)
            {
                ToppinngsTotalPrice += Convert.ToSingle(ckbOlives.Tag);
            }

            if (ckbOnion.Checked)
            {
                ToppinngsTotalPrice += Convert.ToSingle(ckbOnion.Tag);
            }

            if (ckbTomatoes.Checked)
            {
                ToppinngsTotalPrice += Convert.ToSingle(ckbTomatoes.Tag);
            }

            return ToppinngsTotalPrice;
        }

        float GetSelectedCrustPrice()
        {
            if (rbThin.Checked)
            {
                return Convert.ToSingle(rbThin.Tag);
            }
            else
            {
                return Convert.ToSingle(rbThick.Tag);
            }
        }
 
        float CalculateTotalPrice()
        {
            return GetSelectedSizePrice() + GetSelectedCrustPrice() + CalculateToppingsPrice(); 
        }


        void UpdateTotalPrice()
        {
            lblTotalPrice.Text = "$" + CalculateTotalPrice().ToString();
        }

        void UpdateOrderSummary()
        {
            UpdateSize();
            UpdateToppings();
            UpdateCrust();
            UpdateWhereToEat();
            UpdateTotalPrice();
        }

        void ResetForm()
        {
            // Reset Groups
            gbSize.Enabled = true;
            gbToppings.Enabled = true;
            gbCrustType.Enabled = true;
            gbWhereToEat.Enabled = true;

            // Reset Size
            rbMeduim.Checked = true;

            // Reset Toppings
            ckbExtraCheese.Checked = false;
            ckbGreenPeppers.Checked = false;
            ckbMushrooms.Checked = false;
            ckbOlives.Checked = false;
            ckbOnion.Checked = false;
            ckbTomatoes.Checked = false;

            // Reset Crust Type
            rbThin.Checked = true;

            // Reset Where to Eat
            rbEatIn.Checked = true;

            //Reset Order Button
            btnOrder.Enabled = true;

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {

            if(MessageBox.Show("Do you want to place the order?", "Order Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Your order has been placed successfully!", "Order Placed",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnOrder.Enabled = false;
                gbSize.Enabled = false;
                gbToppings.Enabled = false;
                gbCrustType.Enabled = false;
                gbWhereToEat.Enabled = false;

            }
            else
            {
                MessageBox.Show("Please update your order.", "Update Order",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbMeduim_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void ckbExtraCheese_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void ckbMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void ckbTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void ckbOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void ckbOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void ckbGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void rbThin_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rbThick_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void gbOrderSummary_Enter(object sender, EventArgs e)
        {

        }
    }
}
