using System;
using System.Collections.Generic;
using System.Text;

namespace Linda.Entity
{	/// <summary>
    /// ����ʵ��
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
        /// ��ҵ��Ϣ��
        /// </summary>
        public long ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ����classid
        /// </summary>
        public int? ClassId
        {
            set { _classid = value; }
            get { return _classid; }
        }
        /// <summary>
        /// ���ű���
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// ��Դ
        /// </summary>
        public string Source
        {
            set { _source = value; }
            get { return _source; }
        }
        /// <summary>
        /// ��ǩ
        /// </summary>
        public string Label
        {
            set { _label = value; }
            get { return _label; }
        }
        /// <summary>
        /// �Ƿ��ö�
        /// </summary>
        public int? IfTop
        {
            set { _iftop = value; }
            get { return _iftop; }
        }
        /// <summary>
        /// �ö���������
        /// </summary>
        public int? TopOrderNum
        {
            set { _topordernum = value; }
            get { return _topordernum; }
        }
        /// <summary>
        /// �Ƿ��Ƽ�
        /// </summary>
        public int? IfRecommend
        {
            set { _ifrecommend = value; }
            get { return _ifrecommend; }
        }
        /// <summary>
        /// �Ƽ�����
        /// </summary>
        public int? RecommendOrderNum
        {
            set { _recommendordernum = value; }
            get { return _recommendordernum; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? Addtime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }

        /// <summary>
        /// ����ר�����ļ���ַ
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



        ///��ӵ�����
        ///

        private string _add_yxaddress = "";

        /// <summary>
        /// ԺУ����
        /// </summary>
        public string YxAddress
        {
            get { return _add_yxaddress; }
            set { _add_yxaddress = value; }
        }

        private string _add_lxguojia = "";

        /// <summary>
        /// ��ѧ����
        /// </summary>
        public string LxGuojia
        {
            get { return _add_lxguojia; }
            set { _add_lxguojia = value; }
        }
        private string _add_lxms = "";

        /// <summary>
        /// ��ѧģʽ
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
