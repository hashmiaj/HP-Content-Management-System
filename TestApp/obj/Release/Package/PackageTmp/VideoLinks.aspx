<%@ Page Title="Video Links" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="VideoLinks.aspx.cs" Inherits="TestApp.VideoLinks" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Video Links</h2>
    <div>
        <table>
            <tr>
                <td>Select File : </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                <td>
                    <asp:Button ID="btnImport" runat="server" Text="Import Data" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:DataGrid runat="server" ID="dataGrid" HeaderStyle-Font-Bold="true" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundColumn HeaderText="Video ID" DataField="VideoID" />
                <asp:BoundColumn HeaderText="Title" DataField="Title"/>
                <asp:BoundColumn HeaderText="Brightcove Link" DataField="BrightcoveLink" />
                <asp:BoundColumn HeaderText="Youtube Link" DataField="YoutubeLink" />
                <asp:BoundColumn HeaderText="Concentra ID" DataField="ConcentraID"/>
                <asp:BoundColumn HeaderText="Concentra Doc Title"  DataField="ConcentraDocTitle"/>
            </Columns>
        </asp:DataGrid>
    </div>
</asp:Content>
