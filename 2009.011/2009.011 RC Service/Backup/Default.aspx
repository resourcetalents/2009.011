<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="DefaultPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table id="tblHeader" border="0" cellpadding="0" cellspacing="0" style="font-size: 0pt;
            z-index: 106; left: -2px; width: 100%; color: navy; position: absolute; top: 0px"
            width="300">
            <tr>
                <td rowspan="1" style="padding-left: 20px; font-weight: normal; font-size: xx-large;
                    padding-bottom: 20px; text-transform: none; color: navy; padding-top: 30px; font-family: 'Trebuchet MS', Tahoma, Verdana, Arial;
                    font-variant: normal" width="10%">
                    <asp:Label ID="txtApplicatieNaam" runat="server" Font-Bold="True" Font-Size="48px"
                        ForeColor="Navy" Height="37px" Width="463px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2" height="2" style="height: 2px">
                    &nbsp;<img height="12" src="img\bar.gif" width="1400" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <table id="tblMenu" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="border-right: darkgray 1px solid; border-top: darkgray 1px solid; filter: progid:DXImageTransform.Microsoft.Gradient(GradientType=0, StartColorStr='#F0F0F0', EndColorStr='#D8D8D8');
                                border-left: whitesmoke 1px solid; border-bottom: silver 1px solid">
                                <asp:Button ID="btnInstalleer" runat="server" AccessKey="I" BackColor="Transparent"
                                    BorderStyle="None" Enabled="False" Height="23px" Style="cursor: hand" Text="Installeer"
                                    Visible="TRUE" Width="126px" />
                            </td>
                            <td style="border-right: darkgray 1px solid; border-top: darkgray 1px solid; filter: progid:DXImageTransform.Microsoft.Gradient(GradientType=0, StartColorStr='#F0F0F0', EndColorStr='#D8D8D8');
                                border-left: whitesmoke 1px solid; border-bottom: silver 1px solid">
                                <asp:Button ID="btnStart" runat="server" AccessKey="S" BackColor="Transparent" BorderStyle="None"
                                    Height="23px" Style="cursor: hand" Text="Start" Visible="TRUE" Width="126px"/>
                            </td>
                            <td style="border-right: darkgray 1px solid; border-top: darkgray 1px solid; filter: progid:DXImageTransform.Microsoft.Gradient(GradientType=0, StartColorStr='#F0F0F0', EndColorStr='#D8D8D8');
                                border-left: whitesmoke 1px solid; border-bottom: silver 1px solid" width="100%">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 35px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="0%">
                    <table id="tblInfo" border="0" cellpadding="0" cellspacing="3" style="position: static"
                        width="861">
                        <tr style="height: 30px">
                            <td rowspan="3" style="padding-left: 20px">
                                &nbsp;</td>
                            <td style="width: 147px" width="0%">
                                <div style="display: inline; font-weight: normal; font-size: 14pt; width: 180px;
                                    color: navy; height: 15px">
                                    <font face="Trebuchet MS"><strong>Unit 4 Multivers</strong></font></div>
                            </td>
                            <td colspan="2">
                                <font face="Trebuchet MS">
                                    <asp:Label ID="txtMultivers" runat="server" BackColor="Window" BorderColor="ControlDark"
                                        BorderStyle="Solid" BorderWidth="1px" Font-Size="12pt" Width="465px"></asp:Label></font></td>
                        </tr>
                        <tr style="height: 30px">
                            <td style="width: 147px" width="0%">
                                <asp:Label ID="lblApplication" runat="server" BackColor="Window" BorderColor="ControlDark"
                                    BorderStyle="None" Font-Bold="True" Font-Names="Trebuchet MS" Font-Size="14pt"
                                    ForeColor="Navy" Width="180px"></asp:Label>
                            </td>
                            <td colspan="2">
                                <font face="Trebuchet MS">
                                    <asp:Label ID="txtVersie" runat="server" BackColor="Window" BorderColor="ControlDark"
                                        BorderStyle="Solid" BorderWidth="1px" Font-Size="12pt" Width="465px"></asp:Label></font></td>
                        </tr>
                        <tr style="height: 30px">
                            <td style="width: 147px">
                                <div style="display: inline; font-size: 14pt; width: 180px; color: navy; height: 20px">
                                    <font face="Trebuchet MS"><strong>Administratie</strong></font></div>
                            </td>
                            <td style="width: 96px" width="0%">
                                <font face="Trebuchet MS">
                                    <asp:Label ID="txtCdAdmin" runat="server" BackColor="Window" BorderColor="ControlDark"
                                        BorderStyle="Solid" BorderWidth="1px" Font-Size="12pt" Width="120px"></asp:Label></font></td>
                            <td width="0%">
                                <font face="Trebuchet MS">
                                    <asp:Label ID="txtNmAdmin" runat="server" BackColor="Window" BorderColor="ControlDark"
                                        BorderStyle="Solid" BorderWidth="1px" Font-Size="12pt" Width="344px"></asp:Label></font></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
