﻿<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="ewallet.aspx.cs" Inherits="User_ewallet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cptitle" Runat="Server">
    <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpmain" Runat="Server">
    <div class="col-md-12 text-right">
      <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-default" Text="Print" OnClientClick = "return PrintPanel();" />
    </div>
    <asp:Panel ID="pnlContents" runat="server">
    <div class="col-md-12">
        <h4 style="margin-bottom: 20px;">Income Details</h4>
    
            <table style="width: 100%;" class="table table-bordered">
            <tr>
                <td><strong>Name : <asp:Label ID="lblname" runat="server" Text="Label"></asp:Label></strong></td>
                <td><strong>Reg Id : <asp:Label ID="lblregno" runat="server" Text="Label"></asp:Label></strong></td>
               
            </tr>
            <tr>
                <td colspan="2">
                    <table style="width: 100%;" class="table table-bordered">
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style11">&nbsp;</td>
                            <td class="auto-style13">&nbsp;</td>
                            <td class="auto-style4">&nbsp;</td>
                            <td><strong>Income</strong></td>
                        </tr>
                        <tr>
                            <td class="auto-style5"><strong>Total Sponser</strong></td>
                            <td class="auto-style12"><%=sponser %></td>
                            <td class="auto-style14"><span style="color: rgb(52, 73, 94); font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 700; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Income per Sponsor</span></td>
                            <td class="auto-style8"><asp:Label ID="lblsincome" runat="server" Text="300"></asp:Label></td>
                            <td class="auto-style7"><asp:Label ID="lblstotal" runat="server" Text="0"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="auto-style2"><strong>Total Proposers</strong></td>
                            <td class="auto-style11"><%=proposer %></td>
                            <td class="auto-style13"><span style="color: rgb(52, 73, 94); font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 700; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Income per Proposer</span></td>
                            <td class="auto-style4"><asp:Label ID="lblpincome" runat="server" Text="200"></asp:Label></td>
                            <td><asp:Label ID="lblptotal" runat="server" Text="0"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style11">&nbsp;</td>
                            <td class="auto-style13">&nbsp;</td>
                            <td class="auto-style4">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style11">&nbsp;</td>
                            <td class="auto-style13">&nbsp;</td>
                            <td class="auto-style4"><strong Class="text-primary">Total Income</strong></td>
                            <td>
                                <asp:Label ID="lbltotal" runat="server" Text="0" ></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style11">&nbsp;</td>
                            <td class="auto-style13">&nbsp;</td>
                            <td class="auto-style4"><strong Class="text-danger">TDS @ 10%</strong></td>
                            <td>
                                <asp:Label ID="lbltds" runat="server" Text="0" ></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style11">&nbsp;</td>
                            <td class="auto-style13">&nbsp;</td>
                            <td class="auto-style4"><strong Class="text-success">Payable</strong></td>
                            <td>
                                <asp:Label ID="lblnet" runat="server" Text="0" ></asp:Label></td>
                        </tr>
                    </table>
                </td>
               
            </tr>
          
        </table>
         <div class="col-md-12 text-center">
               <strong> Balance : <%=bal %> </strong>
            </div>
        </div>
        <div class="col-md-12">
            <h4 style="margin-bottom: 20px;">Withdrawls</h4>
            <table id="example2" class="table table-striped table-bordered" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th>Sr.No</th>
                <th>Dated</th>
                <th>Amount</th>
                <th>Reason of Payment</th>
                <th>Mode</th>
              
            </tr>
        </thead>
            <asp:ListView ID="ListView1" runat="server" OnItemDataBound="ListView1_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td><%# Container.DataItemIndex+1 %></td>
                    
                    <td><asp:Label ID="lbldate" runat="server" Text='<%# Convert.ToDateTime(Eval("dated")).ToString("dd/MM/yyyy") %>'></asp:Label></td>
                    <td>
                        <asp:Label ID="lblamt" runat="server" Text='<%#Eval("amount") %>'><%#Eval("amount") %></asp:Label></td>
                    <td><%#Eval("remarks") %></td>
                    <td><%#Eval("cash") %></td>
                    
                </tr>
              
            </ItemTemplate>
        </asp:ListView>
        </table>
           
        </div>
        </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpfotter" Runat="Server">
   <style type="text/css">
        .auto-style2 {
            width: 187px;
        }
        .auto-style4 {
            width: 130px;
        }
        .auto-style5 {
            width: 187px;
            height: 19px;
        }
        .auto-style7 {
            height: 19px;
        }
        .auto-style8 {
            width: 130px;
            height: 19px;
        }
        .auto-style11 {
            width: 172px;
        }
        .auto-style12 {
            width: 172px;
            height: 19px;
        }
        .auto-style13 {
            width: 138px;
        }
        .auto-style14 {
            width: 138px;
            height: 19px;
        }
    </style>
</asp:Content>

