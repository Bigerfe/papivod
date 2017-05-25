using System;
using System.Collections.Generic;
using System.Text;

namespace Linda.Entity
{
    /// <summary>
    /// 实体类GetZhaoi 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class GetZhaoi
    {
        public GetZhaoi()
        { }
        #region Model
        private int _id;
        private int _sex;
        private string _dianh;
        private string _email;
        private string _engscore;
        private int _ylxgj;
        private int _city;
        private DateTime _addtime;

        private string _name = "";


        public string name

        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 1 nan  0 nv
        /// </summary>
        public int sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dianh
        {
            set { _dianh = value; }
            get { return _dianh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string engscore
        {
            set { _engscore = value; }
            get { return _engscore; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ylxgj
        {
            set { _ylxgj = value; }
            get { return _ylxgj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int city
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime addtime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        #endregion Model

    }
}
