<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebCapturaDocumentos.aspx.cs" Inherits="WebEpSIF.WebCapturaDocumentos" MasterPageFile="~/MasterPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    

    
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
  
    <link href="WebCapturaDocumentos.css" rel="stylesheet" />



    <script type ="text/javascript" >
        function checkOne(objRef)
        {
            var row = objRef.parentNode.parentNode;

            if (objRef.checked)
            {
                row.style.backgroundColor = "#3366FF"
            }
            else
            {
                if (row.rowIndex % 2 == 0) {
                    row.style.backgroundColor = "#D1DDF1";
                    
                }
                else
                {
                    row.style.backgroundColor = "White";
                }

                              
            }

                
                var gridview = row.parentNode;
                var inputList = gridview.getElementsByTagName("input");
                for (var i = 0; i < inputList.length; i++)
                {
                    var headerInput = inputList[0];
                    var checked = true;
                    if (inputList[i].type == "checkbox" && inputList[i] != headerInput)
                    {
                        if (!inputList[i].checked)
                        {
                            checked = false;
                            break;

                        }

                    }
                }
                       headerInput.checked = checked;
            

        }

        function checkAll(objRef)

        {

            var gridview = objRef.parentNode.parentNode.parentNode;
            var inputList = gridview.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {

                var row = inputList[i].parentNode.parentNode;

                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        row.style.backgroundColor = "#3366FF";
                        inputList[i].checked = true;



                    }
                    else {

                        if (row.rowIndex % 2 == 0) {
                            row.style.backgroundColor = "#D1DDF1";
                        }

                        else {


                            row.style.backgroundColor = "white";

                        }

                        inputList[i].checked = false;
                 
                



                    }

                }
            }





        }


    </script>

    <div class="style1">
        <h2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Descarga&nbsp; de Evidencias</h2>

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

                                             Periodo</td>

                                              <td>
                                              
                                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                         
                                          <td style="color: #3366FF; font-size: smaller" class="auto-style1">

                                               Candidato</td>
                                          
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

                                           
                                            
                                         


                                             Candidatura</td>

                                              <td>
                                              
                                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                         
                                          <td style="color: #3366FF; font-size: smaller" class="auto-style1">

                                            
                                              Tipo de Gasto</td>
                                          
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


                                        
                                             Estado</td>

                                              <td>
                                              
                                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                         
                                          <td style="color: #3366FF; font-size: smaller" class="auto-style1">

                                            
                                              Concepto</td>
                                          
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


                                        
                                             Distrito</td>

                                              <td>
                                              
                                                  </td>
                                         
                                          <td class="auto-style1">

                                            
                                        
                                            <asp:Label ID="Label5" runat="server" Text="Evidencias" Font-Bold="False" ForeColor="#3366FF" Font-Size="Small"></asp:Label>

                                            
                                            
                                         


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

                                             Fecha Inicial</td>

                                              <td>
                                              
                                                    </td>
                                         
                                          <td class="auto-style1">

                                            
                                              Fecha Final</td>
                                          
                                          </tr>

                                 <tr>
                                         <td>
                                       
                                       
                                          </td>
                                         <td>

                                              <asp:TextBox ID="txtFechaInicio" runat="server" OnTextChanged="txtFechaFin_TextChanged"></asp:TextBox>
                                            <asp:Button ID="btnFechaInicio" runat="server" OnClick="btnFechaInicio_Click" Text="V" Width="30px" BackColor="White" BorderStyle="None" Font-Bold="True" ForeColor="#74A38E" />
                                   

                                              &nbsp;</td>

                                              <td>
                                              
                                                   </td>
                                         
                                          <td class="auto-style1">

                                            
                                                  <asp:TextBox ID="txtFechaFin" runat="server" OnTextChanged="txtFechaFin_TextChanged"></asp:TextBox>
                                                  <asp:Button ID="btnFechaFin" runat="server"  Text="V" Width="30px" BackColor="White" BorderStyle="None" Font-Bold="True" ForeColor="#74A38E"  OnClick="btnFechaFin_Click" />

                                         </td>
                                          
                                          </tr>

                                 
                                 <tr style="font-size: smaller">
                                         <td>
                                       
                                       
                                          </td>
                                         <td>

                                             <asp:Calendar ID="CalFechaInicio" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px" OnSelectionChanged="CalFechaInicio_SelectionChanged">
                                                 <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                                 <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                                 <OtherMonthDayStyle ForeColor="#999999" />
                                                 <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                                 <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                                 <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                                 <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                                 <WeekendDayStyle BackColor="#CCCCFF" />
                                             </asp:Calendar>
                                         </td>

                                              <td>
                                              
                                                   &nbsp;</td>
                                         
                                          <td class="auto-style1">

                                            
                                             
                                            
                                              <asp:Calendar ID="CalFechaFin" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px" OnSelectionChanged="CalFechaFin_SelectionChanged">
                                                  <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                                  <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                                  <OtherMonthDayStyle ForeColor="#999999" />
                                                  <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                                  <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                                  <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                                  <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                                  <WeekendDayStyle BackColor="#CCCCFF" />
                                              </asp:Calendar>
                                         </td>
                                          
                                          </tr>
                          
                                
                                 <tr>
                                         <td>
                                       
                                       
                                          </td>
                                         <td>

                                         </td>

                                              <td>
                                              
                                                   &nbsp;</td>
                                         
                                          <td class="auto-style1">

                                            
                                             
                                            
                                              &nbsp;</td>
                                          
                                          </tr>
                          
                                


                                       
                                        <tr>
                                         <td>
                                       
                                       
                                          </td>
                                         <td>

                                             <asp:Button ID="btnConsultaCarpetas" runat="server" OnClick="btnConsultaCarpetas_Click" Text="Consultar" BackColor="#3333FF" BorderColor="White" BorderStyle="None" ForeColor="White" Font-Bold="True" Height="40px" />
                                            </td>

                                              <td>
                                              
                                                   &nbsp;</td>
                                         
                                          <td class="auto-style1">

                                            
                                               &nbsp;</td>
                                          
                                          </tr>

                               

                               
                                
                            </table>


                         

                             
                                

                             <table>
                          

                                  <tr>
                                        
                                        <td>

                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>

                                      <td style="background-color: #FFFFFF">
                                
                                 
                                  &nbsp;&nbsp;&nbsp;
                                

                                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                                            </asp:ScriptManager>
                                            
                                            <%--<img src="Recursos/800.gif" />--%>                                            <%--<img src="Images/ajax-loader.gif" style="text-align:center" /> Cargando...--%>
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
                                 
                                   <asp:GridView ID="gvDetalleSolicitud" runat="server" CellPadding="4" ForeColor="#333333" DataKeyNames="idregistromatriz"
                                    GridLines="None" AutoGenerateColumns="False"
                                    Font-Size="Small" Width="800px" OnRowDeleting="onrowdeleting" OnRowDataBound="ondatabound"  OnSelectedIndexChanged="gvDetalleSolicitud_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanged="gvDetalleSolicitud_PageIndexChanged" OnPageIndexChanging="gvDetalleSolicitud_PageIndexChanging" PageSize="5" HorizontalAlign="Center">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />



