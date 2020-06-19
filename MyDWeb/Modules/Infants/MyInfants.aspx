<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyInfants.aspx.cs" Inherits="MyDWeb.Modules.Infants.MyInfants" %>


<asp:Content runat="server" ContentPlaceHolderID="xyz">
    <style>
       
        .InfnatsUI {
            margin-top: 100px;
            margin-left: 500px;
            margin-bottom: 100px;
            font-weight: 500;
        }
    </style>
    <div class="InfnatsUI">
   <%--     <form id="form1" runat="server">--%>
            <div >
                <asp:GridView runat="server" ID="grdInfants" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderStyle-BackColor="#f2f2f2">
                            <ItemTemplate>
                                <img src="../../Image/login.jpeg" height="100px" width="100px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Id" DataField="Id" Visible="false" />
                        <asp:BoundField HeaderText="First Name"  HeaderStyle-BackColor="#f2f2f2" DataField="FName" />
                        <asp:BoundField HeaderText="Last Name"  HeaderStyle-BackColor="#f2f2f2" DataField="LName" />
                        <asp:BoundField HeaderText="Date of Birth"  HeaderStyle-BackColor="#f2f2f2" DataField="Dob" />
                        <asp:BoundField HeaderText="Sex"  HeaderStyle-BackColor="#f2f2f2" DataField="Sex" />
                        <asp:TemplateField HeaderStyle-BackColor="#f2f2f2">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkViewReport" runat="server" Text="View Report" PostBackUrl='<%# "InfantVaccine.aspx?id=" + Eval("Id") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
       <%-- </form>--%>
    </div>
</asp:Content>
