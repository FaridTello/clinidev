<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificacionMedicos.aspx.cs" Inherits="Vistas.Usuario.Admin.Medicos.ModificacionMedicos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>MODIFICAR MÉDICO</title>

    <link rel="icon" href="/Imagenes/icons8-corazón-con-pulso-96 (1).png" type="image/png" />
    <link href="~/Estilos.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .auto-style1 {
            width: 15px;
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
        .auto-style5 {
            font-size: 35px;
            font-weight: 700;
            color: steelblue;
            margin-left: 0px;
        }
        .auto-style6 {
            margin-left: 17px;
        }
        .auto-style7 {
            width: 7px;
        }
        .auto-style8 {
            width: 5px;
        }
        #gvMedicos td, #gvMedicos th {
    border: 1px solid #cccccc;
        }
        .auto-style9 {
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
                <td class="auto-style2">
                    <asp:HyperLink ID="HyperLink1" runat="server" Style="display: block; text-align: left; margin-left: 25px;" NavigateUrl="~/Usuario/Admin/Medicos/ABML Médicos/HomeABMLMedicos.aspx" CssClass="hylink-limpio" Width="254px">VOLVER</asp:HyperLink>
                </td>
                <td class="auto-style9">
                    <asp:Label ID="lblModificacionPaciente" runat="server" CssClass="auto-style5" Text="MODIFICACIÓN DE MÉDICOS" Style="display: block; text-align: center;" Font-Size="XX-Large"></asp:Label>
                </td>
                <td class="auto-style3">
                    <div style="display: flex; justify-content: flex-end; align-items: center; width: 100%;">
                    <asp:Label ID="lblUsuario" runat="server" Font-Bold="True" Text="Usuario:"></asp:Label>
                    &nbsp;<asp:Label ID="lblUsuarioLogueado" runat="server" ForeColor="SteelBlue" Style="margin-right: 25px;"></asp:Label>
                    </div>
                </td>
            </tr>
        </table>

        <div class="contenido">
            <table class="tabla-form">
                <tr>
                    <td class="auto-style1">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td class="auto-style8">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td class="auto-style7">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="lblLegajoMedico" runat="server" Text="Ingrese el Legajo del medico a modificar:" ForeColor="#333333"></asp:Label>
                    </td>
                    <td class="auto-style8">
                        &nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtLegajoMedico" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style7">
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" CssClass="botones-grises" />
                    </td>
                </tr>
                <tr><td class="auto-style1">&nbsp;</td><td colspan="5">
                    <asp:Label ID="lbl_Mensaje" runat="server"></asp:Label>
                    </td></tr>
            </table>

            <asp:GridView ID="GvMedicos" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True" CellPadding="4" GridLines="None" OnRowCancelingEdit="GvMedicos_RowCancelingEdit" OnRowEditing="GvMedicos_RowEditing" OnRowUpdating="GvMedicos_RowUpdating" ForeColor="#333333" CssClass="auto-style6">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="Legajo">
                        <EditItemTemplate>
                            <asp:Label ID="lbl_eit_Legajo" runat="server" Text='<%# Bind("Legajo") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Legajo" runat="server" Text='<%# Bind("Legajo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DNI">
                        <EditItemTemplate>
                            <asp:Label ID="lbl_eit_Dni" runat="server" Text='<%# Bind("DNI") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Dni" runat="server" Text='<%# Bind("DNI") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_Nombre" runat="server" Text='<%# Bind("Nombre") %>' MaxLength="50"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Nombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Apellido">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_Apellido" runat="server" Text='<%# Bind("Apellido") %>' MaxLength="50"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Apellido" runat="server" Text='<%# Bind("Apellido") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sexo">
                     <EditItemTemplate>
                         <asp:DropDownList ID="ddl_eit_Sexo" runat="server" SelectedValue='<%# Bind("Sexo") %>' Width="165px">
                             <asp:ListItem Text="Masculino" Value="Masculino"></asp:ListItem>
                             <asp:ListItem Text="Femenino" Value="Femenino"></asp:ListItem>
                         </asp:DropDownList>
                     </EditItemTemplate>
                     <ItemTemplate>
                    <asp:Label ID="lbl_it_Sexo" runat="server" Text='<%# Bind("Sexo") %>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha de nacimiento">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_FechaNacimiento" runat="server" Text='<%# Bind("FechaNacimiento") %>' TextMode="Date"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_FechaNacimiento" runat="server" Text='<%# Bind("FechaNacimiento") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nacionalidad">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_Nacionalidad" runat="server" Text='<%# Bind("Nacionalidad") %>' MaxLength="50"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Nacionalidad" runat="server" Text='<%# Bind("Nacionalidad") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Provincia">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_eit_Provincia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_eit_Provincia_SelectedIndexChanged"></asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Provincia" runat="server" Text='<%# Bind("Provincia") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Localidad">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_eit_Localidad" runat="server"></asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Localidad" runat="server" Text='<%# Bind("Localidad") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Direccion">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_Direccion" runat="server" Text='<%# Bind("Direccion") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Direccion" runat="server" Text='<%# Bind("Direccion") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Correo Electronico">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_CorreoElectronico" runat="server" Text='<%# Bind("Correo") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_CorreoElectronico" runat="server" Text='<%# Bind("Correo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Telefono">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_Telefono" runat="server" Text='<%# Bind("Telefono") %>' MaxLength="11"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Telefono" runat="server" Text='<%# Bind("Telefono") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Especialidad">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_eit_Especialidad" runat="server"></asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Especialidades" runat="server" Text='<%# Bind("Especialidad") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado">
                        <EditItemTemplate>
                            <asp:Label ID="lbl_eit_Estado" runat="server" Text='<%# Bind("Estado") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Estado" runat="server" Text='<%# Bind("Estado") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
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