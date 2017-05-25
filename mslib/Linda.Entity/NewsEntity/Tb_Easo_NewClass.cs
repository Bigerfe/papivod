using System;
using System.Collections.Generic;
using System.Text;

namespace Linda.Entity
{
    /// <summary>
    ///  新闻类别管理
    /// </summary>
    [Serializable]
    public class Tb_Easo_NewClass
    {
        public Tb_Easo_NewClass()
        { }
        #region Model
        private int _id;
        private string _cname="";
        private string _description="";
        private int? _type=0;
        private int? _ordernum=100;
        private DateTime? _addtime=DateTime.Now;
        /// <summary>
        /// 行业资讯的类别
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string CName
        {
            set { _cname = value; }
            get { return _cname; }
        }
        /// <summary>
        /// 简单描述
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 区分的类型  默认的是行业信息的类别
        /// </summary>
        public int? Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 排序设置
        /// </summary>
        public int? OrderNum
        {
            set { _ordernum = value; }
            get { return _ordernum; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? Addtime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        #endregion Model

    }
}
