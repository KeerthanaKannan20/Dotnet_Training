using System;
using System.Collections.Generic;

namespace ElectricityBill
{
    public partial class ShowingTheBill : System.Web.UI.Page
    {
        protected void btnShow_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            gvBills.DataSource = null;
            gvBills.DataBind();

            if (!int.TryParse(txtCount.Text.Trim(), out int n) || n <= 0)
            {
                lblMessage.Text = "Please enter a valid number";
                return;
            }

            ElectricityBoard board = new ElectricityBoard();
            List<ElectricityBill> bills = board.GetLastNBills(n);

            if (bills.Count == 0)
            {
                lblMessage.Text = "No bill records found";
                return;
            }

            gvBills.DataSource = bills;
            gvBills.DataBind();
        }
    }
}
