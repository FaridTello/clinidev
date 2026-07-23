<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformePacientesPorFecha.aspx.cs" Inherits="Vistas.Usuario.Admin.Informes.InformePacientesPorFecha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title>PACIENTE POR FECHA</title>

    <link href="~/Estilos.css" rel="stylesheet" type="text/css" />
<link rel="icon" href="/Imagenes/icons8-corazón-con-pulso-96 (1).png" type="image/png" />

    <style type="text/css">
        .auto-style1 {
            width: 8px;
        }
        .auto-style2 {
            margin-left: 17px;
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

            .auto-style3:hover {
                background-color: steelblue;
                color: white;
            }
        .auto-style7 {
            background-color: white;
            text-align: center;
            width: 300px;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
        }
        #gvInforme td, #gvInforme th {
    border: 1px solid #cccccc;
        }
        .auto-style8 {
            width: 898px;
            height: 51px;
        }
        .auto-style9 {
            background-color: white;
            width: 299px;
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

            <td class="auto-style9">

                <asp:HyperLink ID="hlHomeInforme"
                    runat="server"
                    NavigateUrl="~/Usuario/Admin/Informes/HomeInformes.aspx"
                    Style="display: block; text-align: left; margin-left: 25px;" CssClass="hylink-limpio">VOLVER</asp:HyperLink>

            </td>

            <td style="text-align:center" class="auto-style9">

                <asp:Label ID="lblInformePacientesPorFecha"
                    runat="server"
                    CssClass="titulo"
                    Text="PACIENTES POR FECHA" Style="display: block; text-align: center;"></asp:Label>

            </td>

            <td class="auto-style7">
                <div style="display: flex; justify-content: flex-end; align-items: center; width: 100%;">
                <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
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

                <td class="auto-style1">&nbsp;</td>

                <td colspan="2">&nbsp;</td>

            </tr>

            <tr>

                <td class="auto-style1">&nbsp;</td>

                <td style="color: #333333">Fecha desde:</td>

                <td>
                    <asp:TextBox ID="txtFechaDesde"
                        runat="server"
                        TextMode="Date">
                    </asp:TextBox>
                </td>

            </tr>

            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="2">&nbsp;</td>
            </tr>

            <tr>

                <td class="auto-style1">&nbsp;</td>

                <td style="color: #333333">Fecha hasta:</td>

                <td>
                    <asp:TextBox ID="txtFechaHasta"
                        runat="server"
                        TextMode="Date">
                    </asp:TextBox>
                </td>

            </tr>

            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="2">&nbsp;</td>
            </tr>

            <tr>

                <td class="auto-style1">

                    &nbsp;</td>

                <td>

                    <asp:Button ID="btnGenerar"
                        runat="server"
                        Text="Generar"
                        Font-Bold="True"
                        OnClick="btnGenerar_Click" CssClass="auto-style3" Width="94px" />

                </td>

                <td>

                    <asp:Button ID="btnLimpiar"
                        runat="server"
                        Text="Limpiar"
                        Font-Bold="True"
                        Width="97px"
                        OnClick="btnLimpiar_Click" CssClass="auto-style3" />

                </td>

                <td style="padding-left:20px">

                    <asp:Label ID="lblMensaje"
                        runat="server">
                    </asp:Label>

                </td>

            </tr>

            <tr>

                <td class="auto-style1">

                    &nbsp;</td>

                <td>

                    &nbsp;</td>

                <td>

                    &nbsp;</td>

                <td style="padding-left:20px">

                    &nbsp;</td>

            </tr>

            </table>

        <asp:GridView ID="gvInforme"
            runat="server"
            AutoGenerateColumns="False"
            CellPadding="4"
            GridLines="None" CssClass="auto-style2" ForeColor="#333333">

            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

            <Columns>

                <asp:BoundField
                    DataField="Medico"
                    HeaderText="Médico" />

                <asp:BoundField
                    DataField="Fecha"
                    HeaderText="Fecha del Turno" />

                <asp:BoundField DataField="CantidadPacientes" HeaderText="Cantidad de Pacientes" />

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
