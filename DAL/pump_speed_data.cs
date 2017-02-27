using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ALS.DAL
{
    /// <summary>
    /// 数据访问类:pump_speed_data
    /// </summary>
    public partial class pump_speed_data
    {
        public pump_speed_data()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string surgery_no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from pump_speed_data");
            strSql.Append(" where surgery_no=@surgery_no ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@surgery_no", MySqlDbType.VarChar,255)			};
            parameters[0].Value = surgery_no;

            return DbHelperMySQL_Data.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ALS.Model.pump_speed_data model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into pump_speed_data(");
            strSql.Append("surgery_no,time_stamp,cumulative_time,blood_pump,separation_pump,dialysis_pump,tripe_pump,filtration_pump,circulating_pump,heparin_pump,warmer,blood_pump_t,separation_pump_t,dialysis_pump_t,tripe_pump_t,filtration_pump_t,circulating_pump_t,heparin_pump_t)");
            strSql.Append(" values (");
            strSql.Append("@surgery_no,@time_stamp,@cumulative_time,@blood_pump,@separation_pump,@dialysis_pump,@tripe_pump,@filtration_pump,@circulating_pump,@heparin_pump,@warmer,@blood_pump_t,@separation_pump_t,@dialysis_pump_t,@tripe_pump_t,@filtration_pump_t,@circulating_pump_t,@heparin_pump_t)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@surgery_no", MySqlDbType.VarChar,255),
					new MySqlParameter("@time_stamp", MySqlDbType.VarChar,255),
					new MySqlParameter("@cumulative_time", MySqlDbType.VarChar,255),
					new MySqlParameter("@blood_pump", MySqlDbType.VarChar,255),
					new MySqlParameter("@separation_pump", MySqlDbType.VarChar,255),
					new MySqlParameter("@dialysis_pump", MySqlDbType.VarChar,255),
					new MySqlParameter("@tripe_pump", MySqlDbType.VarChar,255),
					new MySqlParameter("@filtration_pump", MySqlDbType.VarChar,255),
					new MySqlParameter("@circulating_pump", MySqlDbType.VarChar,255),
					new MySqlParameter("@heparin_pump", MySqlDbType.VarChar,255),
					new MySqlParameter("@warmer", MySqlDbType.VarChar,255),
					new MySqlParameter("@blood_pump_t", MySqlDbType.VarChar,255),
					new MySqlParameter("@separation_pump_t", MySqlDbType.VarChar,255),
					new MySqlParameter("@dialysis_pump_t", MySqlDbType.VarChar,255),
					new MySqlParameter("@tripe_pump_t", MySqlDbType.VarChar,255),
					new MySqlParameter("@filtration_pump_t", MySqlDbType.VarChar,255),
					new MySqlParameter("@circulating_pump_t", MySqlDbType.VarChar,255),
					new MySqlParameter("@heparin_pump_t", MySqlDbType.VarChar,255)};
            parameters[0].Value = model.surgery_no;
            parameters[1].Value = model.time_stamp;
            parameters[2].Value = model.cumulative_time;
            parameters[3].Value = model.blood_pump;
            parameters[4].Value = model.separation_pump;
            parameters[5].Value = model.dialysis_pump;
            parameters[6].Value = model.tripe_pump;
            parameters[7].Value = model.filtration_pump;
            parameters[8].Value = model.circulating_pump;
            parameters[9].Value = model.heparin_pump;
            parameters[10].Value = model.warmer;
            parameters[11].Value = model.blood_pump_t;
            parameters[12].Value = model.separation_pump_t;
            parameters[13].Value = model.dialysis_pump_t;
            parameters[14].Value = model.tripe_pump_t;
            parameters[15].Value = model.filtration_pump_t;
            parameters[16].Value = model.circulating_pump_t;
            parameters[17].Value = model.heparin_pump_t;

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
        public bool Update(ALS.Model.pump_speed_data model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update pump_speed_data set ");
            strSql.Append("time_stamp=@time_stamp,");
            strSql.Append("cumulative_time=@cumulative_time,");
            strSql.Append("blood_pump=@blood_pump,");
            strSql.Append("separation_pump=@separation_pump,");
            strSql.Append("dialysis_pump=@dialysis_pump,");
            strSql.Append("tripe_pump=@tripe_pump,");
            strSql.Append("filtration_pump=@filtration_pump,");
            strSql.Append("circulating_pump=@circulating_pump,");
            strSql.Append("heparin_pump=@heparin_pump,");
            strSql.Append("warmer=@warmer,");
            strSql.Append("blood_pump_t=@blood_pump_t,");
            strSql.Append("separation_pump_t=@separation_pump_t,");
            strSql.Append("dialysis_pump_t=@dialysis_pump_t,");
            strSql.Append("tripe_pump_t=@tripe_pump_t,");
            strSql.Append("filtration_pump_t=@filtration_pump_t,");
            strSql.Append("circulating_pump_t=@circulating_pump_t,");
            strSql.Append("heparin_pump_t=@heparin_pump_t");
            strSql.Append(" where surgery_no=@surgery_no ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@time_stamp", MySqlDbType.VarChar,255),
					new MySqlParameter("@cumulative_time", MySqlDbType.VarChar,255),
					new MySqlParameter("@blood_pump", MySqlDbType.VarChar,255),
					new MySqlParameter("@separation_pump", MySqlDbType.VarChar,255),
					new MySqlParameter("@dialysis_pump", MySqlDbType.VarChar,255),
					new MySqlParameter("@tripe_pump", MySqlDbType.VarChar,255),
					new MySqlParameter("@filtration_pump", MySqlDbType.VarChar,255),
					new MySqlParameter("@circulating_pump", MySqlDbType.VarChar,255),
					new MySqlParameter("@heparin_pump", MySqlDbType.VarChar,255),
					new MySqlParameter("@warmer", MySqlDbType.VarChar,255),
					new MySqlParameter("@blood_pump_t", MySqlDbType.VarChar,255),
					new MySqlParameter("@separation_pump_t", MySqlDbType.VarChar,255),
					new MySqlParameter("@dialysis_pump_t", MySqlDbType.VarChar,255),
					new MySqlParameter("@tripe_pump_t", MySqlDbType.VarChar,255),
					new MySqlParameter("@filtration_pump_t", MySqlDbType.VarChar,255),
					new MySqlParameter("@circulating_pump_t", MySqlDbType.VarChar,255),
					new MySqlParameter("@heparin_pump_t", MySqlDbType.VarChar,255),
					new MySqlParameter("@surgery_no", MySqlDbType.VarChar,255)};
            parameters[0].Value = model.time_stamp;
            parameters[1].Value = model.cumulative_time;
            parameters[2].Value = model.blood_pump;
            parameters[3].Value = model.separation_pump;
            parameters[4].Value = model.dialysis_pump;
            parameters[5].Value = model.tripe_pump;
            parameters[6].Value = model.filtration_pump;
            parameters[7].Value = model.circulating_pump;
            parameters[8].Value = model.heparin_pump;
            parameters[9].Value = model.warmer;
            parameters[10].Value = model.blood_pump_t;
            parameters[11].Value = model.separation_pump_t;
            parameters[12].Value = model.dialysis_pump_t;
            parameters[13].Value = model.tripe_pump_t;
            parameters[14].Value = model.filtration_pump_t;
            parameters[15].Value = model.circulating_pump_t;
            parameters[16].Value = model.heparin_pump_t;
            parameters[17].Value = model.surgery_no;

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
            strSql.Append("delete from pump_speed_data ");
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
            strSql.Append("delete from pump_speed_data ");
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
        public ALS.Model.pump_speed_data GetModel(string surgery_no)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select surgery_no,time_stamp,cumulative_time,blood_pump,separation_pump,dialysis_pump,tripe_pump,filtration_pump,circulating_pump,heparin_pump,warmer,blood_pump_t,separation_pump_t,dialysis_pump_t,tripe_pump_t,filtration_pump_t,circulating_pump_t,heparin_pump_t from pump_speed_data ");
            strSql.Append(" where surgery_no=@surgery_no ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@surgery_no", MySqlDbType.VarChar,255)			};
            parameters[0].Value = surgery_no;

            ALS.Model.pump_speed_data model = new ALS.Model.pump_speed_data();
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
        public ALS.Model.pump_speed_data DataRowToModel(DataRow row)
        {
            ALS.Model.pump_speed_data model = new ALS.Model.pump_speed_data();
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
                if (row["cumulative_time"] != null)
                {
                    model.cumulative_time = row["cumulative_time"].ToString();
                }
                if (row["blood_pump"] != null)
                {
                    model.blood_pump = row["blood_pump"].ToString();
                }
                if (row["separation_pump"] != null)
                {
                    model.separation_pump = row["separation_pump"].ToString();
                }
                if (row["dialysis_pump"] != null)
                {
                    model.dialysis_pump = row["dialysis_pump"].ToString();
                }
                if (row["tripe_pump"] != null)
                {
                    model.tripe_pump = row["tripe_pump"].ToString();
                }
                if (row["filtration_pump"] != null)
                {
                    model.filtration_pump = row["filtration_pump"].ToString();
                }
                if (row["circulating_pump"] != null)
                {
                    model.circulating_pump = row["circulating_pump"].ToString();
                }
                if (row["heparin_pump"] != null)
                {
                    model.heparin_pump = row["heparin_pump"].ToString();
                }
                if (row["warmer"] != null)
                {
                    model.warmer = row["warmer"].ToString();
                }
                if (row["blood_pump_t"] != null)
                {
                    model.blood_pump_t = row["blood_pump_t"].ToString();
                }
                if (row["separation_pump_t"] != null)
                {
                    model.separation_pump_t = row["separation_pump_t"].ToString();
                }
                if (row["dialysis_pump_t"] != null)
                {
                    model.dialysis_pump_t = row["dialysis_pump_t"].ToString();
                }
                if (row["tripe_pump_t"] != null)
                {
                    model.tripe_pump_t = row["tripe_pump_t"].ToString();
                }
                if (row["filtration_pump_t"] != null)
                {
                    model.filtration_pump_t = row["filtration_pump_t"].ToString();
                }
                if (row["circulating_pump_t"] != null)
                {
                    model.circulating_pump_t = row["circulating_pump_t"].ToString();
                }
                if (row["heparin_pump_t"] != null)
                {
                    model.heparin_pump_t = row["heparin_pump_t"].ToString();
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
            strSql.Append("select surgery_no,time_stamp,cumulative_time,blood_pump,separation_pump,dialysis_pump,tripe_pump,filtration_pump,circulating_pump,heparin_pump,warmer,blood_pump_t,separation_pump_t,dialysis_pump_t,tripe_pump_t,filtration_pump_t,circulating_pump_t,heparin_pump_t ");
            strSql.Append(" FROM pump_speed_data ");
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
            strSql.Append("select count(1) FROM pump_speed_data ");
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
            strSql.Append(")AS Row, T.*  from pump_speed_data T ");
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
            parameters[0].Value = "pump_speed_data";
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

