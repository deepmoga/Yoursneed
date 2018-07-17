<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Creteria-List.aspx.cs" Inherits="Auth_Creteria_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    Criteria
  <%--  <%=cl %>
    <%=single %><br />

    <%=single2 %><br />
    <br />--%>
  <%--  <%=single3 %><br />--%>
    Count=<%=checkdatas %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
     <p>Current Left Criteria Joinings : <asp:Label ID="lblleft" runat="server" Text="0"></asp:Label></p>
     <p>Current Right Criteria Joinings : <asp:Label ID="lblright" runat="server" Text="0"></asp:Label></p>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

