// ============================================================
// Copyright (C) 2022 RenMaoBo All Rights Reserved.
// FileName:    	DbContext
// Version:       	$V1.0.0.0
// Create By:   	maobo
// Email:           renmaobo@outlook.com
// Create Time:  	2022/9/27 下午9:22
//
// Description:
//
// ============================================================
// Modify Mark
// Modify Time:  2022/9/27 下午9:22
// Modify By:    maobo
// Version:      V1.0.0.0
// Description:
//
// ============================================================
using System;
using System.Reflection;

namespace MongoDB.Driver
{
    /// <summary>
    /// Mongo database context
    /// </summary>
    public abstract class DbContext : IDbContext
    {
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DatabaseName { get; protected set; }

        /// <summary>
        /// mongo数据库连接地址
        /// </summary>
        public MongoUrl MongoUrl { get; protected set; }

        /// <summary>
        /// mongo客户端
        /// </summary>
        public MongoClient MongoClient { get; protected set; }

        /// <summary>
        /// mongo客户端配置
        /// </summary>
        public MongoClientSettings MongoClientSettings { get; protected set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public DbContext() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        public DbContext(string connectionString)
        {
            this.MongoUrl = new MongoUrl(connectionString);

            MongoClient = new MongoClient(this.MongoUrl);

            this.DatabaseName = this.MongoUrl.DatabaseName;

            this.InitDbCollection();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="url">mongo数据库连接地址</param>
        public DbContext(MongoUrl url)
        {
            this.MongoUrl = url;

            this.DatabaseName = this.MongoUrl.DatabaseName;

            MongoClient = new MongoClient(url);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="databaseName">数据库名称</param>
        /// <param name="mongoClientSettings">mongo客户端配置</param>
        public DbContext(string databaseName, MongoClientSettings mongoClientSettings)
        {
            this.MongoClientSettings = mongoClientSettings;
            this.DatabaseName = databaseName;
            MongoClient = new MongoClient(mongoClientSettings);
        }

        /// <summary>
        /// 文档集合
        /// </summary>
        /// <typeparam name="TEntity"><typeparamref name="TEntity"/></typeparam>
        /// <returns></returns>
        public DbCollection<TEntity> Collection<TEntity>() where TEntity : class
        {
            DbCollection<TEntity> collection = new DbCollection<TEntity>(this.MongoClient.Settings);

            return collection;
        }

        /// <summary>
        /// 文档集合
        /// </summary>
        /// <typeparam name="TEntity"><typeparamref name="TEntity"/></typeparam>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public DbCollection<TEntity> Collection<TEntity>(string collectionName) where TEntity : class
        {
            DbCollection<TEntity> collection = new DbCollection<TEntity>(this.MongoClient.Settings, this.DatabaseName, collectionName);

            return collection;

        }

        /// <summary>
        /// 初始化数据集合
        /// </summary>
        private void InitDbCollection()
        {
            var properties = this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            Type type = typeof(DbCollection<>);
            foreach (PropertyInfo property in properties)
            {
                Type propertyType = property.PropertyType;
                if (propertyType.Name.Contains("DbCollection"))
                {
                    object value = Activator.CreateInstance(propertyType);
                    var method = value.GetType().GetMethod("SetMongoClient");
                    method.Invoke(value, new object[] { this.MongoClient, this.DatabaseName });

                    property.SetValue(this, value);
                }
            }
        }
    }
}

