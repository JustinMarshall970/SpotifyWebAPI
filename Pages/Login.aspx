<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/SPC.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SPC.Web.WFInterface.Pages.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphSubHeader" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphSideBar" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphMainContent" runat="server">


    <div>
        <div id="login">
            <h1>First, log in to spotify</h1>
            <a href="/login">Log in</a>
        </div>
        <div id="loggedin">
        </div>
    </div>


</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="server">
</asp:Content>
