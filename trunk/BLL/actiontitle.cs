﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ALS.Model;
namespace ALS.BLL
{
    /// <summary>
    /// actiontitle
    /// </summary>
    public partial class actiontitle
    {
        private readonly ALS.DAL.actiontitle dal = new ALS.DAL.actiontitle();
        public actiontitle()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ALS.Model.actiontitle model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ALS.Model.actiontitle model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(IDlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ALS.Model.actiontitle GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ALS.Model.actiontitle GetModel(string title, string method)
        {

            return dal.GetModel(title,method);
        }


        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public ALS.Model.actiontitle GetModelByCache(int ID)
        {

            string CacheKey = "actiontitleModel-" + ID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = (object)dal.GetModel(ID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (ALS.Model.actiontitle)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ALS.Model.actiontitle> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ALS.Model.actiontitle> DataTableToList(DataTable dt)
        {
            List<ALS.Model.actiontitle> modelList = new List<ALS.Model.actiontitle>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ALS.Model.actiontitle model = null;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = (ALS.Model.actiontitle)dal.DataRowToModel(dt.Rows[n]);
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
            return GetList("");
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
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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

