<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebLogin.aspx.cs" Inherits="WebEpSIF.WebLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
<!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">
<!-- Latest compiled and minified JavaScript -->     
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    <link href="Login.css" rel="stylesheet" />

</head>
<body>
    <div id="login">
        <div class="container">
            <div id="login-row" class="row justify-content-center align-items-center">
                <div id="login-column" class="col-md-6">
                    <div id="login-box" class="col-md-12">
                        <form id="WebLogin" runat="server" class="form" action="" method="post">
                            <h3 class="text-center text-info" style="color: #3333FF">Inicio de Sesion</h3>
                            <div class="form-group">
                                <label for="username" class="text-info" style="color: #3333FF">Usuario:</label><br>
                                <asp:TextBox ID="txtUs" runat="server" type="text" name="username" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="password" class="text-info" style="color: #3333FF">Contraseña:</label><br>
                                <asp:TextBox ID="txtPw" runat="server" type="password"   name="password"  class="form-control" MaxLength="8"></asp:TextBox>
                            </div>

                           

                           


                            <div class="form-group">
                                <br>
                               <asp:Button ID="btnIngresar" runat="server"  text ="Ingresar " type="submit" name="submit" value="submit" OnClick="btnIngresar_Click1" BackColor="#3333FF" BorderColor="#3333FF" Font-Bold="True" ForeColor="White" Height="43px" Width="119px"></asp:Button>
  

                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>

</html>
