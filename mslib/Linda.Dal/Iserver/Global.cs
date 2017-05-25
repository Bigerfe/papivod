using System;
using System.Collections.Generic;
using System.Text;

namespace Linda.DAL
{
    /// <summary>
    /// ȫ�ֱ���
    /// </summary>
    public class Global
    {
        /// <summary>
        /// ���һ������url
        /// </summary>
        /// <returns></returns>
        public static string ClassUrlList(int cid)
        {
            string key = "ClassUrlList1111";
            SortedList<int, string> list = (SortedList<int, string>)DoCache.GetCache(key);
            if (list == null)
            {
                list = new SortedList<int, string>();

                list.Add((int)GlobalData.���¹���, "/gonggao/");
                list.Add((int)GlobalData.¼ȡ�챨, "/lqkb/");
                list.Add((int)GlobalData.��ѧ��Ѷ, "/lxzx/");
                list.Add((int)GlobalData.�ȵ�ר��, "/hotzt/");
                list.Add((int)GlobalData.����ͼƬ, "/jctp/");
                list.Add((int)GlobalData.ԺУ��̬, "/yxdt/");
                list.Add((int)GlobalData.��ѧ����, "/jxgl/");
                list.Add((int)GlobalData.��ѧԤ��, "/sztd/");
                list.Add((int)GlobalData.��ѧԤ��, "/lxyk/");
                list.Add((int)GlobalData.��ѧԤ�ƿγ�, "/lxykkc/");
                list.Add((int)GlobalData.���������ѧ, "/guowaidaxue/");
                list.Add((int)GlobalData.��ѧ����, "/dxpm/");
                list.Add((int)GlobalData.רҵ����, "/zypm/");
                DoCache.AddCache(key, list);
            }
            return list[cid];
        }

        public static string jsturnpath = "/upfiles/jsture/";
        /// <summary>
        /// �����ϴ���ͼƬ�����kb
        /// </summary>
        public static int InfoUpSize = 100;

        /// <summary>
        /// һ����Ϣ�����ϴ���ͼƬ����
        /// </summary>
        public static int InfoUpPics = 8;

        /// <summary>
        /// ������Ϣ��id����
        /// </summary>
        public static int helpid = 3;


        /// <summary>
        /// �Ƿ����û���
        /// </summary>
        public static bool UseCache = ConfigHelper.GetConfigInt("UsedCache") == 1 ? true : false;


        /// <summary>
        /// �������ӵ�ͼƬ��ַ
        /// </summary>
        public static string linkimgpath = "/upfiles/friendlink";

        /// <summary>
        /// Ĭ���ϴ�ͼƬ�Ĵ�С 300kb
        /// </summary>
        public static int default_filesize = 300;

        /// <summary>
        /// Ĭ���û��ϴ�ͼƬ�Ĵ�С20kb
        /// </summary>
        public static int user_default_filesize = 20;

        /// <summary>
        /// ͼƬĬ���ϴ�Ŀ¼
        /// </summary>
        public static string default_imgpath = "/upfiles/website/";

        /// <summary>
        /// Ĭ��ͼƬ����
        /// </summary>
        public static string default_imgtype = ".jpg,.gif,.jpeg,.bmp,.png";

        /// <summary>
        /// ���ͼƬ���ϴ�·�� 
        /// </summary>
        public static string AdsImage_Path = "/upfiles/guangg/";

        /// <summary>
        /// ���flash���ϴ�·�� 
        /// </summary>
        public static string AdsFlash_Path = "/upfiles/flashgg/";

        /// <summary>
        /// ���flash������
        /// </summary>
        public static string AdsFlash_type = ".swf";


        /// <summary>
        /// �����Ƶ��ַ
        /// </summary>
        public static string AdsVideo_Path = "/upfiles/adsvideo/";

        /// <summary>
        /// �����Ƶ����
        /// </summary>
        public static string AdsVideo_type = ".mp3,.wav";

        /// <summary>
        /// �����Ƶ��С
        /// </summary>
        public static int AdsVieo_Size = 2000;

        /// <summary>
        /// �����Ƶ��ַ
        /// </summary>
        public static string AdsFlv_Path = "/upfiles/adsflv/";

        /// <summary>
        /// �����Ƶ����
        /// </summary>
        public static string AdsFlv_type = ".flv";


        /// <summary>
        /// ����Ա��Ƭ��ַ
        /// </summary>
        public static string adminpicpath = "/upfiles/adminpic/";

        /// <summary>
        /// ����Ա��Ƭ�����С
        /// </summary>
        public static int adminpicsize = 200;

        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="typeid"></param>
        /// <returns></returns>
        public static string GetTypeName(int typeid)
        {
            if (typeid == 4)
                return "���������ѧ";
            else if (typeid == 16)
                return "����־Ը";
            else if (typeid == 17)
                return "ѧ��";
            return "";
        }
    }


    /// <summary>
    /// ��������������͵�ö����ʽ
    /// </summary>
    public enum GlobalData
    {
        ԺУ��̬ = 1,
        ��ѧ��Ѷ = 2,
        ��ѧԤ�� = 3,
        ���������ѧ = 4,
        ��ѧ���� = 5,
        ��ѧԤ�� = 6,
        Ԥ�Ƶ��� = 7,
        ���¹��� = 8,
        ¼ȡ�챨 = 9,
        ��ѧ���� = 10,
        רҵ���� = 11,
        �ȵ�ר�� = 12,
        ����ͼƬ = 13,
        ��ѧԤ�ƿγ� = 15,
        ����־Ը = 16,
        ѧ��=17,

        ��������ѧ=100,
        ��������ѧ=101,
        ԺУ�Ƽ�=102,
        ��������=103,
        ��������=104,
        ǩ֤����=105,
        �Ƽ��γ�=106,
        ��������=107,
        �����ѧ����=10,
        ��ѧ���齻��=108,
        ��ѧ����=1000,
        ���ڳ���=10001


    }

    /// <summary>
    /// ϵͳ��ҳ���id����
    /// </summary>
    public enum EnumSianPage
    {
        ѧУ��� = 101,
        ��ϵ���� = 100,
    }

}
