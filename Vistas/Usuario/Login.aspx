<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vistas.Usuario.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>LOGIN</title>

<link rel="icon" href="/Imagenes/icons8-corazón-con-pulso-96 (1).png" type="image/png" />
    <link href="~/Estilos.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">

                <table class="centrado-recuadro">
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style2">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style2">
                            <div class="recuadro" style="color: #333333">
                            <img src="../Imagenes/icons8-corazón-con-pulso-96 (1).png" alt="Logo" />
                            <h1 class="titulo">Iniciar Sesión</h1>

                            Usuario<br />
                                <asp:TextBox ID="txtUsuario" runat="server" CssClass="textbox"></asp:TextBox>
                                <br />
                            <br />
                            Contraseña<br />
                                <asp:TextBox ID="txtContrasenia" runat="server" TextMode="Password" CssClass="textbox"></asp:TextBox>
                           
                                <br />

                                <br />

            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger d-block mb-2" ForeColor="Red"></asp:Label>

                                <br />

                            <br />

            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="botones-button" OnClick="btnIngresar_Click" />

                            </div>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style2">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style2">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
    </form>
</body>
</html>