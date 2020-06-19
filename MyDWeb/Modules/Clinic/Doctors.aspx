<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Doctors.aspx.cs" MasterPageFile="~/Site.Master" Inherits="MyDWeb.Modules.Clinic.Doctors" %>

<asp:content runat="server" ContentPlaceHolderID="xyz">
<head>
    <title>Doctors</title>

<style type="text/css">
    .Table
    {
        display: table;
    }
    .Title
    {
        display: table-caption;
        text-align: center;
        font-weight: bold;
        font-size: larger;
    }
    .Heading
    {
        display: table-row;
        font-weight: bold;
        text-align: center;
    }
    .Row
    {
        display: table-row;
    }
    .Cell
    {
        display: table-cell;
        border: none;
        border-width: thin;
        padding-left: 5px;
        padding-right: 5px;
    }
</style>
    </head>

<div style="display:table;margin-left:100px;">   
 <div style="display:table-row">
<div style="display:table-cell">


    <div style="margin-bottom:10px;">
        <div class="Title">
        <p>Doctors</p>
    </div>
            <asp:GridView ID="grdDoctors" runat="server" AutoGenerateColumns="false" AllowPaging="True" Width="750px">
                <HeaderStyle BackColor="#b6c3c3" ForeColor="Black" Font-Bold="true" />
                <Columns>
                    <asp:BoundField DataField="FName" HeaderText="Name" />
                    <asp:BoundField DataField="LName" HeaderText="Last Name" />
                    <asp:BoundField DataField="Specilization" HeaderText="Specilization" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />                  
                </Columns>
                <PagerSettings Mode="NumericFirstLast"  Visible="true" PageButtonCount="5" FirstPageText="First" LastPageText="Last" />
            </asp:GridView>
    </div>


    </div>

<div style="display:table-cell;">
            <div style="padding-left:60px;>
<div class="Table" style="margin-left: 30px; margin-top: 10px;background-image: '~/MyDStyles/img/stickey.jpg'" id="divNewClinic" runat="server">
    <div class="Title">
        <p>Add New Doctor</p>
    </div>

   <div class="Row">
        <div class="Cell">
            <p>First Name</p>
        </div>
        <div class="Cell">
            <input runat="server" type="text" id="txtFname" data-id="txtFname" />
        </div>
    </div>


   <div class="Row">
        <div class="Cell">
            <p>Last Name</p>
        </div>
        <div class="Cell">
            <input runat="server" type="text" id="txtLname" data-id="txtLname" />
        </div>
       </div>

   <div class="Row">
        <div class="Cell">
            <p>Address</p>
        </div>
        <div class="Cell">
            <input runat="server" type="text" id="txtAddress" />
        </div>
       </div>

   <div class="Row">
        <div class="Cell">
            <p>Specilization</p>
        </div>
        <div class="Cell">
            <input runat="server" type="text" id="txtSpecilization" />
        </div>
       </div>


   <div class="Row">
        <div class="Cell">
            <p>StartTime</p>
        </div>
        <div class="Cell">
            <input runat="server" type="text" id="txtStartTime" >
        </div>
       </div>

   <div class="Row">
        <div class="Cell">
            <p>EndTime</p>
        </div>
        <div class="Cell">
            <input runat="server" type="text" id="txtEndTime" />
        </div>
       </div>

   <div class="Row">
        <div class="Cell">
            <p>Reg. No.</p>
        </div>
        <div class="Cell">
            <input runat="server" type="text" id="txtRegistrationNumber" />
        </div>
       </div>

    <div class="Row">
        <div class="Cell">           
        </div>
        <div class="Cell">
            <p><asp:Button ID="btnSubmit" data-id="btnSubmit" runat="server" Text="Add" OnClick="btnSubmit_Click" /></p>
            <p> <label id="lblMessage" runat="server"  visible="false"></label></p>
        </div>
    </div>
    </div>
</div></div>

     </div>
    </div>
</asp:content>
