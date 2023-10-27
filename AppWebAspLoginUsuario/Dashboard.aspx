<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="AppWebAspLoginUsuario.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>DashBoard</h1>
    <h2>Bem vindo <asp:Label ID="lblUser" runat="server" Text=""></asp:Label></h2>
        <table>
        <tr>
            <td>E-mail:</td>
            <td>
                <asp:TextBox ID="txbEmail" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Password:</td>
                <td><asp:TextBox ID="txbPass" runat="server"></asp:TextBox></td>
    
</tr>
        
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
            </td>
        </tr>
        
    </table>
    <br />
    <asp:GridView ID="grvUser" runat="server"></asp:GridView>
</asp:Content>
