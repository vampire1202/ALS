using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ALS.DAL
{
    /// <summary>
    /// 数据访问类:warnrange
    /// </summary>
    public partial class warnrange
    {
        public warnrange()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_warnrange");
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
        public bool Add(ALS.Model.warnrange model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_warnrange(");
            strSql.Append("PaccUpperUpper,PaccUpperLower,PaccLowerUpper,PaccLowerLower,PartUpperUpper,PartUpperLower,PartLowerUpper,PartLowerLower,TMPUpperUpper,TMPUpperLower,TMPLowerUpper,TMPLowerLower,PvenUpperUpper,PvenUpperLower,PvenLowerUpper,PvenLowerLower,P1stUpperUpper,P1stUpperLower,P1stLowerUpper,P1stLowerLower,P2ndUpperUpper,P2ndUpperLower,P2ndLowerUpper,P2ndLowerLower,P3rdUpperUpper,P3rdUpperLower,P3rdLowerUpper,P3rdLowerLower)");
            strSql.Append(" values (");
            strSql.Append("@PaccUpperUpper,@PaccUpperLower,@PaccLowerUpper,@PaccLowerLower,@PartUpperUpper,@PartUpperLower,@PartLowerUpper,@PartLowerLower,@TMPUpperUpper,@TMPUpperLower,@TMPLowerUpper,@TMPLowerLower,@PvenUpperUpper,@PvenUpperLower,@PvenLowerUpper,@PvenLowerLower,@P1stUpperUpper,@P1stUpperLower,@P1stLowerUpper,@P1stLowerLower,@P2ndUpperUpper,@P2ndUpperLower,@P2ndLowerUpper,@P2ndLowerLower,@P3rdUpperUpper,@P3rdUpperLower,@P3rdLowerUpper,@P3rdLowerLower)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@PaccUpperUpper", MySqlDbType.Int32,10),
					new MySqlParameter("@PaccUpperLower", MySqlDbType.Int32,10),
					new MySqlParameter("@PaccLowerUpper", MySqlDbType.Int32,10),
					new MySqlParameter("@PaccLowerLower", MySqlDbType.Int32,10),
					new MySqlParameter("@PartUpperUpper", MySqlDbType.Int32,10),
					new MySqlParameter("@PartUpperLower", MySqlDbType.Int32,10),
					new MySqlParameter("@PartLowerUpper", MySqlDbType.Int32,10),
					new MySqlParameter("@PartLowerLower", MySqlDbType.Int32,10),
					new MySqlParameter("@TMPUpperUpper", MySqlDbType.Int32,10),
					new MySqlParameter("@TMPUpperLower", MySqlDbType.Int32,10),
					new MySqlParameter("@TMPLowerUpper", MySqlDbType.Int32,10),
					new MySqlParameter("@TMPLowerLower", MySqlDbType.Int32,10),
					new MySqlParameter("@PvenUpperUpper", MySqlDbType.Int32,10),
					new MySqlParameter("@PvenUpperLower", MySqlDbType.Int32,10),
					new MySqlParameter("@PvenLowerUpper", MySqlDbType.Int32,10),
					new MySqlParameter("@PvenLowerLower", MySqlDbType.Int32,10),
					new MySqlParameter("@P1stUpperUpper", MySqlDbType.Int32,10),
					new MySqlParameter("@P1stUpperLower", MySqlDbType.Int32,10),
					new MySqlParameter("@P1stLowerUpper", MySqlDbType.Int32,10),
					new MySqlParameter("@P1stLowerLower", MySqlDbType.Int32,10),
					new MySqlParameter("@P2ndUpperUpper", MySqlDbType.Int32,10),
					new MySqlParameter("@P2ndUpperLower", MySqlDbType.Int32,10),
					new MySqlParameter("@P2ndLowerUpper", MySqlDbType.Int32,10),
					new MySqlParameter("@P2ndLowerLower", MySqlDbType.Int32,10),
					new MySqlParameter("@P3rdUpperUpper", MySqlDbType.Int32,10),
					new MySqlParameter("@P3rdUpperLower", MySqlDbType.Int32,10),
					new MySqlParameter("@P3rdLowerUpper", MySqlDbType.Int32,10),
					new MySqlParameter("@P3rdLowerLower", MySqlDbType.Int32,10)};
            parameters[0].Value = model.PaccUpperUpper;
            parameters[1].Value = model.PaccUpperLower;
            parameters[2].Value = model.PaccLowerUpper;
            parameters[3].Value = model.PaccLowerLower;
            parameters[4].Value = model.PartUpperUpper;
            parameters[5].Value = model.PartUpperLower;
            parameters[6].Value = model.PartLowerUpper;
            parameters[7].Value = model.PartLowerLower;
            parameters[8].Value = model.TMPUpperUpper;
            parameters[9].Value = model.TMPUpperLower;
            parameters[10].Value = model.TMPLowerUpper;
            parameters[11].Value = model.TMPLowerLower;
            parameters[12].Value = model.PvenUpperUpper;
            parameters[13].Value = model.PvenUpperLower;
            parameters[14].Value = model.PvenLowerUpper;
            parameters[15].Value = model.PvenLowerLower;
            parameters[16].Value = model.P1stUpperUpper;
            parameters[17].Value = model.P1stUpperLower;
            parameters[18].Value = model.P1stLowerUpper;
            parameters[19].Value = model.P1stLowerLower;
            parameters[20].Value = model.P2ndUpperUpper;
            parameters[21].Value = model.P2ndUpperLower;
            parameters[22].Value = model.P2ndLowerUpper;
            parameters[23].Value = model.P2ndLowerLower;
            parameters[24].Value = model.P3rdUpperUpper;
            parameters[25].Value = model.P3rdUpperLower;
            parameters[26].Value = model.P3rdLowerUpper;
            parameters[27].Value = model.P3rdLowerLower;

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
        public bool Update(ALS.Model.warnrange model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_warnrange set ");
            strSql.Append("PaccUpperUpper=@PaccUpperUpper,");
            strSql.Append("PaccUpperLower=@PaccUpperLower,");
            strSql.Append("PaccLowerUpper=@PaccLowerUpper,");
            strSql.Append("PaccLowerLower=@PaccLowerLower,");
            strSql.Append("PartUpperUpper=@PartUpperUpper,");
            strSql.Append("PartUpperLower=@PartUpperLower,");
            strSql.Append("PartLowerUpper=@PartLowerUpper,");
            strSql.Append("PartLowerLower=@PartLowerLower,");
            strSql.Append("TMPUpperUpper=@TMPUpperUpper,");
            strSql.Append("TMPUpperLower=@TMPUpperLower,");
            strSql.Append("TMPLowerUpper=@TMPLowerUpper,");
            strSql.Append("TMPLowerLower=@TMPLowerLower,");
            strSql.Append("PvenUpperUpper=@PvenUpperUpper,");
            strSql.Append("PvenUpperLower=@PvenUpperLower,");
            strSql.Append("PvenLowerUpper=@PvenLowerUpper,");
            strSql.Append("PvenLowerLower=@PvenLowerLower,");
            strSql.Append("P1stUpperUpper=@P1stUpperUpper,");
            strSql.Append("P1stUpperLower=@P1stUpperLower,");
            strSql.Append("P1stLowerUpper=@P1stLowerUpper,");
            strSql.Append("P1stLowerLower=@P1stLowerLower,");
            strSql.Append("P2ndUpperUpper=@P2ndUpperUpper,");
            strSql.Append("P2ndUpperLower=@P2ndUpperLower,");
            strSql.Append("P2ndLowerUpper=@P2ndLowerUpper,");
            strSql.Append("P2ndLowerLower=@P2ndLowerLower,");
            strSql.Append("P3rdUpperUpper=@P3rdUpperUpper,");
            strSql.Append("P3rdUpperLower=@P3rdUpperLower,");
            strSql.Append("P3rdLowerUpper=@P3rdLowerUpper,");
            strSql.Append("P3rdLowerLower=@P3rdLowerLower");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@PaccUpperUpper", MySqlDbType.Int32,10),
					new MySqlParameter("@PaccUpperLower", MySqlDbType.Int32,10),
					new MySqlParameter("@PaccLowerUpper", MySqlDbType.Int32,10),
					new MySqlParameter("@PaccLowerLower", MySqlDbType.Int32,10),
					new MySqlParameter("@PartUpperUpper", MySqlDbType.Int32,10),
					new MySqlParameter("@PartUpperLower", MySqlDbType.Int32,10),
					new MySqlParameter("@PartLowerUpper", MySqlDbType.Int32,10),
					new MySqlParameter("@PartLowerLower", MySqlDbType.Int32,10),
					new MySqlParameter("@TMPUpperUpper", MySqlDbType.Int32,10),
					new MySqlParameter("@TMPUpperLower", MySqlDbType.Int32,10),
					new MySqlParameter("@TMPLowerUpper", MySqlDbType.Int32,10),
					new MySqlParameter("@TMPLowerLower", MySqlDbType.Int32,10),
					new MySqlParameter("@PvenUpperUpper", MySqlDbType.Int32,10),
					new MySqlParameter("@PvenUpperLower", MySqlDbType.Int32,10),
					new MySqlParameter("@PvenLowerUpper", MySqlDbType.Int32,10),
					new MySqlParameter("@PvenLowerLower", MySqlDbType.Int32,10),
					new MySqlParameter("@P1stUpperUpper", MySqlDbType.Int32,10),
					new MySqlParameter("@P1stUpperLower", MySqlDbType.Int32,10),
					new MySqlParameter("@P1stLowerUpper", MySqlDbType.Int32,10),
					new MySqlParameter("@P1stLowerLower", MySqlDbType.Int32,10),
					new MySqlParameter("@P2ndUpperUpper", MySqlDbType.Int32,10),
					new MySqlParameter("@P2ndUpperLower", MySqlDbType.Int32,10),
					new MySqlParameter("@P2ndLowerUpper", MySqlDbType.Int32,10),
					new MySqlParameter("@P2ndLowerLower", MySqlDbType.Int32,10),
					new MySqlParameter("@P3rdUpperUpper", MySqlDbType.Int32,10),
					new MySqlParameter("@P3rdUpperLower", MySqlDbType.Int32,10),
					new MySqlParameter("@P3rdLowerUpper", MySqlDbType.Int32,10),
					new MySqlParameter("@P3rdLowerLower", MySqlDbType.Int32,10),
					new MySqlParameter("@ID", MySqlDbType.Int32,10)};
            parameters[0].Value = model.PaccUpperUpper;
            parameters[1].Value = model.PaccUpperLower;
            parameters[2].Value = model.PaccLowerUpper;
            parameters[3].Value = model.PaccLowerLower;
            parameters[4].Value = model.PartUpperUpper;
            parameters[5].Value = model.PartUpperLower;
            parameters[6].Value = model.PartLowerUpper;
            parameters[7].Value = model.PartLowerLower;
            parameters[8].Value = model.TMPUpperUpper;
            parameters[9].Value = model.TMPUpperLower;
            parameters[10].Value = model.TMPLowerUpper;
            parameters[11].Value = model.TMPLowerLower;
            parameters[12].Value = model.PvenUpperUpper;
            parameters[13].Value = model.PvenUpperLower;
            parameters[14].Value = model.PvenLowerUpper;
            parameters[15].Value = model.PvenLowerLower;
            parameters[16].Value = model.P1stUpperUpper;
            parameters[17].Value = model.P1stUpperLower;
            parameters[18].Value = model.P1stLowerUpper;
            parameters[19].Value = model.P1stLowerLower;
            parameters[20].Value = model.P2ndUpperUpper;
            parameters[21].Value = model.P2ndUpperLower;
            parameters[22].Value = model.P2ndLowerUpper;
            parameters[23].Value = model.P2ndLowerLower;
            parameters[24].Value = model.P3rdUpperUpper;
            parameters[25].Value = model.P3rdUpperLower;
            parameters[26].Value = model.P3rdLowerUpper;
            parameters[27].Value = model.P3rdLowerLower;
            parameters[28].Value = model.ID;

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
            strSql.Append("delete from tb_warnrange ");
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
            strSql.Append("delete from tb_warnrange ");
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
        public ALS.Model.warnrange GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,PaccUpperUpper,PaccUpperLower,PaccLowerUpper,PaccLowerLower,PartUpperUpper,PartUpperLower,PartLowerUpper,PartLowerLower,TMPUpperUpper,TMPUpperLower,TMPLowerUpper,TMPLowerLower,PvenUpperUpper,PvenUpperLower,PvenLowerUpper,PvenLowerLower,P1stUpperUpper,P1stUpperLower,P1stLowerUpper,P1stLowerLower,P2ndUpperUpper,P2ndUpperLower,P2ndLowerUpper,P2ndLowerLower,P3rdUpperUpper,P3rdUpperLower,P3rdLowerUpper,P3rdLowerLower from tb_warnrange ");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
            parameters[0].Value = ID;

            ALS.Model.warnrange model = new ALS.Model.warnrange();
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
        public ALS.Model.warnrange DataRowToModel(DataRow row)
        {
            ALS.Model.warnrange model = new ALS.Model.warnrange();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["PaccUpperUpper"] != null && row["PaccUpperUpper"].ToString() != "")
                {
                    model.PaccUpperUpper = int.Parse(row["PaccUpperUpper"].ToString());
                }
                if (row["PaccUpperLower"] != null && row["PaccUpperLower"].ToString() != "")
                {
                    model.PaccUpperLower = int.Parse(row["PaccUpperLower"].ToString());
                }
                if (row["PaccLowerUpper"] != null && row["PaccLowerUpper"].ToString() != "")
                {
                    model.PaccLowerUpper = int.Parse(row["PaccLowerUpper"].ToString());
                }
                if (row["PaccLowerLower"] != null && row["PaccLowerLower"].ToString() != "")
                {
                    model.PaccLowerLower = int.Parse(row["PaccLowerLower"].ToString());
                }
                if (row["PartUpperUpper"] != null && row["PartUpperUpper"].ToString() != "")
                {
                    model.PartUpperUpper = int.Parse(row["PartUpperUpper"].ToString());
                }
                if (row["PartUpperLower"] != null && row["PartUpperLower"].ToString() != "")
                {
                    model.PartUpperLower = int.Parse(row["PartUpperLower"].ToString());
                }
                if (row["PartLowerUpper"] != null && row["PartLowerUpper"].ToString() != "")
                {
                    model.PartLowerUpper = int.Parse(row["PartLowerUpper"].ToString());
                }
                if (row["PartLowerLower"] != null && row["PartLowerLower"].ToString() != "")
                {
                    model.PartLowerLower = int.Parse(row["PartLowerLower"].ToString());
                }
                if (row["TMPUpperUpper"] != null && row["TMPUpperUpper"].ToString() != "")
                {
                    model.TMPUpperUpper = int.Parse(row["TMPUpperUpper"].ToString());
                }
                if (row["TMPUpperLower"] != null && row["TMPUpperLower"].ToString() != "")
                {
                    model.TMPUpperLower = int.Parse(row["TMPUpperLower"].ToString());
                }
                if (row["TMPLowerUpper"] != null && row["TMPLowerUpper"].ToString() != "")
                {
                    model.TMPLowerUpper = int.Parse(row["TMPLowerUpper"].ToString());
                }
                if (row["TMPLowerLower"] != null && row["TMPLowerLower"].ToString() != "")
                {
                    model.TMPLowerLower = int.Parse(row["TMPLowerLower"].ToString());
                }
                if (row["PvenUpperUpper"] != null && row["PvenUpperUpper"].ToString() != "")
                {
                    model.PvenUpperUpper = int.Parse(row["PvenUpperUpper"].ToString());
                }
                if (row["PvenUpperLower"] != null && row["PvenUpperLower"].ToString() != "")
                {
                    model.PvenUpperLower = int.Parse(row["PvenUpperLower"].ToString());
                }
                if (row["PvenLowerUpper"] != null && row["PvenLowerUpper"].ToString() != "")
                {
                    model.PvenLowerUpper = int.Parse(row["PvenLowerUpper"].ToString());
                }
                if (row["PvenLowerLower"] != null && row["PvenLowerLower"].ToString() != "")
                {
                    model.PvenLowerLower = int.Parse(row["PvenLowerLower"].ToString());
                }
                if (row["P1stUpperUpper"] != null && row["P1stUpperUpper"].ToString() != "")
                {
                    model.P1stUpperUpper = int.Parse(row["P1stUpperUpper"].ToString());
                }
                if (row["P1stUpperLower"] != null && row["P1stUpperLower"].ToString() != "")
                {
                    model.P1stUpperLower = int.Parse(row["P1stUpperLower"].ToString());
                }
                if (row["P1stLowerUpper"] != null && row["P1stLowerUpper"].ToString() != "")
                {
                    model.P1stLowerUpper = int.Parse(row["P1stLowerUpper"].ToString());
                }
                if (row["P1stLowerLower"] != null && row["P1stLowerLower"].ToString() != "")
                {
                    model.P1stLowerLower = int.Parse(row["P1stLowerLower"].ToString());
                }
                if (row["P2ndUpperUpper"] != null && row["P2ndUpperUpper"].ToString() != "")
                {
                    model.P2ndUpperUpper = int.Parse(row["P2ndUpperUpper"].ToString());
                }
                if (row["P2ndUpperLower"] != null && row["P2ndUpperLower"].ToString() != "")
                {
                    model.P2ndUpperLower = int.Parse(row["P2ndUpperLower"].ToString());
                }
                if (row["P2ndLowerUpper"] != null && row["P2ndLowerUpper"].ToString() != "")
                {
                    model.P2ndLowerUpper = int.Parse(row["P2ndLowerUpper"].ToString());
                }
                if (row["P2ndLowerLower"] != null && row["P2ndLowerLower"].ToString() != "")
                {
                    model.P2ndLowerLower = int.Parse(row["P2ndLowerLower"].ToString());
                }
                if (row["P3rdUpperUpper"] != null && row["P3rdUpperUpper"].ToString() != "")
                {
                    model.P3rdUpperUpper = int.Parse(row["P3rdUpperUpper"].ToString());
                }
                if (row["P3rdUpperLower"] != null && row["P3rdUpperLower"].ToString() != "")
                {
                    model.P3rdUpperLower = int.Parse(row["P3rdUpperLower"].ToString());
                }
                if (row["P3rdLowerUpper"] != null && row["P3rdLowerUpper"].ToString() != "")
                {
                    model.P3rdLowerUpper = int.Parse(row["P3rdLowerUpper"].ToString());
                }
                if (row["P3rdLowerLower"] != null && row["P3rdLowerLower"].ToString() != "")
                {
                    model.P3rdLowerLower = int.Parse(row["P3rdLowerLower"].ToString());
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
            strSql.Append("select ID,PaccUpperUpper,PaccUpperLower,PaccLowerUpper,PaccLowerLower,PartUpperUpper,PartUpperLower,PartLowerUpper,PartLowerLower,TMPUpperUpper,TMPUpperLower,TMPLowerUpper,TMPLowerLower,PvenUpperUpper,PvenUpperLower,PvenLowerUpper,PvenLowerLower,P1stUpperUpper,P1stUpperLower,P1stLowerUpper,P1stLowerLower,P2ndUpperUpper,P2ndUpperLower,P2ndLowerUpper,P2ndLowerLower,P3rdUpperUpper,P3rdUpperLower,P3rdLowerUpper,P3rdLowerLower ");
            strSql.Append(" FROM tb_warnrange ");
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
            strSql.Append("select count(1) FROM tb_warnrange ");
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
            strSql.Append(")AS Row, T.*  from tb_warnrange T ");
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
            parameters[0].Value = "tb_warnrange";
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

