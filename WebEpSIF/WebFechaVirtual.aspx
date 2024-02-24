<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFechaVirtual.aspx.cs" Inherits="WebEpSIF.WebFechaVirtual" MasterPageFile="~/MasterPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    <link href="WebGeneraSolicitud.css" rel="stylesheet" />


    <div class="style1">
        <h2>Fecha Virtual</h2>

        <div id="fecha">
            <div class="container">
                <div id="fecha-row" class="row justify-content-center align-items-center">
                    <div id="fecha-column" class="col-md-6">
                        <div id="fecha-box" class="col-md-12">



                           
                           
                            <div class="form-group">
                                <asp:Calendar ID="calFechaInicio" runat="server" BackColor="White" BorderColor="White" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="10pt" ForeColor="Black" Height="300px" Width="500px"></asp:Calendar>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnFechaInicio" runat="server" Text="Aceptar" Width="80px" class="btn btn-info btn-md" />


                            </div>



                        </div>


                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>

