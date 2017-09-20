<%@ Page Title="Concentra" MasterPageFile="~/Site.Master"  Language="C#" AutoEventWireup="true" CodeBehind="Concentra.aspx.cs" Inherits="TestApp.Concentra" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Import Excel File to Database</h3>
        <div>
        <table>
            <tr>
                <td>Select File : </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                <td>
                    <asp:Button ID="btn" runat="server" Text="Import Data"  OnClick="btn_Click"/>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table style="width:420px;">

        </table>
    </div>
    <div>
        <br />
        <asp:Label ID="lblMessage" runat="server" Font-Bold="true"></asp:Label>
        <%-- 
        <asp:GridView ID="grid" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Document Name" DataField="DocumentName" />
                <asp:BoundField HeaderText="Title" DataField="TItle" />
                <asp:BoundField HeaderText="Collection Type" DataField="CollectionType" />
                <asp:BoundField HeaderText="Language" DataField="Language" />
                <asp:BoundField HeaderText="Collection ID" DataField="CollectionID" />
                <asp:BoundField HeaderText="Content Management Group (CMG)" DataField="CMG" />
                <asp:BoundField HeaderText="Disclosure Level" DataField="DisclosureLevel" />
                <asp:BoundField HeaderText="Document Type" DataField="DocumentType" />
                <asp:BoundField HeaderText="Document Type Detail" DataField="DocumentTypeDetail" />
                <asp:BoundField HeaderText="Regions" DataField="Regions" />
                <asp:BoundField HeaderText="Topic Categories" DataField="TopicCategories" />
                <asp:BoundField HeaderText="Publication Code" DataField="PublicationCode" />
                <asp:BoundField HeaderText="Content Topic" DataField="ContentTopic" />
                <asp:BoundField HeaderText="Search Keywords" DataField="SearchKeywords" />
                <asp:BoundField HeaderText="Embedded Links" DataField="EmbeddedLinks" />
                <asp:BoundField HeaderText="Publication Destinations" DataField="PublicationDestinations" />
                <asp:BoundField HeaderText="Product Line" DataField="ProductLines" />
                <asp:BoundField HeaderText="Original Filename" DataField="OriginalFilename" />
                <asp:BoundField HeaderText="Business Defined Properties" DataField="BusinessDefinedProperties" />
                <asp:BoundField HeaderText="Authors" DataField="Authors" />
                <asp:BoundField HeaderText="Content Version" DataField="ContentVersion" />
                <asp:BoundField HeaderText="Version Label" DataField="VersionLabel" />
                <asp:BoundField HeaderText="Project Name" DataField="ProjectName" />
                <asp:BoundField HeaderText="Collection Master ID" DataField="CollectionMasterID" />
                <asp:BoundField HeaderText="Creation Date" DataField="CreationDate" />
                <asp:BoundField HeaderText="Content Update Date" DataField="ContentUpdateDate" />


            </Columns>
        </asp:GridView>

            --%>
    </div>
</asp:Content>