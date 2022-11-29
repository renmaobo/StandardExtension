// ============================================================
// Copyright (C) 2022 RenMaoBo All Rights Reserved.
// FileName:    	IntegerExtension
// Version:       	$V1.0.0.0
// Create By:   	maobo
// Email:           renmaobo@outlook.com
// Create Time:  	2022/9/19 下午10:43
//
// Description:
//
// ============================================================
// Modify Mark
// Modify Time:  2022/9/19 下午10:43
// Modify By:    maobo
// Version:      V1.0.0.0
// Description:
//
// ============================================================
using System;
namespace System
{
    /// <summary>
    /// 整型扩展(integer32)
    /// </summary>
    public static class IntegerExtension
    {
        /// <summary>
        /// 转换为整型
        /// </summary>
        /// <param name="value">待转换值</param>
        /// <returns></returns>
        public static bool ToBoolean(this int value) => value == 0 ? false : true;
    }
}

