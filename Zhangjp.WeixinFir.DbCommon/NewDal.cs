using Linda.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
namespace Zhangjp.WeixinFir.DbCommon
{
    public class NewDal : DataAccessBase
    {

         //定义一个私有的静态全局变量来保存该类的唯一实例
        private static NewDal singleton;

        //定义一个只读静态对象
        //且这个对象是在程序运行时创建的
        private static readonly object syncObject = new object(); 
        

       /// <summary>
        /// 定义一个全局访问点
        /// 设置为静态方法
        /// 则在类的外部便无需实例化就可以调用该方法
        /// </summary>
        /// <returns></returns>
        public static NewDal GetInstance()
        {
            //这里可以保证只实例化一次
            //即在第一次调用时实例化
            //以后调用便不会再实例化 

            //第一重 singleton == null
            if (singleton == null)
            {
                lock (syncObject)
                {  
                    if (singleton == null)
                    {
                        singleton = new NewDal();
                    }
                }
            }
            return singleton;
        }


        /// <summary>
        /// 获得首页的推荐文章
        /// </summary>
        /// <returns></returns>
        public IList<Tb_Easo_News> GetHomeNew(int classid)
        {
            string sql = "select a.Id, classid,a.title,source,label,iftop,downfile,a.addtime,a.viewcount,realviewcount,commentcount,b.cname as classname from tb_easo_news a left join tb_easo_newclass b on b.id=a.classid where a.IfRecommend=1 and a.classid=@cid order by RecommendOrderNum asc ";
            using (var conn = this.CreateDbConnection())
            {
                var query = conn.Query <Tb_Easo_News>(sql, new {cid=classid});

                if (query.Count() > 0)
                {
                    return query.ToList();
                } 
            }

            return null;
        }

        /// <summary>
        /// 获得文章列表按照时间排序
        /// </summary>
        /// <returns></returns>
        public IList<Tb_Easo_News> GetNewList(int classid)
        {
            string sql = "select a.Id, classid,a.title,source,label,iftop,downfile,a.addtime,a.viewcount,realviewcount,commentcount,b.cname as classname from tb_easo_news a left join tb_easo_newclass b on b.id=a.classid where a.IfRecommend=1 and a.classid=@cid order by addtime desc ";
            using (var conn = this.CreateDbConnection())
            {
                var query = conn.Query<Tb_Easo_News>(sql, new { cid = classid });

                if (query.Count() > 0)
                {
                    return query.ToList();
                }
            }

            return null;
        }

        /// <summary>
        /// 获得文章详情
        /// </summary>
        /// <param name="newsid"></param>
        /// <returns></returns>
        public Tb_Easo_News GetEntity(int newsid)
        {
            string sql = "select a.Id,classid,a.title,source,a.addtime,a.viewcount,realviewcount,commentcount,a.content,b.cname as classname from tb_easo_news a left join Tb_Easo_NewClass b on b.id=a.classid where a.ID=@id;";
            using (var conn = this.CreateDbConnection())
            {
                var query = conn.Query<Tb_Easo_News>(sql, new {ID=newsid});

                if (query.Count() > 0)
                    return query.SingleOrDefault();
                return null;
                
            }
        }

        /// <summary>
        /// 浏览次数+1
        /// </summary>
        /// <param name="newsid"></param>
        /// <returns></returns>
        public int AddViewCount(int newsid)
        {
            using (var conn = this.CreateDbConnection())
            {
               return
                   conn.Execute("update tb_easo_news set viewcount=viewcount+1 where Id=@ID", new { ID = newsid });
                 
            }

        }


       

    }
}
