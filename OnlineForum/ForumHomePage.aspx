<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineForum.Master" AutoEventWireup="true" CodeBehind="ForumHomePage.aspx.cs" Inherits="OnlineForum.ForumHomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="css/OnlineForum.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="mainContainer">
        <div class="containerCaption">
            <label style="font-family:Cambria;font-size:30px;">Discussion Category...</label>
        </div>
        <div class="mainContent">
            <div class="contentCategory">
                <label style="font-family:Cambria;font-size:30px;">Electronics:<br /></label>
                
               &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp  &nbsp &nbsp &nbsp &nbsp &nbsp
                <label style="font-family:Cambria;font-size:20px;">Sub Categories:</label>
                    <a href="ForumQuestions.aspx?id=1" style="font-family:Cambria;font-size:20px;">Mobile</a>
                    <a href="ForumQuestions.aspx?id=2" style="font-family:Cambria;font-size:20px;">Television</a>
                    <a href="ForumQuestions.aspx?id=3" style="font-family:Cambria;font-size:20px;">Camera</a><br/>
                 &nbsp &nbsp &nbsp &nbsp &nbsp  &nbsp &nbsp &nbsp &nbsp &nbsp  &nbsp &nbsp &nbsp &nbsp &nbsp
                <label>Solution of problems of any electrical product is here in the HomeDeal Forum. Ask your problem's solution.</label>
                
            </div>
            <div class="contentCategory">
                <label style="font-family:Cambria;font-size:30px;">Cars/Vehicles</label>
            </div>
            <div class="contentCategory">
                <label style="font-family:Cambria;font-size:30px;">Others</label>
            </div>
        </div>

    </div>

</asp:Content>
