using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ALS.Model;
namespace ALS.BLL
{
    /// <summary>
    /// pressure_data
    /// </summary>
    public partial class pressure_data
    {
        private readonly ALS.DAL.pressure_data dal = new ALS.DAL.pressure_data();
        public pressure_data()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string surgery_no, string time_stamp, string in_blood_pressure, string plasma_inlet_pressure, string arterial_pressure, string venous_pressure, string plasma_pressure, string transmembrane_pressure, string plasma2_pressure)
        {
            return dal.Exists(surgery_no, time_stamp, in_blood_pressure, plasma_inlet_pressure, arterial_pressure, venous_pressure, plasma_pressure, transmembrane_pressure, plasma2_pressure);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ALS.Model.pressure_data model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ALS.Model.pressure_data model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string surgery_no, string time_stamp, string in_blood_pressure, string plasma_inlet_pressure, string arterial_pressure, string venous_pressure, string plasma_pressure, string transmembrane_pressure, string plasma2_pressure)
        {

            return dal.Delete(surgery_no, time_stamp, in_blood_pressure, plasma_inlet_pressure, arterial_pressure, venous_pressure, plasma_pressure, transmembrane_pressure, plasma2_pressure);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ALS.Model.pressure_data GetModel(string surgery_no, string time_stamp, string in_blood_pressure, string plasma_inlet_pressure, string arterial_pressure, string venous_pressure, string plasma_pressure, string transmembrane_pressure, string plasma2_pressure)
        {

            return dal.GetModel(surgery_no, time_stamp, in_blood_pressure, plasma_inlet_pressure, arterial_pressure, venous_pressure, plasma_pressure, transmembrane_pressure, plasma2_pressure);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public ALS.Model.pressure_data GetModelByCache(string surgery_no, string time_stamp, string in_blood_pressure, string plasma_inlet_pressure, string arterial_pressure, string venous_pressure, string plasma_pressure, string transmembrane_pressure, string plasma2_pressure)
        {

            string CacheKey = "pressure_dataModel-" + surgery_no + time_stamp + in_blood_pressure + plasma_inlet_pressure + arterial_pressure + venous_pressure + plasma_pressure + transmembrane_pressure + plasma2_pressure;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(surgery_no, time_stamp, in_blood_pressure, plasma_inlet_pressure, arterial_pressure, venous_pressure, plasma_pressure, transmembrane_pressure, plasma2_pressure);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (ALS.Model.pressure_data)objModel;
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
        public List<ALS.Model.pressure_data> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ALS.Model.pressure_data> DataTableToList(DataTable dt)
        {
            List<ALS.Model.pressure_data> modelList = new List<ALS.Model.pressure_data>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ALS.Model.pressure_data model;
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

