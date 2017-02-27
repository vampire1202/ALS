using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ALS.DAL
{
    /// <summary>
    /// 数据访问类:tb_actions
    /// </summary>
    public partial class actions
    {
        public  actions()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_actions");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
            parameters[0].Value = ID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ALS.Model.actions model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_actions(");
            strSql.Append("customID,portName,arrCommand,actionInfo,cmdLength)");
            strSql.Append(" values (");
            strSql.Append("@customID,@portName,@arrCommand,@actionInfo,@cmdLength)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@customID", MySqlDbType.Int32,20),
					new MySqlParameter("@portName", MySqlDbType.VarChar,255),
					new MySqlParameter("@arrCommand", MySqlDbType.Binary),
					new MySqlParameter("@actionInfo", MySqlDbType.VarChar,255),
                    new MySqlParameter("@cmdLength", MySqlDbType.Int32,20),
                                          };
            parameters[0].Value = model.customID;
            parameters[1].Value = model.portName;
            parameters[2].Value = model.arrCommand;
            parameters[3].Value = model.actionInfo;
            parameters[4].Value = model.cmdLength;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ALS.Model.actions model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_actions set ");
            strSql.Append("customID=@customID,");
            strSql.Append("portName=@portName,");
            strSql.Append("arrCommand=@arrCommand,");
            strSql.Append("actionInfo=@actionInfo");
            strSql.Append("cmdLength = @cmdLength");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@customID", MySqlDbType.Int32,20),
					new MySqlParameter("@portName", MySqlDbType.VarChar,255),
					new MySqlParameter("@arrCommand", MySqlDbType.Binary),
					new MySqlParameter("@actionInfo", MySqlDbType.VarChar,255), 
                    new MySqlParameter("@cmdLength",MySqlDbType.Int32,20),
					new MySqlParameter("@ID", MySqlDbType.Int32,20)
                                          };
            parameters[0].Value = model.customID;
            parameters[1].Value = model.portName;
            parameters[2].Value = model.arrCommand;
            parameters[3].Value = model.actionInfo;
            parameters[4].Value = model.cmdLength;
            parameters[5].Value = model.ID;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_actions ");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
            parameters[0].Value = ID;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_actions ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ALS.Model.actions GetModel(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,customID,portName,arrCommand,actionInfo,cmdLength from tb_actions ");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
            parameters[0].Value = ID;

            ALS.Model.actions model = new ALS.Model.actions();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ALS.Model.actions DataRowToModel(DataRow row)
        {
            ALS.Model.actions model = new ALS.Model.actions();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = long.Parse(row["ID"].ToString());
                }
                if (row["customID"] != null && row["customID"].ToString() != "")
                {
                    model.customID = long.Parse(row["customID"].ToString());
                }
                if (row["portName"] != null)
                {
                    model.portName = row["portName"].ToString();
                }
                if (row["arrCommand"] != null && row["arrCommand"].ToString() != "")
                {
                    model.arrCommand = (byte[])row["arrCommand"];
                }
                if (row["actionInfo"] != null)
                {
                    model.actionInfo = row["actionInfo"].ToString();
                }
                if (row["cmdLength"] != null && row["cmdLength"].ToString() != "")
                {
                    model.cmdLength = int.Parse(row["cmdLength"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere,bool bView)
        {
            StringBuilder strSql = new StringBuilder();
            if(bView)
                strSql.Append("select ID,customID,portName as '串口',actionInfo '动作描述' ");
            else
                strSql.Append("select ID,customID,portName,actionInfo,arrCommand,cmdLength");
            strSql.Append(" FROM tb_actions ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tb_actions ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from tb_actions T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            MySqlParameter[] parameters = {
                    new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("@PageSize", MySqlDbType.Int32),
                    new MySqlParameter("@PageIndex", MySqlDbType.Int32),
                    new MySqlParameter("@IsReCount", MySqlDbType.Bit),
                    new MySqlParameter("@OrderType", MySqlDbType.Bit),
                    new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "tb_actions";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

