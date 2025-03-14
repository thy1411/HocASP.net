using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebQLDaoTao.Models;
namespace WebQLDaoTao
{
    public partial class QLDiem : System.Web.UI.Page
    {
        KetQuaDAO kqDAO = new KetQuaDAO();
        KetQua kq = new KetQua();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btLuu_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvKetQua.Rows.Count; i++)
                {
                    // lấy id (datakeys) của dòng
                    int id = int.Parse(gvKetQua.DataKeys[i].Value.ToString());
                    float diem = float.Parse(((TextBox)gvKetQua.Rows[i].FindControl("txtDiem")).Text);
                    kqDAO.Update(id, diem);
                }
                Response.Write("<script> alert('Lưu Điểm thành Công </script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('Lưu Điểm Thất Bại </script>");
            }
        }
        protected void btxoa_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvKetQua.Rows.Count; i++)
            {
                // lấy id (datakeys) của dòng
                int id = int.Parse(gvKetQua.DataKeys[i].Value.ToString());
                CheckBox chon = (CheckBox)gvKetQua.Rows[i].FindControl("ckChon");
                if (chon.Checked)
                {
                    // goij lip DAO xia khoi csdl
                    kqDAO.Delete(id);
                }
            }
            gvKetQua.DataBind();
        }
        protected void ckAll_Click(object sender, EventArgs e)
        {

        }

        protected void ckAll_Click1(object sender, EventArgs e)
        {

        }


        protected void ckAll_CheckedChanged(object sender, EventArgs e)
        {
            bool checkSate = ((CheckBox)gvKetQua.HeaderRow.FindControl("ckAll")).Checked;
            for (int i = 0; i < gvKetQua.Rows.Count; i++)
            {

                CheckBox chon = (CheckBox)gvKetQua.Rows[i].FindControl("ckChon");
                chon.Checked = checkSate;

            }
        }

        protected void gvKetQua_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}