<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavigationBar.Master" AutoEventWireup="true" CodeBehind="ArtistDetail_Page.aspx.cs" Inherits="Project_PSD_Lab_Group5.View.ArtistDetail_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Artist Detail Page</h1>
    <div>
        <asp:Image ID="imageArtist" runat="server" Height="150px" Width="150px" />
        <br />

        <asp:Label ID="nameArtist" runat="server" Text="" Font-Size="20px"></asp:Label>

        <br />
        <br />
        <br />

        <asp:Repeater ID="cardRepeaterAlbum" runat="server" OnItemCommand="cardRepeaterAlbum_ItemCommand">
            <ItemTemplate>
                <img src="../Assets/Albums/<%# Eval("AlbumImage") %>" alt="..." style="height: 150px; width: 150px" />
                <br />
                <asp:Label ID="lblName" runat="server" Text='<%# "Album Name : "+Eval("AlbumName") %>'></asp:Label>
                <br />
                <asp:Label ID="lblDesc" runat="server" Text='<%# "Description : "+Eval("AlbumDescription") %>'></asp:Label>
                <br />
                <asp:Label ID="lblPrice" runat="server" Text='<%# "Price : "+Eval("AlbumPrice") %>'></asp:Label>

                <br />

                <asp:Button ID="updateAlbumBtn" runat="server" Text="Update Album" CommandArgument='<%# Eval("AlbumID") %>' OnClick="updateAlbumBtn_Click" />

                <asp:Button ID="deleteAlbumBtn" runat="server" Text="Delete Album" CommandArgument='<%# Eval("AlbumID") %>' OnClick="deleteAlbumBtn_Click" />

                <asp:Button ID="viewAlbumBtn" runat="server" Text="View Album" CommandArgument='<%# Eval("AlbumID") %>' OnClick="viewAlbumBtn_Click" />
                <br />
                <br />
            </ItemTemplate>
        </asp:Repeater>
        <br />
        <br />
        <asp:Button ID="insertBtn" runat="server" Text="Insert Album" OnClick="insertBtn_Click" />
    </div>
</asp:Content>
