<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAllContacts.aspx.cs" Inherits="FinalDemo.ViewAllContacts" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style type="text/css">
        .GridviewDiv
        {
            font-size: 100%;
            font-family: 'Lucida Grande' , 'Lucida Sans Unicode' , Verdana, Arial, Helevetica, sans-serif;
            color: #303933;
        }
        Table.Gridview
        {
            border: solid 1px #df5015;
        }
        .Gridview th
        {
            color: #FFFFFF;
            border-right-color: #abb079;
            border-bottom-color: #abb079;
            padding: 0.5em 0.5em 0.5em 0.5em;
            text-align: center;
        }
        .Gridview td
        {
            border-bottom-color: #f0f2da;
            border-right-color: #f0f2da;
            padding: 0.5em 0.5em 0.5em 0.5em;
        }
        .Gridview tr
        {
            color: Black;
            background-color: White;
            text-align: left;
        }
        :link, :visited
        {
            color: #DF4F13;
            text-decoration: none;
        }
        .highlight
        {
            text-decoration: none;
            color: black;
            background: yellow;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <div class="GridviewDiv">
        <p>
            Enter search text :
            <asp:TextBox ID="txtSearch" runat="server" />&nbsp;&nbsp;
            <asp:ImageButton ID="btnSearch" ImageUrl="~/images/SearchButton.png" runat="server" Style="top: 5px;
                position: relative" OnClick="btnSearch_Click" />&nbsp;&nbsp;
            <asp:ImageButton ID="btnClear" ImageUrl="~/images/Clearbutton.png" runat="server" Style="top: 5px;
                position: relative" OnClick="btnClear_Click" /><br />
            <br />
        </p>
        <asp:GridView ID="gvContacts" runat="server" AutoGenerateColumns="False" AllowPaging="True"
            AllowSorting="true"  Width="540px" PageSize="2" CssClass="Gridview" 
             onpageindexchanging="gvContacts_PageIndexChanging">
            <HeaderStyle BackColor="#df5015" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <img src='<%# "upload/" + Eval("ProfiePhoto") %>' width="72" height="72" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="First Name">
                    <ItemTemplate>
                        <asp:Label ID="lblFirstname" Text='<%# HighlightText(Eval("FirstName").ToString()) %>'
                            runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LastName">
                    <ItemTemplate>
                        <asp:Label ID="lblLastname" Text='<%# Eval("LastName") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="City">
                    <ItemTemplate>
                        <asp:Label ID="lblCity" Text='<%#Eval("City") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
