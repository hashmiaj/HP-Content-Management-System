<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddRow.aspx.cs" Inherits="TestApp.AddRow" %>

<asp:Content  ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-left: 30px">
        <h2>Add Row to Topic List</h2>
        <div>
            <table class="table table-hover">
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Product Selection"></asp:Label>
                        <asp:TextBox runat="server" ID="Box1" Text=" "></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label runat="server" Text="Web"></asp:Label>
                        <asp:TextBox runat="server" ID="Box2" Text=" "></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label runat="server" Text="Intellifix"></asp:Label>
                        <asp:TextBox runat="server" ID="Box3" Text=" "></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label runat="server" Text="Issue Signature"></asp:Label>
                        <asp:TextBox runat="server" ID="Box4" Text=" "></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label runat="server" Text="UG"></asp:Label>
                        <asp:TextBox runat="server" ID="Box5" Text=" "></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label runat="server" Text="WLG"></asp:Label>
                        <asp:TextBox runat="server" ID="Box6" Text=" "></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label runat="server" Text="SRM"></asp:Label>
                        <asp:TextBox runat="server" ID="Box7" Text=" "></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label runat="server" Text="Onsite Install Guide"></asp:Label>
                        <asp:TextBox runat="server" ID="Box8" Text=" "></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label runat="server" Text="STR"></asp:Label>
                        <asp:TextBox runat="server" ID="Box9" Text=" "></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label runat="server" Text="WBT 1-3"></asp:Label>
                        <asp:TextBox runat="server" ID="Box10" Text=" "></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label runat="server" Text="WBT 4-6"></asp:Label>
                        <asp:TextBox runat="server" ID="Box11" Text=" "></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="table table-hover">
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Title"></asp:Label>
                        <asp:TextBox runat="server" ID="Box12" Text=" "></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label runat="server" Text="Concentra ID"></asp:Label>
                        <asp:TextBox runat="server" ID="Box13" Text=" "></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label runat="server" Text="Link"></asp:Label>
                        <asp:TextBox runat="server" ID="Box14" Text=" "></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label runat="server" Text="Brightcove Link"></asp:Label>
                        <asp:TextBox runat="server" ID="Box15" Text=" "></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label runat="server" Text="Product Source"></asp:Label>
                        <asp:TextBox runat="server" ID="Box16" Text=" "></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label runat="server" Text="Document Source"></asp:Label>
                        <asp:TextBox runat="server" ID="Box17" Text=" "></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label runat="server" Text="Core"></asp:Label>
                        <asp:TextBox runat="server" ID="Box18" Text=" "></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label runat="server" Text="Design Team Notes"></asp:Label>
                        <asp:TextBox runat="server" ID="Box19" Height="100px" Width="200px" TextMode="MultiLine" Text=" "></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label runat="server" Text="Project Manager Notes"></asp:Label>
                        <asp:TextBox runat="server" ID="Box20" Height="100px" Width="200px" TextMode="MultiLine" Text=" "></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label runat="server" Text="SME/Partner Notes"></asp:Label>
                        <asp:TextBox runat="server" ID="Box21" Height="100px" Width="200px" TextMode="MultiLine" Text=" "></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="table table-hover">
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Pro/LE or Enterprise"></asp:Label>
                        <asp:TextBox runat="server" ID="Box22" Text=" "></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label runat="server" Text="Asset"></asp:Label>
                        <asp:TextBox runat="server" ID="Box23" Text=" "></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label runat="server" Text="Disclosure Level"></asp:Label>
                        <asp:TextBox runat="server" ID="Box24" Text=" "></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label runat="server" Text="Status"></asp:Label>
                        <asp:TextBox runat="server" ID="Box25" Text=" "></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label runat="server" Text="Owner"></asp:Label>
                        <asp:TextBox runat="server" ID="Box26" Text=" "></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClick="Submit_onClick" />
            <asp:Button runat="server" ID="btnCancel" Text="Cancel" OnClick="Cancel_onClick"/>
        </div>
    </div>

</asp:Content>
