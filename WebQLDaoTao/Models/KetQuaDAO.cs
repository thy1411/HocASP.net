using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebQLDaoTao.Models
{
    public class KetQuaDAO
    {
        //--------đọc danh sách các kết quả theo mã môn học trong CSDL-----------------
        public List<KetQua> getByMaMH(string mamh)
        {
            List<KhoaDAO> dsk = new List<KhoaDAO>();
            List<KetQua> ds = new List<KetQua>();

            //1.Mở kết nối CSDL
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_Constr1"].ConnectionString);
            conn.Open();
            //2.tao truy van
            SqlCommand cmd = new SqlCommand("select ketqua.*,hosv,tensv from ketqua inner join sinhvien on ketqua.masv=sinhvien.masv where mamh=@mamh", conn);
            cmd.Parameters.AddWithValue("@mamh", mamh);
            //3.thuc thi ket qua;
            SqlDataReader rd = cmd.ExecuteReader();
            //4.xu ly ket qua tra ve
            while (rd.Read())
            {
                //tao doi tuong ketqua
                KetQua kq = new KetQua()
                {
                    Id = int.Parse(rd["id"].ToString()), // id chuyển thành Int
                    MaSV = rd["MaSV"].ToString(), // masv chuyển thành string
                    MaMH = rd["mamh"].ToString(), // mamh chuyển thành string
                    HoTenSV = rd["hosv"].ToString() + " " + rd["tensv"].ToString()

                };
                if (!string.IsNullOrEmpty(rd["diem"].ToString())) // nếu có điểm sẽ là false , null là true;
                {
                    kq.Diem = float.Parse(rd["diem"].ToString());
                }
                ds.Add(kq);
            }
            return ds;
        }

        public int Update(int id, float diem)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_Constr1"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("update ketqua set diem=@diem  where id=@id", conn);
            cmd.Parameters.AddWithValue("@diem", diem);
            cmd.Parameters.AddWithValue("@id", id);
            //3.thuc thi ket qua;
            return cmd.ExecuteNonQuery();

        }
        public int Delete(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_Constr1"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from ketqua where id=@id", conn);

                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                return 0; // Trả về 0 nếu có lỗi xảy ra
            }

        }

    }
}