<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavigationBar.Master" AutoEventWireup="true" CodeBehind="Home_Page.aspx.cs" Inherits="Project_PSD_Lab_Group5.View.Home_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Home Page</h1>
        <asp:Image ID="homeImage" runat="server" />
        <br />


        <asp:Repeater ID="cardRepeater" runat="server" OnItemCommand="cardRepeater_ItemCommand">
            <ItemTemplate>
            <tr>
                <td>
                    <img src="../Assets/Artists/<%# Eval("ArtistImage") %>" alt="..." style="height: 150px; width: 150px" />
                </td>
                <br />
                <td>
                    <%# Eval("ArtistName") %>
                </td>
                <br />
                <td>
                    <asp:Button ID="updateArtistBtn" runat="server" Text="Update Artist" CommandArgument='<%# Eval("ArtistID") %>' OnClick="updateArtistBtn_Click1" />

                    <asp:Button ID="deleteArtistBtn" runat="server" Text="Delete Artist" CommandArgument='<%# Eval("ArtistID") %>' OnClick="deleteArtistBtn_Click1" />

                    <asp:Button ID="viewArtistBtn" runat="server" Text="View Artist" CommandArgument='<%# Eval("ArtistID") %>' OnClick="viewArtistBtn_Click" />
                </td>
                <br />
                <br />
            </tr>
            </ItemTemplate>
        </asp:Repeater>
        <br />
        <br />
        <asp:Button ID="insertBtn" runat="server" Text="Insert Artist" OnClick="insertBtn_Click"/>
    </div>
</asp:Content>
