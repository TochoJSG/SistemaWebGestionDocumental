<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebGeneraSolicitud.aspx.cs" Inherits="WebEpSIF.WebGeneraSolicitud" MasterPageFile="~/MasterPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
  
    <link href="WebGeneraSolicitud.css" rel="stylesheet" />


    <div class="style1">
        <h2>Carga de Evidencias</h2>

        <div id="login">
            <div class="container">
                <div id="login-row" class="row justify-content-center align-items-center">
                    <div id="login-column" class="col-md-6">
                        <div id="login-box" class="col-md-12">

                            <table border="0">
                               <%-- <tr>

                                    <td colspan="2" class="tituloencabezado">Detalle</td>


                                </tr>--%>


                                 
                                <tr>
                                     <td >
                                          <div >


                                        
                                         


                                        </div>
                                    </td>
                                    

                                     
                                          <tr>
                                         <td>
                                       
                                          </td>
                                         <td style="color: #3366FF; font-size: small">

                                             Periodo<asp:RequiredFieldValidator ID="cvPeriodo" InitialValue="0" runat="server" ControlToValidate="ddlPeriodo" ForeColor="Red" ErrorMessage="El Campo periodo es obligatorio." Font-Bold="False" Font-Size="Large">*</asp:RequiredFieldValidator>
                                         
                                           
                                            
                                         


                                              </td>

                                              <td>
                                              
                                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                         
                                          <td style="color: #3366FF; font-size: smaller" class="auto-style1">

                                               Candidato<asp:RequiredFieldValidator ID="rfvCandidato" InitialValue="0" runat="server" ControlToValidate="ddlCandidato" ForeColor="Red" ErrorMessage="El campo candidato es obligatorio." Font-Bold="False" Font-Size="Large">*</asp:RequiredFieldValidator>
                                           
                                            
                                             
                                         


                                              </td>
                                          
                                          </tr>
                                    

                                <tr>
                                         <td>
                                       
                                       
                                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                                         <td>

                                            
                                          <asp:DropDownList ID="ddlPeriodo" runat="server" Width="334px" class="form-control" OnSelectedIndexChanged="ddlPeriodo_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>

                                            
                                         </td>

                                              <td>
                                              
                                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; </td>
                                         
                                          <td class="auto-style1">

                                            
                                <asp:DropDownList ID="ddlCandidato" runat="server" Width="334px" class="form-control" OnSelectedIndexChanged="ddlCandidato_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>

                                            
                                             </td>
                                          
                                          </tr>
                                    
                               
                                <tr>
                                         <td>
                                       
                                       
                                          </td>
                                         <td style="font-size: smaller; color: #3366FF;">

                                           
                                            
                                         


                                             Candidatura<asp:RequiredFieldValidator ID="cvCandidatura" InitialValue="0" runat="server" ControlToValidate="ddlColectivaDetalle" ForeColor="Red" ErrorMessage="El Campo candidatura es obligatorio." Font-Bold="False" Font-Size="Large">*</asp:RequiredFieldValidator>
                                         
                                           
                                            
                                         


                                         </td>

                                              <td>
                                              
                                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                         
                                          <td style="color: #3366FF; font-size: smaller" class="auto-style1">

                                            
                                              Tipo de Gasto<asp:RequiredFieldValidator ID="cvTipoGasto" InitialValue="0" runat="server" ControlToValidate="ddlConcepto" ForeColor="Red" ErrorMessage="El campo tipo de gasto es obligatorio." Font-Bold="False" Font-Size="Large">*</asp:RequiredFieldValidator>
                                           
                                          
                                           
                                             </td>
                                          
                                          </tr>
                                    
                                 <tr>
                                         <td>
                                       
                                       
                                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                                         <td>

                                          <asp:DropDownList ID="ddlColectivaDetalle" runat="server" Width="334px" class="form-control" OnSelectedIndexChanged="ddlColectivaDetalle_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                              </td>

                                              <td>
                                              
                                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                         
                                          <td class="auto-style1">

                                            
                                         <asp:DropDownList ID="ddlTipoGasto" runat="server" Width="335px" class="form-control" OnSelectedIndexChanged="ddlTipoGasto_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                       
                                            
                                             </td>
                                          
                                          </tr>

                                 <tr>
                                         <td>
                                       
                                       
                                          </td>
                                         <td style="color: #3366FF; font-size: smaller">


                                        
                                             Estado<asp:RequiredFieldValidator ID="rfvEventoEspecifico" InitialValue="0" runat="server" ControlToValidate="ddlEventoEspecifico" ForeColor="Red" ErrorMessage="El campo Estado es obligatorio." Font-Bold="False" Font-Size="Large">*</asp:RequiredFieldValidator>
                                           
                                            
                                             
                                         


                                            </td>

                                              <td>
                                              
                                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                         
                                          <td style="color: #3366FF; font-size: smaller" class="auto-style1">

                                            
                                              Concepto<asp:RequiredFieldValidator ID="cvConcepto" InitialValue="0" runat="server" ControlToValidate="ddlConcepto" ForeColor="Red" ErrorMessage="El campo concepto es  obligatorio." Font-Bold="False" Font-Size="Large">*</asp:RequiredFieldValidator>
                                         
                                           
                                            
                                         


                                             </td>
                                          
                                          </tr>

                                 <tr>
                                         <td>
                                       
                                       
                                          </td>
                                         <td>

                                <asp:DropDownList ID="ddlEventoEspecifico" runat="server" Width="334px" class="form-control" OnSelectedIndexChanged="ddlEventoEspecifico_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                       
                                          </td>

                                              <td>
                                              
                                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                         
                                          <td class="auto-style1">

                                            
                                         <asp:DropDownList ID="ddlConcepto" runat="server" Width="335px" class="form-control" OnSelectedIndexChanged="ddlConcepto_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                       
                                            
                                             </td>
                                          
                                          </tr>

                                 <tr>
                                         <td>
                                       
                                       
                                          </td>
                                         <td style="color: #3366FF; font-size: smaller">


                                        
                                             Distrito<asp:RequiredFieldValidator ID="rfvDistrito" InitialValue="0" runat="server" ControlToValidate="ddlDistrito" ForeColor="Red" ErrorMessage="El campo distrito es obligatorio." Font-Bold="False" Font-Size="Large">*</asp:RequiredFieldValidator>
                                           
                                            
                                             
                                         


                                            </td>

                                              <td>
                                              
                                                  </td>
                                         
                                          <td class="auto-style1">

                                            
                                        
                                            <asp:Label ID="Label5" runat="server" Text="Evidencias" Font-Bold="False" ForeColor="#3366FF" Font-Size="Small"></asp:Label>

                                            
                                            <asp:RequiredFieldValidator ID="cvEvidencia" InitialValue="0" runat="server" ControlToValidate="ddlDocumento" ForeColor="Red" ErrorMessage="El campo evidencia es  obligatorio." Font-Bold="False" Font-Size="Large">*</asp:RequiredFieldValidator>
                                         
                                           
                                            
                                         


                                             </td>
                                          
                                          </tr>

                                 <tr>
                                         <td>
                                       
                                       
                                          </td>
                                         <td>

                                            
                                         <asp:DropDownList ID="ddlDistrito" runat="server" Width="335px" class="form-control" OnSelectedIndexChanged="ddlDistrito_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                       
                                            
                                          </td>

                                              <td>
                                              
                                                    </td>
                                         
                                          <td class="auto-style1">

                                            
                                         <asp:DropDownList ID="ddlDocumento" runat="server" Width="335px" class="form-control" OnSelectedIndexChanged="ddlDocumento_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                       
                                            
                                             </td>
                                          
                                          </tr>

                                 <tr>
                                         <td>
                                       
                                       
                                          </td>
                                         <td>

                                             &nbsp;</td>

                                              <td>
                                              
                                                    </td>
                                         
                                          <td class="auto-style1">

                                            
                                              <asp:Label ID="Label1" runat="server" Text="El documento de evidencia deberá ser solo de las extensiones siguientes:" Font-Size="Small" ForeColor="#3366FF" Font-Bold="True"></asp:Label>

                                            
                                             <asp:Label ID="lblExtensiones" runat="server" Font-Size="Small" Font-Bold="True"></asp:Label>

                                            
                                             </td>
                                          
                                          </tr>

                                 <tr>
                                         <td>
                                       
                                       
                                          </td>
                                         <td>

                                             <asp:ScriptManager ID="ScriptManager1" runat="server">
                                            </asp:ScriptManager>
                                            
                                            <%--<img src="Recursos/800.gif" />--%>                                            <%--<img src="Images/ajax-loader.gif" style="text-align:center" /> Cargando...--%>
                                    

                                               <asp:Button ID="btnAgregar" runat="server" Text="+ Agregar  documento" type="submit" name="submit"  value="submit" OnClick="btnAgregar_Click" BackColor="#3333FF" Font-Bold="True" ForeColor="White" BorderStyle="None" Width="165px" Height="40px"></asp:Button>

                
                                         </td>

                                              <td>
                                              
                                                   </td>
                                         
                                          <td class="auto-style1">

                                            
                                              &nbsp;</td>
                                          
                                          </tr>

                                 
                                 <tr style="font-size: smaller">
                                         <td>
                                       
                                       
                                          </td>
                                         <td>

                                             &nbsp;</td>

                                              <td>
                                              
                                                   &nbsp;</td>
                                         
                                          <td class="auto-style1">

                                            
                                             
                                            
                                             <asp:FileUpload ID="FileUploadEstados" runat="server" ToolTip="El nombre del archivo solo deberá contener los siguientes caracteres: de la letra “a” a la “z”, mayúsculas o minúsculas, dígitos del 0 al 9, los caracteres especiales _, +, -, ., $, % y el &quot;espacio en blanco&quot; (exceptuando la ñ, Ñ, acentos y diéresis)." />
                                            </td>
                                          
                                          </tr>
                          
                                
                                
                          
                                


                                       
                                        

                               

                               
                                
                            </table>


                         

                             
                                

                             <table>
                          

                                  <tr>
                                        
                                        <td>

                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>

                                      <td style="background-color: #FFFFFF">
                                
                                 
                                  &nbsp;&nbsp;&nbsp;
                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server"  DisplayAfter="1000"   >

                                                <ProgressTemplate>
                                                    <div id="Background"> </div>
                                                        
                                                   
                                                    <div id="Progress">
                                                        <br /></b>
                                                          <p style="text-align:center"   > <b style="color: #3333FF">  Procesando, Favor de esperar...<br /></b> <br /></b> <img src="Recursos/77.gif""   />  </p> 
                                                             
                                                        <%--<img src="Recursos/800.gif" />--%>
                                                          
                                                   <%--<img src="Images/ajax-loader.gif" style="text-align:center" /> Cargando...--%>
                                                  </div>

                                                   
                                                </ProgressTemplate>



                                            </asp:UpdateProgress>


                                             
                                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                 
                                  <asp:GridView ID="gvDetalleSolicitud" runat="server" CellPadding="4" ForeColor="#333333" DataKeyNames="IdRegistro"
                                    GridLines="None" AutoGenerateColumns="False"
                                    Font-Size="Small" Width="736px" OnRowDeleting="onrowdeleting" OnRowDataBound="ondatabound" OnRowCommand="gvDetalleSolicitud_RowCommand" OnSelectedIndexChanged="gvDetalleSolicitud_SelectedIndexChanged" Height="20px">
                                    <RowStyle BackColor="#EFF3FB" />

                                    <Columns>

                                        <asp:BoundField DataField="IdRegistro" HeaderText="IdRegistro" Visible="False" />
                                        <asp:BoundField DataField="IdEstado" HeaderText="IdEstado" Visible="False" />
                                        <asp:BoundField DataField="IdNivel" HeaderText="IdNivel" Visible="False" />
                                        <asp:BoundField DataField="IdTipoGasto" HeaderText="IdTipoGasto" Visible="False" />
                                        <asp:BoundField DataField="Estado" HeaderText="Estado" Visible="False"/>
                                        <asp:BoundField DataField="Nivel" HeaderText="Nivel"/>
                                        <asp:BoundField DataField="TipoGasto" HeaderText="Tipo Gasto" Visible="False"/>
                                        <asp:BoundField DataField="Archivo" HeaderText="Documento"/>

                                        <asp:ButtonField Text="Ver documento" CommandName="Select" HeaderText="Ver documento" />
                                        <asp:CommandField ButtonType="Image"
                                            DeleteImageUrl="Recursos/EliminaReg.png"
                                            ShowDeleteButton="True" InsertVisible="False" ShowCancelButton="False"  ItemStyle-HorizontalAlign="Left" HeaderText="Borrar">

                                         <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:CommandField>

                                        



                                    </Columns>

                                    <PagerStyle BackColor="#009999" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="#3366FF" Height ="20px" />

                                    <EditRowStyle BackColor="#2461BF" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>

                                                                         
</ContentTemplate>

</asp:UpdatePanel>


                             </td>
                                          
                                          </tr>

                             </table>
                                

                             
                        <br />

                         <div>

                            
                            <div class="alert alert-danger">
                                <asp:ValidationSummary ID="ValidaDetalle" runat="server" />

                            </div>

                        </div>


                    </div>
                </div>
                               
            </div>

        </div>
    </div>
    
 <style type="text/css">


    #Background
	{
		position: fixed;
		top: 0px;
		bottom: 0px;
		left:0px;
		right: 0px;
		overflow: hidden;
		padding:0;
		margin:0;
		background-color: #F0F0F0;
		filter: alpha(opacity=80);
		opacity:0.8;
		z-index:100000;

	}

	#Progress
	{
		position: fixed;
		top: 40%;
		left: 40%;
		height:20%;
		width:20%;
		z-index:100001;
		background-color:#ffffff;
		border:1px solid Gray;
		background-image: url(''); 
		background-repeat: no-repeat ;
		background-position:center;  
          

	}







    </style>

               
</asp:Content>


