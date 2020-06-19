<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InfantVaccine.aspx.cs" Inherits="MyDWeb.Modules.Infants.InfantVaccine" %>

<form id="form1" runat="server">
<div id="mainDiv" style="margin-left:200px;margin-right:200px;">
<div id="divHeader">

<div style="width: 100%; overflow: hidden;background-color:#b6c3c3"> 
    <div style="width: 150px; float: left;margin-left: 5px;margin-top: 5px;">  <%--background-color:aliceblue;--%>
<div id="divLogo">
    <img src="../../Image/defaultHospitalLogo.jpg"  height="100px" width="100px" />
</div>
    </div>
    <div>   <%--style="background-color:antiquewhite;"--%>
        <div style="text-align: center;font-size:xxx-large;font-weight:bold">
            <label id="lblClinicName" runat="server"></label>
            <br />
        </div>
        <div style="text-align: center;">
            <label id="lblClinicRegistrationNumber" runat="server"></label>
            <br />
            <label id="lblClinicAddress" runat="server"></label>
            <br />
            <label id="lblClinicEmail" runat="server"></label>
        </div>
    </div>
    <div id="divDoctorDetails" style="margin-left:5px">
        <label id="lblDoctorName" runat="server"></label>
        <br />
        <span>R No:</span><span runat="server" id="spnRNo"></span>&nbsp;&nbsp;&nbsp;<span id="spnSpecialization" runat="server"></span>
        <br />
        <span>Timings:</span><span id="spnTimings" runat="server"></span>
    </div>
</div>


<hr />
</div>
<div id="divImunitizationCard" style="height:400px;">

    <style>
        .InfantVaccine{
            /*margin-left: 135px;*/
    margin-top: 25px;
    margin-bottom: 25px;
        }
         .responsive-table {
             border-radius: 3px;
    padding: 25px 30px;
    display: flex;
    justify-content: space-between;
    margin-bottom: 25px;
    background-color: #3c5b6d73;
    font-size: 14px;
    text-transform: uppercase;
    letter-spacing: 0.03em;
  }
       .GridViewEditRow input[type=text] {width:70px; font-size: .9em} 
 
    </style>
    <asp:Button runat="server" id="btnHome" Text="Back to Home" OnClick="btnHome_Click"  />
<div class="InfantVaccine">
    <div class="responsive-table">
        <asp:gridview runat="server" id="grdVaccineReport" autogeneratecolumns="false" datakeynames="VaccineId"
            onrowediting="grdVaccineReport_RowEditing" onrowupdating="grdVaccineReport_RowUpdating"
            onrowcancelingedit="grdVaccineReport_RowCancelingEdit" allowpaging="true" onpageindexchanged="grdVaccineReport_PageIndexChanged"
            onpageindexchanging="grdVaccineReport_PageIndexChanging">
            <EditRowStyle CssClass="GridViewEditRow" /> 
                <Columns>                                                            
                    <asp:BoundField HeaderText="Vaccination" HeaderStyle-BackColor="#f2f2f2" ReadOnly="true" DataField="Vaccination" />
                    <asp:TemplateField HeaderText="Age(yrs)" HeaderStyle-BackColor="#f2f2f2">
                        <ItemTemplate><%#Eval("MinAge") %>-<%#Eval("MaxAge") %></ItemTemplate>                       
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Dose" HeaderStyle-BackColor="#f2f2f2" DataField="DoseCompleted" ItemStyle-Width="50px" />
                    <asp:BoundField HeaderText="Dose Taken On" HeaderStyle-BackColor="#f2f2f2" DataField="LastDoseTakenON" ItemStyle-Width="70px" />   
                    <%--<asp:TemplateField HeaderText="Last Dose Taken On">
                        <ItemTemplate>
                            <%#Eval("LastDoseTakenON") %>                    
                            </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtLastDoseTakenOn" runat="server"></asp:TextBox>
                    <asp:Calendar runat="server" ID='cal1' ></asp:Calendar>
                    </EditItemTemplate> 
                    </asp:TemplateField>--%>
                    <asp:BoundField HeaderText="Due On" HeaderStyle-BackColor="#f2f2f2" DataField="DueOn" ItemStyle-Width="70px" />
                    <asp:BoundField HeaderText="Weight" HeaderStyle-BackColor="#f2f2f2" DataField="Weight" ItemStyle-Width="50px" />
                    <asp:BoundField HeaderText="Remark" HeaderStyle-BackColor="#f2f2f2" DataField="Remark" ItemStyle-wrap="true" ItemStyle-Width="100%" />
                    <asp:BoundField HeaderText="VaccineId" DataField="VaccineId" Visible="false" ItemStyle-Width="50px" />   
                    <asp:CommandField ShowEditButton="true" UpdateText="Save"  HeaderStyle-BackColor="#f2f2f2" ShowCancelButton="true" ButtonType="link" ItemStyle-Width="50px" />
                </Columns>
            </asp:gridview>
    </div>
</div>
  
</div>

    <div style="background-color:#b6c3c3">
        <hr />
        <footer >
            <center><p>&copy; <%=( DateTime.Now.Year) %> - All Copy Right to MyD </p></center>
        </footer>
    </div>
</div>
  </form>