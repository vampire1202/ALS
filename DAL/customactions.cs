using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ALS.DAL
{
	/// <summary>
	/// 数据访问类:customactions
	/// </summary>
	public partial class customactions
	{
		public customactions()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_customactions");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
			parameters[0].Value = ID;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(ALS.Model.customactions model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_customactions(");
			strSql.Append("methodName,timeCount,actionName,timeString,timeSpan,timeSpanString,tipPic)");
			strSql.Append(" values (");
			strSql.Append("@methodName,@timeCount,@actionName,@timeString,@timeSpan,@timeSpanString,tipPic)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@methodName", MySqlDbType.VarChar,255),
					new MySqlParameter("@timeCount", MySqlDbType.Int32,11),
					new MySqlParameter("@actionName", MySqlDbType.VarChar,255),
                    new MySqlParameter("@timeString", MySqlDbType.VarChar,255),
                    new MySqlParameter("@timeSpan", MySqlDbType.Int32,11),
                    new MySqlParameter("@timeSpanString", MySqlDbType.VarChar,255),
                    new MySqlParameter("@tipPic",MySqlDbType.LongBlob)
                                          };
			parameters[0].Value = model.methodName;
			parameters[1].Value = model.timeCount;
			parameters[2].Value = model.actionName;
            parameters[3].Value = model.timeString;
            parameters[4].Value = model.timeSpan;
            parameters[5].Value = model.timeSpanString;
            parameters[6].Value = model.tipPic;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
        public bool Update(ALS.Model.customactions model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_customactions set ");
			strSql.Append("methodName=@methodName,");
			strSql.Append("timeCount=@timeCount,");
			strSql.Append("actionName=@actionName,");
            strSql.Append("timeString = @timeString,");
            strSql.Append("timeSpan = @timeSpan,");
            strSql.Append("timeSpanString=@timeSpanString,");
            strSql.Append("tipPic = @tipPic");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@methodName", MySqlDbType.VarChar,255),
					new MySqlParameter("@timeCount", MySqlDbType.Int32,11),
					new MySqlParameter("@actionName", MySqlDbType.VarChar,255),
                    new MySqlParameter("@timeString", MySqlDbType.VarChar,255),
                    new MySqlParameter("@timeSpan", MySqlDbType.Int32,11),
                    new MySqlParameter("@timeSpanString", MySqlDbType.VarChar,255),
                    new MySqlParameter("@tipPic",MySqlDbType.LongBlob),
					new MySqlParameter("@ID", MySqlDbType.Int32,11)
                                          };
			parameters[0].Value = model.methodName;
			parameters[1].Value = model.timeCount;
			parameters[2].Value = model.actionName;
            parameters[3].Value = model.timeString;
            parameters[4].Value = model.timeSpan;
			parameters[5].Value = model.timeSpanString;
            parameters[6].Value = model.tipPic;
            parameters[7].Value = model.ID;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_customactions ");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
			parameters[0].Value = ID;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_customactions ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
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
        public ALS.Model.customactions GetModelOfMaxID(string _methodName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(ID) from tb_customactions ");
            strSql.Append("where methodName='" + _methodName + "'");
            DataSet ds = DbHelperMySQL.Query(strSql.ToString());
            int ID=0; 
            if(!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["max(ID)"].ToString()))
               ID =Convert.ToInt32( ds.Tables[0].Rows[0]["max(ID)"].ToString());
            ALS.Model.customactions model = GetModel(ID);
            if (model !=null)
            {
                return model;
            }
            else
            {
                return null;
            }
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public ALS.Model.customactions GetModel(long timeCount, string methodName)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,methodName,timeCount,actionName,timeString,timeSpan,timeSpanString,tipPic from tb_customactions ");
            strSql.Append(" where timeCount=@timeCount and methodName=@methodName");
			MySqlParameter[] parameters = {
					new MySqlParameter("@timeCount", MySqlDbType.Int32),
                    new MySqlParameter("@methodName", MySqlDbType.VarChar)

			};
            parameters[0].Value = timeCount;
            parameters[1].Value = methodName;

            ALS.Model.customactions model = new ALS.Model.customactions();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
        public ALS.Model.customactions GetModel(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,methodName,timeCount,actionName,timeString,timeSpan,timeSpanString,tipPic from tb_customactions ");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
            parameters[0].Value = ID;

            ALS.Model.customactions model = new ALS.Model.customactions();
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

        public ALS.Model.customactions GetModel(string methodName, string actionName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,methodName,timeCount,actionName,timeString,timeSpan,timeSpanString,tipPic from tb_customactions ");
            strSql.Append(" where actionName=@actionName and methodName=@methodName  ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@actionName", MySqlDbType.VarChar),
                    new MySqlParameter("@methodName", MySqlDbType.VarChar)
			};
            parameters[0].Value = actionName;
            parameters[1].Value = methodName;
            ALS.Model.customactions model = new ALS.Model.customactions();
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
        public ALS.Model.customactions DataRowToModel(DataRow row)
		{
            ALS.Model.customactions model = new ALS.Model.customactions();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=long.Parse(row["ID"].ToString());
				}
				if(row["methodName"]!=null)
				{
					model.methodName=row["methodName"].ToString();
				}
				if(row["timeCount"]!=null && row["timeCount"].ToString()!="")
				{
					model.timeCount=int.Parse(row["timeCount"].ToString());
				}
                if (row["timeSpan"] != null && row["timeSpan"].ToString() != "")
                {
                    model.timeSpan = int.Parse(row["timeSpan"].ToString());
                }
				if(row["actionName"]!=null)
				{
					model.actionName=row["actionName"].ToString();
				}
                if (row["timeString"] != null)
                {
                    model.timeString = row["timeString"].ToString();
                }
                if (row["timeSpanString"] != null)
                {
                    model.timeString = row["timeSpanString"].ToString();
                }
                if (row["tipPic"] != null && row["tipPic"].ToString() != "")
                {
                    model.tipPic = (byte[])row["tipPic"]; 
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
                strSql.Append("select ID, actionName as '描述',timeSpan ");
            else
                strSql.Append("select ID, methodName ,actionName, timeString,timeCount,timeSpan,timeSpanString,tipPic ");

            strSql.Append(" FROM tb_customactions ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
                strSql.Append(" order by ID asc");//升序
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }


		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM tb_customactions ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_customactions T ");
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
			parameters[0].Value = "tb_customactions";
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

