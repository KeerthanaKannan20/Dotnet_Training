<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="task1.aspx.cs" 
    Inherits="Validations.task1" 
    UnobtrusiveValidationMode="None" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validation Form</title>
</head>
<body>
    <form id="f" runat="server">
        <div>
            <h3>Insert Your Details:</h3>

            <!-- Name -->
            <asp:Label ID="lblN" runat="server" Text="Name:"></asp:Label>
            <asp:TextBox ID="txtN" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvN" runat="server" 
                ControlToValidate="txtN" ErrorMessage="* required" ForeColor="red" />
            <br /><br />

            <!-- Family Name -->
            <asp:Label ID="lblF" runat="server" Text="Family Name:"></asp:Label>
            <asp:TextBox ID="txtF" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvF" runat="server" 
                ControlToValidate="txtF" ErrorMessage="* required" ForeColor="red" />
            <asp:CustomValidator ID="cvName" runat="server" 
                ControlToValidate="txtF" OnServerValidate="chkName" 
                ErrorMessage="Must differ from name" ForeColor="red" />
            <br /><br />

            <!-- Address -->
            <asp:Label ID="lblAdd" runat="server" Text="Address:"></asp:Label>
            <asp:TextBox ID="txtAdd" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvAdd" runat="server" 
                ControlToValidate="txtAdd" ErrorMessage="* required" ForeColor="red" />
            <asp:CustomValidator ID="cvAdd" runat="server" 
                ControlToValidate="txtAdd" OnServerValidate="chkAdd" 
                ErrorMessage="At least 2 chars please" ForeColor="red" />
            <br /><br />

            <!-- City -->
            <asp:Label ID="lblCity" runat="server" Text="City:"></asp:Label>
            <asp:TextBox ID="txtCity" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCity" runat="server" 
                ControlToValidate="txtCity" ErrorMessage="* required" ForeColor="red" />
            <asp:CustomValidator ID="cvCity" runat="server" 
                ControlToValidate="txtCity" OnServerValidate="chkCity" 
                ErrorMessage="At least 2 chars please" ForeColor="red" />
            <br /><br />

            <!-- Zip Code -->
            <asp:Label ID="lblZip" runat="server" Text="Zip Code:"></asp:Label>
            <asp:TextBox ID="txtZip" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvZip" runat="server" 
                ControlToValidate="txtZip" ErrorMessage="* required" ForeColor="red" />
            <asp:RegularExpressionValidator ID="revZip" runat="server" 
                ControlToValidate="txtZip" ValidationExpression="^\d{5}$" 
                ErrorMessage="Zip must be 5 digits" ForeColor="red" />
            <br /><br />

            <!-- Phone -->
            <asp:Label ID="lblPh" runat="server" Text="Phone:"></asp:Label>
            <asp:TextBox ID="txtPh" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPh" runat="server" 
                ControlToValidate="txtPh" ErrorMessage="* required" ForeColor="red" />
            <asp:RegularExpressionValidator ID="revPh" runat="server" 
                ControlToValidate="txtPh" ValidationExpression="^\d{2,3}-\d{7}$" 
                ErrorMessage="Format: XX-XXXXXXX or XXX-XXXXXXX" ForeColor="red" />
            <br /><br />

            <!-- E-Mail -->
            <asp:Label ID="lblEm" runat="server" Text="E-Mail:"></asp:Label>
            <asp:TextBox ID="txtEm" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEm" runat="server" 
                ControlToValidate="txtEm" ErrorMessage="* required" ForeColor="red" />
            <asp:RegularExpressionValidator ID="revEm" runat="server" 
                ControlToValidate="txtEm" ValidationExpression="^[^\s@]+@[^\s@]+\.[^\s@]+$" 
                ErrorMessage="Invalid email, please check" ForeColor="red" />
            <br /><br />

            <!-- Check Button -->
            <asp:Button ID="btnChk" runat="server" Text="Check" OnClick="btnChk_Click" />
            <br /><br />

            <!-- Validation Summary & Result Label -->
            <asp:ValidationSummary ID="valSum" runat="server" ForeColor="green" />
            <asp:Label ID="lblMsg" runat="server" ForeColor="green"></asp:Label>

        </div>
    </form>
</body>
</html>
