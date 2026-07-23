<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaMedicos.aspx.cs" Inherits="Vistas.Usuario.Admin.Medicos.AltaMedicos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>REGISTRAR NUEVO MÉDICO</title>
    <style type="text/css">
        .auto-style1 {
            width: 200px;
        }
        .auto-style5 {
            background-color: white;
            text-align: center;
            width: 34%;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
        }
        .auto-style6 {
            background-color: white;
            text-align: center;
            width: 33%;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
        }
        .auto-style8 {
            width: 15px;
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
            width: 15px;
            height: 26px;
        }
        .auto-style11 {
            height: 26px;
        }
        .auto-style12 {
            background-color: white;
            width: 33%;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
        }
    </style>

    <link rel="icon" href="/Imagenes/icons8-corazón-con-pulso-96 (1).png" type="image/png" />
    <link href="~/Estilos.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server" autocomplete="off">

        <table class="tabla-barra-superior" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="auto-style6">
                    <asp:HyperLink ID="hlABMLpaciente" runat="server" Style="display: block; text-align: left; margin-left: 25px;" NavigateUrl="~/Usuario/Admin/Medicos/ABML Médicos/HomeABMLMedicos.aspx" CssClass="hylink-limpio">VOLVER</asp:HyperLink>
                </td>
                <td class="auto-style12">
                    <asp:Label ID="lblMensaje1" runat="server" CssClass="titulo" Text="REGISTRAR NUEVO MÉDICO" Style="display: block; text-align: center;" Font-Size="XX-Large"></asp:Label>
                </td>
                <td class="auto-style5">
                    <div style="display: flex; justify-content: flex-end; align-items: center; " class="centrado-recuadro">
                    &nbsp;<asp:Label ID="Label1" runat="server" Text="Usuario: "></asp:Label>
                    &nbsp;<asp:Label ID="lblUsuario" runat="server" ForeColor="SteelBlue" Style="margin-right: 25px;"></asp:Label>
                    </div>
                </td>
            </tr>
        </table>

        <div class="contenido">
            <p style="color: #333333"><strong>&nbsp;&nbsp;&nbsp;&nbsp; </strong>Ingresar datos del nuevo médico:</p>
            <table class="tabla-form">
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="label-campo" style="color: #333333">DNI:</td>
                    <td>
                        <asp:TextBox ID="txtDni" runat="server" autocomplete="off" MaxLength="8"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvDni" runat="server" ControlToValidate="txtDni" ErrorMessage="Ingrese DNI" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                    &nbsp;
                        <br />
                        <asp:RegularExpressionValidator ID="revDni" runat="server" ControlToValidate="txtDni" ErrorMessage="Ingresar solo digitos" ForeColor="Red" ValidationGroup="1" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10"></td>
                    <td class="auto-style11" style="color: #333333">Nombre:</td>
                    <td class="auto-style11">
                        <asp:TextBox ID="txtNombre" runat="server" autocomplete="new-password" MaxLength="50"></asp:TextBox>
                    </td>
                    <td class="auto-style11">
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Ingrese Nombre" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="revNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Solo se permiten letras" ForeColor="Red" ValidationGroup="1" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"></asp:RegularExpressionValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="label-campo" style="color: #333333">Apellido:</td>
                    <td>
                        <asp:TextBox ID="txtApellido" runat="server" autocomplete="new-password" MaxLength="50"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="Ingrese Apellido" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="revApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="Solo se permiten letras" ForeColor="Red" ValidationGroup="1" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="label-campo" style="color: #333333">Especialidad:</td>
                    <td>
                        <asp:DropDownList ID="ddlEspecialidad" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvEspecialidad" runat="server" ControlToValidate="ddlEspecialidad" ErrorMessage="Seleccione Especialidad" ForeColor="Red" InitialValue="0" ValidationGroup="1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="label-campo" style="color: #333333">Provincia:</td>
                    <td>
                        <asp:DropDownList ID="ddlProvincia" runat="server" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="ddlProvincia" ErrorMessage="Seleccione Provincia" ForeColor="Red" InitialValue="0" ValidationGroup="1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="label-campo" style="color: #333333">Localidad:</td>
                    <td>
                        <asp:DropDownList ID="ddlLocalidad" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ControlToValidate="ddlLocalidad" ErrorMessage="Seleccione Localidad" ForeColor="Red" InitialValue="0" ValidationGroup="1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="label-campo" style="color: #333333">Sexo:</td>
                    <td>
                        <asp:DropDownList ID="ddlSexo" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvSexo" runat="server" ControlToValidate="ddlSexo" ErrorMessage="Seleccione Sexo" ForeColor="Red" InitialValue="-1" ValidationGroup="1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="label-campo" style="color: #333333">Nacionalidad:</td>
                    <td>
                        <asp:TextBox ID="txtNacionalidad" runat="server" autocomplete="off" MaxLength="50"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvNacionalidad" runat="server" ControlToValidate="txtNacionalidad" ErrorMessage="Ingrese Nacionalidad" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="revNacionalidad" runat="server" ControlToValidate="txtNacionalidad" ErrorMessage="Solo se permiten letras" ForeColor="Red" ValidationGroup="1" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="label-campo" style="color: #333333">Fecha de nacimiento:</td>
                    <td>
                        <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date" autocomplete="off"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvFechaNacimiento" runat="server" ControlToValidate="txtFechaNacimiento" ErrorMessage="Ingrese Fecha de Nacimiento" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="label-campo" style="color: #333333">Direccion:</td>
                    <td>
                        <asp:TextBox ID="txtDireccion" runat="server" autocomplete="new-password" MaxLength="50"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" ErrorMessage="Ingrese Dirección" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="label-campo" style="color: #333333">Correo electronico:</td>
                    <td>
                        <asp:TextBox ID="txtCorreoElectro" runat="server" autocomplete="new-password" MaxLength="50"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvCorreoElec" runat="server" ControlToValidate="txtCorreoElectro" ErrorMessage="Ingrese Correo Electrónico" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                        &nbsp;<br />
                        <asp:RegularExpressionValidator ID="revCorreoElec" runat="server" ControlToValidate="txtCorreoElectro" ErrorMessage="Ingrese un Correo Electrónico válido" ValidationExpression="^[\w\.\-]+@[\w\-]+\.[a-zA-Z]{2,}$" ForeColor="Red" ValidationGroup="1"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="label-campo" style="color: #333333">Telefono:</td>
                    <td>
                        <asp:TextBox ID="txtTelefono" runat="server" autocomplete="new-password" MaxLength="11"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="Ingrese Teléfono" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="Solo se permiten digitos" ForeColor="Red" ValidationGroup="1" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style1" style="color: #333333">Contraseña:</td>
                    <td>
                        <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password" autocomplete="new-password" MaxLength="10"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvContraseña" runat="server" ControlToValidate="txtContraseña" ErrorMessage="Ingrese Contraseña" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style1" style="color: #333333">Confirmar Contraseña:</td>
                    <td>
                        <asp:TextBox ID="txtConfirmarContra" runat="server" TextMode="Password" autocomplete="new-password" MaxLength="10"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvConfirmarContra" runat="server" ControlToValidate="txtConfirmarContra" ErrorMessage="Confirme la contraseña" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                        <br />
                        <asp:CompareValidator ID="cvContraseña" runat="server" ControlToValidate="txtConfirmarContra" ControlToCompare="txtContraseña" ErrorMessage="Las contraseñas no coinciden" ForeColor="Red" ValidationGroup="1"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td colspan="3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnGuardar" runat="server" style="font-weight: 700" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="1" CssClass="auto-style9" Height="26px" Width="90px" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnLimpiar" runat="server" style="font-weight: 700" Text="Limpiar" OnClick="btnLimpiar_Click" CssClass="auto-style9" Height="26px" Width="90px" />
                    </td>
                    <td colspan="2">
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>

    </form>
</body>
</html>