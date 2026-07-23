<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformeMapaDeDemanda.aspx.cs" Inherits="Vistas.Usuario.Admin.Informes.InformeDemandaLocalidad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title>MAPA DE DEMANDA</title>

    <link href="~/Estilos.css" rel="stylesheet" type="text/css" />
<link rel="icon" href="/Imagenes/icons8-corazón-con-pulso-96 (1).png" type="image/png" />

    <style type="text/css">
        .auto-style1 {
            margin-left: 17px;
        }
        .auto-style2 {
            background-color: #dddddd;
            border-radius: 5px;
            color: steelblue;
            font-weight: 600;
            border: solid 1px steelblue;
            font-size: 20px;
            text-decoration: none;
            display: inline-block;
        }
            .auto-style2:hover {
                background-color: steelblue;
                color: white;
            }

        .auto-style3 {
            font-size: 35px;
            font-weight: 700;
            color: steelblue;
            margin-left: 0px;
        }
        #gvInforme td, #gvInforme th {
    border: 1px solid #cccccc;
        }

        .auto-style5 {
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

    <table class="tabla-barra-superior" border="0" cellspacing="0" cellpadding="0">

        <tr>

            <td class="auto-style5">

                <asp:HyperLink ID="hlHomeInforme"
                    runat="server"
                    NavigateUrl="~/Usuario/Admin/Informes/HomeInformes.aspx"
                    Style="display: block; text-align: left; margin-left: 25px;" CssClass="hylink-limpio" Width="245px">VOLVER</asp:HyperLink>

            </td>

            <td style="text-align:center" class="auto-style5">

                <asp:Label ID="lblInformeMapaDeDemanda"
                    runat="server"
                    CssClass="auto-style3"
                    Text="MAPA DE DEMANDA" Style="display: block; text-align: center;"></asp:Label>

            </td>

            <td class="auto-style5">
                <div style="display: flex; justify-content: flex-end; align-items: center; width: 100%;">
                &nbsp;<asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
&nbsp;<asp:Label ID="lblUsuario"
                    runat="server"
                    Style="margin-right: 25px;" ForeColor="SteelBlue"></asp:Label>
                </div>

            </td>

        </tr>

    </table>

    <div class="contenido">

        <table>

            <tr>

                <td>&nbsp;</td>

                <td colspan="3">&nbsp;</td>

            </tr>

            <tr>

                <td>&nbsp;</td>

                <td style="color: #333333">Fecha desde:</td>

                <td>
                    <asp:TextBox ID="txtFechaDesde"
                        runat="server"
                        TextMode="Date">
                    </asp:TextBox>
                </td>

            </tr>

            <tr>
                <td>&nbsp;</td>
                <td colspan="3">&nbsp;</td>
            </tr>

            <tr>

                <td>&nbsp;</td>

                <td style="color: #333333">Fecha hasta:</td>

                <td>
                    <asp:TextBox ID="txtFechaHasta"
                        runat="server"
                        TextMode="Date">
                    </asp:TextBox>
                </td>

            </tr>

            <tr>
                <td>&nbsp;</td>
                <td colspan="3">&nbsp;</td>
            </tr>

            <tr>

                <td>

                    &nbsp;</td>

                <td>

                    <asp:Button ID="btnGenerar"
                        runat="server"
                        Text="Generar"
                        Font-Bold="True"
                        OnClick="btnGenerar_Click" CssClass="auto-style2" Width="89px" />

                </td>

                <td>

                    &nbsp;<asp:Button ID="btnLimpiar"
                        runat="server"
                        Text="Limpiar"
                        Font-Bold="True"
                        Width="104px"
                        OnClick="btnLimpiar_Click" CssClass="auto-style2" />

                </td>

                <td style="padding-left:20px">

                    <asp:Label ID="lblMensaje"
                        runat="server">
                    </asp:Label>

                </td>

            </tr>

            <tr>
                <td>&nbsp;</td>
                <td colspan="3"><strong>&nbsp;</strong></td>
            </tr>

        </table>

        <asp:GridView ID="gvInforme"
            runat="server"
            AutoGenerateColumns="False"
            CellPadding="4"
            GridLines="None" CssClass="auto-style1" ForeColor="#333333">

            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

            <Columns>

                <asp:BoundField
                    DataField="Localidad"
                    HeaderText="Localidad" />

                <asp:BoundField
                    DataField="Provincia"
                    HeaderText="Provincia" />

                <asp:BoundField DataField="TurnosAtendidos" HeaderText="Pacientes Atendidos" />

                <asp:BoundField DataField="PorcentajeDemanda" HeaderText="Porcentaje de la Demanda" />

            </Columns>

            <EditRowStyle BackColor="#999999" />

            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

        </asp:GridView>

    </div>

</form>

</body>
</html>