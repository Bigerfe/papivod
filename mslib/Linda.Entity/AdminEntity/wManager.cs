using System;
using System.Collections.Generic;
using System.Text;
namespace Linda.Entity
{

    public class wManager
    {
        public wManager()
        { }
        #region Model
        private int _imanagerid;
        private string _smanager;
        private string _smanagername;
        private string _spassword;
        private string _scertname;
        private string _scertid;
        private string _smail;
        private string _saddress;
        private string _stel;
        private string _smobile;
        private string _sfax;
        private string _sqq;
        private string _scall;
        private string _sduty;
        private string _sremark;
        private string _cfrost;
        private string _spicname;
        private DateTime _dtstart = DateTime.Now;
        private DateTime _dtend = DateTime.Now;
        private string _cdel;
        private string _slogin;
        private DateTime _dtlogin = DateTime.Now;
        private string _supd;
        private DateTime _dtupd = DateTime.Now;

        private int _roleid = 0;
        /// <summary>
        /// 角色id
        /// </summary>
        public int RoleId
        {
            get
            {
                return _roleid;
            }
            set
            {
                _roleid = value;

            }

        }
        /// <summary>
        /// 管理员序号  	会员中心管理员表
        /// </summary>
        public int iManagerId
        {
            set { _imanagerid = value; }
            get { return _imanagerid; }
        }
        /// <summary>
        /// 管理员帐号
        /// </summary>
        public string sManager
        {
            set { _smanager = value; }
            get { return _smanager; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string sManagerName
        {
            set { _smanagername = value; }
            get { return _smanagername; }
        }
        /// <summary>
        /// 加密密码
        /// </summary>
        public string sPassWord
        {
            set { _spassword = value; }
            get { return _spassword; }
        }
        /// <summary>
        /// 证件名称
        /// </summary>
        public string sCertName
        {
            set { _scertname = value; }
            get { return _scertname; }
        }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string sCertId
        {
            set { _scertid = value; }
            get { return _scertid; }
        }
        /// <summary>
        /// 邮编
        /// </summary>
        public string sMail
        {
            set { _smail = value; }
            get { return _smail; }
        }
        /// <summary>
        /// 联系地址
        /// </summary>
        public string sAddress
        {
            set { _saddress = value; }
            get { return _saddress; }
        }
        /// <summary>
        /// 联系电话 区号-号码如010-1234578
        /// </summary>
        public string sTel
        {
            set { _stel = value; }
            get { return _stel; }
        }
        /// <summary>
        /// 手机
        /// </summary>
        public string sMobile
        {
            set { _smobile = value; }
            get { return _smobile; }
        }
        /// <summary>
        /// 传真 区号-号码如010-1234578
        /// </summary>
        public string sFax
        {
            set { _sfax = value; }
            get { return _sfax; }
        }
        /// <summary>
        /// QQ号码
        /// </summary>
        public string sQQ
        {
            set { _sqq = value; }
            get { return _sqq; }
        }
        /// <summary>
        /// 称呼 1：先生2：女士
        /// </summary>
        public string sCall
        {
            set { _scall = value; }
            get { return _scall; }
        }
        /// <summary>
        /// 职务
        /// </summary>
        public string sDuty
        {
            set { _sduty = value; }
            get { return _sduty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sRemark
        {
            set { _sremark = value; }
            get { return _sremark; }
        }
        /// <summary>
        /// 冻结状态 0：未冻结1：已冻结
        /// </summary>
        public string cFrost
        {
            set { _cfrost = value; }
            get { return _cfrost; }
        }
        /// <summary>
        /// 图片地址 管理员照片的地址
        /// </summary>
        public string sPicName
        {
            set { _spicname = value; }
            get { return _spicname; }
        }
        /// <summary>
        /// 该管理员身份的开始时间
        /// </summary>
        public DateTime dtStart
        {
            set { _dtstart = value; }
            get { return _dtstart; }
        }
        /// <summary>
        /// 结束时间 该管理员身份的结束时间
        /// </summary>
        public DateTime dtEnd
        {
            set { _dtend = value; }
            get { return _dtend; }
        }
        /// <summary>
        /// 删除标记 0：未删除1：已删除
        /// </summary>
        public string cDel
        {
            set { _cdel = value; }
            get { return _cdel; }
        }
        /// <summary>
        /// 创建人  信息创建者的会员账号
        /// </summary>
        public string sLogin
        {
            set { _slogin = value; }
            get { return ""; }
        }
        /// <summary>
        /// 信息创建的时间
        /// </summary>
        public DateTime dtLogin
        {
            set { _dtlogin = value; }
            get { return _dtlogin; }
        }
        /// <summary>
        /// 更新人 信息更新者的会员账号
        /// </summary>
        public string sUpd
        {
            set { _supd = value; }
            get { return ""; }
        }
        /// <summary>
        /// 更新时间  上次更新的时间
        /// </summary>
        public DateTime dtUpd
        {
            set { _dtupd = value; }
            get { return _dtupd; }
        }


        private string _type = "";

        /// <summary>
        /// 所属的部门 也就是不同的系统
        /// </summary>
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        private string _isTopPermissions = "";

        /// <summary>
        /// 是否是最高权限
        /// </summary>
        public string IsTopPermissoins
        {
            get
            {
                return _isTopPermissions;
            }

            set
            {
                _isTopPermissions = value;
            }
        }
        #endregion Model
    }

}