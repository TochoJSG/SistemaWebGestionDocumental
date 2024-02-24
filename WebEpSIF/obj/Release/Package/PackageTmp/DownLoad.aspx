<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DownLoad.aspx.cs" Inherits="WebEpSIF.DownLoad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="color: #3333FF; font-size: x-large;">
            Para visualizar el archivo es necesario descargarlo...<br />
            <br />
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Aceptar" BackColor="#3333FF" BorderStyle="None" Font-Bold="True" ForeColor="White" Height="40px" Width="146px"  />
     
    
    
    
    
    
    &nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Regresar" BackColor="#3333FF" BorderStyle="None" Font-Bold="True" ForeColor="White" Height="40px" Width="139px" />
     
    
    
    
    
    
    </form>
</body>
</html>
