<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineForum.Master" AutoEventWireup="true" CodeBehind="QuestionDeatils.aspx.cs" Inherits="OnlineForum.QuestionDeatils" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/OnlineForum.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mainContainer">
        <div class="containerCaption">

            <label style="font-family: Cambria; font-size: 20px;">Question...</label>

        </div>
        <div class="mainContent">
            <div class="userQuestion">

                <div class="queIcon">
                    <img src="Images/question.png" />
                    <asp:Label runat="server" ID="usreName"></asp:Label>

                    <asp:ImageButton runat="server" ID="fbShareButton" ImageUrl="Images/facebookShare.png" OnClick="fbShareButton_Click" />

                </div>
                <div class="que">
                    <asp:Label runat="server" ID="question"></asp:Label>

                </div>

            </div>
            <div class="comments">

                <div class="commentsOnQue">
                    <asp:Repeater ID="commentRepeater" runat="server">
                        <ItemTemplate>
                            <asp:Table runat="server" Style="border-bottom: 2px solid white;">
                                <asp:TableRow runat="server">
                                    <asp:TableCell CssClass="commenterNameBlock">
                                        <asp:Label runat="server" Style="width: 100px; font-family: Cambria; font-size: 18px" ID="commenterName" Text='<%#Eval("name") %>'></asp:Label>

                                    </asp:TableCell>
                                    <asp:TableCell runat="server" CssClass="commentLabel">
                                        <asp:Label runat="server" ID="comments" Text='<%#Eval("comment") %>'></asp:Label>
                                        <br />
                                        <asp:Label runat="server" ID="commentDate" Style="font-size: 10px; color: #808080;" Text='<%#Eval("commentDate") %>'></asp:Label>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>


                <div class="commentingDiv">

                    <div class="labelDiv">
                        <asp:Label runat="server" ID="commenterName"></asp:Label>
                    </div>

                    <div class="commentTextBox">

                        <div class="commentBox">
                            <table>
                                <tr>
                                    <td>
                                        <asp:TextBox runat="server" ID="commentBox" AutoCompleteType="Disabled" placeholder="write comment..." CssClass="commentBox"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button runat="server" Style="height: 32px;" ID="commentButton" Text="Comment" OnClick="commentButton_Click"></asp:Button>
                                    </td>
                                </tr>
                            </table>


                        </div>
                    </div>
                </div>
            </div>


        </div>

    </div>

    <script type="text/javascript">stLight.options({ publisher: "c03cca80-3473-4269-b9cc-745d4de5d689", doNotHash: false, doNotCopy: false, hashAddressBar: false });</script>
    <script>
        var options = { "publisher": "c03cca80-3473-4269-b9cc-745d4de5d689", "position": "left", "ad": { "visible": false, "openDelay": 5, "closeDelay": 0 }, "chicklets": { "items": ["facebook", "twitter", "linkedin", "email", "sharethis"] } };
        var st_hover_widget = new sharethis.widgets.hoverbuttons(options);
    </script>

</asp:Content>


