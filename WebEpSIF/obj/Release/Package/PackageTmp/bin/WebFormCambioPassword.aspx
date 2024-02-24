<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormCambioPassword.aspx.cs" Inherits="WebEpSIF.WebFormCambioPassword" MasterPageFile="~/MasterPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
   
    
    <link href="Login.css" rel="stylesheet" />
    
     <div id="login">
        <div class="container">
            <div id="login-row" class="row justify-content-center align-items-center">
                <div id="login-column" class="col-md-6">
                    <div id="login-box" class="col-md-12">
                 
                            <h3 class="text-center text-info" style="color: #3333FF">Cambio de Contraseña</h3>
                            <div class="form-group">
                                <label for="username" class="text-info" style="color: #3333FF">Contraseña Actual:</label><br>
                                <asp:TextBox ID="txtPwActual" runat="server"   class="form-control"   TextMode ="Password" ></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="password" class="text-info" style="color: #3333FF">Contrseña Nueva:</label><br>
                                <asp:TextBox ID="txtPw" runat="server"     class="form-control" MaxLength="8" TextMode ="Password"></asp:TextBox>
                            </div>

                           

                           


                            <div class="form-group">
                                <br>
                               <asp:Button ID="btnIngresar" runat="server"  text ="Cambiar" type="submit" name="submit" value="submit" OnClick="btnIngresar_Click1" BackColor="#3333FF" BorderColor="#3333FF" Font-Bold="True" ForeColor="White" Height="43px" Width="91px"></asp:Button>
  
                            </div>
                    
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
</asp:Content>
