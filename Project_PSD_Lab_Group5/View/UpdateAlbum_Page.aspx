<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavigationBar.Master" AutoEventWireup="true" CodeBehind="UpdateAlbum_Page.aspx.cs" Inherits="Project_PSD_Lab_Group5.View.UpdateAlbum_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Update Album Page</h1>
    <asp:Image ID="albumImage" runat="server" Height="150px" Width="150px" />
    <br />
    <asp:Label ID="Label6" runat="server" Text="Album Name : "></asp:Label>
    <asp:Label ID="lblAlbumName" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="Label7" runat="server" Text="Album Description : "></asp:Label>
    <asp:Label ID="lblAlbumDesc" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="Label8" runat="server" Text="Album Price : "></asp:Label>
    <asp:Label ID="lblAlbumPrice" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="Label9" runat="server" Text="Album Stock : "></asp:Label>
    <asp:Label ID="lblAlbumStock" runat="server" Text="Label"></asp:Label>

    <br />
    <asp:Label ID="Label1" runat="server" Text="Name : "></asp:Label>
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Description : "></asp:Label>
    <asp:TextBox ID="txtDesc" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Price : "></asp:Label>
    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Stock : "></asp:Label>
    <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Image Upload : "></asp:Label>
    <asp:FileUpload ID="imageUpload" runat="server" />
    <br />
    <br />
    <asp:Button ID="updateAlbumBtn" runat="server" Text="Update Album" OnClick="updateAlbumBtn_Click" />
    <br />
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
</asp:Content>
