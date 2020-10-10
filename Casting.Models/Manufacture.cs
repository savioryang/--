using System;
using System.Linq;
using System.Text;

namespace Model
{
    ///<summary>
    ///
    ///</summary>
    public partial class Manufacture
    {
           public Manufacture(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int ID {get;set;}

           /// <summary>
           /// Desc:操作标志
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ACTION_CODE {get;set;}

           /// <summary>
           /// Desc:制造命令号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PONO {get;set;}

           /// <summary>
           /// Desc:计划日期
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PLAN_DATE {get;set;}

           /// <summary>
           /// Desc:内部钢种
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ST_NO {get;set;}

           /// <summary>
           /// Desc:牌号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SG_SIGN {get;set;}

           /// <summary>
           /// Desc:CASTLOT号	
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CAST_LOT_NO {get;set;}

           /// <summary>
           /// Desc:CASTLOT总炉数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? CAST_LOT_SUM {get;set;}

           /// <summary>
           /// Desc:CASTLOT分割号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? CAST_LOT_DIV_NO {get;set;}

           /// <summary>
           /// Desc:连铸机号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CC_MACH_NO {get;set;}

           /// <summary>
           /// Desc:钢坯总支数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? PLAN_TAP_NUM {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? PLAN_TAP_WT {get;set;}

           /// <summary>
           /// Desc:精炼路径
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string REFINE_ROUTE {get;set;}

           /// <summary>
           /// Desc:备注
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string REMARK {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string TEMP_C1 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string TEMP_C2 {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string TEMP_C3 {get;set;}

           /// <summary>
           /// Desc:备用字段N1
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? TEMP_N1 {get;set;}

           /// <summary>
           /// Desc:备用字段N2
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? TEMP_N2 {get;set;}

    }
}
