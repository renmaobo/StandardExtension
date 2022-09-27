// ============================================================
// Copyright (C) 2022 RenMaoBo All Rights Reserved.
// FileName:    	MongoServiceExtension
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
using System;
using Microsoft.Extensions.DependencyInjection;

namespace MongoDB.Driver
{
    /// <summary>
    /// mongo服务扩展
    /// </summary>
    public static class MongoServiceExtension
    {
        /// <summary>
        /// 设置mongo环境服务
        /// </summary>
        /// <param name="serviceCollection">服务集合</param>
        /// <param name="options">选择项</param>
        public static void AddMongoContext(this IServiceCollection serviceCollection, Action<MongoBuilder> options)
        {
            var build = new MongoBuilder(serviceCollection);
            options(build);
        }
    }
}

