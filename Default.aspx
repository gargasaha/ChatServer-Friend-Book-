<%@ Page Title="" Language="C#" MasterPageFile="~/Container.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FinalYearProject.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <style>
        .HalfPage, .middleP {
            padding-left: 30px;
            font-size: 20px;
        }

        #logo {
            height: 60px;
            width: 60px;
            border-radius: 50px;
        }

        .logoD {
            width: 1000px;
        }

        #GoChat {
            color: blue;
            width: 100px;
        }

        .ChtP {
            height: 60px;
            width: 60px;
            border-radius: 50px;
        }

        .chatbot {
            height: 300px;
            width: 300px;
            border-radius: 30px;
        }

        .textS {
            font-size: 30px;
            padding-left: 20px;
            width: 300px;
            overflow: hidden;
        }

        .msgS {
            font-size: 30px;
            padding-left: 20px;
        }

        .middleP {
            padding-top: 40px;
        }

        #spn {
            color: dodgerblue;
        }

        #logoT {
            padding-left: 20px;
            color: dodgerblue;
            font-size: 40px;
        }

        #btnL {
            padding-left: 80%;
            font-size: 30px;
            text-decoration: none;
            color: dodgerblue;
            width: 40px;
        }

        .sml {
            font-size: 20px;
        }

        .runTime {
            width: 700px;
        }

        .mrg {
            width: 1000px;
        }
    </style>
    <div>
        <div class="HalfPage">
            <table class="list">
                <tr>
                    <td>
                        <asp:Image runat="server" ID="logo" ImageUrl="~/IMAGES/go.jpg" />
                    </td>
                    <td>
                        <div class="logoD">
                            <asp:Label runat="server" ID="logoT" Text="FriendBook"></asp:Label>
                        </div>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="GoChat" Text="Go For Chat"></asp:Label>
                    </td>
                    <td>
                        <asp:ImageButton runat="server" ID="GoToChat" ImageUrl="~/IMAGES/Chatbot.jpg" class="ChtP" />
                    </td>
                </tr>
            </table>

        </div>
        <div class="middleP">
            <table>
                <tr>
                    <td>
                        <asp:Image runat="server" ID="chatbot" ImageUrl="~/IMAGES/go.jpg" CssClass="chatbot" />
                    </td>
                    <td class="textS">
                        <asp:Label runat="server" ID="msgShow" class="msgS">
                            <span id="spn">FriendBook</span>
                            is a new FUN !!
                            <p>
                                Try it out !!!
                            </p>
                            <p class="sml"> neque,oluptate vitae nesciunt explicabo,m atque rerum laudantium aut cupiditate eius quisquam incidunt delectus.

                            </p>

                        </asp:Label>

                    </td>
                    <td class="runTime"></td>
                </tr>
                <tr>
                    <td colspan="2" class="mrg"></td>
                    <td>
                        <asp:LinkButton runat="server" ID="btnL" Text="Explore"></asp:LinkButton></td>
                </tr>
            </table>

        </div>

    </div>
</asp:Content>
