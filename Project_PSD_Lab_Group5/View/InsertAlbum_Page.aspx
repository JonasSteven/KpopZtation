<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavigationBar.Master" AutoEventWireup="true" CodeBehind="InsertAlbum_Page.aspx.cs" Inherits="Project_PSD_Lab_Group5.View.InsertAlbum_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Insert Album</h1>
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
    <asp:Button ID="addAlbumBtn" runat="server" Text="Insert Album" OnClick="addAlbumBtn_Click" />
    <br />
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
</asp:Content>
