using System;
using System.Collections.Generic;
using System.Text;

namespace Kehu1.Entity
{

    /// <summary>
    /// 报名  。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Pbaoming
    {
        public Pbaoming()
        { }
        #region Model
        private int _id;
        private int? _firstz;
        private int? _secondz;
        private string _pname;
        private string _card;
        private int? _xueli;
        private string _sex;
        private string _province;
        private string _city;
        private string _area;
        private string _gaokchengj;
        private string _engchengj;
        private string _tel;
        private string _address;
        private string _post;
     
        private string _receiver;
        private string _onlinetype;
        private string _email;
        private string _remark;
        private DateTime? _addtime;
        private int? _ifpass;
        private string _passremark;

        private int _xuexiaoid = 0;

        /// <summary>
        /// 学校id
        /// </summary>
        public int Xuexiaoid
        {
            get { return _xuexiaoid; }

            set { _xuexiaoid = value; }
        }


        /// <summary>
        /// 报名
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 第一志愿
        /// </summary>
        public int? firstz
        {
            set { _firstz = value; }
            get { return _firstz; }
        }
        /// <summary>
        /// 第二志愿
        /// </summary>
        public int? secondz
        {
            set { _secondz = value; }
            get { return _secondz; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string pname
        {
            set { _pname = value; }
            get { return _pname; }
        }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string card
        {
            set { _card = value; }
            get { return _card; }
        }
        /// <summary>
        /// 学历
        /// </summary>
        public int? xueli
        {
            set { _xueli = value; }
            get { return _xueli; }
        }
        /// <summary>
        /// 男女
        /// </summary>
        public string sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string province
        {
            set { _province = value; }
            get { return _province; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string city
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string area
        {
            set { _area = value; }
            get { return _area; }
        }
        /// <summary>
        /// 高考成绩
        /// </summary>
        public string gaokchengj
        {
            set { _gaokchengj = value; }
            get { return _gaokchengj; }
        }
        /// <summary>
        /// 英语成绩
        /// </summary>
        public string engchengj
        {
            set { _engchengj = value; }
            get { return _engchengj; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 邮编
        /// </summary>
        public string post
        {
            set { _post = value; }
            get { return _post; }
        }
       
        /// <summary>
        /// 收件人名称
        /// </summary>
        public string receiver
        {
            set { _receiver = value; }
            get { return _receiver; }
        }
        /// <summary>
        /// 在线方式
        /// </summary>
        public string onlinetype
        {
            set { _onlinetype = value; }
            get { return _onlinetype; }
        }
        /// <summary>
        /// emai
        /// </summary>
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? addtime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 是否录取
        /// </summary>
        public int? ifpass
        {
            set { _ifpass = value; }
            get { return _ifpass; }
        }
        /// <summary>
        /// 录取描述
        /// </summary>
        public string passremark
        {
            set { _passremark = value; }
            get { return _passremark; }
        }
        #endregion Model

    }
}
