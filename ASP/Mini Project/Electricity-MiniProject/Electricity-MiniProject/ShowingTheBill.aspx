﻿<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="ShowingTheBill.aspx.cs"
    Inherits="ElectricityBill.ShowingTheBill" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>View Electricity Bills</title>

<style>
body {
    font-family: 'Poppins', 'Segoe UI', sans-serif;
    margin: 0;
    min-height: 100vh;
    background: linear-gradient(135deg,
        #fde2f3,   
        #ecfeff,  
        #dcfce7   
    );
}

.header {
    background: linear-gradient(135deg,
        #ec4899,   
        #22c55e    
    );
    color: white;
    padding: 16px 32px;
    display: flex;
    justify-content: space-between;
    align-items: center;
    box-shadow: 0 10px 30px rgba(0,0,0,0.25);
}

.header h2 {
    margin: 0;
    font-weight: 600;
    letter-spacing: 0.5px;
}

.header a {
    color: white;
    text-decoration: none;
    margin-left: 20px;
    font-weight: 500;
    position: relative;
}

.header a::after {
    content: "";
    position: absolute;
    left: 0;
    bottom: -4px;
    width: 0;
    height: 2px;
    background: #fef08a;
    transition: width 0.3s ease;
}

.header a:hover::after {
    width: 100%;
}

.card,
.container,
.login-card {
    width: 420px;
    margin: 80px auto;
    background: rgba(255, 255, 255, 0.95);
    padding: 36px;
    border-radius: 22px;
    border: 1px solid rgba(34,197,94,0.25);
    box-shadow:
        0 25px 50px rgba(0,0,0,0.18),
        inset 0 0 0 1px rgba(255,255,255,0.5);
}

.container.wide {
    width: 90%;
    max-width: 1000px;
}

h2, h3 {
    text-align: center;
    margin-bottom: 25px;
    color: #15803d;
}

input[type=text],
input[type=password] {
    width: 100%;
    padding: 13px 14px;
    margin-bottom: 18px;
    border-radius: 14px;
    border: 1px solid #f9a8d4;
    background: #fdf2f8;
    font-size: 14px;
    transition: all 0.25s ease;
}

input::placeholder {
    color: #9ca3af;
}

input:focus {
    outline: none;
    background: white;
    border-color: #22c55e;
    box-shadow: 0 0 0 3px rgba(34,197,94,0.3);
}

input[type=submit],
button {
    width: 100%;
    padding: 14px;
    border-radius: 16px;
    border: none;
    background: linear-gradient(135deg,
        #ec4899,
        #22c55e
    );
    color: white;
    font-size: 15px;
    font-weight: 600;
    cursor: pointer;
    transition: transform 0.15s ease, box-shadow 0.15s ease;
}

input[type=submit]:hover,
button:hover {
    transform: translateY(-1px);
    box-shadow: 0 15px 35px rgba(236,72,153,0.45);
}

.message,
.error {
    text-align: center;
    font-size: 14px;
    margin-top: 12px;
    color: #dc2626;
}

.amount {
    text-align: center;
    font-size: 18px;
    font-weight: 700;
    margin-top: 14px;
    color: #15803d;
}

.grid {
    width: 100%;
    border-collapse: collapse;
    margin-top: 25px;
    table-layout: fixed;
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
}

    .grid th, .grid td {
        padding: 12px 15px;
        border: 1px solid #ddd;
        text-align: center;
        overflow-wrap: break-word;
        word-break: break-word;
        max-width: 150px;
    }

.grid th {
    background: linear-gradient(135deg, #ec4899, #22c55e);
    color: white;
    font-weight: 700;
}
.grid tr:nth-of-type(even) {
    background-color: #fdf2f8;
}

.grid tr:hover {
    background-color: #dcfce7;
}
</style>

</head>

<body>
<form id="form1" runat="server">

<div class="header">
    <h2>Electricity Board</h2>
    <div>
        <a href="AddBilling.aspx">Add Bill</a>
        <a href="Logout.aspx">Logout</a>
    </div>
</div>

<div class="container">
    <h3>View Last N Electricity Bills</h3>

    <div class="input-row">
        <asp:TextBox ID="txtCount" runat="server"
            Placeholder="Enter N value"></asp:TextBox>

        <asp:Button ID="btnShow" runat="server"
            Text="Show Bills" OnClick="btnShow_Click" />
    </div>

    <asp:Label ID="lblMessage" runat="server" CssClass="error"></asp:Label>

    <asp:GridView ID="gvBills" runat="server"
        CssClass="grid" AutoGenerateColumns="true"
        BorderWidth="0">
    </asp:GridView>
</div>

</form>
</body>
</html>
