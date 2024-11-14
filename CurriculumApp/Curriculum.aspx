<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Curriculum.aspx.cs" Inherits="CurriculumApp.Curriculum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
       <title>Generador de Currículums</title>
    <link rel="stylesheet" type="text/css" href="Style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center;">
            <h2>Generador de Currículums</h2>

            <!-- Dropdown para seleccionar categoría -->
            <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                <asp:ListItem Value="0" Text="Seleccione una categoría" />
                <asp:ListItem Value="Educación" Text="Educación" />
                <asp:ListItem Value="Experiencia Laboral" Text="Experiencia Laboral" />
                <asp:ListItem Value="Habilidades" Text="Habilidades" />
            </asp:DropDownList>

            <!-- GridView para mostrar el currículum -->
            <asp:GridView ID="gvCurriculum" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="5"
                OnPageIndexChanging="gvCurriculum_PageIndexChanging" OnRowEditing="gvCurriculum_RowEditing"
                OnRowDeleting="gvCurriculum_RowDeleting" OnRowUpdating="gvCurriculum_RowUpdating"
                OnRowCancelingEdit="gvCurriculum_RowCancelingEdit">
                <Columns>
                    <asp:BoundField DataField="Category" HeaderText="Categoría" ReadOnly="True" />
                    <asp:BoundField DataField="Detail" HeaderText="Detalle" />
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>

            <!-- TextBox y botón para agregar nuevo detalle -->
            <asp:TextBox ID="txtDetail" runat="server" Placeholder="Ingrese detalle" Width="200px"></asp:TextBox>
            <asp:Button ID="btnAdd" runat="server" Text="Agregar" OnClick="btnAdd_Click" />
        </div>
    </form>
</body>
</html>