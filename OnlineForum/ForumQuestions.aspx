<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineForum.Master" AutoEventWireup="true" CodeBehind="ForumQuestions.aspx.cs" Inherits="OnlineForum.MobileForum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mainContainer">
        <div class="containerCaption">
           
                <label style="font-family:Cambria;font-size:20px;">Electronics > Mobile</label>
           
        </div>
        <div class="mainContent">
            <div class="questionsDiv">
            
            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <asp:Table ID="Table1" runat="server">
                                        <asp:TableRow ID="TableRow1" runat="server" >
                                            <asp:TableCell runat="server"><asp:image runat="server" ImageUrl="Images/question.png" /> </asp:TableCell>
                                            <asp:TableCell ID="TableCell1" runat="server" CssClass="questionBlocks">
                                               
                                                <a href="QuestionDeatils.aspx?id=<%#Eval("qId").ToString() %>" id='<%#Eval("qId") %>'><asp:Label ID="Label2" runat="server" Text='<%#Eval("question") %>'></asp:Label></a>
                                            </asp:TableCell>
                                           
                                        </asp:TableRow>
                                    </asp:Table>
                                </ItemTemplate>
                            </asp:Repeater>
            
            </div>
            
         </div>

    </div>

</asp:Content>
