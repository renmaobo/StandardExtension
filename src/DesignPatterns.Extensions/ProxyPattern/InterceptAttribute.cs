// ============================================================
// Copyright (C) 2022 RenMaoBo All Rights Reserved.
// FileName:    	InterceptAttribute
// Version:       	$V1.0.0.0
// Create By:   	maobo
// Email:           renmaobo@outlook.com
// Create Time:  	2022/9/26 下午10:20
//
// Description:
//
// ============================================================
// Modify Mark
// Modify Time:  2022/9/26 下午10:20
// Modify By:    maobo
// Version:      V1.0.0.0
// Description:
//
// ============================================================
using System;
namespace DesignPatterns.Extensions.ProxyPattern
{
    /// <summary>
    /// 拦截特性
    /// </summary>
    public class InterceptAttribute : Attribute
    {
        /// <summary>
        /// 执行前拦截
        /// </summary>
        public virtual void Executing() { }

        /// <summary>
        /// 执行后拦截
        /// </summary>
        public virtual void Executed() { }
    }
}

