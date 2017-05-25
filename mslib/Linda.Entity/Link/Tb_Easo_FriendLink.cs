using System;


namespace Linda.Entity
{
    /// <summary>
    /// ʵ����Tb_Easo_FriendLink ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// �������ӱ�
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ����Ŀ����ʾ Ĭ����ҳ
        /// </summary>
        public int? LocationType
        {
            set { _locationtype = value; }
            get { return _locationtype; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// ��ַ
        /// </summary>
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public int? Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// ͼƬ��ַ
        /// </summary>
        public string Pic
        {
            set { _pic = value; }
            get { return _pic; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// ���� 1 Ĭ������
        /// </summary>
        public int? Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public int? ClickNum
        {
            set { _clicknum = value; }
            get { return _clicknum; }
        }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime? Addtime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        #endregion Model

    }

}

