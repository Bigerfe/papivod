using System;
using System.Collections.Generic;
using System.Text;

namespace Linda.Entity
{	/// <summary>
    /// 新闻实体
    /// </summary>
    [Serializable]
    public class Tb_Easo_News
    {
        public Tb_Easo_News()
        { }
        #region Model
        private long _id;
        private int? _classid=0;
        private string _title="";
        private string _content="";
        private string _source="";
        private string _label="";
        private int? _iftop=0;
        private int? _topordernum=100;
        private int? _ifrecommend;
        private int? _recommendordernum=100;
        private DateTime? _addtime;
        private string _downfile = "";
        /// <summary>
        /// 行业信息表
        /// </summary>
        public long ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 新闻classid
        /// </summary>
        public int? ClassId
        {
            set { _classid = value; }
            get { return _classid; }
        }
        /// <summary>
        /// 新闻标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 来源
        /// </summary>
        public string Source
        {
            set { _source = value; }
            get { return _source; }
        }
        /// <summary>
        /// 标签
        /// </summary>
        public string Label
        {
            set { _label = value; }
            get { return _label; }
        }
        /// <summary>
        /// 是否置顶
        /// </summary>
        public int? IfTop
        {
            set { _iftop = value; }
            get { return _iftop; }
        }
        /// <summary>
        /// 置顶排序数字
        /// </summary>
        public int? TopOrderNum
        {
            set { _topordernum = value; }
            get { return _topordernum; }
        }
        /// <summary>
        /// 是否推荐
        /// </summary>
        public int? IfRecommend
        {
            set { _ifrecommend = value; }
            get { return _ifrecommend; }
        }
        /// <summary>
        /// 推荐排序
        /// </summary>
        public int? RecommendOrderNum
        {
            set { _recommendordernum = value; }
            get { return _recommendordernum; }
        }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? Addtime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }

        /// <summary>
        /// 下载专区的文件地址
        /// </summary>
        public string Downfile
        {
            get
            {
                return _downfile;
            }

            set
            {
                _downfile = value;
            }
        }
        #endregion Model



        ///添加的属性
        ///

        private string _add_yxaddress = "";

        /// <summary>
        /// 院校地区
        /// </summary>
        public string YxAddress
        {
            get { return _add_yxaddress; }
            set { _add_yxaddress = value; }
        }

        private string _add_lxguojia = "";

        /// <summary>
        /// 留学国家
        /// </summary>
        public string LxGuojia
        {
            get { return _add_lxguojia; }
            set { _add_lxguojia = value; }
        }
        private string _add_lxms = "";

        /// <summary>
        /// 留学模式
        /// </summary>
        public string Lxms
        {
            get { return _add_lxms; }
            set { _add_lxms = value; }
        }

        public int viewcount { get; set; }

        public int realviewcount { get; set; }

        public int commentcount { get; set; }

        public string className { get; set; }
    }
}
