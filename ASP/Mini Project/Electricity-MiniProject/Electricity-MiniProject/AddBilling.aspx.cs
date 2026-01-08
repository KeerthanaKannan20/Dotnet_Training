using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectricityBill
{
    public partial class AddBilling : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            lblBillAmount.Text = "";
        }

        protected void btnAddBill_Click(object sender, EventArgs e)
        {
            try
            {
                ElectricityBill ebill = new ElectricityBill
                {
                    ConsumerNumber = txtConsumerNumber.Text.Trim(),
                    ConsumerName = txtConsumerName.Text.Trim()
                };

                if (!int.TryParse(txtUnitsConsumed.Text.Trim(), out int units))
                {
                    lblMessage.Text = "Units must be a valid number";
                    lblBillAmount.Text = "";
                    return;
                }
                ebill.UnitsConsumed = units;

                ElectricityBoard board = new ElectricityBoard();
                board.CalculateBill(ebill);

                try
                {
                    board.AddBill(ebill);
                    lblBillAmount.Text = $"Bill Amount: ₹{ebill.BillAmount}";
                    lblMessage.Text = "";

                    txtConsumerNumber.Text = "";
                    txtConsumerName.Text = "";
                    txtUnitsConsumed.Text = "";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                    lblBillAmount.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblBillAmount.Text = "";
            }
        }
    }
}