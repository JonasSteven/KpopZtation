<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavigationBar.Master" AutoEventWireup="true" CodeBehind="Cart_Page.aspx.cs" Inherits="Project_PSD_Lab_Group5.View.Cart_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Cart Page</h1>
    <asp:Repeater ID="cartImageRepeater" runat="server" OnItemCommand="cartImageRepeater_ItemCommand">
        <ItemTemplate>
            <img src="../Assets/Albums/<%# GetAlbumImageById(Convert.ToInt32(Eval("AlbumID"))) %>" alt="" style="height: 150px; width: 150px" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Album Name : "></asp:Label>
            <asp:Label ID="lblName" runat="server" Text='<%# GetAlbumNameById(Convert.ToInt32(Eval("AlbumID"))) %>'></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Album Price : "></asp:Label>
            <asp:Label ID="lblPrice" runat="server" Text='<%# GetAlbumPriceById(Convert.ToInt32(Eval("AlbumID"))) %>'></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Album Quantity : "></asp:Label>
            <asp:Label ID="lblQty" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>
            <br />
            <asp:Button ID="removeItemBtn" runat="server" Text="Remove Item" CommandArgument='<%# Eval("CustomerID") %>' OnClick="removeItemBtn_Click" />
            <br />
            <br />
        </ItemTemplate>
    </asp:Repeater>
    <br />
    <br />
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    <asp:Button ID="checkoutBtn" runat="server" Text="Check Out" OnClick="checkoutBtn_Click" />
</asp:Content>
