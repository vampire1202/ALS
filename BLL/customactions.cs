using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ALS.Model;
namespace ALS.BLL
{
	/// <summary>
	/// customactions
	/// </summary>
	public partial class customactions
	{
        private readonly ALS.DAL.customactions dal = new ALS.DAL.customactions();
		public customactions()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(ALS.Model.customactions model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(ALS.Model.customactions model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(IDlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public ALS.Model.customactions GetModel(long timeCount, string methodName)
		{			
			return dal.GetModel(timeCount,methodName);
		}

        public ALS.Model.customactions GetModelOfMaxID(string _methodName)
        {
            return dal.GetModelOfMaxID(_methodName);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ALS.Model.customactions GetModel(long ID)
        {
            return dal.GetModel(ID);
        }

        public ALS.Model.customactions GetModel(string method, string actionName)
        {
            return dal.GetModel(method,actionName);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public ALS.Model.customactions GetModelByCache(long ID)
		{
			
			string CacheKey = "customactionsModel-" + ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (ALS.Model.customactions)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere,bool bview)
		{
			return dal.GetList(strWhere,bview);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<ALS.Model.customactions> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere,false);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<ALS.Model.customactions> DataTableToList(DataTable dt)
		{
            List<ALS.Model.customactions> modelList = new List<ALS.Model.customactions>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                ALS.Model.customactions model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("",true);
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

