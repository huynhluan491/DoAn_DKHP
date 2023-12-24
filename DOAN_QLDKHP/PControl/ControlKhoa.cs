using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_QLDKHP.PControl
{
    public class ControlKhoa
    {
        public static QLDangKiHPEntities db = ControlDatabase.qldkhp;

        public static List<tbKhoa> getAllKhoa()
        {
            return db.tbKhoas.ToList();
        }

        public static tbKhoa getKhoaById(string id)
        {
            return db.tbKhoas.FirstOrDefault(k => k.MaKhoa == id);
        }
     
    }
}
