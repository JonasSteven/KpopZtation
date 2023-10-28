<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavigationBar.Master" AutoEventWireup="true" CodeBehind="UpdateProfile_Page.aspx.cs" Inherits="Project_PSD_Lab_Group5.View.UpdateProfile_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Update Profile Page</h1>
    <div>
        <asp:Label ID="Label6" runat="server" Text="Name : "></asp:Label>
        <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="Label8" runat="server" Text="Email : "></asp:Label>
        <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="Label10" runat="server" Text="Gender : "></asp:Label>
        <asp:Label ID="lblGender" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="Label12" runat="server" Text="Address : "></asp:Label>
        <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="Label14" runat="server" Text="Password : "></asp:Label>
        <asp:Label ID="lblPassword" runat="server" Text=""></asp:Label>
        <br />
        <br />


            <asp:Label ID="Label1" runat="server" Text="Name : "></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Email : "></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Gender : "></asp:Label>
            <asp:RadioButtonList ID="rbl_gender" runat="server">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Address : "></asp:Label>
            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Password : "></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Button ID="btnUpdate" runat="server" Text="Update Profile" OnClick="btnUpdate_Click"/>
            <asp:Button ID="btnDelete" runat="server" Text="Delete Account" OnClick="btnDelete_Click" />
            <br />
            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
