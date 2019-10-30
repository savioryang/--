using SqlSugar;
using System;
using System.Linq;
using System.Text;

namespace Model
{
    ///<summary>
    ///
    ///</summary>
    public partial class board_all_systerm
    {
           public board_all_systerm(){

            this.forumReserve5 =Convert.ToString("备用5");
            this.forumDiscuss =Convert.ToString("论坛评论");
            this.forumReserve6 =Convert.ToString("备用6");
            this.forumId =Convert.ToString("论坛ID");
            this.forumTitle =Convert.ToString("论坛标题");
            this.forumPic =Convert.ToString("论坛图片");
            this.forumReserve1 =Convert.ToString("备用1");
            this.forumReserve2 =Convert.ToString("备用2");
            this.userID =Convert.ToString("用户ID");
            this.forumReserve3 =Convert.ToString("备用3");
            this.forumBody =Convert.ToString("论坛正文");
            this.forumReserve4 =Convert.ToString("备用4");

           }
           /// <summary>
           /// Desc:论坛产生时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? forumCreatTime {get;set;}

           /// <summary>
           /// Desc:
           /// Default:备用5
           /// Nullable:True
           /// </summary>           
           public string forumReserve5 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:论坛评论
           /// Nullable:True
           /// </summary>           
           public string forumDiscuss {get;set;}

           /// <summary>
           /// Desc:
           /// Default:备用6
           /// Nullable:True
           /// </summary>           
           public string forumReserve6 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:论坛ID
           /// Nullable:False
           /// </summary>           
           public string forumId {get;set;}

           /// <summary>
           /// Desc:
           /// Default:论坛标题
           /// Nullable:False
           /// </summary>           
           public string forumTitle {get;set;}

           /// <summary>
           /// Desc:
           /// Default:论坛图片
           /// Nullable:True
           /// </summary>           
           public string forumPic {get;set;}

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>       
        [SugarColumn(IsPrimaryKey = true)]
        public int id {get;}

           /// <summary>
           /// Desc:
           /// Default:备用1
           /// Nullable:True
           /// </summary>           
           public string forumReserve1 {get;set;}

           /// <summary>
           /// Desc:点赞次数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? lovenum {get;set;}

           /// <summary>
           /// Desc:
           /// Default:备用2
           /// Nullable:True
           /// </summary>           
           public string forumReserve2 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:用户ID
           /// Nullable:False
           /// </summary>           
           public string userID {get;set;}

           /// <summary>
           /// Desc:评论次数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? commitnum {get;set;}

           /// <summary>
           /// Desc:
           /// Default:备用3
           /// Nullable:True
           /// </summary>           
           public string forumReserve3 {get;set;}

           /// <summary>
           /// Desc:浏览次数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? viewnum {get;set;}

           /// <summary>
           /// Desc:
           /// Default:论坛正文
           /// Nullable:False
           /// </summary>           
           public string forumBody {get;set;}

           /// <summary>
           /// Desc:
           /// Default:备用4
           /// Nullable:True
           /// </summary>           
           public string forumReserve4 {get;set;}

           /// <summary>
           /// Desc:转发次数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? zhuanfanum {get;set;}

    }
}
