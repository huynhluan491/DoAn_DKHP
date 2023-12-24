using DOAN_QLDKHP.DTO;
using DOAN_QLDKHP.PView;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN_QLDKHP.PControl
{
    public class ControlMonHoc
    {
        public static QLDangKiHPEntities db = ControlDatabase.qldkhp;
        private static tbMonHoc monhoc;
        public tbSinhVien userInfo = GlobalVars.Instance.userInfo;

        public static tbMonHoc Monhoc { get => monhoc; set => monhoc = value; }

        public static IEnumerable<DTOMonHoc> FindAll()
        {
            var aList = db.tbMonHocs.Select(s => new DTOMonHoc
            {
                MaMH = s.MaMH,
                MaKhoa = s.MaKhoa,
                TenMH = s.TenMH,
                SoTinChi = s.SoTinChi
            }).ToList();
            return aList;
        }


        public  IEnumerable<DTOMonHoc> FindMonHocByMaMaKhoa()
        {
            // Flatten the list of MaMH strings
            var list = userInfo != null
               ? userInfo.tbPhieuDangKies.SelectMany(pdk => pdk.tbChiTietPDKs.Select(s => s.MaMH)).ToList()
               : new List<string>();


            var listMH = userInfo != null? db.tbMonHocs
                           .Where(s => s.MaKhoa == userInfo.MaKhoa && !list.Contains(s.MaMH)) // Use MaMH instead of TenMH
                           .Select(mh => new DTOMonHoc
                           {
                               MaMH = mh.MaMH,
                               MaKhoa = mh.MaKhoa,
                               TenMH = mh.TenMH,
                               SoTinChi = mh.SoTinChi
                           })
                           .ToList() :  new List<DTOMonHoc>();

            return listMH;
        }

        public static tbMonHoc FindMH(string mh)
        {
            return db.tbMonHocs.Find(mh);
        }

        public static List<DTOMonHoc> TimKiemMonHoc(string search)
        {
            List<DTOMonHoc> listId = (from s in FindAll().ToList() where s.MaKhoa.ToString().Contains(search) select s).ToList();
            List<DTOMonHoc> listName = (from s in FindAll().ToList() where s.TenMH.Contains(search) select s).ToList();
            if (listName.Count != 0)
            {
                MessageBox.Show($"Tìm được {listName.Count} kết quả");
                return listName;
            }
            else if (listId.Count != 0)
            {
                MessageBox.Show($"Tìm được {listId.Count} kết quả");
                return listId;
            }
            else
            {
                MessageBox.Show($"Không có kết quả");
                return FindAll().ToList();
            }
        }

        public static void Add(tbMonHoc mh)
        {


            Debug.WriteLine(mh.ToString());
            db.tbMonHocs.Add(mh);
            db.SaveChanges();
            MessageBox.Show("Thêm thành công");
 /*           try
            {

            }*/
/*            catch 
            {

                MessageBox.Show("Không thêm được");
            }*/
        }

        public static void Delete(tbMonHoc mh)
        {
            try
            {
                db.tbMonHocs.Remove(mh);
                db.SaveChanges();
                MessageBox.Show("Xóa thành công");
            }
            catch
            {
                MessageBox.Show("Không xóa được");
            }
        }

        public static void Update(tbMonHoc mh)
        {
            try
            {
                db.tbMonHocs.AddOrUpdate(mh);
                db.SaveChanges();
                MessageBox.Show("Cập nhật thành công");
            }
            catch
            {
                MessageBox.Show("Không cập nhật được");
            }
        }

    }
}
