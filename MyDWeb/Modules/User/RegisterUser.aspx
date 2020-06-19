<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" MasterPageFile="~/Site.Master" Inherits="MyDWeb.Modules.User.RegisterUser" %>

     <asp:content runat="server" ContentPlaceHolderID="xyz">
         <style>
             table{ 
border-collapse:separate; 
border-spacing: 0 15px; 
} 
th{ 
/*background-color: #4287f5; 
color: white;*/ 
} 
th,td{ 
width: 150px; 
text-align: center; 
border: 1px solid black;
padding: 5px;
}
         </style>
         <div style="margin-left:120px;">
             <br />
   <%-- <form id="form1" runat="server">--%>
        <div id="MainDiv" runat="server">
            <table border="0">
                <tr>
                    <th>First Name</th>
                    <td><asp:TextBox ID="txtFname" runat="server" />
                        <asp:RequiredFieldValidator runat="server" ID="reqFirstName" ControlToValidate="txtFname"
                            ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <th>Last Name</th>
                    <td><asp:TextBox ID="txtLname" runat="server" />
                        <asp:RequiredFieldValidator runat="server" ID="reqLastName" ControlToValidate="txtLname"
                            ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <th>Email</th>
                    <td><asp:TextBox ID="txtEmail" runat="server" />
                         <asp:RequiredFieldValidator runat="server" ID="reqEmail" ControlToValidate="txtEmail"
                            ErrorMessage="*" ForeColor="Red" ></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <th>User Type</th>
                    <td><%--<asp:TextBox ID="txtUserType" runat="server" />--%>
                        <asp:DropDownList ID="ddlUserType" runat="server">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem>User</asp:ListItem>
                            <asp:ListItem>Admin</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="reqUserType" ControlToValidate="ddlUserType"
                            ErrorMessage="*" ForeColor="Red" ></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <th>Date of Birth</th>
                    <td><asp:TextBox ID="txtDOB" runat="server" />
                         <asp:RequiredFieldValidator runat="server" ID="reqTxtDob" ControlToValidate="txtDOB"
                            ErrorMessage="*" ForeColor="Red" ></asp:RequiredFieldValidator>
                    </td>
                </tr> 
                </table>
            <hr />
            <table border="0">
                <tr>
                    <td colspan="2" width="">
                        <span><b>Add Infant Details</b></span>
                    </td>
                </tr>
                <tr>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Date of Birth</th>
                    <th>Sex</th>
                    <th>Clinic</th>
                    <th>Doctor</th>
                </tr>                
                <tr>
                    <td><asp:TextBox ID="txtInfantFName1" runat="server" /> </td>
                    <td><asp:TextBox ID="txtInfantLName1" runat="server" /> </td>
                    <td><asp:TextBox ID="txtInfantDob1" runat="server" /></td>
                    <td><asp:RadioButton runat="server" ID="rdnMale1" GroupName="Sex1" Text="Male" /> <asp:RadioButton runat="server" ID="rdnFemale1" GroupName="Sex1" Text="Female" />  </td>
                    <td><asp:DropDownList ID="ddlClinic" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClinic_SelectedIndexChanged">                 
                        </asp:DropDownList></td>
                    <td><asp:DropDownList ID="ddlDoctors" runat="server">
                         <asp:ListItem>--Select--</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="txtInfantFName2" runat="server" /> </td>
                    <td><asp:TextBox ID="txtInfantLName2" runat="server" /> </td>
                    <td><asp:TextBox ID="txtInfantDob2" runat="server" /></td>
                    <td><asp:RadioButton runat="server" ID="rdnMale2" GroupName="Sex2" Text="Male" /> <asp:RadioButton runat="server" ID="rdnFemale2" GroupName="Sex2" Text="Female" />  </td>
                    <td><asp:DropDownList ID="ddlClinic2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClinic2_SelectedIndexChanged">
                       
                        </asp:DropDownList></td>
                    <td><asp:DropDownList ID="ddlDoctors2" runat="server">
                        <asp:ListItem>--Select--</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>                    
                    <td colspan="2"><asp:Button ID="btnSubmit" Text="Register" OnClick="btnSubmit_Click" runat="server" /></td>
                </tr>
            </table>
        </div>

        <br />
        
             <div id="divConfimation" runat="server" visible="false">
                 <label runat="server">User is created successfully</label>
                 <br />
                 <asp:Button ID="btnConfirmation" runat="server" Text="OK" OnClick="btnConfirmation_Click" />
             </div>
            
    <%--</form>--%>
             
             </div>
         </asp:content>
