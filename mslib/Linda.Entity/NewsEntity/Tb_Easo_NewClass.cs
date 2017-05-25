using System;
using System.Collections.Generic;
using System.Text;

namespace Linda.Entity
{
    /// <summary>
    ///  ����������
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
        /// ��ҵ��Ѷ�����
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public string CName
        {
            set { _cname = value; }
            get { return _cname; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// ���ֵ�����  Ĭ�ϵ�����ҵ��Ϣ�����
        /// </summary>
        public int? Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public int? OrderNum
        {
            set { _ordernum = value; }
            get { return _ordernum; }
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
