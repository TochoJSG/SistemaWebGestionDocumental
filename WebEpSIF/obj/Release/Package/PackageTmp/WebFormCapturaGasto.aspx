<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormCapturaGasto.aspx.cs" Inherits="WebEpSIF.WebFormCapturaGasto" MasterPageFile="~/MasterPage.Master" %>

<%@ OutputCache Location="None" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>


      <link href="WebFormCapturaGasto.css" rel="stylesheet" />

    <script type="text/javascript">

        function DesactivaBoton() {
            document.getElementById("<%=btnAgregar.ClientID %>").disabled = true;
            document.getElementById("procesando").style.display = "block";

        }
        window.onbeforeunload = DesactivaBoton;


       <%-- function DesactivaBoton() {
            var btn = "<%= btnAgregar.ClientID %>";
             if (confirm("Confirme postback")) {
                 document.getElementById(btn).disabled = true;
                 return true;
             }
             return false;
         }--%>


        function mascara(o, f) {
            v_obj = o;
            v_fun = f;
            setTimeout("execmascara()", 1);
        }
        function execmascara() {
            v_obj.value = v_fun(v_obj.value);
        }
        function cpf(v) {
            v = v.replace(/([^0-9\.]+)/g, '');
            v = v.replace(/^[\.]/, '');
            v = v.replace(/[\.][\.]/g, '');
            v = v.replace(/\.(\d)(\d)(\d)/g, '.$1$2');
            v = v.replace(/\.(\d{1,2})\./g, '.$1');
            v = v.toString().split('').reverse().join('').replace(/(\d{3})/g, '$1,');
            v = v.split('').reverse().join('').replace(/^[\,]/, '');
            return v;
        }

        function checkTextAreaMaxLength(textBox, e, length) {

            var mLen = textBox["MaxLength"];
            if (null == mLen)
                mLen = length;

            var maxLength = parseInt(mLen);
            if (!checkSpecialKeys(e)) {
                if (textBox.value.length > maxLength - 1) {
                    if (window.event)//IE
                        e.returnValue = false;
                    else//Firefox
                        e.preventDefault();
                }
            }
        }




        function alertMessageCancelado(NombreArchivoSat) {
            alert('El estatus del CFDI ' + NombreArchivoSat + ' en SAT es Cancelado.');
        }

        function alertMessageNoEncontrado(NombreArchivoSat) {
            alert('El estatus del CFDI ' + NombreArchivoSat + ' en SAT es No Encontrado.');
        }


        function alertMessageDefinitivo(RFCSat) {
            alert('El estatus del RFC ' + RFCSat + ' es Definitivo, el archivo no se puede cargar.');
        }

        function alertMessagePresunto(RFCSat) {
            alert('El estatus del RFC ' + RFCSat + ' es Presunto, el archivo no se puede cargar.');
        }



    </script>

    <div class="style1">
        <h2 style="color: #C0C0C0">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </h2>
        <h2 style="color: #C0C0C0">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Captura de Gasto por Agrupador</h2>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;    
        <asp:Label ID="LabelAgrupador" runat="server" Text="P1_01" Font-Size="X-Large" ForeColor="#3366FF"></asp:Label>

        &nbsp;&nbsp &nbsp;&nbsp  &nbsp;&nbsp &nbsp;&nbsp &nbsp;&nbsp  &nbsp;&nbsp &nbsp;&nbsp &nbsp;&nbsp &nbsp;&nbsp &nbsp;&nbsp &nbsp;&nbsp &nbsp;&nbsp &nbsp;&nbsp &nbsp;&nbsp &nbsp;&nbsp &nbsp;&nbsp;&nbsp&nbsp;&nbsp&nbsp;&nbsp    
        
        <div id="login">
            <div class="container">
                <div id="login-row" class="row justify-content-center align-items-center">
                    <div id="login-column" class="col-md-6">
                        <div id="login-box" class="col-md-12">




                            



                            <table border="0">



                               

                              


                               

                              

                               

                               

                                <tr>

                                    <td>&nbsp;</td>

                                    

                                    

                                </tr>

                                <tr>

                                    <td>
                                        &nbsp;</td>

                                    <td></td>

                                    <td></td>

                                    <td>
                                        &nbsp;</td>

                                </tr>

                                <tr>

                                    <td></td>

                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Disponible"></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text="Capturado"></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text="Importe"></asp:Label>
                                        </td>

                                </tr>

                                <tr>

                                    <td>


                                        &nbsp;</td>

                                    <td>
                                        <asp:TextBox ID="TextBoxDisponible" runat="server" Width="145px" type="text" MaxLength="14" class="form-control" Height="30px" onkeypress="mascara(this,cpf)" placeholder="$0" OnTextChanged="TextBoxDisponible_TextChanged" ReadOnly="True"></asp:TextBox>
                                     
                                        
                                    </td>

                                    <td>
                                        <asp:TextBox ID="TextBoxCapturado" runat="server" Width="145px" type="text" MaxLength="14" class="form-control" Height="30px" onkeypress="mascara(this,cpf)" placeholder="$0" ReadOnly="True"></asp:TextBox>
                                     
                                        
                                    </td>

                                    <td>
                                    
                                     <asp:TextBox ID="txtImporte" runat="server" Width="145px" type="text" MaxLength="14" class="form-control" Height="30px" onkeypress="mascara(this,cpf)" placeholder="$0"></asp:TextBox>
                                    
                                        
                                    </td>

                                </tr>

                                <tr>

                                    <td>&nbsp;</td>

                                    <td>&nbsp;</td>

                                    <td></td>

                                    <td>
                                        &nbsp;</td>

                                </tr>

                                <tr>

                                    <td>
                                        &nbsp;<td>
                                        <asp:Button ID="btnAgregar" runat="server" BackColor="#3333FF" BorderStyle="None" Font-Bold="True" ForeColor="White" Height="40px" OnClick="btnAgregar_Click" Text="Guardar" Width="140px" />






                                    </td>

                                    <td>
                                        &nbsp;</td>

                                    <td>






