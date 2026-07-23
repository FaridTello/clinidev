<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeABMLHorarios.aspx.cs" Inherits="Vistas.Usuario.Admin.Medicos.ABML_Horarios.HomeABMLHorarios" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>GESTIÓN HORARIOS</title>
    <link rel="icon" href="/Imagenes/icons8-corazón-con-pulso-96 (1).png" type="image/png" />
    <link href="~/Estilos.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            height: 98px;
            width: 250px;
        }
        .auto-style2 {
            background-color: white;
            text-align: center;
            width: 33%;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
        }
        .auto-style3 {
            background-color: white;
            text-align: center;
            width: 34%;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
        }
        .auto-style4 {
            height: 24px;
            width: 250px;
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
                <td class="auto-style2" >
                    <asp:HyperLink ID="hlHome" runat="server" NavigateUrl="~/Usuario/Admin/Home.aspx" CssClass="hylink-limpio" Style="display: block; text-align: left; margin-left: 25px;">VOLVER</asp:HyperLink>
                </td>
                <td class="auto-style5" >
                    <asp:Label ID="lblAbmlMedicos" runat="server" CssClass="titulo" Text="GESTIÓN HORARIOS" Style="display: block; text-align: center;"></asp:Label>
                </td>
                <td class="auto-style3">
                    <div style="display: flex; justify-content: flex-end; align-items: center; width: 100%;">
                        <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
&nbsp;<asp:Label ID="lblUsuario" runat="server" ForeColor="SteelBlue" Style="margin-right: 25px;"></asp:Label>
                   </div>
                </td>
            </tr>
        </table>


            <table class="centrado-recuadro">
                <tr>
                    <td class="auto-style4">
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <div class="recuadro-opciones" style="color: #333333">
                        Seleccione la funcionalidad a realizar:<br />
                        <br />
                        <asp:HyperLink ID="hlAltaMedico" runat="server" CssClass="botones2" NavigateUrl="~/Usuario/Admin/Medicos/ABML Horarios/AltaHorarioMedico.aspx">NUEVO HORARIO</asp:HyperLink>
                        <br />
                        <br />
                        <asp:HyperLink ID="hlAltaMedico0" runat="server" CssClass="botones2" NavigateUrl="~/Usuario/Admin/Medicos/ABML Horarios/AltaLogicaHorarioMedico.aspx">REACTIVAR HORARIO</asp:HyperLink>
                        <br />
                        <br />
                        <asp:HyperLink ID="hlBajaMedico" runat="server" CssClass="botones2" NavigateUrl="~/Usuario/Admin/Medicos/ABML Horarios/BajaHorarioMedico.aspx">BAJA HORARIO</asp:HyperLink>
                        <br />
                        <br />
                        <asp:HyperLink ID="hlListadoMedicos" runat="server" CssClass="botones2" NavigateUrl="~/Usuario/Admin/Medicos/ABML Horarios/ListadoHorarioMedico.aspx">LISTADO DE HORARIOS</asp:HyperLink>
                        <br />
                        <br />
                        <asp:HyperLink ID="hlModificarMedico" runat="server" CssClass="botones2" NavigateUrl="~/Usuario/Admin/Medicos/ABML Horarios/ModificarHorarioMedico.aspx">MODIFICAR HORARIO</asp:HyperLink>
                        </div>
                    </td>
                </tr>
            </table>

    </form>
</body>
</html>