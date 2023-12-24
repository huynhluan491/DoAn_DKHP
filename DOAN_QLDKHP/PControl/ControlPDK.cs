using DOAN_QLDKHP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN_QLDKHP.PControl
{
    internal class ControlPDK
    {
        public static QLDangKiHPEntities db = ControlDatabase.qldkhp;
        private static tbSinhVien userInfo = GlobalVars.Instance.userInfo;

        public static IEnumerable queryPhieuDKBySinhVien()
        {
            var pdks = db.tbPhieuDangKies.Where(pdk => pdk.tbSinhVien.MaSV == userInfo.MaSV).Select(s => new {
                SoPDK = s.SoPDK,
                MaSV = s.MaSV,
                TenKhoa = s.TenKhoa,
                HocKi = s.HocKi,
                TongSoTC = s.TongSoTC,
                NgayDK = s.NgayDK,
            }).ToList();
            return pdks;



        }


        public static IEnumerable queryCTDK(string soPDK)
        {
            var ctdks = db.tbChiTietPDKs.Where(ctdk => ctdk.MaDK == soPDK).Select(s => new {
               MaDK = s.MaDK,
                MaMH = s.MaMH,
                TenLHP = s.TenLHP,
                SoTinChi = s.SoTinChi,
                ThongTin = s.ThongTin,
            }).ToList();
            return ctdks;

        }

        public static void AddPDK(string hocki, List<DTOMonHoc> listMH)
        {
            int listPDKLength = db.tbPhieuDangKies.ToList().Count;
            String newPDKId = $"PDK0{listPDKLength + 1}";
            int totalTC = 0;
            listMH.ForEach(t => totalTC += int.Parse(t.SoTinChi));

            tbPhieuDangKy pdk = new tbPhieuDangKy
            {
                SoPDK = newPDKId,
                MaSV = userInfo.MaSV,
                TenKhoa = userInfo.tbKhoa.TenKhoa,
                HocKi = hocki,
                TongSoTC = totalTC.ToString(),
                NgayDK = DateTime.Now
            };
            Debug.WriteLine("cc test", pdk);
            db.tbPhieuDangKies.Add(pdk);
            db.SaveChanges();

            foreach (var item in listMH)
            {
                tbChiTietPDK ctpdk = new tbChiTietPDK
                {
                    MaDK = newPDKId,
                    MaMH = item.MaMH,
                    TenLHP = item.TenMH,
                    SoTinChi = item.SoTinChi,
                    ThongTin = "Da dang ki"
                };
                db.tbChiTietPDKs.Add(ctpdk);
            }
            db.SaveChanges();
        }
    }
}
