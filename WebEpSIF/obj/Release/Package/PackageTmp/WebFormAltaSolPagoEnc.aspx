<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormAltaSolPagoEnc.aspx.cs" Inherits="WebEpSIF.WebFormAltaSolPagoEnc" MasterPageFile="~/MasterPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    <link href="WebFormAltaSolPagoEnc.css" rel="stylesheet" />

    <div class="style1">
      <h2>Matriz de Carga</h2>
        <div id="login">
       
           <div class="container">
                <div id="login-row" class="row justify-content-center align-items-center">  

                            <table border="0" class="auto-style1">
                                

                               
                                            <%--<img src="Recursos/800.gif" />--%>                                            <%--<img src="Images/ajax-loader.gif" style="text-align:center" /> Cargando...--%>
                                          
                                
                                
                                <tr>
                                    <td>
                                        <div class="form-group" style="color: #3333FF">
                                            Estado&nbsp;&nbsp;&nbsp;&nbsp;
                                           
                                            <asp:DropDownList ID="ddlEstado" runat="server" class="form-control" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged1" AutoPostBack="true">
                                            </asp:DropDownList>
                                           
                                        </div>
                                    </td>
                                     <td>
                                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                                     <td>
                                        <div class="form-group" style="color: #3333FF">
                                            Candidato&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;<asp:DropDownList ID="ddlCandidato" runat="server" class="form-control" OnSelectedIndexChanged="ddlCandidato_SelectedIndexChanged1" AutoPostBack="true" Width="396px">
                                            </asp:DropDownList>
                                         </div>
                                    </td>
                                    
                                 <asp:ScriptManager ID="ScriptManager1" runat="server">
                                            </asp:ScriptManager>
                                            
                                      <asp:UpdateProgress ID="UpdateProgress1" runat="server"  DisplayAfter="1000" Visible="False">

                                                <ProgressTemplate>
                                                    <div id="Background"> </div>
                                                        
                                                   
                                                    <div id="Progress">
                                                        <br /></b>
                                                          <p style="text-align:center"   > <b style="color: #008080">  Enviando Avisos, Favor de esperar...<br /></b> <br /></b> <img src="Recursos/77.gif""   />  </p> 
                                                             
                                                        <%--<img src="Recursos/800.gif" />--%>
                                                          
                                                   <%--<img src="Images/ajax-loader.gif" style="text-align:center" /> Cargando...--%>
                                                  </div>

                                                   
                                                </ProgressTemplate>



                                            </asp:UpdateProgress>

                                         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                  
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnEnvioExcel" runat="server"  class="btn btn-info btn-md" Text="Enviar a Excel" OnClick="btnEnvioExcel_Click" />
                                           
                                            <asp:Button ID="btnEnvioCorreo" runat="server"  class="btn btn-info btn-md" OnClick="btnEnvioCorreo_Click" Text="Envio de Alertas" />
                                           
                                        <br />
                                           <br /> 
                                    </td>
                                    
                                    <td>
                                           
                                            &nbsp;</td>
                                     <td>
                                           



                                            <asp:Label ID="Label1" runat="server" BackColor="#FFCCCC" ForeColor="#FFCCCC" Text="Label"></asp:Label>
                                             &nbsp;Documentos faltantes por concepto&nbsp;&nbsp;
                                            <asp:Label ID="Label2" runat="server" BackColor="GreenYellow" ForeColor="GreenYellow" Text="Label"></asp:Label>
                                             &nbsp;Documentos cargados por concepto &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                         
                                           <asp:Label ID="Label3" runat="server" BackColor= "#ff6600" ForeColor="White"   Visible="false" Text="Label" ></asp:Label>
                                           
                                         

                                     </td>
                                    <%--</td>--%><%--<asp:TextBox ID="txtConceptoz" runat="server"  type="text" MaxLength="255"   Width="1005px" class="form-control" height ="50px"  Style="text-transform: uppercase"  ></asp:TextBox>--%><%--</td>--%>                                        <%--<asp:TextBox ID="txtConceptoz" runat="server"  type="text" MaxLength="255"   Width="1005px" class="form-control" height ="50px"  Style="text-transform: uppercase"  ></asp:TextBox>--%>
                                       
                                    <%--</td>--%>
                                </tr>


                                 
                             <asp:GridView ID="GridViewMatriz" CssClass="table"   AutoGenerateColumns ="false"  HeaderStyle-BackColor ="#cccccc" HeaderStyle-ForeColor ="White" runat ="server" Height="420px" OnSelectedIndexChanged="GridViewMatriz_SelectedIndexChanged" Width="1116px" OnRowDataBound="GridViewMatriz_RowDataBound">
                                            <Columns>
                                                <asp:BoundField DataField="Concepto" HeaderText="Concepto"  />
                                                <asp:BoundField DataField="Evento" HeaderText="Tipo Gasto"  />
                                                <asp:BoundField DataField="CANTIDADFACTURAPDF" HeaderText="Factura PDF"  />
                                                <asp:BoundField DataField="CANTIDADXML" HeaderText="XML" />
                                                <asp:BoundField DataField="CANTIDADPAG" HeaderText="Pago" />
                                                <asp:BoundField DataField="CANTIDADCON" HeaderText="Contrato" />
                                           
                                                
                                               <asp:BoundField DataField="CANTIDADAVC" HeaderText="Aviso de Contratación" />
                                               <asp:BoundField DataField="CANTIDADAUV" HeaderText="Audio/video" /> 
                                               <asp:BoundField DataField="CANTIDADIMF" HeaderText="Imagen/Foto" /> 
                                               <asp:BoundField DataField="CANTIDADHOM" HeaderText="Hoja Membretada" /> 
                                               <asp:BoundField DataField="CANTIDADCRE" HeaderText="Credenciaal de Elector" /> 
                                               <asp:BoundField DataField="CANTIDADREI" HeaderText="Recibo Interno" /> 
                                               <asp:BoundField DataField="CANTIDADPEC" HeaderText="Permiso de Colocación" /> 
                                               <asp:BoundField DataField="CANTIDADKAR" HeaderText="Kardex" /> 
                                               <asp:BoundField DataField="CANTIDADREP" HeaderText="Relación Pormenorizada" /> 
                                               <asp:BoundField DataField="CANTIDADCOT" HeaderText="Cotización" /> 
                                               <asp:BoundField DataField="CANTIDADEXP" HeaderText="Expediente de Proveedor" /> 
                                               <asp:BoundField DataField="CANTIDADOTR" HeaderText="Otros" /> 
                                               <asp:BoundField DataField="CANTIDADRLP" HeaderText="REL-PROM" /> 
                                               <asp:BoundField DataField="CANTIDADESC" HeaderText="Estado de Cuenta" />

                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            </Columns>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:GridView>
                    </ContentTemplate>


                                                  
                                            </asp:UpdatePanel>

                                </table>
                        </div>
                   
                         </div>
                   
                    
    </div>
    </div>
</asp:Content>




