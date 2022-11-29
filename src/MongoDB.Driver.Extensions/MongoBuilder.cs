// ============================================================
// Copyright (C) 2022 RenMaoBo All Rights Reserved.
// FileName:    	MongoBuilder
// Version:       	$V1.0.0.0
// Create By:   	maobo
// Email:           renmaobo@outlook.com
// Create Time:  	2022/9/27 下午9:23
//
// Description:
//
// ============================================================
// Modify Mark
// Modify Time:  2022/9/27 下午9:23
// Modify By:    maobo
// Version:      V1.0.0.0
// Description:
//
// ============================================================
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MongoDB.Driver
{
    /// <summary>
    /// mongo建造器
    /// </summary>
    public class MongoBuilder
    {
        /// <summary>
        /// 服务集合
        /// </summary>
        public IServiceCollection ServiceCollection { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serviceCollection">服务集合</param>
        public MongoBuilder(IServiceCollection serviceCollection)
        {
            this.ServiceCollection = serviceCollection;
        }

        /// <summary>
        /// 使用mongo构造器
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        public void UseMongoContext<TDbContext>(string connectionString) where TDbContext : DbContext
        {
            this.ServiceCollection.AddSingleton(e =>
            {
                Type type = typeof(TDbContext);
                object context = Activator.CreateInstance(type, connectionString);

                return context as TDbContext;
            });
        }
    }
}

