<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavigationBar.Master" AutoEventWireup="true" CodeBehind="AlbumDetail_Page.aspx.cs" Inherits="Project_PSD_Lab_Group5.View.AlbumDetail_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Album Detail</h1>
    <div>
        <asp:Image ID="albumImage" runat="server" Height="150px" Width="150px" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Album Name : "></asp:Label>
        <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Album Description : "></asp:Label>
        <asp:Label ID="lblDesc" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Album Price : "></asp:Label>
        <asp:Label ID="lblPrice" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Album Stock : "></asp:Label>
        <asp:Label ID="lblStock" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblQty" runat="server" Text="Quantity : "></asp:Label>
        <asp:TextBox ID="txtQty" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="addCartBtn" runat="server" Text="Add To Cart" OnClick="addCartBtn_Click" />
        <br />
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
