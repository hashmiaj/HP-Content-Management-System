<%@ Page Title="TList" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="TList.aspx.cs" Inherits="TestApp.TList"  EnableEventValidation="false" EnableViewState="true"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-left: 30px">
    <h2>Topic List</h2>
        <div>
           <asp:Label ID="Product" Text="Product Title" runat="server"></asp:Label>
           <asp:DropDownList ID="DDL29" runat="server" Width="90px"></asp:DropDownList>
        </div>
    <h3>Import EXCEL file to Database</h3>
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="prod" runat="server" Text="Product"></asp:Label>
                    <asp:TextBox ID="ProductName" runat="server"></asp:TextBox>
                </td>
                <td>Select File : </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                <td>
                    <asp:Button ID="btn" runat="server" Text="Import Data"  OnClick="btn_Click"/>
                </td>
                <td>
                    <asp:Label ID="label" runat="server" Text="Search From Column"></asp:Label>
                    <asp:DropDownList runat="server" ID="ColumnsDDL"></asp:DropDownList>
                    <asp:TextBox runat="server" ID="searchColumn"></asp:TextBox>
                    <asp:Button runat="server" Text="Search" ID="btnSearch" OnClick="btnSearch_Click" />
                </td>
                <%--
                <script id="script">
                        function alerting () {
                            var productName = $('#ProductName').text();

                            if (productName == '') {
                                alert('Please enter a product name');
                                $('#btn').prop('disabled', true);
                                console.log('Please enter a product name');
                                return false;
                            }
                            else {
                                $('#btn').prop('disabled', false);
                            }
                        };
                    </script>

                    --%>
            </tr>
        </table>
    </div>
    <div id="lbl">
        <br />
        <asp:Label ID="lblMessage" runat="server" Font-Bold="true" />
        <br />
        <br />
        <asp:Button ID="addRow" runat="server" Text="Add Row" OnClick="AddRow_Click" />
        <br />
    </div>

    <div>
        <table class="table table-hover">
            <tr>
                <td style="width:auto">
                    <asp:Label ID="ProductSelection" runat="server" Text="Product Selection"></asp:Label>
                    <asp:DropDownList ID="DDL1" runat="server" Width="90px"></asp:DropDownList>
                </td>
                <td style="width:auto">
                    <asp:Label ID="Web" runat="server" Text="Web"></asp:Label>
                    <asp:DropDownList ID="DDL2" runat="server" Width="90px"></asp:DropDownList>
                </td>
                <td style="width:auto">
                    <asp:Label ID="Intellifix" runat="server" Text="Intellifix"></asp:Label>
                    <asp:DropDownList ID="DDL3" runat="server" Width="90px"></asp:DropDownList>
                </td>
                <td style="width:auto">
                    <asp:Label ID="UG" runat="server" Text="UG"></asp:Label>
                    <asp:DropDownList ID="DDL5" runat="server" Width="90px"></asp:DropDownList>
                </td>
                <td style="width:auto">
                    <asp:Label ID="WLG" runat="server" Text="WLG"></asp:Label>
                    <asp:DropDownList ID="DDL6" runat="server" Width="90px"></asp:DropDownList>
                </td>
                <td style="width:auto">
                    <asp:Label ID="SRM" runat="server" Text="SRM"></asp:Label>
                    <asp:DropDownList ID="DDL7" runat="server" Width="90px"></asp:DropDownList>
                </td>
                <td style="width:auto">
                    <asp:Label ID="OnsiteInstallGuide" runat="server" Text="Onsite Install Guide"></asp:Label>
                    <asp:DropDownList ID="DDL8" runat="server" Width="90px"></asp:DropDownList>
                </td>
                <td style="width:auto">
                    <asp:Label ID="WBT1_3" runat="server" Text="WBT 1-3"></asp:Label>
                    <asp:DropDownList ID="DDL10" runat="server" Width="90px"></asp:DropDownList>
                </td>
                <td style="width:auto">
                    <asp:Label ID="WBT4_6" runat="server" Text="WBT 4-6"></asp:Label>
                    <asp:DropDownList ID="DDL11" runat="server" Width="90px"></asp:DropDownList>
                </td>
            </tr>
        </table>

        <div>
            <table class="table table-hover">
                <tr>
                    <td style="width:auto">
                        <asp:Label ID="ProductSource" runat="server" Text="Product Source"></asp:Label>
                        <asp:DropDownList ID="DDL16" runat="server" Width="90px"></asp:DropDownList>
                    </td>
                    <td style="width:auto">
                        <asp:Label ID="DocumentSource" runat="server" Text="Document Source"></asp:Label>
                        <asp:DropDownList ID="DDL17" runat="server" Width="90px"></asp:DropDownList>
                    </td>
                    <td style="width:auto">
                        <asp:Label ID="Core" runat="server" Text="Core"></asp:Label>
                        <asp:DropDownList ID="DDL18" runat="server" Width="90px"></asp:DropDownList>
                    </td>
                    <td style="width:auto">
                        <asp:Label ID="ProLEorEnterprise" runat="server" Text="Pro/LE or Enterprise"></asp:Label>
                        <asp:DropDownList ID="DDL22" runat="server" Width="90px"></asp:DropDownList>
                    </td>
                    <td style="width:auto">
                        <asp:Label ID="Asset" runat="server" Text="Asset"></asp:Label>
                        <asp:DropDownList ID="DDL23" runat="server" Width="90px"></asp:DropDownList>
                    </td>
                    <td style="width:auto">
                        <asp:Label ID="DisclosureLevel" runat="server" Text="Disclosure Level"></asp:Label>
                        <asp:DropDownList ID="DDL24" runat="server" Width="90px"></asp:DropDownList>
                    </td>
                    <td style="width:auto">
                        <asp:Label ID="AquentGrouping" Text="Aquent Grouping" runat="server"></asp:Label>
                        <asp:DropDownList ID="DDL27" runat="server" Width="90px"></asp:DropDownList>
                    </td>
                    <td style="width:auto">
                        <asp:Label ID="Onboarded" Text="Onboarded" runat="server"></asp:Label>
                        <asp:DropDownList ID="DDL28" runat="server" Width="90px"></asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="table table-hover">
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label1" runat="server" Text="Status" Visible="false"></asp:Label>
                        <asp:DropDownList ID="DDL25" runat="server" Width="90px" Visible="false"></asp:DropDownList>
                    </td>
                    <td style="width: 100px">
                        <asp:Label ID="Label2" runat="server" Text="Owner/PM" Visible="false"></asp:Label>
                        <asp:DropDownList ID="DDL26" runat="server" Width="90px" Visible="false"></asp:DropDownList>
                    </td>
                    <td style="width: 100px">
                        <asp:Label ID="DesignTeamNotes" runat="server" Text="Design Team Notes" Visible="false"></asp:Label>
                        <asp:DropDownList ID="DDL19" runat="server" Width="90px" Visible="false"></asp:DropDownList>
                    </td>
                    <td style="width: 100px">
                        <asp:Label ID="ProjectManagerNotes" runat="server" Text="Project Manager Notes" Visible="false"></asp:Label>
                        <asp:DropDownList ID="DDL20" runat="server" Width="90px" Visible="false"></asp:DropDownList>
                    </td>
                    <td style="width: 100px">
                        <asp:Label ID="SMEPartnerNotes" runat="server" Text="SME/Partner Notes" Visible="false"></asp:Label>
                        <asp:DropDownList ID="DDL21" runat="server" Width="90px" Visible="false"></asp:DropDownList>
                    </td>
                    <td style="width: 100px">
                        <asp:Label ID="title" runat="server" Text="Title" Visible="false"></asp:Label>
                        <asp:DropDownList ID="DDL12" runat="server" Width="90px" Visible="false"></asp:DropDownList>
                    </td>
                    <td style="width: 100px">
                        <asp:Label ID="ConcenctraID" runat="server" Text="Concentra ID" Visible="false"></asp:Label>
                        <asp:DropDownList ID="DDL13" runat="server" Width="90px" Visible="false"></asp:DropDownList>
                    </td>
                    <td style="width: 100px">
                        <asp:Label ID="Link" runat="server" Text="Link ID" Visible="false"></asp:Label>
                        <asp:DropDownList ID="DDL14" runat="server" Width="90px" Visible="false"></asp:DropDownList>
                    </td>
                    <td style="width: 100px">
                        <asp:Label ID="BrightcoveLink" runat="server" Text="Brightcove Link" Visible="false"></asp:Label>
                        <asp:DropDownList ID="DDL15" runat="server" Width="90px" Visible="false"></asp:DropDownList>
                    </td>
                    <td style="width: 100px">
                        <asp:Label ID="IssueSignature" runat="server" Text="Issue Signature" Visible="false"></asp:Label>
                        <asp:DropDownList ID="DDL4" runat="server" Width="90px" Visible="false"></asp:DropDownList>         
                    </td>
                    <td style="width: 100px">
                        <asp:Label ID="STR" runat="server" Text="STR" Visible="false"></asp:Label>
                        <asp:DropDownList ID="DDL9" runat="server" Width="90px" Visible="false"></asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>

        <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click"/>
        <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click"/>
    </div>
        <div>
            <asp:DataGrid runat="server" ID="dataGrid" HeaderStyle-Font-Bold="true" AutoGenerateColumns="false" CellPadding="4" 
                OnCancelCommand="dataGrid_CancelCommand" PageSize="50" AllowPaging="false" OnDeleteCommand="dataGrid_DeleteCommand" 
                OnEditCommand="dataGrid_EditCommand" OnUpdateCommand="dataGrid_UpdateCommand" AllowSorting="true" OnSortCommand="dataGrid_Sorting">
                <Columns>
                    <asp:EditCommandColumn EditText="Edit" CancelText="Cancel" UpdateText="Update" HeaderText="Edit"></asp:EditCommandColumn>
                    <asp:ButtonColumn  CommandName="Delete" HeaderText="Delete" Text="Delete"></asp:ButtonColumn>
                    <asp:BoundColumn HeaderText="Document ID" DataField="ID" SortExpression="ID"/>
                    <asp:BoundColumn HeaderText="Product Selection" DataField="ProductSelection" SortExpression="ProductSelection" />
                    <asp:BoundColumn HeaderText="Web" DataField="Web" SortExpression="Web"/>
                    <asp:BoundColumn HeaderText="Intellifix" DataField="Intellifix" SortExpression="Intellifix" />
                    <asp:BoundColumn HeaderText="Issue Signature" DataField="IssueSignature" SortExpression="IssueSignature" />
                    <asp:BoundColumn HeaderText="UG" DataField="UG" SortExpression="UG"/>
                    <asp:BoundColumn HeaderText="WLG" DataField="WLG" SortExpression="WLG"/>
                    <asp:BoundColumn HeaderText="SRM" DataField="SRM" SortExpression="SRM"/>
                    <asp:BoundColumn HeaderText="Onsite Install Guide" DataField="OnsiteInstallGuide" SortExpression="OnsiteInstallGuide" />
                    <asp:BoundColumn HeaderText="STR" DataField="STR" SortExpression="STR" />
                    <asp:BoundColumn HeaderText="WBT 1-3" DataField="WBT1_3" SortExpression="WBT1_3" />
                    <asp:BoundColumn HeaderText="WBT 4-6" DataField="WBT4_6" SortExpression="WBT4_6" />
                    <asp:BoundColumn HeaderText="Title" DataField="Title" SortExpression="Title" />
                    <asp:BoundColumn HeaderText="Concentra ID" DataField="ConcentraID" SortExpression="ConcentraID" />
                    <asp:BoundColumn HeaderText="Link" DataField="Link" SortExpression="Link" />
                    <asp:BoundColumn HeaderText="Brightcove Link" DataField="BrightcoveLink" SortExpression="BrightcoveLink" />
                    <asp:BoundColumn HeaderText="Product Source" DataField="ProductSource" SortExpression="ProductSource"/>
                    <asp:BoundColumn HeaderText="Document Source" DataField="DocumentSource" SortExpression="DocumentSource" />
                    <asp:BoundColumn HeaderText="Core" DataField="Core" SortExpression="Core" />
                    <asp:BoundColumn HeaderText="Design Team Notes" DataField="DesignTeamNotes" SortExpression="DesignTeamNotes" />
                    <asp:BoundColumn HeaderText="Project Manager Notes" DataField="ProjectManagerNotes" SortExpression="ProjectManagerNotes" />
                    <asp:BoundColumn HeaderText="SME/Partner Notes" DataField="SMEPartnerNotes" SortExpression="SMEPartnerNotes" />
                    <asp:BoundColumn HeaderText="Pro/LE or Enterprise" DataField="ProLeEnterprise" SortExpression="ProLeEnterprise"/>
                    <asp:BoundColumn HeaderText="Asset" DataField="Asset" SortExpression="Asset" />
                    <asp:BoundColumn HeaderText="Disclosure level" DataField="DisclosureLevel" SortExpression="DisclosureLevel"/>
                    <asp:BoundColumn HeaderText="Status" DataField="Status" SortExpression="Status" />
                    <asp:BoundColumn HeaderText="Owner/PM" DataField="OwnerPM" SortExpression="OwnerPM" />
                    <asp:BoundColumn HeaderText="Aquent Grouping" DataField="AquentGrouping" SortExpression="AquentGrouping" />
                    <asp:BoundColumn HeaderText="Onboarded" DataField="Onboarded" SortExpression="Onboarded" />
                    <asp:BoundColumn HeaderText="Embedded Links" DataField="EmbeddedLinks" SortExpression="EmbeddedLinks" />
                    <asp:BoundColumn HeaderText="Business Defined Properties" DataField="BDP" SortExpression="BDP"/>
                    <asp:BoundColumn HeaderText="Product Title" DataField="ProductTitle" SortExpression="ProductTitle" />
                </Columns>
            </asp:DataGrid>
            <br />
            <br />
        </div>
        <div id="gridDiv" style="float:left;">

         <%--
        <asp:GridView runat="server" ID="grid" AutoGenerateColumns="false"  DataKeyNames="ID">
            <Columns>
                <asp:BoundField HeaderText="Document ID" DataField="ID" Visible="false"/>
                <asp:BoundField HeaderText="Product Selection" DataField="ProductSelection" />
                <asp:BoundField HeaderText="Web" DataField="Web" />
                <asp:BoundField HeaderText="Intellifix" DataField="Intellifix" />
                <asp:BoundField HeaderText="Issue Signature" DataField="IssueSignature" />
                <asp:BoundField HeaderText="UG" DataField="UG" />
                <asp:BoundField HeaderText="WLG" DataField="WLG" />
                <asp:BoundField HeaderText="SRM" DataField="SRM" />
                <asp:BoundField HeaderText="Onsite Install Guide" DataField="OnsiteInstallGuide" />
                <asp:BoundField HeaderText="STR" DataField="STR" />
                <asp:BoundField HeaderText="WBT 1-3" DataField="WBT1_3" />
                <asp:BoundField HeaderText="WBT 4-6" DataField="WBT4_6" />
                <asp:BoundField HeaderText="Title" DataField="Title" />
                <asp:BoundField HeaderText="Concentra ID" DataField="ConcentraID" />
                <asp:BoundField HeaderText="Link" DataField="Link" />
                <asp:BoundField HeaderText="Brightcove Link" DataField="BrightcoveLink" />
                <asp:BoundField HeaderText="Product Source" DataField="ProductSource" />
                <asp:BoundField HeaderText="Document Source" DataField="DocumentSource" />
                <asp:BoundField HeaderText="Core" DataField="Core" />
                <asp:BoundField HeaderText="Design Team Notes" DataField="DesignTeamNotes" />
                <asp:BoundField HeaderText="Project Manager Notes" DataField="ProjectManagerNotes" />
                <asp:BoundField HeaderText="SME/Partner Notes" DataField="SMEPartnerNotes" />
                <asp:BoundField HeaderText="Pro/LE or Enterprise" DataField="ProLeEnterprise" />
                <asp:BoundField HeaderText="Asset" DataField="Asset" />
                <asp:BoundField HeaderText="Disclosure level" DataField="DisclosureLevel" />
                <asp:BoundField HeaderText="Status" DataField="Status" />
                <asp:BoundField HeaderText="Owner/PM" DataField="OwnerPM" />
                <asp:BoundField />
                <asp:BoundField />
                <asp:BoundField />
                <asp:BoundField />
                <asp:BoundField />
                <asp:BoundField />
                <asp:BoundField />
                <asp:BoundField />
                <asp:BoundField />
                <asp:BoundField />
                <asp:BoundField />
                <asp:BoundField />
                <asp:BoundField />
                <asp:BoundField />
                <asp:BoundField />
                <asp:BoundField />
                <asp:BoundField />
                <asp:BoundField />
                <asp:BoundField />
                <asp:BoundField />
                <asp:BoundField />
                <asp:BoundField />
                <asp:BoundField />
                <asp:BoundField />


            </Columns>

        </asp:GridView>

             --%>
            <div>
        <asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click"/>
    </div>
    </div>
        </div>
</asp:Content>

