<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyDWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

<style>
    .btnStyle {
        background-color: orange;
        border-radius: 10px;
        height: 38px;
        width: 65px;
    }
</style>

</head>
<body>
  <%--  <form id="frmLogin" runat="server">
        <div>
            <table>
                <tr>
                    <td><label>User Id:</label></td>
                    <td> <asp:TextBox ID="email" runat="server"></asp:TextBox></td>
                </tr>
                                <tr>
                    <td><label>Password:</label></td>
                    <td><asp:TextBox ID="pwd" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" Text="Login" runat="server" />
                        <asp:Label runat="server" ID="lblLoginError" Visible="false" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>                                                          
        </div>
    </form>--%>


    <div>
    <div style="background-color:#b6c3c3;height: 30px;border-style: double;font-weight:bold; width:100.5%"><center><span>Login</span></center></div>
</div>
<div style="background-color:#f2f2f2;height:250px; display:block!important">
    <div>
        <center><img id="imgUser" height="100px" width="100px" src="Image/login.png" style="border-radius: 50%;" /></center>
    </div>

    <center>
        <form id="frmLogin" runat="server">
        <table style="width:40%;border:outset">
            
                <tr>
                    <td><b><label>User Id:</label></b></td>
                    <td><asp:TextBox ID="email" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td><b><label>Password:</label></b></td>
                    <td><asp:TextBox ID="pwd" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr colspan="2" style="width:100%">
                    <td>
                      <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" Text="Login" runat="server" />
                        <asp:Label runat="server" ID="lblLoginError" Visible="false" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
        </table>
         </form>
    </center>
</div>

</body>
</html>