&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" BackColor="#3333FF" BorderStyle="None" Font-Bold="True" ForeColor="White" Height="40px" OnClick="Button1_Click" Text="Cerrar" Width="140px" />
                                        &nbsp;&nbsp;&nbsp;
                                        <br />
                                    </td>

                                </tr>





                               <tr>

                                    <td>
                                        &nbsp;</td>

                                    <td>
                                        &nbsp;</td>

                                    <td>
                                        &nbsp;</td>


                                    <td>
                                    
                                        &nbsp;</td>


                                    <td>
                                        <%--<asp:TextBox ID="TextBox2" runat="server" Width="145px"></asp:TextBox>--%>
                                    
                                    </td>

                                </tr>
















                            </table>

                            <br />

                            <div id="procesando" style="display: none">
                                
                                <p>
                                    <asp:Label ID="Label2" runat="server" Text=" Procesando Información. Favor de esperar..." Font-Bold="True" ForeColor="#3333FF" Font-Size="X-Large"></asp:Label>

                                </p>



                            </div>



                            <br />

                            <div>

                            </div>







                            <br />

                            <div>


                                <%--<div class="alert alert-danger">--%>

                                <%--</div>--%>
                            </div>


                        </div>
                    </div>






                </div>



            </div>
        </div>
    </div>
    <style type="text/css">
        #Background {
            position: fixed;
            top: 0px;
            bottom: 0px;
            left: 0px;
            right: 0px;
            overflow: hidden;
            padding: 0;
            margin: 0;
            background-color: #F0F0F0;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 100000;
        }

        #Progress {
            position: fixed;
            top: 26%;
            left: 12%;
            height: 44%;
            width: 37%;
            z-index: 100001;
            background-color: #ffffff;
            border: 1px solid Gray;
            background-image: url('');
            background-repeat: no-repeat;
            background-position: center;
        }







        </style>


</asp:Content>



