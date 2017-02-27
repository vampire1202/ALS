using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ALS.DAL
{
    /// <summary>
    /// 数据访问类:calibrateweigh
    /// </summary>
    public partial class calibrateweigh
    {
        public calibrateweigh()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_calibrateweigh");
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
        public bool Add(ALS.Model.calibrateweigh model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_calibrateweigh(");
            strSql.Append("weigh1_0kgcode,weigh1_5kgcode,weigh1_10kgcode,weigh1_resolution,weigh2_0kgcode,weigh2_5kgcode,weigh2_10kgcode,weigh2_resolution,weigh3_0kgcode,weigh3_5kgcode,weigh3_10kgcode,weigh3_resolution,weigh4_0kgcode,weigh4_5kgcode,weigh4_10kgcode,weigh4_resolution,pumpspeedchange)");
            strSql.Append(" values (");
            strSql.Append("@weigh1_0kgcode,@weigh1_5kgcode,@weigh1_10kgcode,@weigh1_resolution,@weigh2_0kgcode,@weigh2_5kgcode,@weigh2_10kgcode,@weigh2_resolution,@weigh3_0kgcode,@weigh3_5kgcode,@weigh3_10kgcode,@weigh3_resolution,@weigh4_0kgcode,@weigh4_5kgcode,@weigh4_10kgcode,@weigh4_resolution,@pumpspeedchange)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@weigh1_0kgcode", MySqlDbType.Int32,11),
					new MySqlParameter("@weigh1_5kgcode", MySqlDbType.Int32,11),
					new MySqlParameter("@weigh1_10kgcode", MySqlDbType.Int32,11),
					new MySqlParameter("@weigh1_resolution", MySqlDbType.Double),
					new MySqlParameter("@weigh2_0kgcode", MySqlDbType.Int32,11),
					new MySqlParameter("@weigh2_5kgcode", MySqlDbType.Int32,11),
					new MySqlParameter("@weigh2_10kgcode", MySqlDbType.Int32,11),
					new MySqlParameter("@weigh2_resolution", MySqlDbType.Double),
					new MySqlParameter("@weigh3_0kgcode", MySqlDbType.Int32,11),
					new MySqlParameter("@weigh3_5kgcode", MySqlDbType.Int32,11),
					new MySqlParameter("@weigh3_10kgcode", MySqlDbType.Int32,11),
					new MySqlParameter("@weigh3_resolution", MySqlDbType.Double),
					new MySqlParameter("@weigh4_0kgcode", MySqlDbType.Int32,11),
					new MySqlParameter("@weigh4_5kgcode", MySqlDbType.Int32,11),
					new MySqlParameter("@weigh4_10kgcode", MySqlDbType.Int32,11),
					new MySqlParameter("@weigh4_resolution", MySqlDbType.Double),
					new MySqlParameter("@pumpspeedchange", MySqlDbType.Int32,11)};
            parameters[0].Value = model.weigh1_0kgcode;
            parameters[1].Value = model.weigh1_5kgcode;
            parameters[2].Value = model.weigh1_10kgcode;
            parameters[3].Value = model.weigh1_resolution;
            parameters[4].Value = model.weigh2_0kgcode;
            parameters[5].Value = model.weigh2_5kgcode;
            parameters[6].Value = model.weigh2_10kgcode;
            parameters[7].Value = model.weigh2_resolution;
            parameters[8].Value = model.weigh3_0kgcode;
            parameters[9].Value = model.weigh3_5kgcode;
            parameters[10].Value = model.weigh3_10kgcode;
            parameters[11].Value = model.weigh3_resolution;
            parameters[12].Value = model.weigh4_0kgcode;
            parameters[13].Value = model.weigh4_5kgcode;
            parameters[14].Value = model.weigh4_10kgcode;
            parameters[15].Value = model.weigh4_resolution;
            parameters[16].Value = model.pumpspeedchange;

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
        public bool Update(ALS.Model.calibrateweigh model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_calibrateweigh set ");
            strSql.Append("weigh1_0kgcode=@weigh1_0kgcode,");
            strSql.Append("weigh1_5kgcode=@weigh1_5kgcode,");
            strSql.Append("weigh1_10kgcode=@weigh1_10kgcode,");
            strSql.Append("weigh1_resolution=@weigh1_resolution,");
            strSql.Append("weigh2_0kgcode=@weigh2_0kgcode,");
            strSql.Append("weigh2_5kgcode=@weigh2_5kgcode,");
            strSql.Append("weigh2_10kgcode=@weigh2_10kgcode,");
            strSql.Append("weigh2_resolution=@weigh2_resolution,");
            strSql.Append("weigh3_0kgcode=@weigh3_0kgcode,");
            strSql.Append("weigh3_5kgcode=@weigh3_5kgcode,");
            strSql.Append("weigh3_10kgcode=@weigh3_10kgcode,");
            strSql.Append("weigh3_resolution=@weigh3_resolution,");
            strSql.Append("weigh4_0kgcode=@weigh4_0kgcode,");
            strSql.Append("weigh4_5kgcode=@weigh4_5kgcode,");
            strSql.Append("weigh4_10kgcode=@weigh4_10kgcode,");
            strSql.Append("weigh4_resolution=@weigh4_resolution,");
            strSql.Append("pumpspeedchange=@pumpspeedchange");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@weigh1_0kgcode", MySqlDbType.Int32,11),
					new MySqlParameter("@weigh1_5kgcode", MySqlDbType.Int32,11),
					new MySqlParameter("@weigh1_10kgcode", MySqlDbType.Int32,11),
					new MySqlParameter("@weigh1_resolution", MySqlDbType.Double),
					new MySqlParameter("@weigh2_0kgcode", MySqlDbType.Int32,11),
					new MySqlParameter("@weigh2_5kgcode", MySqlDbType.Int32,11),
					new MySqlParameter("@weigh2_10kgcode", MySqlDbType.Int32,11),
					new MySqlParameter("@weigh2_resolution", MySqlDbType.Double),
					new MySqlParameter("@weigh3_0kgcode", MySqlDbType.Int32,11),
					new MySqlParameter("@weigh3_5kgcode", MySqlDbType.Int32,11),
					new MySqlParameter("@weigh3_10kgcode", MySqlDbType.Int32,11),
					new MySqlParameter("@weigh3_resolution", MySqlDbType.Double),
					new MySqlParameter("@weigh4_0kgcode", MySqlDbType.Int32,11),
					new MySqlParameter("@weigh4_5kgcode", MySqlDbType.Int32,11),
					new MySqlParameter("@weigh4_10kgcode", MySqlDbType.Int32,11),
					new MySqlParameter("@weigh4_resolution", MySqlDbType.Double),
					new MySqlParameter("@pumpspeedchange", MySqlDbType.Int32,11),
					new MySqlParameter("@ID", MySqlDbType.Int32,10)};
            parameters[0].Value = model.weigh1_0kgcode;
            parameters[1].Value = model.weigh1_5kgcode;
            parameters[2].Value = model.weigh1_10kgcode;
            parameters[3].Value = model.weigh1_resolution;
            parameters[4].Value = model.weigh2_0kgcode;
            parameters[5].Value = model.weigh2_5kgcode;
            parameters[6].Value = model.weigh2_10kgcode;
            parameters[7].Value = model.weigh2_resolution;
            parameters[8].Value = model.weigh3_0kgcode;
            parameters[9].Value = model.weigh3_5kgcode;
            parameters[10].Value = model.weigh3_10kgcode;
            parameters[11].Value = model.weigh3_resolution;
            parameters[12].Value = model.weigh4_0kgcode;
            parameters[13].Value = model.weigh4_5kgcode;
            parameters[14].Value = model.weigh4_10kgcode;
            parameters[15].Value = model.weigh4_resolution;
            parameters[16].Value = model.pumpspeedchange;
            parameters[17].Value = model.ID;

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
            strSql.Append("delete from tb_calibrateweigh ");
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
            strSql.Append("delete from tb_calibrateweigh ");
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
        public ALS.Model.calibrateweigh GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,weigh1_0kgcode,weigh1_5kgcode,weigh1_10kgcode,weigh1_resolution,weigh2_0kgcode,weigh2_5kgcode,weigh2_10kgcode,weigh2_resolution,weigh3_0kgcode,weigh3_5kgcode,weigh3_10kgcode,weigh3_resolution,weigh4_0kgcode,weigh4_5kgcode,weigh4_10kgcode,weigh4_resolution,pumpspeedchange from tb_calibrateweigh ");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
            parameters[0].Value = ID;

            ALS.Model.calibrateweigh model = new ALS.Model.calibrateweigh();
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
        public ALS.Model.calibrateweigh DataRowToModel(DataRow row)
        {
            ALS.Model.calibrateweigh model = new ALS.Model.calibrateweigh();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["weigh1_0kgcode"] != null && row["weigh1_0kgcode"].ToString() != "")
                {
                    model.weigh1_0kgcode = int.Parse(row["weigh1_0kgcode"].ToString());
                }
                if (row["weigh1_5kgcode"] != null && row["weigh1_5kgcode"].ToString() != "")
                {
                    model.weigh1_5kgcode = int.Parse(row["weigh1_5kgcode"].ToString());
                }
                if (row["weigh1_10kgcode"] != null && row["weigh1_10kgcode"].ToString() != "")
                {
                    model.weigh1_10kgcode = int.Parse(row["weigh1_10kgcode"].ToString());
                }
                model.weigh1_resolution=double.Parse( row["weigh1_resolution"].ToString());
                if (row["weigh2_0kgcode"] != null && row["weigh2_0kgcode"].ToString() != "")
                {
                    model.weigh2_0kgcode = int.Parse(row["weigh2_0kgcode"].ToString());
                }
                if (row["weigh2_5kgcode"] != null && row["weigh2_5kgcode"].ToString() != "")
                {
                    model.weigh2_5kgcode = int.Parse(row["weigh2_5kgcode"].ToString());
                }
                if (row["weigh2_10kgcode"] != null && row["weigh2_10kgcode"].ToString() != "")
                {
                    model.weigh2_10kgcode = int.Parse(row["weigh2_10kgcode"].ToString());
                }
                model.weigh2_resolution= double.Parse(row["weigh2_resolution"].ToString());
                if (row["weigh3_0kgcode"] != null && row["weigh3_0kgcode"].ToString() != "")
                {
                    model.weigh3_0kgcode = int.Parse(row["weigh3_0kgcode"].ToString());
                }
                if (row["weigh3_5kgcode"] != null && row["weigh3_5kgcode"].ToString() != "")
                {
                    model.weigh3_5kgcode = int.Parse(row["weigh3_5kgcode"].ToString());
                }
                if (row["weigh3_10kgcode"] != null && row["weigh3_10kgcode"].ToString() != "")
                {
                    model.weigh3_10kgcode = int.Parse(row["weigh3_10kgcode"].ToString());
                }
                 model.weigh3_resolution=double.Parse(row["weigh3_resolution"].ToString());
                if (row["weigh4_0kgcode"] != null && row["weigh4_0kgcode"].ToString() != "")
                {
                    model.weigh4_0kgcode = int.Parse(row["weigh4_0kgcode"].ToString());
                }
                if (row["weigh4_5kgcode"] != null && row["weigh4_5kgcode"].ToString() != "")
                {
                    model.weigh4_5kgcode = int.Parse(row["weigh4_5kgcode"].ToString());
                }
                if (row["weigh4_10kgcode"] != null && row["weigh4_10kgcode"].ToString() != "")
                {
                    model.weigh4_10kgcode = int.Parse(row["weigh4_10kgcode"].ToString());
                }
                model.weigh4_resolution=double.Parse(row["weigh4_resolution"].ToString());
                if (row["pumpspeedchange"] != null && row["pumpspeedchange"].ToString() != "")
                {
                    model.pumpspeedchange = int.Parse(row["pumpspeedchange"].ToString());
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
            strSql.Append("select ID,weigh1_0kgcode,weigh1_5kgcode,weigh1_10kgcode,weigh1_resolution,weigh2_0kgcode,weigh2_5kgcode,weigh2_10kgcode,weigh2_resolution,weigh3_0kgcode,weigh3_5kgcode,weigh3_10kgcode,weigh3_resolution,weigh4_0kgcode,weigh4_5kgcode,weigh4_10kgcode,weigh4_resolution,pumpspeedchange ");
            strSql.Append(" FROM tb_calibrateweigh ");
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
            strSql.Append("select count(1) FROM tb_calibrateweigh ");
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
            strSql.Append(")AS Row, T.*  from tb_calibrateweigh T ");
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
            parameters[0].Value = "tb_calibrateweigh";
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

