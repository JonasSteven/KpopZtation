<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavigationBar.Master" AutoEventWireup="true" CodeBehind="TransactionHistory_Page.aspx.cs" Inherits="Project_PSD_Lab_Group5.View.TransactionHistory_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Transaction History Page</h1>
    <asp:GridView ID="transactionGV" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="transactionId" HeaderText="Transaction ID" SortExpression="transactionId" />
            <asp:BoundField DataField="transactionDate" HeaderText="Transaction Date" SortExpression="transactionDate" />
            <asp:BoundField DataField="customerName" HeaderText="Customer Name" SortExpression="customerName" />
            <asp:BoundField DataField="courier" HeaderText="Courier" SortExpression="courier" />
            <asp:ImageField DataImageUrlField="albumImage" DataImageUrlFormatString="~/Assets/Albums/{0}" HeaderText="Album Image" ControlStyle-Height="150px" ControlStyle-Width="150px">
            </asp:ImageField>
            <asp:BoundField DataField="albumName" HeaderText="Album Name" SortExpression="albumName" />
            <asp:BoundField DataField="qty" HeaderText="Quantity" SortExpression="qty" />
            <asp:BoundField DataField="albumPrice" HeaderText="Album Price" SortExpression="albumPrice" />
        </Columns>
    </asp:GridView>
</asp:Content>
