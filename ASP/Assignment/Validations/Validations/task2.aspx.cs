using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Validations
{
    public partial class task2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }
        protected void ddlChg(object sender, EventArgs e)
        {
            string val = ddlProd.SelectedValue;

            if (val == "1") imgProd.ImageUrl = "Pictures/beanie.jpg";
            else if (val == "2") imgProd.ImageUrl = "Pictures/Vneck.jpg";
            else if (val == "3") imgProd.ImageUrl = "Pictures/hoodie.jpg";
            else imgProd.ImageUrl = "";
        }
        protected void btnPr(object sender, EventArgs e)
        {
            string val = ddlProd.SelectedValue;

            if (val == "1") lblPrice.Text = "Price: 5000";
            else if (val == "2") lblPrice.Text = "Price: 2000";
            else if (val == "3") lblPrice.Text = "Price: 5000";
            else lblPrice.Text = "Please Select a Product";
        }
    }
}