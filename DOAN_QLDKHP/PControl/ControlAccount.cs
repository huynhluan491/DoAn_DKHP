using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN_QLDKHP.PControl
{
    internal class ControlAccount
    {
        public static QLDangKiHPEntities db = ControlDatabase.qldkhp;
        private static tbAccount account;

        public static tbAccount Account { get => account; set => account = value; }

        public static List<tbAccount> FindAll()
        {
            var aList = db.tbAccounts.ToList();
            return aList;
        }

        public static bool Login(string username, string password)
        {
            bool result = false;
            foreach (var item in FindAll())
            {
                if (item.TaiKhoan == username && item.MatKhau == password)
                {
                    result = true;
                }
            }
                return result;
        }

        public static tbAccount DefineAccount(string acc) {
            try
            {
                return db.tbAccounts.Find(int.Parse(acc));
            }
            catch 
            {
                return db.tbAccounts.Find(int.Parse("1"));
            }
        }

        public static void Add(tbAccount acc)
        {
            try
            {
                db.tbAccounts.Add(acc);
                db.SaveChanges();
                MessageBox.Show("Them Account Thanh Cong");
            }
            catch
            {
                MessageBox.Show("Them Account That Bai");
            }
        }

        public static void Delete(tbAccount acc)
        {
            try
            {
                db.tbAccounts.Remove(acc);
                db.SaveChanges();
                MessageBox.Show("Xoa thanh cong");
            }
            catch
            {
                MessageBox.Show("Xoa khong thanh cong");
            }
        }

        public static void Update(tbAccount acc)
        {
            try
            {
                db.tbAccounts.AddOrUpdate(acc);
                db.SaveChanges();
                MessageBox.Show("Cap nhat thanh cong");
            }
            catch
            {
                MessageBox.Show("Cap nhat khong thanh cong");
            }

        }

        public static List<tbAccount> AccountSearching(string search)
        {
            List<tbAccount> listUName = (from s in FindAll().ToList() where s.TaiKhoan.Contains(search) select s).ToList();

            if (listUName.Count != 0)
            {
                MessageBox.Show($"Tìm được {listUName.Count} kết quả");
                return listUName;
            }
            else
            {
                MessageBox.Show($"Không có kết quả");
                return FindAll().ToList();
            }
        }
    }
}
