<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Estudiantes.aspx.cs" Inherits="TareaASP.Estudiantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Estudiantes</h1>
    
    <asp:Label ID="lblID" runat="server" Text="ID:" CssClass="badge" Font-Size="Small"></asp:Label>
    <asp:TextBox ID="txtID" runat="server" CssClass="form-control" Placeholder="Ej: E001"></asp:TextBox>
    <asp:Label ID="lblCarnet" runat="server" Text="Carnet:" CssClass="badge" Font-Size="Small"></asp:Label>
    <asp:TextBox ID="txtCarnet" runat="server" CssClass="form-control" Placeholder="Ej: 0910-10-12345"></asp:TextBox>
    <asp:Label ID="lblNombres" runat="server" Text="Nombres:" CssClass="badge" Font-Size="Small"></asp:Label>
    <asp:TextBox ID="txtNombres" runat="server" CssClass="form-control" Placeholder="Ej: Juan José"></asp:TextBox>
    <asp:Label ID="lblApellidos" runat="server" Text="Apellidos:" CssClass="badge" Font-Size="Small"></asp:Label>
    <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control" Placeholder="Ej: Pérez López"></asp:TextBox>
    <asp:Label ID="lblDireccion" runat="server" Text="Dirección:" CssClass="badge" Font-Size="Small"></asp:Label>
    <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" Placeholder="Ej: Casa 2, calle 1, Ciudad"></asp:TextBox>
    <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:" CssClass="badge" Font-Size="Small"></asp:Label>
    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" Placeholder="Ej: 33445566" TextMode="Number"></asp:TextBox>
    <asp:Label ID="lblCorreo" runat="server" Text="E-mail:" CssClass="badge" Font-Size="Small"></asp:Label>
    <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" Placeholder="Ej: nombre@dominio.com" TextMode="Email"></asp:TextBox>
    <asp:Label ID="lblTipoSangre" runat="server" Text="Tipo de sangre:" CssClass="badge" Font-Size="Small"></asp:Label>
    <asp:DropDownList ID="drpTipoSangre" runat="server" CssClass="form-control"></asp:DropDownList>
    <asp:Label ID="lblFechaNac" runat="server" Text="Fecha de nacimiento:" CssClass="badge" Font-Size="Small"></asp:Label>
    <asp:TextBox ID="txtFechaNac" runat="server" CssClass="form-control" Placeholder="Ej: E001" TextMode="Date"></asp:TextBox>
    <div></div>
    <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn btn-primary btn-lg" OnClick="Crear_Click"/>
    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-success btn-lg" OnClick="Actualizar_Click" Visible="False"/>
    <asp:Label ID="lblMensaje" runat="server" CssClass="badge" Font-Size="Small"></asp:Label>
    <asp:GridView ID="grdEstudiantes" runat="server" AutoGenerateColumns="False" CssClass="table-condensed" DataKeyNames="id,id_tipo_sangre" OnRowDeleting="GridEstudiantes_RowDeleting" OnSelectedIndexChanged="GridEstudiantes_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnSel" runat="server" CausesValidation="False" CommandName="Select" CssClass="btn btn-info" Text="Ver" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnBorrar" runat="server" CausesValidation="False" CommandName="Delete" CssClass="btn btn-danger" Text="Borrar  " />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="id_estudiante" HeaderText="Código" />
            <asp:BoundField DataField="carne" HeaderText="Carnet" />
            <asp:BoundField DataField="nombres" HeaderText="Nombres" />
            <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
            <asp:BoundField DataField="direccion" HeaderText="Dirección" />
            <asp:BoundField DataField="telefono" HeaderText="Teléfono" />
            <asp:BoundField DataField="correo_electronico" HeaderText="E-mail" />
            <asp:BoundField DataField="sangre" HeaderText="Tipo de Sangre" />
            <asp:BoundField DataField="fecha_nacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:d}" />
        </Columns>
    </asp:GridView>
</asp:Content>
