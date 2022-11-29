// ============================================================
// Copyright (C) 2022 RenMaoBo All Rights Reserved.
// FileName:    	HttpRequestEnum
// Version:       	$V1.0.0.0
// Create By:   	maobo
// Email:           renmaobo@outlook.com
// Create Time:  	2022/9/20 下午11:21
//
// Description:
//
// ============================================================
// Modify Mark
// Modify Time:  2022/9/20 下午11:21
// Modify By:    maobo
// Version:      V1.0.0.0
// Description:
//
// ============================================================
using System;
namespace System.Net
{
    /// <summary>
    /// http请求类型枚举
    /// </summary>
    public enum HttpRequestType
    {
        /// <summary>
        /// get获取请求
        /// </summary>
        HttpGet = 10,
        /// <summary>
        /// post请求
        /// </summary>
        HttpPost = 20,
        /// <summary>
        /// 删除请求
        /// </summary>
        HttpDelete = 21,
        /// <summary>
        /// 修改请求
        /// </summary>
        HttpPut = 22,
    }
}

