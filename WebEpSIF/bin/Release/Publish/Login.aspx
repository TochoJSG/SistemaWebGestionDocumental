<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebEpSIF.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 40%;
        }
        .auto-style2 {
            width: 107px;
        }
        .auto-style3 {
            margin-left: 0px;
        }
        .auto-style4 {
            margin-left: 167px;
        }
        .auto-style5 {
            width: 627px;
        }
    </style>
</head>
<body>
    <form id="Login" runat="server">
        <div style="margin-left: 200px">
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <br />
            <br />
            <br />
&nbsp;
            <br />
            <table class="auto-style1">
                <tr>
                    <td style="background-color: #999966; table-layout: inherit;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
&nbsp;
                        <asp:Label ID="Label4" runat="server" BorderStyle="None" CssClass="auto-style3" Font-Bold="True" Font-Size="X-Large" ForeColor="White" Text="Inicio de Sesion" Width="304px"></asp:Label>
                        <br />
&nbsp;&nbsp;
                        <asp:Label ID="Label3" runat="server" BorderStyle="None" Font-Bold="True" Font-Size="X-Large" ForeColor="White" Text="    " Width="296px"></asp:Label>
&nbsp;&nbsp;&nbsp; </td>
                </tr>
            </table>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2" style="background-color: #C0C0C0; line-height: inherit; table-layout: inherit;">&nbsp;
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="White" Text="Usuario"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtUsuario" runat="server" Width="165px"></asp:TextBox>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" style="background-color: #C0C0C0; line-height: inherit; table-layout: inherit;">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="White" Text="Contraseña"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtPwUsu" runat="server" Width="165px"></asp:TextBox>
                        <br />
                    </td>
                </tr>
            </table>
            <table class="auto-style1">
                <tr style="background-color: #008080">
                    <td class="auto-style5" style="line-height: 0px">
                        <br />
                        <br />
                    </td>
                    <td>
                        <br />
                        <asp:Button ID="btnIngresar" runat="server" CssClass="auto-style4" OnClick="btnIngresar_Click1" Text="Ingresar" Width="133px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5" style="line-height: 0px">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            <br />
        </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
