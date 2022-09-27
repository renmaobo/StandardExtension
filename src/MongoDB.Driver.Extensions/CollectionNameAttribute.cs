// ============================================================
// Copyright (C) 2022 RenMaoBo All Rights Reserved.
// FileName:    	CollectionNameAttribute
// Version:       	$V1.0.0.0
// Create By:   	maobo
// Email:           renmaobo@outlook.com
// Create Time:  	2022/9/27 下午9:24
//
// Description:
//
// ============================================================
// Modify Mark
// Modify Time:  2022/9/27 下午9:24
// Modify By:    maobo
// Version:      V1.0.0.0
// Description:
//
// ============================================================
using System;
namespace MongoDB.Driver
{
    /// <summary>
    /// 文档集合名称特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class CollectionNameAttribute : Attribute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">文档名称</param>
        /// <param name="describe">描述</param>
        public CollectionNameAttribute(string name, string describe = default)
        {
            this.Name = name;
            this.Describe = describe;
        }

        /// <summary>
        /// 文档名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }
    }
}

