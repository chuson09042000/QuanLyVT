using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyVT.Models
{
    public class UserDAO
    {
        //public int Login(string userName, string passWord, bool isLoginAdmin = false)
        //{
        //    var result = db.Users.SingleOrDefault(x => x.UserName == userName);
        //    if (result == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        if (isLoginAdmin == true)
        //        {
        //            if (result.GroupID == CommonConstants.ADMIN_GROUP || result.GroupID == CommonConstants.MOD_GROUP)
        //            {
        //                if (result.Status == false)
        //                {
        //                    return -1;
        //                }
        //                else
        //                {
        //                    if (result.Password == passWord)
        //                        return 1;
        //                    else
        //                        return -2;
        //                }
        //            }
        //            else
        //            {
        //                return -3;
        //            }
        //        }
        //        else
        //        {
        //            if (result.Status == false)
        //            {
        //                return -1;
        //            }
        //            else
        //            {
        //                if (result.Password == passWord)
        //                    return 1;
        //                else
        //                    return -2;
        //            }
        //        }
        //    }
        //}
        private Model1 db = new Model1();
        public NGUOI_DUNG GetByID(string userName)
        {
            return db.NGUOI_DUNG.SingleOrDefault(x => x.Ma_Nguoi_Dung == userName);
        }
        public bool Login(string userName, string passWord)
        {
            var result = db.NGUOI_DUNG.Count(x => x.Ma_Nguoi_Dung == userName && x.Mat_Khau == passWord);
            if(result > 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}