<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MyDWeb.Modules.Home" %>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
   

</head> --%>

    <asp:content runat="server" ContentPlaceHolderID="xyz">
        <body>
 <style>
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

    .OptionBox{
  border: 0px solid;
  padding: 10px;
  box-shadow: 5px 10px #e6e6e6;
  background-color:#f2f2f2;
  height:200px;
  width:250px;
  margin-left:420px;
    }
 </style>         
<asp:HiddenField ID="hdnFName" runat="server" />
<asp:HiddenField ID="hdnLname" runat="server" />
            <asp:HiddenField ID="hdnEmail" runat="server" />
            <asp:HiddenField ID="hdnUserType" runat="server" />
            <asp:HiddenField ID="hdnDOB" runat="server" />

<div style="margin-left:100px;">
<div style="display:table-row">

    <div style="display:table-cell">
        <br />
    <img src="../Image/login.png" height="150px" width="150px"></img>              
    </div>
                <div style="display:table-cell">
                    <br />
<div class="Table" id="divNewVAccine" runat="server" style="margin-left: 25px;">
    <div class="Title">
        <p>My Details</p>
    </div>
    <div class="Row">
        <div class="Cell">
            <p><b>First Name</b></p>
        </div>
        <div class="Cell">
            <%= (hdnFName.Value) %>
        </div>
    </div>
    <div class="Row">
        <div class="Cell">
            <p><b>Last Name</b></p>
        </div>
        <div class="Cell">          
            <%= (hdnLname.Value) %>
        </div>
    </div>
        <div class="Row">
        <div class="Cell">
            <p><b>User Type</b></p>
        </div>
        <div class="Cell">
             <%= (hdnUserType.Value) %>
        </div>
    </div>

    <div class="Row">
        <div class="Cell">
            <p><b>Date of Birth</b></p>
        </div>
        <div class="Cell">
             <%= (hdnDOB.Value) %>
        </div>
    </div>
    <div class="Row">
        <div class="Cell">   
            <p><b>Email</b></p>
        </div>
        <div class="Cell">
       <%= (hdnEmail.Value) %>
        </div>
    </div>
</div>
                </div>
<div style="display:table-cell;">
    <br />
                <div class="OptionBox">
             <asp:LinkButton runat="server" Visible="false" ID="lnkCreateUser" PostBackUrl="~/Modules/User/RegisterUser.aspx">User</asp:LinkButton>    
                <br />
            <asp:LinkButton runat="server" visible="false" ID="lnkVaccine" PostBackUrl="~/Modules/Vaccine/AddVaccine.aspx">Vaccine</asp:LinkButton>
                <br />
            <asp:LinkButton runat="server" ID="lnkInfants" PostBackUrl="~/Modules/Infants/MyInfants.aspx">My Infants</asp:LinkButton>
                    <br />
            <asp:LinkButton runat="server" ID="lnkClinic" PostBackUrl="~/Modules/Clinic/AddClinic.aspx">Clinics</asp:LinkButton>
                </div>
                
                </div>
    <br />
    </div>
            </div>
    <%--<form id="form1" runat="server">--%>
        <div style="margin-left:100px">
            <asp:GridView ID="grdPatients" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Name" DataField="PatientName" />
                    <asp:BoundField HeaderText="Sex" DataField="Sex" />
                    <asp:BoundField HeaderText="DOB" DataField="DOB" />
                    <asp:BoundField HeaderText="Assertion Number" DataField="AssertionNumber" />
                    <asp:BoundField HeaderText="Drawn" DataField="Drawn" />
                    <asp:BoundField HeaderText="Received" DataField="Received" />
                    <asp:BoundField HeaderText="Reported" DataField="Reported" />
                    <asp:BoundField HeaderText="DoctorName" DataField="DoctorName" />
                    <asp:BoundField HeaderText="Result" DataField="Result" />
              
                </Columns>
            </asp:GridView>
        </div>
  <%--  </form>--%>
</body>
    </asp:content>
<%--</html>--%>
