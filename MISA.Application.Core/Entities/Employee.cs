using MISA.CukCuk.Core.Commons.Attributes;
using MISA.CukCuk.Core.Enum;
using MISA.CukCuk.Core.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CukCuk.Core.Entities
{
    /// <summary>
    /// Thông tin nhân viên
    /// </summary>
    /// Created by CMChau 19/05/2021
    public class Employee:BaseEntity
    {
        #region Properties

        /// <summary>
        /// Id nhân viên
        /// </summary>
        /// Created by CMChau 19/05/2021
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        /// Created by CMChau 19/05/2021
        [MSRequired("Mã nhân viên không được để trống.")]
        [MSDuplicate("Mã nhân viên đã tồn tại trong hệ thống.")]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Họ và tên nhân viên
        /// </summary>
        /// Created by CMChau 19/05/2021
        [MSRequired("Họ và tên không được để trống.")]
        public string FullName { get; set; }

        /// <summary>
        /// Ngày sinh nhân viên
        /// </summary>
        /// Created by CMChau 19/05/2021
        public DateTime DateOfBirth { get; set; }


        /// <summary>
        /// Giới tính nhân viên
        /// </summary>
        /// Created by CMChau 19/05/2021
        public int? Gender { get; set; }

        public string GenderName
        {
            get
            {
                var name = string.Empty;
                if(Gender==null|| Gender.ToString().Length<=0)
                {
                    return null;
                }    
                switch ((Enum.Gender)Gender)
                {
                    case Enum.Gender.Female:
                        name = Properties.Resources.Enum_Gender_Female;
                        break;
                    case Enum.Gender.Male:
                        name = Properties.Resources.Enum_Gender_Male;
                        break;
                    case Enum.Gender.Other:
                        name = Properties.Resources.Enum_Gender_Other;
                        break;
                    default:
                        break;
                }
                return name;
            }
        }
        /// <summary>
        /// Địa chỉ nhân viên
        /// </summary>
        /// Created by CMChau 19/05/2021
        public string Address { get; set; }

        /// <summary>
        /// Số CMND nhân viên
        /// </summary>
        /// Created by CMChau 19/05/2021
        public string IdentityNo { get; set; }

        /// <summary>
        /// Ngày cấp CMND
        /// </summary>
        /// Created by CMChau 19/05/2021
        [MSDuplicate("Số CMND/Căn Cước đã tồn tại trong hệ thống.")]
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Nơi cấp CMND
        /// </summary>
        /// Created by CMChau 19/05/2021
        public string IdentityPlace { get; set; }

        /// <summary>
        /// Id phòng ban
        /// </summary>
        /// Created by CMChau 19/05/2021
        [MSRequired("Phòng ban không được để trống")]
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        /// Created by CMChau 19/05/2021
        public string DepartmentName { get; set; }

        /// <summary>
        /// Tên vị trí làm việc
        /// </summary>
        /// Created by CMChau 19/05/2021
        public string PositionName { get; set; }

        /// <summary>
        /// Số điện thoại di động nhân viên
        /// </summary>
        /// Created by CMChau 19/05/2021
        [MSDuplicate("Số điện thoại di động đã tồn tại trong hệ thống.")]
        public string MobilePhoneNumber { get; set; }

        /// <summary>
        /// Số điện thoại bàn nhân viên
        /// </summary>
        /// Created by CMChau 19/05/2021
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Email nhân viên
        /// </summary>
        /// Created by CMChau 19/05/2021
        [MSDuplicate("Email đã tồn tại trong hệ thống.")]
        public string Email { get; set; }

        /// <summary>
        /// Số tài khoản ngân hàng nhân viên
        /// </summary>
        /// Created by CMChau 19/05/2021
        [MSDuplicate("Số tài khoản ngân hàng đã tồn tại trong hệ thống.")]
        public string BankAccount { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        /// Created by CMChau 19/05/2021
        public string BankName { get; set; }

        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        /// Created by CMChau 19/05/2021
        public string BankBranch { get; set; }

        /// <summary>
        /// Số thứ tự
        /// </summary>
        /// CreatedBy CMChau 13/6/2021
        public int? Sort { set; get; }
        #endregion


    }
}
