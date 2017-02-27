using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ALS.DAL
{
    /// <summary>
    /// 数据访问类:warnlog
    /// </summary>
    public partial class warnlog
    {
        public warnlog()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_warnlog");
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
        public bool Add(ALS.Model.warnlog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_warnlog(");
            strSql.Append("grade,logdate,logtime,warncode,warntitle,sign,para1,para2,para3)");
            strSql.Append(" values (");
            strSql.Append("@grade,@logdate,@logtime,@warncode,@warntitle,@sign,@para1,@para2,@para3)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@grade", MySqlDbType.Int32,11),
					new MySqlParameter("@logdate", MySqlDbType.Date),
					new MySqlParameter("@logtime", MySqlDbType.DateTime),
					new MySqlParameter("@warncode", MySqlDbType.VarChar,255),
					new MySqlParameter("@warntitle", MySqlDbType.VarChar,255),
					new MySqlParameter("@sign", MySqlDbType.Text),
					new MySqlParameter("@para1", MySqlDbType.VarChar,255),
					new MySqlParameter("@para2", MySqlDbType.VarChar,255),
					new MySqlParameter("@para3", MySqlDbType.VarChar,255)};
            parameters[0].Value = model.grade;
            parameters[1].Value = model.logdate;
            parameters[2].Value = model.logtime;
            parameters[3].Value = model.warncode;
            parameters[4].Value = model.warntitle;
            parameters[5].Value = model.sign;
            parameters[6].Value = model.para1;
            parameters[7].Value = model.para2;
            parameters[8].Value = model.para3;

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
        public bool Update(ALS.Model.warnlog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_warnlog set ");
            strSql.Append("grade=@grade,");
            strSql.Append("logdate=@logdate,");
            strSql.Append("logtime=@logtime,");
            strSql.Append("warncode=@warncode,");
            strSql.Append("warntitle=@warntitle,");
            strSql.Append("sign=@sign,");
            strSql.Append("para1=@para1,");
            strSql.Append("para2=@para2,");
            strSql.Append("para3=@para3");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@grade", MySqlDbType.Int32,11),
					new MySqlParameter("@logdate", MySqlDbType.Date),
					new MySqlParameter("@logtime", MySqlDbType.DateTime),
					new MySqlParameter("@warncode", MySqlDbType.VarChar,255),
					new MySqlParameter("@warntitle", MySqlDbType.VarChar,255),
					new MySqlParameter("@sign", MySqlDbType.Text),
					new MySqlParameter("@para1", MySqlDbType.VarChar,255),
					new MySqlParameter("@para2", MySqlDbType.VarChar,255),
					new MySqlParameter("@para3", MySqlDbType.VarChar,255),
					new MySqlParameter("@ID", MySqlDbType.Int32,20)};
            parameters[0].Value = model.grade;
            parameters[1].Value = model.logdate;
            parameters[2].Value = model.logtime;
            parameters[3].Value = model.warncode;
            parameters[4].Value = model.warntitle;
            parameters[5].Value = model.sign;
            parameters[6].Value = model.para1;
            parameters[7].Value = model.para2;
            parameters[8].Value = model.para3;
            parameters[9].Value = model.ID;

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
            strSql.Append("delete from tb_warnlog ");
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
            strSql.Append("delete from tb_warnlog ");
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
        public ALS.Model.warnlog GetModel(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,grade,logdate,logtime,warncode,warntitle,sign,para1,para2,para3 from tb_warnlog ");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
            parameters[0].Value = ID;

            ALS.Model.warnlog model = new ALS.Model.warnlog();
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
        public ALS.Model.warnlog DataRowToModel(DataRow row)
        {
            ALS.Model.warnlog model = new ALS.Model.warnlog();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = long.Parse(row["ID"].ToString());
                }
                if (row["grade"] != null && row["grade"].ToString() != "")
                {
                    model.grade = int.Parse(row["grade"].ToString());
                }
                if (row["logdate"] != null && row["logdate"].ToString() != "")
                {
                    model.logdate = DateTime.Parse(row["logdate"].ToString());
                }
                if (row["logtime"] != null && row["logtime"].ToString() != "")
                {
                    model.logtime = DateTime.Parse(row["logtime"].ToString());
                }
                if (row["warncode"] != null)
                {
                    model.warncode = row["warncode"].ToString();
                }
                if (row["warntitle"] != null)
                {
                    model.warntitle = row["warntitle"].ToString();
                }
                if (row["sign"] != null)
                {
                    model.sign = row["sign"].ToString();
                }
                if (row["para1"] != null)
                {
                    model.para1 = row["para1"].ToString();
                }
                if (row["para2"] != null)
                {
                    model.para2 = row["para2"].ToString();
                }
                if (row["para3"] != null)
                {
                    model.para3 = row["para3"].ToString();
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
            strSql.Append("select ID,grade,logdate,logtime,warncode,warntitle,sign,para1,para2,para3 ");
            strSql.Append(" FROM tb_warnlog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere + " order by logtime desc");
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tb_warnlog ");
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
            strSql.Append(")AS Row, T.*  from tb_warnlog T ");
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
            parameters[0].Value = "tb_warnlog";
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

