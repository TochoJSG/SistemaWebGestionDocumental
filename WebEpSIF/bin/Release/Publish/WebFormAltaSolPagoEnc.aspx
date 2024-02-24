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
                    <div id="login-column" class="col-md-6">
                        <div id="login-box" class="col-md-12">

                            <table border="0">
                                <tr>
                                    <td colspan="2" class="tituloencabezado">&nbsp;</td>


                                </tr>


                                <tr>
                                    <td>
                                        <div class="form-group">
                                            Estado<asp:DropDownList ID="ddlDependencia" runat="server" Width="500px" class="form-control" OnSelectedIndexChanged="ddlDependencia_SelectedIndexChanged">
                                            </asp:DropDownList>
                                           
                                        </div>
                                    </td>
                                    <td>
                                        <div class="form-group">
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    
                                    <td>
                                        &nbsp;</td>

                                    <%--<asp:Button ID="btnBuscar" runat="server" Text="Buscar"  class="btn btn-info btn-md"  ></asp:Button>--%><%--<asp:TextBox ID="txtBuscColectiva" runat="server" Width="345px" class="form-control"></asp:TextBox>--%><%--</td>--%>
                                        <%--<asp:TextBox ID="txtConceptoz" runat="server"  type="text" MaxLength="255"   Width="1005px" class="form-control" height ="50px"  Style="text-transform: uppercase"  ></asp:TextBox>--%>
                                       
                                    <%--</td>--%>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="GridViewMatriz" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="420px" OnSelectedIndexChanged="GridViewMatriz_SelectedIndexChanged" Width="1116px">
                                            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                            <RowStyle BackColor="White" ForeColor="#003399" />
                                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                            <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                            <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                            <SortedDescendingHeaderStyle BackColor="#002876" />
                                        </asp:GridView>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="form-group">
                                             <asp:TextBox ID="txtBeneficiarioCheque" runat="server" Width="500px" class="form-control" MaxLength='60' Style="text-transform: uppercase"></asp:TextBox>
                                      
                                        </div>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="auto-style1">


                                        <div class="form-group">

                                            <%--<asp:TextBox ID="txtConceptoz" runat="server"  type="text" MaxLength="255"   Width="1005px" class="form-control" height ="50px"  Style="text-transform: uppercase"  ></asp:TextBox>--%>
                                        
                                        </div>
                                    </td>
                                    <td class="auto-style1"></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>

                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
    .auto-style1 {
        height: 35px;
    }
</style>
</asp:Content>

