<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormAdministraSolicitudes.aspx.cs" Inherits="WebSIF.WebForms.WebFormAdministraSolicitudes" MasterPageFile="~/MasterPage.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    <link href="WebFormAdministraSolicitudes.css" rel="stylesheet" />



    <div class="alert-link">

        
        <h2>Administración de Documentos</h2>

        <div id="login">
            <div class="container">
                <div id="login-row" class="row justify-content-center align-items-center">
                    <div id="login-column" class="col-md-6">
                        <div id="login-box" class="col-md-12">



                            <table border="0">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Fecha Inicial" Font-Bold="True" ForeColor="#74A38E"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Fecha Final" Font-Bold="True" ForeColor="#74A38E"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text="Estado" Width="160px" Font-Bold="True" ForeColor="#74A38E"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Nivel" Width="160px" Font-Bold="True" ForeColor="#74A38E"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtFechaInicio" runat="server" OnTextChanged="txtFechaFin_TextChanged"></asp:TextBox>
                                            <asp:Button ID="btnFechaInicio" runat="server" OnClick="btnFechaInicio_Click" Text="V" Width="30px" BackColor="White" BorderStyle="None" Font-Bold="True" ForeColor="#74A38E" />
                                        </div>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtFechaFin" runat="server" OnTextChanged="txtFechaFin_TextChanged"></asp:TextBox>
                                            <asp:Button ID="btnFechaFin" runat="server" OnClick="btnFechaFin_Click" Text="V" Width="30px" BackColor="White" BorderStyle="None" Font-Bold="True" ForeColor="#74A38E" />
                                        </div>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                            <asp:DropDownList ID="ddlEventoEspecifico" Width="300px" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                            <asp:DropDownList ID="ddlColectivaDetalle" Width="300px" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="form-group">
                                            <asp:Calendar ID="calFechaInicio" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="108px" OnSelectionChanged="calFechaI_SelectionChanged" Width="110px"></asp:Calendar>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                            <asp:Calendar  ID="calFechaFin"            runat           ="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="115px"      OnSelectionChanged ="calFechaFin_SelectionChanged" Width="110px"></asp:Calendar>
                                        </div>
                                    </td>
                                    <td class="auto-style5">
                                            <asp:Label ID="Label7" runat="server" Text="Tipo Gasto" Font-Bold="True" ForeColor="#74A38E"></asp:Label>
                                            <asp:DropDownList ID="ddlConcepto" Width="300px" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </td>
                                    <td class="auto-style6">


                                            <asp:TextBox ID="txtNumSolicitud" runat="server" Visible="False"></asp:TextBox>
                                            <asp:CheckBox ID="chkSolicitudesTodas" runat="server" Text="Todas" Visible="False" />


                                        </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">
                                        <asp:Label ID="Label1" runat="server" Text="Num.Solicitud  " Visible="False" Font-Bold="True" ForeColor="#74A38E"></asp:Label>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td>
                                        <div class="form-group">

                                               <asp:Button ID="btnActualiza" runat="server" Text="Consultar" type="submit" name="submit"  value="submit" OnClick="btnActualiza_Click" BackColor="White" BorderColor="#74A38E" Font-Bold="True" ForeColor="#74A38E" BorderStyle="Solid"></asp:Button>


                                        </div>
                                    </td>
                                    <td>
                                        <div class="form-group">

                                <asp:Button ID="btnNuevaSolicitud" runat="server" Text="Carga de documentos..." type="submit" name="submit"  value="submit" OnClick="btnNuevaSolicitud_Click" BackColor="White" BorderColor="#74A38E" BorderStyle="Solid" Font-Bold="True" ForeColor="#74A38E" ></asp:Button>


                                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                                            </asp:ScriptManager>
                                            
                                            <%--<img src="Recursos/800.gif" />--%>                                            <%--<img src="Images/ajax-loader.gif" style="text-align:center" /> Cargando...--%>
                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server"  DisplayAfter="1000" Visible="False">

                                                <ProgressTemplate>
                                                    <div id="Background"> </div>
                                                        
                                                   
                                                    <div id="Progress">
                                                        <br /></b>
                                                          <p style="text-align:center"   > <b style="color: #008080">  Descargando Archivo, Favor de esperar...<br /></b> <br /></b> <img src="Recursos/77.gif""   />  </p> 
                                                             
                                                        <%--<img src="Recursos/800.gif" />--%>
                                                          
                                                   <%--<img src="Images/ajax-loader.gif" style="text-align:center" /> Cargando...--%>
                                                  </div>

                                                   
                                                </ProgressTemplate>



                                            </asp:UpdateProgress>

                                            


                                        </div>
                                    </td>
                                </table>

                            
                             
                             <br />
                            <div class="form-group">

                              <%--<asp:GridView ID="gvDetalleSolicitud" runat="server" CellPadding="4" ForeColor="#333333"--%>
                                   

                                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                  <asp:GridView ID="gvDetalleSolicitud" runat="server" CellPadding="4" ForeColor="#333333" DataKeyNames="IdRegistro"
                                    GridLines="None" AutoGenerateColumns="False"
                                    Font-Size="Small" Width="1000px" OnRowDeleting="onrowdeleting" OnRowDataBound="ondatabound" OnRowCommand="gvDetalleSolicitud_RowCommand" OnSelectedIndexChanged="gvDetalleSolicitud_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanged="gvDetalleSolicitud_PageIndexChanged" OnPageIndexChanging="gvDetalleSolicitud_PageIndexChanging" PageSize="5">
                                    <RowStyle BackColor="#EFF3FB" />

                                    <Columns>

                                        <asp:BoundField DataField="IdRegistro" HeaderText="IdRegistro" Visible="False" />
                                        <asp:BoundField DataField="IdEstado" HeaderText="IdEstado" Visible="False" />
                                        <asp:BoundField DataField="IdNivel" HeaderText="IdNivel" Visible="False" />
                                        <asp:BoundField DataField="IdTipoGasto" HeaderText="IdTipoGasto" Visible="False" />
                                        <asp:BoundField DataField="Estado" HeaderText="Estado"/>
                                        <asp:BoundField DataField="Nivel" HeaderText="Nivel"/>
                                        <asp:BoundField DataField="TipoGasto" HeaderText="Tipo Gasto"/>
                                        <asp:BoundField DataField="Archivo" HeaderText="Archivo"/>

                                        <asp:BoundField DataField="FechaCarga" HeaderText="Fecha" ReadOnly="True" SortExpression="FechaCarga" />

                                        <asp:ButtonField Text="Ver documento" CommandName="Select" />
                                        <asp:CommandField ButtonType="Image"
                                            DeleteImageUrl="Recursos/EliminaReg.png"
                                            ShowDeleteButton="True" InsertVisible="False" ShowCancelButton="False"  ItemStyle-HorizontalAlign="Left">

                                         <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:CommandField>

                                        



                                        <asp:ButtonField CommandName="Descarga" Text="Descargar" />

                                        



                                    </Columns>

                                    <PagerStyle BackColor="#74A38E" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#74A38E" Font-Bold="True" ForeColor="White" Height ="20px" />

                                    <EditRowStyle BackColor="#2461BF" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>

  </ContentTemplate>


                                                  
                                            </asp:UpdatePanel>


                            </div>
                            <div class="form-group">

                                <asp:Button ID="btnImprimirSolicitud" runat="server" Text="Imprimir " type="submit" name="submit" class="btn btn-info btn-md" value="submit" Visible="False" ></asp:Button>

                                <asp:Button ID="btnSiguienteEstatus" runat="server" Text="Siguiente Estatus " type="submit" name="submit" class="btn btn-info btn-md" value="submit" Visible="False" ></asp:Button>

                                <asp:Button ID="btnOtrosEstatus" runat="server" Text="Otros Estatus " type="submit" name="submit" class="btn btn-info btn-md" value="submit" Visible="False" OnClick="btnOtrosEstatus_Click" ></asp:Button>


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
            top: 40%;
            left: 40%;
            height: 20%;
            width: 20%;
            z-index: 100001;
            background-color: #ffffff;
            border: 1px solid Gray;
            background-image: url('');
            background-repeat: no-repeat;
            background-position: center;
            b
        }
    </style>

</asp:Content>

