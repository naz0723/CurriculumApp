using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CurriculumApp
{
    public partial class Curriculum : System.Web.UI.Page
    {
        private static DataTable curriculumTable;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeDataTable();
                BindGrid();
            }
        }

        // Inicializar el DataTable
        private void InitializeDataTable()
        {
            if (curriculumTable == null)
            {
                curriculumTable = new DataTable();
                curriculumTable.Columns.Add("Category", typeof(string));
                curriculumTable.Columns.Add("Detail", typeof(string));
            }
        }

        // Método para vincular datos al GridView
        private void BindGrid()
        {
            string selectedCategory = ddlCategory.SelectedValue;
            DataView dv = curriculumTable.DefaultView;

            // Filtrar datos según la categoría seleccionada
            if (selectedCategory != "0")
            {
                dv.RowFilter = $"Category = '{selectedCategory}'";
            }
            else
            {
                dv.RowFilter = string.Empty;
            }

            gvCurriculum.DataSource = dv;
            gvCurriculum.DataBind();
        }

        // Evento para agregar un nuevo registro
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDetail.Text) && ddlCategory.SelectedValue != "0")
            {
                DataRow row = curriculumTable.NewRow();
                row["Category"] = ddlCategory.SelectedItem.Text;
                row["Detail"] = txtDetail.Text;
                curriculumTable.Rows.Add(row);

                txtDetail.Text = string.Empty;
                BindGrid();
            }
        }

        // Evento de cambio de página en el GridView
        protected void gvCurriculum_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvCurriculum.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        // Evento para iniciar la edición de una fila
        protected void gvCurriculum_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvCurriculum.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        // Evento para actualizar un registro
        protected void gvCurriculum_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int index = e.RowIndex;
            GridViewRow row = gvCurriculum.Rows[index];
            string detail = ((System.Web.UI.WebControls.TextBox)row.Cells[1].Controls[0]).Text;

            // Actualizar el detalle en el DataTable
            curriculumTable.Rows[index]["Detail"] = detail;
            gvCurriculum.EditIndex = -1;
            BindGrid();
        }

        // Evento para cancelar la edición
        protected void gvCurriculum_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvCurriculum.EditIndex = -1;
            BindGrid();
        }

        // Evento para eliminar un registro
        protected void gvCurriculum_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            curriculumTable.Rows[index].Delete();
            BindGrid();
        }

        // Evento para filtrar según la categoría seleccionada
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}