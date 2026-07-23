<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeABMLMedicos.aspx.cs" Inherits="Vistas.Usuario.Admin.Medicos.HomeABMLMedicos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>GESTIÓN DE MÉDICOS</title>

    <link rel="icon" href="/Imagenes/icons8-corazón-con-pulso-96 (1).png" type="image/png" />
    <link href="~/Estilos.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .auto-style3 {
            background-color: white;
            text-align: center;
            width: 299px;
            height: 45px;
            margin-bottom: 50px;
        }
        .auto-style6 {
            background-color: white;
            text-align: center;
            width: 300px;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
        }
        .auto-style7 {
            font-size: 35px;
            font-weight: 700;
            color: steelblue;
            margin-left: 0px;
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
                <td class="auto-style3">
                    <asp:HyperLink ID="hlHome" runat="server" NavigateUrl="~/Usuario/Admin/Home.aspx" CssClass="hylink-limpio" Style="display: block; text-align: left; margin-left: 25px;">VOLVER</asp:HyperLink>
                </td>
                <td class="auto-style9">
                    <asp:Label ID="lblAbmlMedicos" runat="server" CssClass="auto-style7" Style="display: block; text-align: center;" Text="GESTIÓN MEDICOS"></asp:Label>
                </td>
                <td class="auto-style6">
                    <div style="display: flex; justify-content: flex-end; align-items: center; width: 100%;">
                    &nbsp;<asp:HyperLink ID="lblUsuario" runat="server">Usuario: </asp:HyperLink>
                    &nbsp;<asp:HyperLink ID="lblUsuarioLogueado" runat="server" ForeColor="SteelBlue" Style="margin-right: 25px;">[lblUsuarioLogueado]</asp:HyperLink>
                    </div>
                </td>
            </tr>
        </table>


            <table class="centrado-recuadro">
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                       <div class="recuadro-opciones">
                           <p style="color: #333333">Seleccione la funcionalidad a realizar:</p>
                        <asp:HyperLink ID="hlAltaMedico" runat="server" CssClass="botones2" NavigateUrl="~/Usuario/Admin/Medicos/ABML Médicos/AltaMedicos.aspx">REGISTRAR NUEVO MÉDICO</asp:HyperLink>
                        <br />
                        <br />
                        <asp:HyperLink ID="hlAltaMedico0" runat="server" CssClass="botones2" NavigateUrl="~/Usuario/Admin/Medicos/ABML Médicos/AltaLogicaMedicos.aspx">REACTIVAR MÉDICO</asp:HyperLink>
                        <br />
                        <br />
                        <asp:HyperLink ID="hlBajaMedico" runat="server" CssClass="botones2" NavigateUrl="~/Usuario/Admin/Medicos/ABML Médicos/BajaMedicos.aspx">BAJA MÉDICO</asp:HyperLink>
                        <br />
                        <br />
                        <asp:HyperLink ID="hlListadoMedicos" runat="server" CssClass="botones2" NavigateUrl="~/Usuario/Admin/Medicos/ABML Médicos/ListadoMedicos.aspx">LISTADO DE MÉDICOS</asp:HyperLink>
                        <br />
                        <br />
                        <asp:HyperLink ID="hlModificarMedico" runat="server" CssClass="botones2" NavigateUrl="~/Usuario/Admin/Medicos/ABML Médicos/ModificacionMedicos.aspx">MODIFICAR MÉDICO</asp:HyperLink>
                        </div>
                    </td>
                </tr>
            </table>

    </form>
</body>
</html>