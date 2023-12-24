using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_QLDKHP.PControl
{
    public class ControlSinhVien
    {
        public static QLDangKiHPEntities db = ControlDatabase.qldkhp;
        private static tbAccount account;
        private static tbSinhVien userInfo = GlobalVars.Instance.userInfo;
        public static tbAccount Account { get => account; set => account = value; }

        public static tbSinhVien findSv(string masv)
        {
            return db.tbSinhViens.FirstOrDefault(s => s.MaSV == masv);
        }
       public static List<tbSinhVien> getAll()
        {
            return db.tbSinhViens.Where(x => x.MaSV.ToLower().Contains("sv")).ToList();
        }
    }
}
