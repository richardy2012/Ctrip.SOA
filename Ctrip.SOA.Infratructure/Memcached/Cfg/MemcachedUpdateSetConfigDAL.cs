/******************************************************************
** 数据库HHCfgDB中表MemcachedUpdateSetConfig数据访问层操作类
** 此代码由工具自动生成
******************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using HHInfratructure.Data;

namespace HHInfratructure.Memcached.Cfg
{
    /// <summary>
    /// 缓存更新配置设置数据访问类
    /// </summary>
   public class MemcachedUpdateSetConfigDAL : DALContext
   {
        public MemcachedUpdateSetConfigDAL() : base(DBConsts.HHCfgDB_SELECT) { }

        /// <summary>
        /// 根据主键获取一个实体对象
        /// </summary>
        public MemcachedUpdateSetConfigEntity SelectKey(string CacheKeyPrefix)
        {
            DbCommand cmd = DB.DbProviderFactory.CreateCommand();
            cmd.CommandText = "select * from MemcachedUpdateSetConfig with(nolock) where CacheKeyPrefix=@CacheKeyPrefix";
            cmd.CommandType = System.Data.CommandType.Text;

            DB.AddInParameter(cmd, "CacheKeyPrefix", DbType.AnsiString, CacheKeyPrefix);
            DataSet ds = DB.ExecuteDataSet(cmd);
            if (ds.Tables[0].Rows.Count == 0) return null;

            DataRow dr = ds.Tables[0].Rows[0];
            return MemcachedUpdateSetConfigEntity.CreateEntity(dr);
        }

        /// <summary>
        /// 根据条件获取一个实体对象
        /// </summary>
        public MemcachedUpdateSetConfigEntity Select(string where)
        {
            DbCommand cmd = DB.DbProviderFactory.CreateCommand();
            cmd.CommandText = "select * from MemcachedUpdateSetConfig with(nolock) where " + where;
            cmd.CommandType = System.Data.CommandType.Text;

            DataSet ds = DB.ExecuteDataSet(cmd);
            if (ds.Tables[0].Rows.Count == 0) return null;

            DataRow dr = ds.Tables[0].Rows[0];
            return MemcachedUpdateSetConfigEntity.CreateEntity(dr);
        }

        /// <summary>
        /// 根据条件获取对应的记录集
        /// </summary>
        public DataTable SelectTable(string where)
        {
            DbCommand cmd = DB.DbProviderFactory.CreateCommand();
            cmd.CommandText = "select * from MemcachedUpdateSetConfig with(nolock) where " + where;
            cmd.CommandType = System.Data.CommandType.Text;

            DataSet ds = DB.ExecuteDataSet(cmd);
            if (ds.Tables[0].Rows.Count == 0) return null;

            return ds.Tables[0];
        }

        /// <summary>
        /// 根据指定字段、字段值、表达式，查询出符合条件的记录，并按照指定的排序方式返回记录集
        /// </summary>
        /// <param name="fields">字段集</param>
        /// <param name="values">字段对应的值</param>
        /// <param name="expressions">字段与值的表达式</param>
        /// <param name="orderby">排序字段，默认asc，需要desc直接含在排序字段中</param>
        /// <returns>符合条件的记录集</returns>
        public DataTable Select(List<string> fields, List<string> values, List<string> expressions, List<string> orderby)
        {
            DbCommand cmd = DB.DbProviderFactory.CreateCommand();
            cmd.CommandText = "select * from MemcachedUpdateSetConfig with(nolock) where ";
            cmd.CommandType = System.Data.CommandType.Text;

            for (int i = 0; i < fields.Count; i++)
            {
                cmd.CommandText += fields[i] + " " + expressions[i] + " @" + fields[i] + " & ";
                if (expressions[i].ToLower() != "like")
                    DB.AddInParameter(cmd, "@" + fields[i], DbType.Object, values[i]);
                else
                    DB.AddInParameter(cmd, "@" + fields[i], DbType.String, " % " + values[i] + " % ");
            }
            cmd.CommandText = cmd.CommandText.TrimEnd().TrimEnd('&').Replace("&", " and ");

            if (orderby != null && orderby.Count > 0)
            {
                cmd.CommandText += " order by ";
                for (int i = 0; i < orderby.Count; i++)
                {
                    cmd.CommandText += orderby[i] + ",";
                }
            }
            cmd.CommandText = cmd.CommandText.TrimEnd(',');

            return DB.ExecuteDataSet(cmd).Tables[0];
        }

        public bool Insert(MemcachedUpdateSetConfigEntity entity)
        {
            DbCommand cmd = DB.DbProviderFactory.CreateCommand();
            cmd.CommandText = "spA_MemcachedUpdateSetConfig_i";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            if (entity.CacheKeyPrefix != null) DB.AddInParameter(cmd, "@CacheKeyPrefix", DbType.AnsiString, entity.CacheKeyPrefix);
            DB.AddInParameter(cmd, "@UpdateHourSpan", DbType.Int32, entity.UpdateHourSpan);
            DB.AddInParameter(cmd, "@IsJobActByMin", DbType.Int32, entity.IsJobActByMin);
            DB.AddInParameter(cmd, "@FreMin", DbType.Int32, entity.FreMin);
            if (entity.DataChange_LastTime.Year != 1) DB.AddInParameter(cmd, "@DataChange_LastTime", DbType.DateTime, entity.DataChange_LastTime);
            bool b = (int)DB.ExecuteNonQuery(cmd) == 0 ? true : false;
            return b;
        }

        public bool Update(MemcachedUpdateSetConfigEntity entity)
        {
            DbCommand cmd = DB.DbProviderFactory.CreateCommand();
            cmd.CommandText = "spA_MemcachedUpdateSetConfig_u";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            if (entity.CacheKeyPrefix != null) DB.AddInParameter(cmd, "@CacheKeyPrefix", DbType.AnsiString, entity.CacheKeyPrefix);
            DB.AddInParameter(cmd, "@UpdateHourSpan", DbType.Int32, entity.UpdateHourSpan);
            DB.AddInParameter(cmd, "@IsJobActByMin", DbType.Int32, entity.IsJobActByMin);
            DB.AddInParameter(cmd, "@FreMin", DbType.Int32, entity.FreMin);
            if (entity.DataChange_LastTime.Year != 1) DB.AddInParameter(cmd, "@DataChange_LastTime", DbType.DateTime, entity.DataChange_LastTime);
            return DB.ExecuteNonQuery(cmd) == 0 ? true : false;
        }

        public bool Delete(string CacheKeyPrefix)
        {
            DbCommand cmd = DB.DbProviderFactory.CreateCommand();
            cmd.CommandText = "spA_MemcachedUpdateSetConfig_d";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            DB.AddInParameter(cmd, "@CacheKeyPrefix", DbType.AnsiString, CacheKeyPrefix);
            return DB.ExecuteNonQuery(cmd) == 0 ? true : false;
        }

        public List<MemcachedUpdateSetConfigEntity> GetAll()
        {
            DbCommand cmd = DB.DbProviderFactory.CreateCommand();
            cmd.CommandText = "select * from MemcachedUpdateSetConfig with(nolock)";
            cmd.CommandType = System.Data.CommandType.Text;

            DataSet ds = DB.ExecuteDataSet(cmd);

            List<MemcachedUpdateSetConfigEntity> list = new List<MemcachedUpdateSetConfigEntity>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                list.Add(MemcachedUpdateSetConfigEntity.CreateEntity(item));
            }
            return list;
        }
    }
}
