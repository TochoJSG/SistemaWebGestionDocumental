<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormConfirmaCancelar.aspx.cs" Inherits="WebEpSIF.WebFormConfirmaCancelar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            height: 66px;
        }
    </style>
</head>
<body style="height: 87px">
    <form id="form1" runat="server">
        <div style="color: #0000FF; font-size: x-large; background-color: #FFFFFF;">
            <asp:Label ID="Label1" runat="server" ForeColor="#3333FF" Text="Esta acción cancelará el registro de la póliza y no podra ser utilizado para la carga en el INE. 
"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="¿Deseas Continuar?"></asp:Label>
            <br />
        </div>
         &nbsp;<p>
            <asp:Button ID="Button1" runat="server" Text="Sí" OnClick="Button1_Click" BackColor="#3333FF" BorderColor="White" BorderStyle="None" ForeColor="White" Font-Bold="True" Height="40px" Width="100px" />
         <asp:Button ID="Button2" runat="server" Text="No" BackColor="#3333FF" BorderColor="White" BorderStyle="None" ForeColor="White" Font-Bold="True" Height="40px" OnClick="Button2_Click" style="margin-left: 23px" Width="97px" />
        </p>
    </form>
</body>
</html>
