<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaLogicaHorarioMedico.aspx.cs" Inherits="Vistas.Usuario.Admin.Medicos.ABML_Horarios.AltaLogicaHorarioMedico" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>REACTIVAR HORARIO</title>
    <link rel="icon" href="/Imagenes/icons8-corazón-con-pulso-96 (1).png" type="image/png" />
    <link href="~/Estilos.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 8px;
        }
        .auto-style2 {
            margin-left: 17px;
        }
        .auto-style4 {
            background-color: white;
            text-align: center;
            width: 34%;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
        }
        .auto-style5 {
            background-color: white;
            text-align: center;
            width: 33%;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
        }
        .auto-style6 {
            font-size: 35px;
            font-weight: 700;
            color: steelblue;
            margin-left: 0px;
            margin-right: 0px;
        }
        .auto-style8 {
            width: 90px;
        }
        .auto-style9 {
            background-color: #dddddd;
            border-radius: 5px;
            color: steelblue;
            font-weight: 600;
            border: solid 1px steelblue;
            font-size: 20px;
            text-decoration: none;
            display: inline-block;
        }
            
            .auto-style9:hover {
                background-color: steelblue;
                color: white;
            }

        .auto-style10 {
            width: 102px;
        }
        .auto-style11 {
            width: 6px;
        }
        .auto-style12 {
            width: 384px;
        }
        #gvHorariosInactivos td, #gvHorariosInactivos th {
    border: 1px solid #cccccc;
        }
        .auto-style13 {
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
                <td class="auto-style5" >
                    <asp:HyperLink ID="hlHorarios" runat="server"  NavigateUrl="~/Usuario/Admin/Medicos/ABML Horarios/HomeABMLHorarios.aspx" CssClass="hylink-limpio"  Style="display: block; text-align: left; margin-left: 25px;">VOLVER</asp:HyperLink>
                </td>
                <td class="auto-style13" >
                    <asp:Label ID="lblAltaLogica" runat="server" CssClass="auto-style6" Text="REACTIVAR HORARIO MÉDICO" Style="display: block; text-align: center;" Font-Size="X-Large"></asp:Label>
                </td>
                <td class="auto-style4">
                    <div style="display: flex; justify-content: flex-end; align-items: center; width: 100%;">
                    <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
                    &nbsp;<asp:Label ID="lblUsuario" runat="server" ForeColor="SteelBlue" Style="margin-right: 25px;"></asp:Label>
                    </div>
                </td>
            </tr>
        </table>

        
            <table>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style8">
                        &nbsp;</td>
                    <td class="auto-style11">
                        &nbsp;</td>
                    <td class="auto-style10">
                        &nbsp;</td>
                    <td class="auto-style12">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td style="color: #333333">Ingrese ID Del Horario Medico:&nbsp;&nbsp;&nbsp; </td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtIdHorarioMedico" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
                    <td class="auto-style11">
                        &nbsp;</td>
                    <td class="auto-style10">
                        <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" CssClass="botones-grises" />
                    </td>
                    <td class="auto-style12">
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr><td class="auto-style1">&nbsp;</td><td colspan="4">&nbsp;</td><td class="auto-style12">&nbsp;</td></tr>
                <tr>
                    <td class="auto-style1">
                        &nbsp;</td>
                    <td colspan="2">
                        <asp:Button ID="btnConfirmar" runat="server" OnClick="btnConfirmar_Click" Text="Confirmar" CssClass="auto-style9" Width="118px" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" CssClass="auto-style9" Width="115px" />
                    </td>
                </tr>
                <tr><td class="auto-style1">&nbsp;</td><td>&nbsp;</td></tr>
            </table>

            <asp:GridView ID="gvHorariosInactivos" runat="server" AutoGenerateColumns="False" DataKeyNames="IdHorario" OnRowCommand="gvHorariosInactivos_RowCommand" CellPadding="4" GridLines="None" CssClass="auto-style2" ForeColor="#333333">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Medico" HeaderText="Medico" />
                    <asp:BoundField DataField="Dia" HeaderText="Día" />
                    <asp:BoundField DataField="Inicio" HeaderText="Inicio" />
                    <asp:BoundField DataField="Fin" HeaderText="Fin" />
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

    </form>
</body>
</html>