<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebImprimirSolicitud.aspx.cs" Inherits="WebEpSIF.WebImprimirSolicitud" MasterPageFile="~/MasterPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
   
    <div id="login">
        <div class="container">
            <div id="login-row" class="row justify-content-center align-items-center">
                <div id="login-column" class="col-md-6">
                    <div id="login-box" class="col-md-12">
                              <div class="form-group">
        
                                <h3> Se genero la solicitud número:  <span> <asp:Label  ID="lblNumeroSolicitud" runat="server"  Text="Numero"></asp:Label></span></h3> 
                                <asp:Button ID="btnImprimirSolicitud" runat="server" CausesValidation="False" Text="Imprimir Solicitud"  class="btn btn-info btn-md" OnClick="btnImprimirSolicitud_Click"  ></asp:Button>
                                        
   
                            </div>
                    
                    </div>
                </div>
            </div>
        </div>
    </div>

    

</asp:Content>
