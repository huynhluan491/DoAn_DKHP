using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_QLDKHP
{
    internal class GlobalVars
    {
        private static GlobalVars instance;

        // Private constructor so that no instances can be created outside this class
        private GlobalVars() { }

        // Public static method to get the instance
        public static GlobalVars Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GlobalVars();
                }
                return instance;
            }   
        }

        public tbSinhVien userInfo { get; set; }
        public int role { get; set; } // 1 - admin
    }
}
