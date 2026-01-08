using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using System.Web.UI;

using System.Web.UI.WebControls;

namespace ElectricityBill

{

    public partial class LoginForm : System.Web.UI.Page

    {

        private string adminUsername = "keerthu";

        private string adminPassword = "2005";

        protected void Page_Load(object sender, EventArgs e)

        {

            lblMessage.Text = "";

        }

        protected void btnLogin_Click(object sender, EventArgs e)

        {

            string username = txtUsername.Text.Trim();

            string password = txtPassword.Text.Trim();

            if (username == adminUsername && password == adminPassword)

            {

                Response.Redirect("AddBilling.aspx");

            }

            else

            {

                lblMessage.Text = "Invalid Username or Password";

            }

        }

    }

}