<%--
                                        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" DataKeyNames="IdRegistro"
                                    GridLines="None" AutoGenerateColumns="False"
                                    Font-Size="Small" Width="428px" OnRowDeleting="onrowdeleting" OnRowDataBound="ondatabound" OnRowCommand="gvDetalleSolicitud_RowCommand" OnSelectedIndexChanged="gvDetalleSolicitud_SelectedIndexChanged" Height="20px">
                                    <RowStyle BackColor="#EFF3FB" />--%>
                                   
                                            
                                            
                                            <Columns>

                                        



                                        <%--<asp:ButtonField Text="Ver documento" CommandName="Select" Visible="False" />
                                        <asp:CommandField ButtonType="Image"
                                            DeleteImageUrl="Recursos/EliminaReg.png"
                                            ShowDeleteButton="True" InsertVisible="False" ShowCancelButton="False"  ItemStyle-HorizontalAlign="Left" Visible="False">

                                         <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        </asp:CommandField>

                                        



                                        <asp:ButtonField CommandName="Descarga" Text="Descargar" Visible="False" />

                                        --%>



                                                 <asp:TemplateField>
            
                      
                                              <HeaderTemplate>
                                                <asp:CheckBox ID="chbTodos" runat="server" onclick ="checkAll(this)" />
                                              </HeaderTemplate>
                      
                      
                                              <ItemTemplate>
                                                  <asp:CheckBox ID="chbItem" runat="server" onclick ="checkOne(this)" />
                                              </ItemTemplate>
                                             </asp:TemplateField>


                                        <asp:BoundField DataField="idregistromatriz" HeaderText="ID" ShowHeader="False"/>

                                        <asp:BoundField DataField="Agrupador" HeaderText="Agrupador" Visible="True"/>

                                        <asp:BoundField DataField="Candidato" HeaderText="Candidato"/>

                                        



                                        <asp:BoundField DataField="Periodo" HeaderText="Periodo" ShowHeader="False" Visible="False" />
                                        <asp:BoundField DataField="Candidatura" HeaderText="Candidatura" ShowHeader="False" Visible="False" />
                                        <asp:BoundField DataField="Estado" HeaderText="Estado" Visible="False" ShowHeader="False" />
                                        <asp:BoundField DataField="Distrito" HeaderText="Distrito" ShowHeader="False" Visible="False"/>
                                        <asp:BoundField DataField="Evento" HeaderText="Evento" ShowHeader="False" Visible="False"/>

                                        <asp:BoundField DataField="Concepto" HeaderText="Concepto"/>
                                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString = "{0:dd/MM/yyyy}" />

                                        <asp:BoundField DataField="Archivos" HeaderText="Archivos" />

                                        



                                        <asp:BoundField DataField="Documento" HeaderText="Documento" ShowHeader="False" Visible="False">

                                        </asp:BoundField>

                                        



                                    </Columns>

                                    <PagerStyle BackColor="#3333FF" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                    <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="#3333FF" Height ="20px" />

                                       <EditRowStyle BackColor="#999999" />
                                       <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                       <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                       <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                       <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                       <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
                                                     <br /></b>

                                                    <asp:Button ID="btnDescargar" runat="server" BackColor="#3333FF" BorderStyle="None" Font-Bold="True" ForeColor="White" Height="40px" OnClick="btnDescargar_Click" Text="Descargar elementos seleccionados" Width="282px" CssClass="col-xs-offset-0" />

</ContentTemplate>

</asp:UpdatePanel>
                             </td>
                                          
                           </tr>

                             </table>
                                

                             
                        <br />

                         <div>

                            
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
<%--<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 330px;
        }
    </style>





     




    </asp:Content>--%>
