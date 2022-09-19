// ============================================================
// Copyright (C) 2022 RenMaoBo All Rights Reserved.
// FileName:    	DateTimeExtension
// Version:       	$V1.0.0.0
// Create By:   	maobo
// Email:           renmaobo@outlook.com
// Create Time:  	2022/9/19 下午11:27
//
// Description:
//
// ============================================================
// Modify Mark
// Modify Time:  2022/9/19 下午11:27
// Modify By:    maobo
// Version:      V1.0.0.0
// Description:
//
// ============================================================
using System;
namespace System
{
    /// <summary>
    /// 时间扩展
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// 转换为时间戳
        /// </summary>
        /// <param name="currentTime">当前时间</param>
        /// <returns></returns>
        public static long ToTimestamp(this DateTime currentTime)
        {
            DateTime initTime = new DateTime(1970, 1, 1, 0, 0, 0, kind: DateTimeKind.Local);

            return currentTime.Ticks - initTime.Ticks;
        }

        /// <summary>
        /// 时间偏大
        /// </summary>
        /// <param name="sourceTime">实际值</param>
        /// <param name="comparisonValue">对比值</param>
        /// <param name="timeDefference">允许误差</param>
        /// <returns>true: 实际值大于对比值；false:实际值小于对比值</returns>
        public static bool DateTimeHuge(this DateTime sourceTime, DateTime comparisonValue, TimeSpan timeDefference = default)
        {
            long value = sourceTime.Ticks - comparisonValue.Add(timeDefference).Ticks;

            return value > 0 ? false : true;
        }


        /// <summary>
        /// 时间偏小
        /// </summary>
        /// <param name="sourceTime">实际值</param>
        /// <param name="comparisonValue">对比值</param>
        /// <param name="timeDefference">允许误差</param>
        /// <returns>false: 实际值大于对比值；true:实际值小于对比值</returns>
        public static bool DateTimeTiny(this DateTime sourceTime, DateTime comparisonValue, TimeSpan timeDefference = default)
        {
            long value = sourceTime.Ticks - comparisonValue.Add(timeDefference).Ticks;

            return value > 0 ? true : false;
        }
    }
}

