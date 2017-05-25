using System;
using System.Collections.Generic;
using System.Text;

namespace Linda.Entity 
{
    /// <summary>
    /// �ֻ�ͼƬ����
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
        /// ��ҳ�ֻ�ͼƬ����id
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ͼƬ��ʾ����
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// Ĭ��ͼƬ�ĵ�ַ
        /// </summary>
        public string Pic
        {
            set { _pic = value; }
            get { return _pic; }
        }
        /// <summary>
        /// ���ͼƬ
        /// </summary>
        public string WPic
        {
            set { _wpic = value; }
            get { return _wpic; }
        }
        /// <summary>
        /// ����״̬
        /// </summary>
        public string Target
        {
            set { _target = value; }
            get { return _target; }
        }
        /// <summary>
        /// ���ӵ�ַ
        /// </summary>
        public string Http
        {
            set { _http = value; }
            get { return _http; }
        }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime? Addtime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// ��ĿĬ����ҳ
        /// </summary>
        public int? Channel
        {
            set { _channel = value; }
            get { return _channel; }
        }
        /// <summary>
        /// ����Աid
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
