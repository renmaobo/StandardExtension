// ============================================================
// Copyright (C) 2022 RenMaoBo All Rights Reserved.
// FileName:    	Integer64Extension
// Version:       	$V1.0.0.0
// Create By:   	maobo
// Email:           renmaobo@outlook.com
// Create Time:  	2022/9/19 下午10:52
//
// Description:
//
// ============================================================
// Modify Mark
// Modify Time:  2022/9/19 下午10:52
// Modify By:    maobo
// Version:      V1.0.0.0
// Description:
//
// ============================================================
using System;
namespace System
{
    /// <summary>
    /// 长整型扩展
    /// </summary>
    public static class LongExtension
    {
        /// <summary>
        /// 转换为时间
        /// </summary>
        /// <param name="timetamp">时间戳</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this long timetamp)
        {
            DateTime initTime = new DateTime(1970, 1, 1, 0, 0, 0, kind: DateTimeKind.Local);
            TimeSpan timeSpan = new TimeSpan(timetamp);
            return initTime.Add(timeSpan);
        }
    }
}

