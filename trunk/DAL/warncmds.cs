using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ALS.DAL
{
    /// <summary>
    /// 数据访问类:warncmds
    /// </summary>
    public partial class warncmds
    {
        public warncmds()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("ID", "tb_warncmds");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_warncmds");
            strSql.Append(" where ID=@ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32,11)			};
            parameters[0].Value = ID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ALS.Model.warncmds model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_warncmds(");
            strSql.Append("ID,warnCodeID,actionInfo,portName,cmd,cmdLength)");
            strSql.Append(" values (");
            strSql.Append("@ID,@warnCodeID,@actionInfo,@portName,@cmd,@cmdLength)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32,11),
					new MySqlParameter("@warnCodeID", MySqlDbType.Int32,11),
					new MySqlParameter("@actionInfo", MySqlDbType.VarChar,255),
					new MySqlParameter("@portName", MySqlDbType.VarChar,255),
					new MySqlParameter("@cmd", MySqlDbType.Binary),
					new MySqlParameter("@cmdLength", MySqlDbType.Int32,11)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.warnCodeID;
            parameters[2].Value = model.actionInfo;
            parameters[3].Value = model.portName;
            parameters[4].Value = model.cmd;
            parameters[5].Value = model.cmdLength;

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
        public bool Update(ALS.Model.warncmds model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_warncmds set ");
            strSql.Append("warnCodeID=@warnCodeID,");
            strSql.Append("actionInfo=@actionInfo,");
            strSql.Append("portName=@portName,");
            strSql.Append("cmd=@cmd,");
            strSql.Append("cmdLength=@cmdLength");
            strSql.Append(" where ID=@ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@warnCodeID", MySqlDbType.Int32,11),
					new MySqlParameter("@actionInfo", MySqlDbType.VarChar,255),
					new MySqlParameter("@portName", MySqlDbType.VarChar,255),
					new MySqlParameter("@cmd", MySqlDbType.Binary),
					new MySqlParameter("@cmdLength", MySqlDbType.Int32,11),
					new MySqlParameter("@ID", MySqlDbType.Int32,11)};
            parameters[0].Value = model.warnCodeID;
            parameters[1].Value = model.actionInfo;
            parameters[2].Value = model.portName;
            parameters[3].Value = model.cmd;
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
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_warncmds ");
            strSql.Append(" where ID=@ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32,11)			};
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
            strSql.Append("delete from tb_warncmds ");
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
        public ALS.Model.warncmds GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,warnCodeID,actionInfo,portName,cmd,cmdLength from tb_warncmds ");
            strSql.Append(" where ID=@ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32,11)			};
            parameters[0].Value = ID;

            ALS.Model.warncmds model = new ALS.Model.warncmds();
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

        public ALS.Model.warncmds GetModel(int warnCodeID, string _actionInfo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,warnCodeID,actionInfo,portName,cmd,cmdLength from tb_warncmds ");
            strSql.Append(" where warnCodeID=@warnCodeID and actionInfo=@actionInfo ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@warnCodeID", MySqlDbType.Int32,11),
                    new MySqlParameter("@actionInfo", MySqlDbType.VarChar)                
                                          };
            parameters[0].Value = warnCodeID;
            parameters[1].Value = _actionInfo;

            ALS.Model.warncmds model = new ALS.Model.warncmds();
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
        public ALS.Model.warncmds DataRowToModel(DataRow row)
        {
            ALS.Model.warncmds model = new ALS.Model.warncmds();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["warnCodeID"] != null && row["warnCodeID"].ToString() != "")
                {
                    model.warnCodeID = int.Parse(row["warnCodeID"].ToString());
                }
                if (row["actionInfo"] != null)
                {
                    model.actionInfo = row["actionInfo"].ToString();
                }
                if (row["portName"] != null)
                {
                    model.portName = row["portName"].ToString();
                }
                if (row["cmd"] != null && row["cmd"].ToString() != "")
                {
                    model.cmd = (byte[])row["cmd"];
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
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,warnCodeID,actionInfo,portName,cmd,cmdLength ");
            strSql.Append(" FROM tb_warncmds");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        public DataSet GetListShow(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,warnCodeID,actionInfo as '动作列表' ");
            strSql.Append(" FROM tb_warncmds");
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
            strSql.Append("select count(1) FROM tb_warncmds ");
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
            strSql.Append(")AS Row, T.*  from tb_warncmds T ");
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
            parameters[0].Value = "tb_warncmds";
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

