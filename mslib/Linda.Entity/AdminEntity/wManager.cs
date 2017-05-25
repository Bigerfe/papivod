using System;
using System.Collections.Generic;
using System.Text;
namespace Linda.Entity
{

    public class wManager
    {
        public wManager()
        { }
        #region Model
        private int _imanagerid;
        private string _smanager;
        private string _smanagername;
        private string _spassword;
        private string _scertname;
        private string _scertid;
        private string _smail;
        private string _saddress;
        private string _stel;
        private string _smobile;
        private string _sfax;
        private string _sqq;
        private string _scall;
        private string _sduty;
        private string _sremark;
        private string _cfrost;
        private string _spicname;
        private DateTime _dtstart = DateTime.Now;
        private DateTime _dtend = DateTime.Now;
        private string _cdel;
        private string _slogin;
        private DateTime _dtlogin = DateTime.Now;
        private string _supd;
        private DateTime _dtupd = DateTime.Now;

        private int _roleid = 0;
        /// <summary>
        /// ��ɫid
        /// </summary>
        public int RoleId
        {
            get
            {
                return _roleid;
            }
            set
            {
                _roleid = value;

            }

        }
        /// <summary>
        /// ����Ա���  	��Ա���Ĺ���Ա��
        /// </summary>
        public int iManagerId
        {
            set { _imanagerid = value; }
            get { return _imanagerid; }
        }
        /// <summary>
        /// ����Ա�ʺ�
        /// </summary>
        public string sManager
        {
            set { _smanager = value; }
            get { return _smanager; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string sManagerName
        {
            set { _smanagername = value; }
            get { return _smanagername; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string sPassWord
        {
            set { _spassword = value; }
            get { return _spassword; }
        }
        /// <summary>
        /// ֤������
        /// </summary>
        public string sCertName
        {
            set { _scertname = value; }
            get { return _scertname; }
        }
        /// <summary>
        /// ֤������
        /// </summary>
        public string sCertId
        {
            set { _scertid = value; }
            get { return _scertid; }
        }
        /// <summary>
        /// �ʱ�
        /// </summary>
        public string sMail
        {
            set { _smail = value; }
            get { return _smail; }
        }
        /// <summary>
        /// ��ϵ��ַ
        /// </summary>
        public string sAddress
        {
            set { _saddress = value; }
            get { return _saddress; }
        }
        /// <summary>
        /// ��ϵ�绰 ����-������010-1234578
        /// </summary>
        public string sTel
        {
            set { _stel = value; }
            get { return _stel; }
        }
        /// <summary>
        /// �ֻ�
        /// </summary>
        public string sMobile
        {
            set { _smobile = value; }
            get { return _smobile; }
        }
        /// <summary>
        /// ���� ����-������010-1234578
        /// </summary>
        public string sFax
        {
            set { _sfax = value; }
            get { return _sfax; }
        }
        /// <summary>
        /// QQ����
        /// </summary>
        public string sQQ
        {
            set { _sqq = value; }
            get { return _sqq; }
        }
        /// <summary>
        /// �ƺ� 1������2��Ůʿ
        /// </summary>
        public string sCall
        {
            set { _scall = value; }
            get { return _scall; }
        }
        /// <summary>
        /// ְ��
        /// </summary>
        public string sDuty
        {
            set { _sduty = value; }
            get { return _sduty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sRemark
        {
            set { _sremark = value; }
            get { return _sremark; }
        }
        /// <summary>
        /// ����״̬ 0��δ����1���Ѷ���
        /// </summary>
        public string cFrost
        {
            set { _cfrost = value; }
            get { return _cfrost; }
        }
        /// <summary>
        /// ͼƬ��ַ ����Ա��Ƭ�ĵ�ַ
        /// </summary>
        public string sPicName
        {
            set { _spicname = value; }
            get { return _spicname; }
        }
        /// <summary>
        /// �ù���Ա��ݵĿ�ʼʱ��
        /// </summary>
        public DateTime dtStart
        {
            set { _dtstart = value; }
            get { return _dtstart; }
        }
        /// <summary>
        /// ����ʱ�� �ù���Ա��ݵĽ���ʱ��
        /// </summary>
        public DateTime dtEnd
        {
            set { _dtend = value; }
            get { return _dtend; }
        }
        /// <summary>
        /// ɾ����� 0��δɾ��1����ɾ��
        /// </summary>
        public string cDel
        {
            set { _cdel = value; }
            get { return _cdel; }
        }
        /// <summary>
        /// ������  ��Ϣ�����ߵĻ�Ա�˺�
        /// </summary>
        public string sLogin
        {
            set { _slogin = value; }
            get { return ""; }
        }
        /// <summary>
        /// ��Ϣ������ʱ��
        /// </summary>
        public DateTime dtLogin
        {
            set { _dtlogin = value; }
            get { return _dtlogin; }
        }
        /// <summary>
        /// ������ ��Ϣ�����ߵĻ�Ա�˺�
        /// </summary>
        public string sUpd
        {
            set { _supd = value; }
            get { return ""; }
        }
        /// <summary>
        /// ����ʱ��  �ϴθ��µ�ʱ��
        /// </summary>
        public DateTime dtUpd
        {
            set { _dtupd = value; }
            get { return _dtupd; }
        }


        private string _type = "";

        /// <summary>
        /// �����Ĳ��� Ҳ���ǲ�ͬ��ϵͳ
        /// </summary>
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        private string _isTopPermissions = "";

        /// <summary>
        /// �Ƿ������Ȩ��
        /// </summary>
        public string IsTopPermissoins
        {
            get
            {
                return _isTopPermissions;
            }

            set
            {
                _isTopPermissions = value;
            }
        }
        #endregion Model
    }

}