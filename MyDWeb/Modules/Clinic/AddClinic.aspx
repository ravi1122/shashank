<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddClinic.aspx.cs" MasterPageFile="~/Site.Master" Inherits="MyDWeb.Modules.Clinic.AddClinic" %>

<asp:content runat="server" ContentPlaceHolderID="xyz">
<head>
    <title>Clinics</title>

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
    <%--<form id="form1" runat="server">--%>
<div style="display:table-cell">


    <div style="margin-bottom:10px;">
        <div class="Title">
        <p>Clinics</p>
    </div>
            <asp:GridView ID="grdClinics" runat="server" AutoGenerateColumns="false" AllowPaging="True" Width="750px">
                <HeaderStyle BackColor="#b6c3c3" ForeColor="Black" Font-Bold="true" />
                <Columns>
                    <%--<asp:BoundField DataField="Name" HeaderText="Name" />--%>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>                   
                            <asp:HyperLink runat="server" ID="btnGo" Text='<%# Eval("Name") %>' 
                                 NavigateUrl='<%# "Doctors.aspx?id=" + Eval("ClinicId") %>' />                           
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="OpenTime" HeaderText="Open Time" />
                    <asp:BoundField DataField="CloseTime" HeaderText="Close Time" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:BoundField DataField="ClinicId" Visible="false" />
                </Columns>
                <PagerSettings Mode="NumericFirstLast"  Visible="true" PageButtonCount="5" FirstPageText="First" LastPageText="Last" />
            </asp:GridView>
    </div>


    </div>


       <div style="display:table-cell;">
            <div style="padding-left:60px;>
<div class="Table" style="margin-left: 30px; margin-top: 10px;background-image: '~/MyDStyles/img/stickey.jpg'" id="divNewClinic" runat="server">
    <div class="Title">
        <p>Add New Clinic</p>
    </div>

   <div class="Row">
        <div class="Cell">
            <p>Name</p>
        </div>
        <div class="Cell">
            <input runat="server" type="text" id="txtClinicName" data-id="txtClinicName" />
        </div>
    </div>


   <div class="Row">
        <div class="Cell">
            <p>Address</p>
        </div>
        <div class="Cell">
            <input runat="server" type="text" id="txtAddress" data-id="txtAddress" />
        </div>
       </div>

   <div class="Row">
        <div class="Cell">
            <p>Reg. No.</p>
        </div>
        <div class="Cell">
            <input runat="server" type="text" id="txtRegNo" />
        </div>
       </div>

   <div class="Row">
        <div class="Cell">
            <p>Email</p>
        </div>
        <div class="Cell">
            <input runat="server" type="text" id="txtEmail" />
        </div>
       </div>

   <div class="Row">
        <div class="Cell">
            <p>City</p>
        </div>
        <div class="Cell">
            <input runat="server" type="text" id="txtCity" data-id="txtCity" />
        </div>
       </div>

   <div class="Row">
        <div class="Cell">
            <p>State</p>
        </div>
        <div class="Cell">
            <input runat="server" type="text" id="txtState" data-id="txtState" />
        </div>
       </div>

   <div class="Row">
        <div class="Cell">
            <p>Country</p>
        </div>
        <div class="Cell">
            <input runat="server" type="text" id="txtCountry" data-id="txtCountry" />
        </div>
       </div>

   <div class="Row">
        <div class="Cell">
            <p>Pin Code</p>
        </div>
        <div class="Cell">
            <input runat="server" type="text" id="txtPinCode" data-id="txtPinCode" />
        </div>
       </div>

   <div class="Row">
        <div class="Cell">
            <p>OpenTime</p>
        </div>
        <div class="Cell">
            <input runat="server" type="text" id="txtOpenTime" >
        </div>
       </div>

   <div class="Row">
        <div class="Cell">
            <p>Close Time</p>
        </div>
        <div class="Cell">
            <input runat="server" type="text" id="txtCloseTime" />
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
</div></div></div>


     </div>

</div>

    </asp:Content>
