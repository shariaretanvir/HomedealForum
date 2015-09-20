<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineForum.Master" AutoEventWireup="true" CodeBehind="UserRegister.aspx.cs" Inherits="OnlineForum.UserRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainContainer">
        <div class="containerCaption">

            <label style="font-family: Cambria; font-size: 20px;">Provide your basic informations</label>

        </div>
        <div class="mainContent">
            <div class="tableHolder">
                <asp:Table runat="server" class="regesterTable">
                    <asp:TableRow runat="server">
                        <asp:TableCell CssClass="regLable">Name</asp:TableCell>
                        <asp:TableCell>:</asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox runat="server" CssClass="regTxtBox" ID="userNameTextBox" AutoCompleteType="Disabled" placeholder="User's Short Name"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow1" runat="server">
                        <asp:TableCell CssClass="regLable">Email</asp:TableCell>
                        <asp:TableCell>:</asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox runat="server" CssClass="regTxtBox" ID="mailTextBox" AutoCompleteType="Disabled" placeholder="E-mail address"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow2" runat="server">
                        <asp:TableCell CssClass="regLable">Phone no</asp:TableCell>
                        <asp:TableCell>:</asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox runat="server" CssClass="regTxtBox" ID="phoneTextBox" AutoCompleteType="Disabled" placeholder="Phone number"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow3" runat="server">
                        <asp:TableCell CssClass="regLable">Password</asp:TableCell>
                        <asp:TableCell>:</asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox runat="server" CssClass="regTxtBox" ID="passwordTextBox" AutoCompleteType="Disabled" placeholder="Password"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell></asp:TableCell>
                        <asp:TableCell></asp:TableCell>
                        <asp:TableCell><asp:Button runat="server" Text="Register" ID="registerButton" OnClick="registerButton_Click" />
            </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
        </div>

    </div>
</asp:Content>
