<%@Page Title="Doc Matrix" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Matrix.aspx.cs" Inherits="TestApp.Matrix" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-left: 30px">
    <h2>Doc Matrix</h2>
    <div>
        <asp:Label ID="Product" Text="Product Title" runat="server"></asp:Label>
        <asp:DropDownList ID="ProdDDL" runat="server" Width="90px"></asp:DropDownList>
    </div>
    <h3>Import EXCEL file to Database</h3>
    <div>
        <table>
            <tr>
                <td>Select File : </td>
                <td>
                    <asp:Label ID="prod" runat="server" Text="Product"></asp:Label>
                    <asp:TextBox ID="ProdName" runat="server" OnTextChanged="ProdName_TextChanged"></asp:TextBox>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                <td>
                    <asp:Button ID="btnImport" runat="server" Text="Import Data" OnClick="btnImport_Click"/>
                </td>
            </tr>
        </table>
    </div>
        <div>
            <table class="table table-hover">
                <tr>
                    <td style="width:auto">
                        <asp:Label ID="lbl1" runat="server" Text="Date Final"></asp:Label>
                        <asp:DropDownList ID="DDL1" runat="server" Width="90px"></asp:DropDownList>
                    </td>
                    <td style="width:auto">
                        <asp:Label ID="lbl2" runat="server" Text="Doc Discipline"></asp:Label>
                        <asp:DropDownList ID="DDL2" runat="server" Width="90px"></asp:DropDownList>
                    </td>
                    <td style="width:auto">
                        <asp:Label ID="lbl3" runat="server" Text="Document Type"></asp:Label>
                        <asp:DropDownList ID="DDL3" runat="server" Width="90px"></asp:DropDownList>
                    </td>
                    <td style="width:auto">
                        <asp:Label ID="lbl15" runat="server" Text="Document Name"></asp:Label>
                        <asp:DropDownList ID="DDL15" runat="server" Width="90px"></asp:DropDownList>
                    </td>
                    <td style="width:auto">
                        <asp:Label ID="lbl4" runat="server" Text="Product#"></asp:Label>
                        <asp:DropDownList ID="DDL4" runat="server" Width="90px"></asp:DropDownList>
                    </td>
                    <td style="width:auto">
                        <asp:Label ID="lbl5" runat="server" Text="Doc Part Number"></asp:Label>
                        <asp:DropDownList ID="DDL5" runat="server" Width="90px"></asp:DropDownList>
                    </td>
                    <td style="width:auto">
                        <asp:Label ID="lbl6" runat="server" Text="Doc Service Level"></asp:Label>
                        <asp:DropDownList ID="DDL6" runat="server" Width="90px"></asp:DropDownList>
                    </td>
                    <td style="width:auto">
                        <asp:Label ID="lbl7" runat="server" Text="Service Kit Part"></asp:Label>
                        <asp:DropDownList ID="DDL7" runat="server" Width="90px"></asp:DropDownList>
                    </td>
                    <td style="width:auto">
                        <asp:Label ID="lbl8" runat="server" Text="Concentra (PDF ID)"></asp:Label>
                        <asp:DropDownList ID="DDL8" runat="server" Width="90px"></asp:DropDownList>
                    </td>
                    <td style="width:auto">
                        <asp:Label ID="lbl9" runat="server" Text="Languages"></asp:Label>
                        <asp:DropDownList ID="DDL9" runat="server" Width="90px"></asp:DropDownList>
                    </td>
                    <td style="width:auto">
                        <asp:Label ID="lbl10" runat="server" Text="Supply Chain Strategy"></asp:Label>
                        <asp:DropDownList ID="DDL10" runat="server" Width="90px"></asp:DropDownList>
                    </td>
                    <td style="width:auto">
                        <asp:Label ID="lbl11" runat="server" Text="QR Code URL"></asp:Label>
                        <asp:DropDownList ID="DDL11" runat="server" Width="90px"></asp:DropDownList>
                    </td>
                    <td style="width:auto">
                        <asp:Label ID="lbl12" runat="server" Text="Linked Doc Concentra ID"></asp:Label>
                        <asp:DropDownList ID="DDL12" runat="server" Width="90px"></asp:DropDownList>
                    </td>
                    <td style="width:auto">
                        <asp:Label ID="lbl13" runat="server" Text="Video URL"></asp:Label>
                        <asp:DropDownList ID="DDL13" runat="server" Width="90px"></asp:DropDownList>
                    </td>
                    <td style="width:auto">
                        <asp:Label ID="lbl14" runat="server" Text="Comments"></asp:Label>
                        <asp:DropDownList ID="DDL14" runat="server" Width="90px"></asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
    <div>
        <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
        <asp:Button ID="btnReset" runat="server" Text="Reset"  OnClick="btnreset_Click"/>

        <br />
        <br />
        <asp:Label ID="lblMessage" runat="server" Font-Bold="true" />
        <br /> 
    </div>
    <div>
        <asp:DataGrid runat="server" ID="dataGrid" HeaderStyle-Font-Bold="true" AutoGenerateColumns="false" CellPadding="4"
             OnCancelCommand="dataGrid_CancelCommand" OnDeleteCommand="dataGrid_DeleteCommand" OnEditCommand="dataGrid_EditCommand" 
             OnUpdateCommand="dataGrid_UpdateCommand">
            <Columns>
                <asp:EditCommandColumn EditText="Edit" CancelText="Cancel" UpdateText="Update" HeaderText="Edit"></asp:EditCommandColumn>
                <asp:ButtonColumn  CommandName="Delete" HeaderText="Delete" Text="Delete"></asp:ButtonColumn>
                <asp:BoundColumn HeaderText="Matrix ID" DataField="MatrixID" />
                <asp:BoundColumn HeaderText="Date Final" DataField="DateFinal" />
                <asp:BoundColumn HeaderText="Doc Discipline" DataField="DocDiscipline" />
                <asp:BoundColumn HeaderText="Document Type" DataField="DocumentType" />
                <asp:BoundColumn HeaderText="Document Name" DataField="DocumentName" />
                <asp:BoundColumn HeaderText="Product#" DataField="ProductNumber" />
                <asp:BoundColumn HeaderText="Doc Part Number" DataField="DocPartNumber" />
                <asp:BoundColumn HeaderText="Doc Service Level" DataField="DocServiceLevel" />
                <asp:BoundColumn HeaderText="Service Kit Part" DataField="ServiceKitPart" />
                <asp:BoundColumn HeaderText="Concentra (PDF ID)" DataField="ConcentraPDFID" />
                <asp:BoundColumn HeaderText="Languages" DataField="Languages" />
                <asp:BoundColumn HeaderText="Supply Chain Strategy" DataField="SupplyChainStrategy" />
                <asp:BoundColumn HeaderText="QR Code URL" DataField="QRCodeURL" />
                <asp:BoundColumn HeaderText="Linked Doc Concentra ID" DataField="LinkDocConcentraID" />
                <asp:BoundColumn HeaderText="Video URL" DataField="VideoURL" />
                <asp:BoundColumn HeaderText="Comments" DataField="Comments" />
                <asp:BoundColumn HeaderText="Brightcove Link" DataField="BrightcoveLink" />
                <asp:BoundColumn HeaderText="Business Defined Properties" DataField="BDP" />
                <asp:BoundColumn HeaderText="Product Name" DataField="ProductName" />
            </Columns>
        </asp:DataGrid>
    </div>
    <div>
    </div>
    </div>
</asp:Content>