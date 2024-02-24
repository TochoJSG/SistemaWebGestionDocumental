<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebGeneraSolicitud.aspx.cs" Inherits="WebEpSIF.WebGeneraSolicitud" MasterPageFile="~/MasterPage.Master" %>

<%@ OutputCache Location="None" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>

    <link href="WebGeneraSolicitud.css" rel="stylesheet" />


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
        <h2 style="color: #C0C0C0">Carga de Evidencias</h2>
        <asp:Button ID="Button1" runat="server" CausesValidation="False" OnClick="Button1_Click" Text="Administración de Cargas" Width="197px"  BackColor="#3333FF" BorderStyle="None" Font-Bold="True" ForeColor="White" Height="40px" Visible="False" />
       
        
        <asp:Button ID="ButtonCerrar" runat="server" CausesValidation="False" OnClick="Button1_Click" Text="Administración de Cargas" Width="197px"  BackColor="#3333FF" BorderStyle="None" Font-Bold="True" ForeColor="White" Height="40px" Visible="False" />
       
        
        <p style="color: #C0C0C0">&nbsp;</p>



        &nbsp;&nbsp &nbsp;&nbsp  &nbsp;&nbsp &nbsp;&nbsp &nbsp;&nbsp  &nbsp;&nbsp &nbsp;&nbsp &nbsp;&nbsp &nbsp;&nbsp &nbsp;&nbsp &nbsp;&nbsp &nbsp;&nbsp &nbsp;&nbsp &nbsp;&nbsp &nbsp;&nbsp &nbsp;&nbsp;&nbsp&nbsp;&nbsp<asp:Label ID="LabelEtiquetaAgrupador" runat="server" Text="AGRUPADOR" Font-Size="X-Large" ForeColor="Silver"></asp:Label>
        &nbsp;<asp:Label ID="IDAGRUPADOR" runat="server" Text="IDAGRUPADOR" Font-Size="X-Large" ForeColor="#3366FF"></asp:Label>

        &nbsp    
        <asp:Label ID="LabelAgrupador" runat="server" Text="P1_01" Font-Size="X-Large" ForeColor="#3366FF"></asp:Label>

        <div id="login">
            <asp:Label ID="IDUSUARIOCAPTURA" runat="server" Text="Label" Font-Bold="True" ForeColor="#0066CC"></asp:Label>
            <asp:Label ID="USUARIOCAPTURA" runat="server" Text="Label" Font-Bold="True" ForeColor="#0066CC"></asp:Label>
            <br />
            <br />
            <div class="container">
                <div id="login-row" class="row justify-content-center align-items-center">
                    <div id="login-column" class="col-md-6">
                        <div id="login-box" class="col-md-12">




                            



                            <table border="0">



                                <tr>

                                    <td>Periodo<asp:RequiredFieldValidator ID="cvPeriodo" runat="server" ControlToValidate="ddlPeriodo" ErrorMessage="El Campo periodo es obligatorio." Font-Bold="False" Font-Size="Large" ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                                    </td>

                                    <td>&nbsp;</td>

                                    <td></td>

                                    <td>Candidato<asp:RequiredFieldValidator ID="cvCandidato" runat="server" ControlToValidate="ddlCandidato" ErrorMessage="El Campo Candidato es obligatorio." Font-Bold="False" Font-Size="Large" ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                                    </td>

                                </tr>


                                <tr>

                                    <td>
                                        <asp:DropDownList ID="ddlPeriodo" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlPeriodo_SelectedIndexChanged" Width="334px">
                                        </asp:DropDownList>
                                    </td>

                                    <td></td>

                                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>

                                    <td>
                                        <asp:DropDownList ID="ddlCandidato" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlCandidato_SelectedIndexChanged" Width="334px">
                                        </asp:DropDownList>
                                    </td>

                                </tr>


                                <tr>

                                    <td>Candidatura<asp:RequiredFieldValidator ID="cvCandidatura" runat="server" ControlToValidate="ddlColectivaDetalle" ErrorMessage="El Campo candidatura es obligatorio." Font-Bold="False" Font-Size="Large" ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                                    </td>

                                    <td></td>

                                    <td></td>

                                    <td>TipoGasto<asp:RequiredFieldValidator ID="cvTipoGasto" runat="server" ControlToValidate="ddlTipoGasto" ErrorMessage="El campo Tipo Gasto es  obligatorio." Font-Bold="False" Font-Size="Large" ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                                    </td>

                                </tr>

                                <tr>

                                    <td>
                                        <asp:DropDownList ID="ddlColectivaDetalle" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlColectivaDetalle_SelectedIndexChanged" Width="334px">
                                        </asp:DropDownList>
                                    </td>

                                    <td></td>

                                    <td></td>

                                    <td>
                                        <asp:DropDownList ID="ddlTipoGasto" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlTipoGasto_SelectedIndexChanged" Width="335px">
                                        </asp:DropDownList>
                                    </td>

                                </tr>

                                <tr>

                                    <td>Estado<asp:RequiredFieldValidator ID="rfvEventoEspecifico" runat="server" ControlToValidate="ddlEventoEspecifico" ErrorMessage="El campo Estado es obligatorio." Font-Bold="False" Font-Size="Large" ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                                    </td>

                                    <td></td>

                                    <td></td>

                                    <td>Concepto<asp:RequiredFieldValidator ID="cvConcepto0" runat="server" ControlToValidate="ddlConcepto" ErrorMessage="El campo concepto es  obligatorio." Font-Bold="False" Font-Size="Large" ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                                    </td>

                                </tr>

                                <tr>

                                    <td>
                                        <asp:DropDownList ID="ddlEventoEspecifico" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlEventoEspecifico_SelectedIndexChanged" Width="334px">
                                        </asp:DropDownList>
                                    </td>

                                    <td></td>

                                    <td>&nbsp;</td>

                                    <td>
                                        <asp:DropDownList ID="ddlConcepto" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlConcepto_SelectedIndexChanged" Width="335px">
                                        </asp:DropDownList>
                                    </td>

                                </tr>

                                <tr>

                                    <td>Distrito<asp:RequiredFieldValidator ID="rfvDistrito" runat="server" ControlToValidate="ddlDistrito" ErrorMessage="El campo distrito es obligatorio." Font-Bold="False" Font-Size="Large" ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                                    </td>

                                    <td></td>

                                    <td></td>

                                    <td>
                                        <asp:Label ID="Label5" runat="server" Font-Bold="False" Font-Size="Small" ForeColor="#3366FF" Text="Evidencias"></asp:Label>
                                        <asp:RequiredFieldValidator ID="cvEvidencia" runat="server" ControlToValidate="ddlDocumento" ErrorMessage="El campo evidencia es  obligatorio." Font-Bold="False" Font-Size="Large" ForeColor="Red" InitialValue="0">*</asp:RequiredFieldValidator>
                                    </td>

                                </tr>

                                <tr>

                                    <td>
                                        <asp:DropDownList ID="ddlDistrito" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlDistrito_SelectedIndexChanged" Width="335px">
                                        </asp:DropDownList>
                                    </td>

                                    <td></td>

                                    <td></td>

                                    <td>
                                        <asp:DropDownList ID="ddlDocumento" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlDocumento_SelectedIndexChanged" Width="335px">
                                        </asp:DropDownList>
                                    </td>

                                </tr>

                                <tr>

                                    <td></td>

                                    <td></td>

                                    <td></td>

                                    <td></td>

                                </tr>

                                <tr>

                                    <td>


                                        <asp:FileUpload ID="FileUploadEstados" runat="server" AllowMultiple="True" ToolTip="El nombre del archivo solo deberá contener los siguientes caracteres: de la letra “a” a la “z”, mayúsculas o minúsculas, dígitos del 0 al 9, los caracteres especiales _, +, -, ., $, % y el &quot;espacio en blanco&quot; (exceptuando la ñ, Ñ, acentos y diéresis)."></asp:FileUpload>

                                    </td>

                                    <td></td>

                                    <td></td>

                                    <td>
                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="#3366FF" Text="El documento de evidencia deberá ser solo de las extensiones siguientes:"></asp:Label>
                                    </td>

                                </tr>

                                <tr>

                                    <td>&nbsp;</td>

                                    <td></td>

                                    <td></td>

                                    <td>
                                        <asp:Label ID="lblExtensiones" runat="server" Font-Bold="True" Font-Size="Small" Width="500px"></asp:Label>
                                    </td>

                                </tr>

                                <tr>

                                    <td>
                                        <asp:Button ID="btnAgregar" runat="server" BackColor="#3333FF" BorderStyle="None" Font-Bold="True" ForeColor="White" Height="40px" OnClick="btnAgregar_Click" Text="+ Agregar  documento" Width="188px" />






                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Disponible" Visible="False"></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text="Capturado" Visible="False"></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text="Importe" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <br />
                                    </td>

                                </tr>





                               <tr>

                                    <td>&nbsp;</td>

                                    <td>
                                        <asp:TextBox ID="TextBoxDisponible" runat="server" Width="145px" type="text" MaxLength="14" class="form-control" Height="30px" onkeypress="mascara(this,cpf)" placeholder="$0" Visible="False"></asp:TextBox>
                                     
                                        
                                    </td>

                                    <td>
                                        <asp:TextBox ID="TextBoxCapturado" runat="server" Width="145px" type="text" MaxLength="14" class="form-control" Height="30px" onkeypress="mascara(this,cpf)" placeholder="$0" Visible="False"></asp:TextBox>
                                     
                                        
                                    </td>


                                    <td>
                                    
                                     <asp:TextBox ID="txtImporte" runat="server" Width="145px" type="text" MaxLength="14" class="form-control" Height="30px" onkeypress="mascara(this,cpf)" placeholder="$0" Visible="False"></asp:TextBox>
                                    
                                        
                                    </td>


                                    <td>
                                        <%--<asp:TextBox ID="TextBox2" runat="server" Width="145px"></asp:TextBox>--%>
                                    
                                    </td>

                                </tr>
















                            </table>







                            <asp:GridView ID="gvDetalleSolicitud" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="auto-style1" DataKeyNames="idRegistro" Font-Size="Small" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" OnPageIndexChanged="gvDetalleSolicitud_PageIndexChanged" OnPageIndexChanging="gvDetalleSolicitud_PageIndexChanging" OnRowCommand="gvDetalleSolicitud_RowCommand" OnSelectedIndexChanged="gvDetalleSolicitud_SelectedIndexChanged" PageSize="30" ViewStateMode="Enabled" Width="1158px">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:TemplateField></asp:TemplateField>
                                    <asp:BoundField DataField="IdRegistro" HeaderText="IdRegistro" />
                                    <asp:BoundField DataField="IdEstado" HeaderText="IdEstado" Visible="False" />
                                    <asp:BoundField DataField="IdNivel" HeaderText="IdNivel" Visible="False" />
                                    <asp:BoundField DataField="IdTipoGasto" HeaderText="IdTipoGasto" Visible="False" />
                                    <asp:BoundField DataField="Estado" HeaderText="Estado" Visible="False" />
                                    <asp:BoundField DataField="Nivel" HeaderText="Nivel" />
                                    <asp:BoundField DataField="TipoGasto" HeaderText="Tipo Gasto" Visible="False" />
                                    <asp:BoundField DataField="Evidencia" HeaderText="Evidencia" />
                                    <asp:BoundField DataField="Archivo" HeaderText="Documento" />
                                    <asp:BoundField DataField="Fechacarga" HeaderText="Fecha de Carga" />
                                    <asp:BoundField DataField="Usuario" HeaderText="Usuario" />

                                    <asp:ButtonField CommandName="Seleccionar" HeaderText="Ver Archivo" Text="Ver Archivo" Visible="False" />

                                    <asp:ButtonField ButtonType="Image" CommandName="Eliminar" HeaderText="Eliminar" ImageUrl="~/Recursos/EliminaReg.png" Text="Eliminar" />
                                    <asp:TemplateField HeaderText="Sustituir">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chbItem" runat="server" onclick="checkOne(this)" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle BackColor="#3333FF" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="#3333FF" Height="20px" HorizontalAlign="Center" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>

                            <br />

                            <div id="procesando" style="display: none">
                                
                                <p>
                                    <asp:Label ID="Label2" runat="server" Text=" Procesando Información. Favor de esperar (Para documentos de gran tamaño puede tardar algunos minutos....)." Font-Bold="True" ForeColor="#3333FF" Font-Size="X-Large"></asp:Label>

                                </p>



                            </div>







                            <br />

                            <div>
                                <asp:ValidationSummary ID="ValidaDetalle" runat="server" Width="432px" CssClass="auto-style1" ForeColor="#ff3300" />

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







        .auto-style1 {
            margin-left: 0px;
            margin-right: 0px;
            margin-top: 17px;
        }
    </style>


</asp:Content>


