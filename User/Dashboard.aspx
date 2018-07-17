<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="User_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cptitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" Runat="Server">
    <div class="alert alert-success" role="alert">
        Two Direct Compulsary Id's (One Left and On Right)
    </div>
    <div class="col-md-12">
        Welcome <%=name %>
    </div>
    <div class="col-md-6 col-md-offset-3">
        <table style="width: 100%;" class="table table-bordered">
            <tr>
                <td colspan="2">
                    <b>Member Details</b>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Registration Id</td>
                <td><%=regno %></td>
            </tr>
            <tr>
                <td class="auto-style1">First Name</td>
                <td><%=name %></td>
            </tr>
            <tr>
                <td class="auto-style1">S/o,W/o,D/o</td>
                <td><%=father %>;</td>
            </tr>
            <tr>
                <td class="auto-style1">Joining Date</td>
                <td><%=date %></td>
            </tr>
            <tr>
                <td class="auto-style1">Address</td>
                <td><%=address %></td>
            </tr>
            <tr>
                <td class="auto-style1">Gender</td>
                <td><%=gender %></td>
            </tr>
            <tr>
                <td class="auto-style1">Mobileno.</td>
                <td><%=phn %></td>
            </tr>
            <tr>
                <td class="auto-style1">Marital Status</td>
                <td><%=marital %></td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

