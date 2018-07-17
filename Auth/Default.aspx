<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/Main.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Auth_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
     <style>
        .Dash {
            padding: 20px;
            background: menu;
            margin:10px
        }
        .blue{    background: #3498db;
    color: white;}
        .yellow{ background:#ffc61d;
                 color:white;
        }
        .green{ background:#27ae60;color:white}
        .contact-info h5{
            color:white;
                font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
    <div class="col-md-12" style="margin-bottom: 20px">
        <div class="col-lg-2 col-sm-3 bottom-m3 Dash blue">
            <div class="contact-box">
                <div class="contact-icon">
                    <i class="fa fa-inr"></i>
                </div>
                <div class="contact-info">
                    <h5>Today Joining</h5>
                    <span>
                        <asp:Label ID="lbltoday" runat="server" Text=""></asp:Label></span>
                </div>
            </div>
        </div>
        <div class="col-lg-2 col-sm-3 bottom-m3 Dash yellow">
            <div class="contact-box">
                <div class="contact-icon">
                    <i class="fa fa-anchor"></i>
                </div>
                <div class="contact-info">
                    <h5>Total User</h5>
                    <span>
                        <asp:Label ID="lbltotal" runat="server" Text=""></asp:Label></span>
                </div>
            </div>
        </div>
        <div class="col-lg-2 col-sm-3 bottom-m3 Dash green">
            <div class="contact-box">
                <div class="contact-icon">
                    <i class="fa fa-link"></i>
                </div>
                <div class="contact-info">
                    <h5>Pairing</h5>
                    <span>
                       L: <asp:Label ID="lblleft" runat="server" Text=""></asp:Label></span>
                    <span>
                       R: <asp:Label ID="lblright" runat="server" Text=""></asp:Label></span>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

