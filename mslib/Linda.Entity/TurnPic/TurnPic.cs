using System;
using System.Collections.Generic;
using System.Text;

namespace Linda.Entity 
{
    /// <summary>
    /// 轮换图片管理
    /// </summary>
    public class TurnPic
    {
        public TurnPic()
        { }
        #region Model
        private int _id;
        private string _title="";
        private string _pic="";
        private string _wpic="";
        private string _target="_blank";
        private string _http="";
        private DateTime? _addtime=DateTime.Now;
        private int? _channel=0;
        private int? _operid = 0;
        /// <summary>
        /// 首页轮换图片管理id
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 图片提示内容
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 默认图片的地址
        /// </summary>
        public string Pic
        {
            set { _pic = value; }
            get { return _pic; }
        }
        /// <summary>
        /// 宽的图片
        /// </summary>
        public string WPic
        {
            set { _wpic = value; }
            get { return _wpic; }
        }
        /// <summary>
        /// 弹出状态
        /// </summary>
        public string Target
        {
            set { _target = value; }
            get { return _target; }
        }
        /// <summary>
        /// 连接地址
        /// </summary>
        public string Http
        {
            set { _http = value; }
            get { return _http; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? Addtime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 栏目默认首页
        /// </summary>
        public int? Channel
        {
            set { _channel = value; }
            get { return _channel; }
        }
        /// <summary>
        /// 操作员id
        /// </summary>
        public int? Operid
        {
            set { _operid = value; }
            get { return _operid; }
        }

        private int _ordernum = 0;

        public int OrderNum
        {
            get
            {
                return _ordernum;
            }
            set
            {
                _ordernum = value;
            }
        }
        #endregion Model
    }
}
