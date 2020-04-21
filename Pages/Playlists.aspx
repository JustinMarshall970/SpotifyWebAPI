<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/SPC.Master" AutoEventWireup="true" CodeBehind="Playlists.aspx.cs" Inherits="SPC.Web.WFInterface.Pages.Playlists" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphSubHeader" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphSideBar" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphMainContent" runat="server">
    
    <div class="panel">
        <div class="panel__header">
            <h4 class="panel__title">Search for a Song</h4>
        </div>

        <div class="row">
            <div class="panel__content">
                <div class="form">

                    <div class="row">
                        <div class="col col-12">
                            <div class="form__item">
                                <label class="form__label">Song Title</label>
                                <asp:TextBox ID="tb_Song_Name" runat="server" CssClass="form__input" MaxLength="50" />
                            </div>
                        </div>

                        <div class="col col-12">
                            <div class="form__item">
                                <label class="form__label">Song Artist</label>
                                <asp:TextBox ID="tb_Song_Artist" runat="server" CssClass="form__input" MaxLength="50" />
                            </div>
                        </div>
                    </div>

                    <div class="form__item">
                        <asp:Button runat="server" ID="btn_Song_Search" CssClass="button" Text="Search" CausesValidation="true" OnClick="btn_Song_Search_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="panel">
        <div class="panel__header">
            <h4 class="panel__title">Search results</h4>
        </div>

        <div class="row">
            <div class="panel__content">


                <div class="row">
                    <div class="col col-3">
                        <label class="form__label">Song Title</label>
                    </div>
                    <div class="col col-3">
                        <label class="form__label">Artist Name</label>
                    </div>
                    <div class="col col-3">
                        <label class="form__label">Album Name</label>
                    </div>
                    <div class="col col-3">
                        <label class="form__label">Album Cover</label>
                    </div>
                </div>
                    
                
                <asp:Repeater ID="rpt_Tracks" runat="server" OnItemDataBound="rpt_Tracks_ItemDataBound" ItemType ="SPC.Core.Tracks.Track">
                    <ItemTemplate>
                        <div class="row">
                            <div class="col col-3">
                                <asp:Literal ID="lit_Name" runat="server" />
                            </div>
                            <div class="col col-3">
                                <asp:Literal ID="lit_Artist" runat="server" />
                            </div>
                            <div class="col col-3">
                                <asp:Literal ID="lit_Album" runat="server" />
                            </div>
                            <div class="col col-3">
                                <asp:Literal ID="lit_Image" runat="server" />
                            </div>
                        </div>
                        </br>
                        </br>
                    </ItemTemplate>
                </asp:Repeater>
                
                    </table>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="server">
</asp:Content>
