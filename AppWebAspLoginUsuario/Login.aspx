<%@ Page Title="Register" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AppWebAspLoginUsuario.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Login<center><asp:Label ID="lblMensagem" runat="server" BackColor="#990000" BorderColor="White" ForeColor="White"></asp:Label></center>
    </h1>
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
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /></td>
        </tr>
        
    </table>
</asp:Content>
