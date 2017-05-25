using System;


namespace Linda.Entity
{
    /// <summary>
    /// 实体类Tb_Easo_FriendLink 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Tb_Easo_FriendLink
    {
        public Tb_Easo_FriendLink()
        { }
        #region Model
        private int _id=0;
        private int? _locationtype=0;
        private string _name="";
        private string _url="";
        private int? _sort=0;
        private string _pic="";
        private string _description="";
        private int? _type=1;
        private int? _clicknum=1000;
        private DateTime? _addtime=DateTime.Now;
        /// <summary>
        /// 友情链接表
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 分栏目的显示 默认首页
        /// </summary>
        public int? LocationType
        {
            set { _locationtype = value; }
            get { return _locationtype; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int? Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string Pic
        {
            set { _pic = value; }
            get { return _pic; }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 类型 1 默认文字
        /// </summary>
        public int? Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 点击次数
        /// </summary>
        public int? ClickNum
        {
            set { _clicknum = value; }
            get { return _clicknum; }
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

