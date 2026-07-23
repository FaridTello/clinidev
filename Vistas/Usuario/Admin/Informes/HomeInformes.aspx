<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeInformes.aspx.cs" Inherits="Vistas.Usuario.Admin.HomeInformes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>INFORMES</title>

    <link href="~/Estilos.css" rel="stylesheet" type="text/css" />
<link rel="icon" href="/Imagenes/icons8-corazón-con-pulso-96 (1).png" type="image/png" />
    

    <style type="text/css">
        .auto-style1 {
            height: 171px;
        }
        .auto-style2 {
            height: 24px;
        }
        .auto-style3 {
            background-color: white;
            text-align: center;
            width: 33%;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
        }
        .auto-style4 {
            font-size: 35px;
            font-weight: 700;
            color: steelblue;
            margin-left: 0px;
        }
        .auto-style5 {
            background-color: white;
            width: 33%;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
        }
        .auto-style6 {
            background-color: white;
            width: 34%;
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
                <asp:HyperLink ID="hlHome"
                    runat="server"
                    NavigateUrl="~/Usuario/Admin/Home.aspx"
                    Font-Bold="True" CssClass="hylink-limpio" Style="display: block; text-align: left; margin-left: 25px;" Width="144px">VOLVER</asp:HyperLink>
            </td>

            <td style="text-align:center" class="auto-style5">
                <asp:Label ID="lblAltaPaciente"
                    runat="server"
                    CssClass="auto-style4"
                    Text="INFORMES" Style="display: block; text-align: center;"></asp:Label>
            </td>

            <td class="auto-style6">
                <div style="display: flex; justify-content: flex-end; align-items: center; width: 100%;">
                <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
&nbsp;<asp:HyperLink ID="lblUsuarioLogueado"
                    runat="server"
                    Font-Bold="True" ForeColor="SteelBlue" Style="margin-right: 25px;">[lblUsuarioLogueado]</asp:HyperLink>
                </div>
            </td>

        </tr>
    </table>



    <div class="contenido">

        <table class="centrado-recuadro">

            <tr>

                <td class="auto-style2">
                </td>
            </tr>

            <tr>

                <td class="auto-style1">
                    <div class="recuadro-opciones" style="color: #333333">
            Seleccione el informe que quiere generar: <br />
                    <br />
                    <asp:HyperLink ID="hlInforme1"
                        runat="server"
                        NavigateUrl="~/Usuario/Admin/Informes/InformeAusentismo.aspx"
                        Font-Bold="True" CssClass="botones2">AUSENTISMO POR FECHA</asp:HyperLink>
                    <br />
                    <br />
                    <asp:HyperLink ID="hlInforme2"
                        runat="server"
                        NavigateUrl="~/Usuario/Admin/Informes/DemandaEspecialidades.aspx"
                        Font-Bold="True" CssClass="botones2">DEMANDA DE ESPECIALIDADES</asp:HyperLink>
                    <br />
                    <br />
                    <asp:HyperLink ID="hlInforme3"
                        runat="server"
                        Font-Bold="True" NavigateUrl="~/Usuario/Admin/Informes/InformePacientesPorFecha.aspx" CssClass="botones2">PACIENTES POR FECHA</asp:HyperLink>
                    <br />
                    <br />
                    <asp:HyperLink ID="hlInforme4"
                        runat="server"
                        Font-Bold="True" NavigateUrl="~/Usuario/Admin/Informes/InformeMapaDeDemanda.aspx" CssClass="botones2">MAPA DE DEMANDA</asp:HyperLink>
                    <br />
                    </div>    
                </td>
            </tr>

            </table>

    </div>

</form>

</body>
</html>