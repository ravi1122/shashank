<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddVaccine.aspx.cs" Inherits="MyDWeb.Modules.Vaccine.AddVaccine" %>


<asp:content runat="server" ContentPlaceHolderID="xyz">
<head>
    <title>Vaccines</title>

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
    <script src="../../Scripts/jquery-3.3.1.js"></script>
    <script>
        
        $(document).ready(function () {

        $("[data-id='btnOk']").click(function () {           
            location.reload();
        });

        });

        
        //$(document).ready(function () {
        //for (var i = 0; i < 20; i++) {
        //    $("[data-id=ddlminAge1]").append("<option>" + i + "</option>");
        //}
        //});

    </script>
</head>
<body>

<div style="display:table;margin-left:100px;">   
    <div style="display:table-row">
    <%--<form id="form1" runat="server">--%>
<div style="display:table-cell">
    <div style="margin-bottom:10px;">
        <div class="Title">
        <p>Vaccines</p>
    </div>
            <asp:GridView ID="grdVaccine" runat="server" AutoGenerateColumns="false" AllowPaging="True" OnPageIndexChanging="grdVaccine_PageIndexChanging" Width="750px">
                <HeaderStyle BackColor="#b6c3c3" ForeColor="Black" Font-Bold="true" />
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="MinAge" HeaderText="Minimum Age" />
                    <asp:BoundField DataField="MaxAge" HeaderText="Maximum Age" />
                    <asp:BoundField DataField="Dose" HeaderText="Dose" />
                </Columns>
                <PagerSettings Mode="NumericFirstLast"  Visible="true" PageButtonCount="5" FirstPageText="First" LastPageText="Last" />
            </asp:GridView>
    </div>
    </div>
        <div style="display:table-cell;">
            <div style="padding-left:60px;>
<div class="Table" style="margin-left: 30px; margin-top: 10px;background-image: '~/MyDStyles/img/stickey.jpg'" id="divNewVAccine" runat="server">
    <div class="Title">
        <p>Add New Vaccine</p>
    </div>
    <div class="Row">
        <div class="Cell">
            <p>Vaccine Name</p>
        </div>
        <div class="Cell">
            <input runat="server" type="text" id="txtName" data-id="txtName" />
        </div>
    </div>
    <div class="Row">
        <div class="Cell">
            <p>Minimum Age</p>
        </div>
        <div class="Cell">  
           <input runat="server" type="text" id="txtMinAge" data-id="txtMinAge" />
            <asp:RequiredFieldValidator ControlToValidate="txtMinAge" runat="server" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
            <%--<asp:RegularExpressionValidator ControlToValidate="txtMinAge" runat="server" ValidationExpression="[0-9]+(\.[0-9][0-9]?)?" ForeColor="Red" ErrorMessage="*"></asp:RegularExpressionValidator>--%>
        </div>
    </div>
        <div class="Row">
        <div class="Cell">
            <p>Maximum Age</p>
        </div>
        <div class="Cell">
            <input runat="server" type="text" id="txtMaxAge" data-id="txtMaxAge" />
             <asp:RequiredFieldValidator ControlToValidate="txtMaxAge" runat="server" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
            <%--<asp:RegularExpressionValidator ControlToValidate="txtMaxAge" runat="server" ValidationExpression="[0-9]+(\.[0-9][0-9]?)?" ForeColor="Red" ErrorMessage="*"></asp:RegularExpressionValidator>--%>
        </div>
    </div>

    <div class="Row">
        <div class="Cell">
            <p>Minimum Dose</p>
        </div>
        <div class="Cell">
            <input runat="server" type="text" id="txtDose" data-id="txtDose" />
             <%--<asp:RegularExpressionValidator ControlToValidate="txtDose" runat="server" ValidationExpression="[0-9]" ForeColor="Red" ErrorMessage="*"></asp:RegularExpressionValidator>--%>
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
                </div>
        </div>
   <%-- </form>--%>
       
            <div id="confirmation" visible="false" runat="server" style="margin-left: 194px;margin-top: 25px;">
               
                <br />
                <%--<asp:Button id="btnConfirmation" onclick="btnConfirmation_Click" Visible="false" runat="server" Text="OK"></asp:Button>--%>
                <button id="btnOk" data-id="btnOk">OK</button>
            </div>
            
</div>  
  </div>       
</body>
 </asp:content>