<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformeAusentismo.aspx.cs" Inherits="Vistas.Usuario.Admin.Informes.InformeAusentismo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>AUSENTISMO POR FECHA</title>

    <link href="~/Estilos.css" rel="stylesheet" type="text/css" />
<link rel="icon" href="/Imagenes/icons8-corazón-con-pulso-96 (1).png" type="image/png" />

    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
        .auto-style2 {
            height: 18px;
        }
        .auto-style3 {
            background-color: #dddddd;
            border-radius: 5px;
            color: steelblue;
            font-weight: 600;
            border: solid 1px steelblue;
            font-size: 20px;
            text-decoration: none;
            display: inline-block;
        }

            .botones-grises:hover {
                background-color: steelblue;
                color: white;
            }

        .auto-style4 {
            background-color: white;
            text-align: center;
            width: 33%;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
        }
        .auto-style5 {
            font-size: 35px;
            font-weight: 700;
            color: steelblue;
            margin-left: 0px;
        }
        .auto-style6 {
            height: 24px;
        }
        .auto-style7 {
            height: 7px;
        }
        .auto-style8 {
            height: 6px;
        }
        .auto-style9 {
            height: 18px;
            width: 306px;
        }
        .auto-style10 {
            height: 26px;
            width: 306px;
        }
        .auto-style11 {
            width: 306px;
        }
        .auto-style12 {
            width: 149px;
        }
        .auto-style13 {
            height: 24px;
            width: 149px;
        }
        .auto-style14 {
            width: 44px;
        }
        .auto-style15 {
            height: 24px;
            width: 44px;
        }
        .auto-style16 {
            background-color: white;
            width: 33%;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
        }
    </style>

</head>

<body>

<form id="form1" runat="server">

    <!-- Encabezado -->

    <table class="tabla-barra-superior" border="0" cellspacing="0" cellpadding="0">

        <tr>

            <td class="auto-style4">
                <asp:HyperLink ID="hlHomeInforme"
                    runat="server"
                    NavigateUrl="~/Usuario/Admin/Informes/HomeInformes.aspx"
                    Font-Bold="True" CssClass="hylink-limpio" Style="display: block; text-align: left; margin-left: 25px;" Width="147px">VOLVER</asp:HyperLink>
            </td>

            <td style="text-align:center" class="auto-style16">
                <asp:Label ID="lblInformeAusentismo"
                    runat="server"
                    CssClass="auto-style5"
                    Text="AUSENTISMO POR FECHA" Style="display: block; text-align: center;" Width="552px"></asp:Label>
            </td>

            <td class="auto-style16">
                <div style="display: flex; justify-content: flex-end; align-items: center; width: 100%;"> 	
                <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
&nbsp;<asp:Label ID="lblUsuario"
                    runat="server"
                    Font-Bold="True" ForeColor="SteelBlue" Style="margin-right: 25px;"></asp:Label>
                </div>
            </td>

        </tr>

    </table>

    <!-- Contenido -->

    <div class="contenido">

        <table class="tabla-datos">

            <tr>

                <td class="auto-style2"></td>

                <td class="auto-style2"></td>

                <td class="auto-style9">
                </td>

            </tr>

            <tr>

                <td class="auto-style1">&nbsp;</td>

                <td class="auto-style1">Fecha desde:&nbsp;&nbsp; </td>

                <td class="auto-style10">
                    <asp:TextBox ID="txtFechaDesde"
                        runat="server"
                        TextMode="Date">
                    </asp:TextBox>
                </td>

            </tr>

            <tr>

                <td>&nbsp;</td>

                <td>Fecha hasta:&nbsp;&nbsp;&nbsp;&nbsp; </td>

                <td class="auto-style11">
                    <asp:TextBox ID="txtFechaHasta"
                        runat="server"
                        TextMode="Date">
                    </asp:TextBox>
                </td>

            </tr>

            <tr>

                <td class="auto-style8">
                    </td>

                <td colspan="2" class="auto-style8">
                </td>

            </tr>

            <tr>

                <td>&nbsp;</td>

                <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnGenerar"
                        runat="server"
                        Text="Generar Informe"
                        Font-Bold="True"
                        OnClick="btnGenerar_Click" CssClass="auto-style3" Height="30px" Width="170px" />
                </td>

            </tr>

            <tr>

                <td class="auto-style7"></td>

                <td class="auto-style7" colspan="2"></td>

            </tr>

            <tr>

                <td>

                    &nbsp;</td>

                <td colspan="2">

                    <asp:Label ID="lblMensaje"
                        runat="server">
                    </asp:Label>

                </td>

            </tr>

            <tr>

                <td>

                    &nbsp;</td>

                <td colspan="2">

                    <table class="centrado-recuadro">
                        <tr>
                            <td class="auto-style14">&nbsp;</td>
                            <td class="auto-style12">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style14">&nbsp;</td>
                            <td class="auto-style12">Total Turnos:</td>
                            <td>
                    <asp:Label ID="lblTotal"
                        runat="server"
                        Font-Bold="True">
                    </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">&nbsp;</td>
                            <td class="auto-style12">Total Presentes:</td>
                            <td>
                    <asp:Label ID="lblPresentes"
                        runat="server"
                        Font-Bold="True">
                    </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style15">&nbsp;</td>
                            <td class="auto-style13">Total Ausentes:</td>
                            <td class="auto-style6">
                    <asp:Label ID="lblAusentes"
                        runat="server"
                        Font-Bold="True">
                    </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">&nbsp;</td>
                            <td class="auto-style12">Porcentaje Presentes:</td>
                            <td>
                    <asp:Label ID="lblPorcentajePresentes"
                        runat="server"
                        Font-Bold="True">
                    </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">&nbsp;</td>
                            <td class="auto-style12">Porcentaje Ausentes:</td>
                            <td>
                    <asp:Label ID="lblPorcentajeAusentes"
                        runat="server"
                        Font-Bold="True">
                    </asp:Label>
                            </td>
                        </tr>
                    </table>

                </td>

            </tr>

            <tr>

                <td>

                    &nbsp;</td>

            </tr>

            <tr>

                <td>

                    &nbsp;</td>

            </tr>

            <tr>

                <td>

                    &nbsp;</td>

            </tr>

            <tr>

                <td>

                    &nbsp;</td>

            </tr>

        </table>

    </div>

</form>

</body>
</html>