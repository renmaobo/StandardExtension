// ============================================================
// Copyright (C) 2022 RenMaoBo All Rights Reserved.
// FileName:    	ByteExtension
// Version:       	$V1.0.0.0
// Create By:   	maobo
// Email:           renmaobo@outlook.com
// Create Time:  	2022/9/20 下午10:36
//
// Description:
//
// ============================================================
// Modify Mark
// Modify Time:  2022/9/20 下午10:36
// Modify By:    maobo
// Version:      V1.0.0.0
// Description:
//
// ============================================================
using System;
using System.Text;

namespace System
{
    /// <summary>
    /// 字节扩展
    /// </summary>
    public static class ByteExtension
    {
        /// <summary>
        /// 转换为字符串
        /// </summary>
        /// <param name="bytes">待转换字节数组</param>
        /// <param name="encoding">编码格式</param>
        /// <returns></returns>
        public static string GetString(this byte[] bytes, Encoding encoding) => encoding.GetString(bytes);
    }
}

