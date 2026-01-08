<%@ Page Language="C#" AutoEventWireup="true" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Clear();    
        Session.Abandon();  
        Response.Redirect("LoginForm.aspx");
    }
</script>
