<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavigationBar.Master" AutoEventWireup="true" CodeBehind="InsertArtist_Page.aspx.cs" Inherits="Project_PSD_Lab_Group5.View.InsertArtist_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Insert Artist Page</h1>
    <asp:Label ID="Label1" runat="server" Text="Name : "></asp:Label>
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Artist Image"></asp:Label>
    <asp:FileUpload ID="imageUpload" runat="server" />
    <br />
    <asp:Button ID="insertArtistBtn" runat="server" Text="Insert Artist" OnClick="insertArtistBtn_Click"/>
    <br />
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
</asp:Content>
