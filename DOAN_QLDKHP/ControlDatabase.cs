using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_QLDKHP
{
    class ControlDatabase
    {
        public static QLDangKiHPEntities qldkhp = new QLDangKiHPEntities();

        static ControlDatabase()
        {
            if (qldkhp == null) {
                qldkhp = new QLDangKiHPEntities();
            }
        }
    }
}
