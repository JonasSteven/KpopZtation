<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavigationBar.Master" AutoEventWireup="true" CodeBehind="UpdateArtist_Page.aspx.cs" Inherits="Project_PSD_Lab_Group5.View.UpdateArtist_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Update Artist Page</h1>
    <asp:Image ID="artistImage" runat="server" Height="150px" Width="150px" />
    <br />
    <asp:Label ID="artistName" runat="server" Text="" Font-Size="20px"></asp:Label>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Name : "></asp:Label>
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Artist Image"></asp:Label>
    <asp:FileUpload ID="imageUpload" runat="server" />
    <br />
    <asp:Button ID="insertArtistBtn" runat="server" Text="Update Artist" OnClick="insertArtistBtn_Click"/>
    <br />
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
</asp:Content>
