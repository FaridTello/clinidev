<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaPaciente.aspx.cs" Inherits="Vistas.Usuario.Admin.AltaPaciente" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>REGISTRAR NUEVO PACIENTE</title>
    <link rel="icon" href="/Imagenes/icons8-corazón-con-pulso-96 (1).png" type="image/png" />
    <link href="~/Estilos.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
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
        .auto-style6 {
            width: 17px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="tabla-barra-superior" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="auto-style3">
                    <asp:HyperLink ID="hlABMLpaciente" runat="server" NavigateUrl="~/Usuario/Admin/Pacientes/HomeABMLPacientes.aspx" CssClass="hylink-limpio" Style="display: block; text-align: left; margin-left: 25px;">VOLVER</asp:HyperLink>
                </td>
                <td class="auto-style3">
                    <asp:Label ID="lblAltaPaciente" runat="server" CssClass="auto-style4" Text="REGISTRAR NUEVO PACIENTE" Style="display: block; text-align: center;" Font-Size="XX-Large"></asp:Label>
                </td>
                <td class="auto-style3" >
                    <div style="display: flex; justify-content: flex-end; align-items: center; width: 100%;">
                    &nbsp;<asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
                    &nbsp;<asp:Label ID="lblUsuario" runat="server" ForeColor="SteelBlue" Style="margin-right: 25px;"></asp:Label>
                    </div>
                </td>
            </tr>
        </table>
        
            <p style="color: #333333"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>Ingresar datos del nuevo paciente:</p>
            <table class="tabla-form">
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td style="color: #333333">DNI:</td>
                    <td><asp:TextBox ID="txtDni" runat="server" Width="187px" MaxLength="8"></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator ID="rfvDni" runat="server" ControlToValidate="txtDni" ErrorMessage="Ingrese DNI" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="revDni" runat="server" ControlToValidate="txtDni" ErrorMessage="Ingresar solo digitos" ForeColor="Red" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td style="color: #333333">Nombre:</td>
                    <td><asp:TextBox ID="txtNombre" runat="server" Width="187px" MaxLength="50"></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Ingrese Nombre" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="revNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Solo se permiten letras" ForeColor="Red" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td style="color: #333333">Apellido:</td>
                    <td><asp:TextBox ID="txtApellido" runat="server" Width="187px" MaxLength="50"></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="Ingrese Apellido" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="revApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="Solo se permiten letras" ForeColor="Red" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td style="color: #333333">Sexo:</td>
                    <td><asp:DropDownList ID="ddlSexo" runat="server" Width="195px"></asp:DropDownList></td>
                    <td><asp:RequiredFieldValidator ID="rfvSexo" runat="server" ControlToValidate="ddlSexo" ErrorMessage="Seleccione Sexo" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td style="color: #333333">Dirección:</td>
                    <td><asp:TextBox ID="txtDireccion" runat="server" Width="187px" MaxLength="50"></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" ErrorMessage="Ingrese Dirección" ForeColor="Red"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td style="color: #333333">Provincia:</td>
                    <td><asp:DropDownList ID="ddlProvincia" runat="server" Width="195px" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"></asp:DropDownList></td>
                    <td><asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="ddlProvincia" ErrorMessage="Seleccione una provincia" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td style="color: #333333">Localidad:</td>
                    <td><asp:DropDownList ID="ddlLocalidad" runat="server" Width="195px"></asp:DropDownList></td>
                    <td><asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ControlToValidate="ddlLocalidad" ErrorMessage="Seleccione una localidad" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td style="color: #333333">Nacionalidad:</td>
                    <td><asp:TextBox ID="txtNacionalidad" runat="server" Width="187px" MaxLength="50"></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator ID="rfvNacionalidad" runat="server" ControlToValidate="txtNacionalidad" ErrorMessage="Ingrese Nacionalidad" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="revNombre1" runat="server" ControlToValidate="txtNacionalidad" ErrorMessage="Solo se permiten letras" ForeColor="Red" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td style="color: #333333">Fecha de Nacimiento:</td>
                    <td><asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date" Width="187px"></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator ID="rfvFechaNacimiento" runat="server" ControlToValidate="txtFechaNacimiento" ErrorMessage="Ingrese Fecha de Nacimiento" ForeColor="Red"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td style="color: #333333">Correo electrónico:</td>
                    <td><asp:TextBox ID="txtCorreo" runat="server" Width="187px"></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="txtCorreo" ErrorMessage="Ingrese Correo Electrónico" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                    <asp:RegularExpressionValidator ID="revCorreo" runat="server" ControlToValidate="txtCorreo" ErrorMessage="Ingrese un Correo Electrónico válido" ValidationExpression="^[\w\.\-]+@[\w\-]+\.[a-zA-Z]{2,}$" ForeColor="Red"></asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td style="color: #333333">Teléfono:</td>
                    <td><asp:TextBox ID="txtTelefono" runat="server" TextMode="Number" Width="187px" MaxLength="11"></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="Ingrese Teléfono" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="Solo se permiten digitos" ForeColor="Red" ValidationGroup="^[0-9]+$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr><td class="auto-style6">&nbsp;</td><td colspan="3">&nbsp;</td></tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td><asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="127px" Font-Bold="True" OnClick="btnGuardar_Click" CssClass="botones-grises" /></td>
                    <td><asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="127px" Font-Bold="True" OnClick="btnLimpiar_Click" CssClass="botones-grises" ValidationGroup="1" /></td>
                    <td><asp:Label ID="lblMensaje" runat="server"></asp:Label></td>
                </tr>
            </table>
    </form>
</body>
</html>