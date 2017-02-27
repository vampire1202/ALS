using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ALS.DAL
{
    /// <summary>
    /// 数据访问类:syringecal
    /// </summary>
    public partial class syringecal
    {
        public syringecal()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID, string brand, int version)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_syringecal");
            strSql.Append(" where ID=@ID and brand=@brand and version=@version ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32,11),
					new MySqlParameter("@brand", MySqlDbType.VarChar,100),
					new MySqlParameter("@version", MySqlDbType.Int32,11)			};
            parameters[0].Value = ID;
            parameters[1].Value = brand;
            parameters[2].Value = version;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ALS.Model.syringecal model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_syringecal(");
            strSql.Append("brand,version,calibre,compdis,length)");
            strSql.Append(" values (");
            strSql.Append("@brand,@version,@calibre,@compdis,@length)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@brand", MySqlDbType.VarChar,100),
					new MySqlParameter("@version", MySqlDbType.Int32,11),
					new MySqlParameter("@calibre", MySqlDbType.Int32,11),
					new MySqlParameter("@compdis", MySqlDbType.Int32,11),
					new MySqlParameter("@length", MySqlDbType.Int32,11)};
            parameters[0].Value = model.brand;
            parameters[1].Value = model.version;
            parameters[2].Value = model.calibre;
            parameters[3].Value = model.compdis;
            parameters[4].Value = model.length;

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
        public bool Update(ALS.Model.syringecal model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_syringecal set ");
            strSql.Append("calibre=@calibre,");
            strSql.Append("compdis=@compdis,");
            strSql.Append("length=@length");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@calibre", MySqlDbType.Int32,11),
					new MySqlParameter("@compdis", MySqlDbType.Int32,11),
					new MySqlParameter("@length", MySqlDbType.Int32,11),
					new MySqlParameter("@ID", MySqlDbType.Int32,11),
					new MySqlParameter("@brand", MySqlDbType.VarChar,100),
					new MySqlParameter("@version", MySqlDbType.Int32,11)};
            parameters[0].Value = model.calibre;
            parameters[1].Value = model.compdis;
            parameters[2].Value = model.length;
            parameters[3].Value = model.ID;
            parameters[4].Value = model.brand;
            parameters[5].Value = model.version;

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
            strSql.Append("delete from tb_syringecal ");
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID, string brand, int version)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_syringecal ");
            strSql.Append(" where ID=@ID and brand=@brand and version=@version ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32,11),
					new MySqlParameter("@brand", MySqlDbType.VarChar,100),
					new MySqlParameter("@version", MySqlDbType.Int32,11)			};
            parameters[0].Value = ID;
            parameters[1].Value = brand;
            parameters[2].Value = version;

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
            strSql.Append("delete from tb_syringecal ");
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
        public ALS.Model.syringecal GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,brand,version,calibre,compdis,length from tb_syringecal ");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
            parameters[0].Value = ID;

            ALS.Model.syringecal model = new ALS.Model.syringecal();
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
        public ALS.Model.syringecal DataRowToModel(DataRow row)
        {
            ALS.Model.syringecal model = new ALS.Model.syringecal();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["brand"] != null)
                {
                    model.brand = row["brand"].ToString();
                }
                if (row["version"] != null && row["version"].ToString() != "")
                {
                    model.version = int.Parse(row["version"].ToString());
                }
                if (row["calibre"] != null && row["calibre"].ToString() != "")
                {
                    model.calibre = int.Parse(row["calibre"].ToString());
                }
                if (row["compdis"] != null && row["compdis"].ToString() != "")
                {
                    model.compdis = int.Parse(row["compdis"].ToString());
                }
                if (row["length"] != null && row["length"].ToString() != "")
                {
                    model.length = int.Parse(row["length"].ToString());
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
            strSql.Append("select ID,brand,version,calibre,compdis,length ");
            strSql.Append(" FROM tb_syringecal ");
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
            strSql.Append("select count(1) FROM tb_syringecal ");
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
            strSql.Append(")AS Row, T.*  from tb_syringecal T ");
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
            parameters[0].Value = "tb_syringecal";
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

