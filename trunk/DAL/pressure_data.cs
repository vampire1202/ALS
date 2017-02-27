using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ALS.DAL
{
    /// <summary>
    /// 数据访问类:pressure_data
    /// </summary>
    public partial class pressure_data
    {
        public pressure_data()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string surgery_no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from pressure_data");
            strSql.Append(" where surgery_no=@surgery_no ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@surgery_no", MySqlDbType.VarChar,255)			};
            parameters[0].Value = surgery_no;

            return DbHelperMySQL_Data.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ALS.Model.pressure_data model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pressure_data(");
            strSql.Append("surgery_no,time_stamp,in_blood_pressure,plasma_inlet_pressure,arterial_pressure,venous_pressure,plasma_pressure,transmembrane_pressure)");
            strSql.Append(" values (");
            strSql.Append("@surgery_no,@time_stamp,@in_blood_pressure,@plasma_inlet_pressure,@arterial_pressure,@venous_pressure,@plasma_pressure,@transmembrane_pressure)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@surgery_no", MySqlDbType.VarChar,255),
					new MySqlParameter("@time_stamp", MySqlDbType.VarChar,255),
					new MySqlParameter("@in_blood_pressure", MySqlDbType.VarChar,255),
					new MySqlParameter("@plasma_inlet_pressure", MySqlDbType.VarChar,255),
					new MySqlParameter("@arterial_pressure", MySqlDbType.VarChar,255),
					new MySqlParameter("@venous_pressure", MySqlDbType.VarChar,255),
					new MySqlParameter("@plasma_pressure", MySqlDbType.VarChar,255),
					new MySqlParameter("@transmembrane_pressure", MySqlDbType.VarChar,255)};
            parameters[0].Value = model.surgery_no;
            parameters[1].Value = model.time_stamp;
            parameters[2].Value = model.in_blood_pressure;
            parameters[3].Value = model.plasma_inlet_pressure;
            parameters[4].Value = model.arterial_pressure;
            parameters[5].Value = model.venous_pressure;
            parameters[6].Value = model.plasma_pressure;
            parameters[7].Value = model.transmembrane_pressure;

            int rows = DbHelperMySQL_Data.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Update(ALS.Model.pressure_data model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pressure_data set ");
            strSql.Append("time_stamp=@time_stamp,");
            strSql.Append("in_blood_pressure=@in_blood_pressure,");
            strSql.Append("plasma_inlet_pressure=@plasma_inlet_pressure,");
            strSql.Append("arterial_pressure=@arterial_pressure,");
            strSql.Append("venous_pressure=@venous_pressure,");
            strSql.Append("plasma_pressure=@plasma_pressure,");
            strSql.Append("transmembrane_pressure=@transmembrane_pressure");
            strSql.Append(" where surgery_no=@surgery_no ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@time_stamp", MySqlDbType.VarChar,255),
					new MySqlParameter("@in_blood_pressure", MySqlDbType.VarChar,255),
					new MySqlParameter("@plasma_inlet_pressure", MySqlDbType.VarChar,255),
					new MySqlParameter("@arterial_pressure", MySqlDbType.VarChar,255),
					new MySqlParameter("@venous_pressure", MySqlDbType.VarChar,255),
					new MySqlParameter("@plasma_pressure", MySqlDbType.VarChar,255),
					new MySqlParameter("@transmembrane_pressure", MySqlDbType.VarChar,255),
					new MySqlParameter("@surgery_no", MySqlDbType.VarChar,255)};
            parameters[0].Value = model.time_stamp;
            parameters[1].Value = model.in_blood_pressure;
            parameters[2].Value = model.plasma_inlet_pressure;
            parameters[3].Value = model.arterial_pressure;
            parameters[4].Value = model.venous_pressure;
            parameters[5].Value = model.plasma_pressure;
            parameters[6].Value = model.transmembrane_pressure;
            parameters[7].Value = model.surgery_no;

            int rows = DbHelperMySQL_Data.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(string surgery_no)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from pressure_data ");
            strSql.Append(" where surgery_no=@surgery_no ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@surgery_no", MySqlDbType.VarChar,255)			};
            parameters[0].Value = surgery_no;

            int rows = DbHelperMySQL_Data.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string surgery_nolist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from pressure_data ");
            strSql.Append(" where surgery_no in (" + surgery_nolist + ")  ");
            int rows = DbHelperMySQL_Data.ExecuteSql(strSql.ToString());
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
        public ALS.Model.pressure_data GetModel(string surgery_no)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select surgery_no,time_stamp,in_blood_pressure,plasma_inlet_pressure,arterial_pressure,venous_pressure,plasma_pressure,transmembrane_pressure from pressure_data ");
            strSql.Append(" where surgery_no=@surgery_no ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@surgery_no", MySqlDbType.VarChar,255)			};
            parameters[0].Value = surgery_no;

            ALS.Model.pressure_data model = new ALS.Model.pressure_data();
            DataSet ds = DbHelperMySQL_Data.Query(strSql.ToString(), parameters);
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
        public ALS.Model.pressure_data DataRowToModel(DataRow row)
        {
            ALS.Model.pressure_data model = new ALS.Model.pressure_data();
            if (row != null)
            {
                if (row["surgery_no"] != null)
                {
                    model.surgery_no = row["surgery_no"].ToString();
                }
                if (row["time_stamp"] != null)
                {
                    model.time_stamp = row["time_stamp"].ToString();
                }
                if (row["in_blood_pressure"] != null)
                {
                    model.in_blood_pressure = row["in_blood_pressure"].ToString();
                }
                if (row["plasma_inlet_pressure"] != null)
                {
                    model.plasma_inlet_pressure = row["plasma_inlet_pressure"].ToString();
                }
                if (row["arterial_pressure"] != null)
                {
                    model.arterial_pressure = row["arterial_pressure"].ToString();
                }
                if (row["venous_pressure"] != null)
                {
                    model.venous_pressure = row["venous_pressure"].ToString();
                }
                if (row["plasma_pressure"] != null)
                {
                    model.plasma_pressure = row["plasma_pressure"].ToString();
                }
                if (row["transmembrane_pressure"] != null)
                {
                    model.transmembrane_pressure = row["transmembrane_pressure"].ToString();
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
            strSql.Append("select surgery_no,time_stamp,in_blood_pressure,plasma_inlet_pressure,arterial_pressure,venous_pressure,plasma_pressure,transmembrane_pressure ");
            strSql.Append(" FROM pressure_data ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL_Data.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM pressure_data ");
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
                strSql.Append("order by T.surgery_no desc");
            }
            strSql.Append(")AS Row, T.*  from pressure_data T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperMySQL_Data.Query(strSql.ToString());
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
            parameters[0].Value = "pressure_data";
            parameters[1].Value = "surgery_no";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL_Data.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

