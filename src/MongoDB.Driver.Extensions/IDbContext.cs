// ============================================================
// Copyright (C) 2022 RenMaoBo All Rights Reserved.
// FileName:    	IDbContext
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
namespace MongoDB.Driver
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// 数据集合
        /// </summary>
        /// <typeparam name="TEntity"><para>TEntity</para> 数据类型</typeparam>
        /// <returns></returns>
        public DbCollection<TEntity> Collection<TEntity>() where TEntity : class;
    }
}

