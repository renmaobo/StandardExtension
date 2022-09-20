// ============================================================
// Copyright (C) 2022 RenMaoBo All Rights Reserved.
// FileName:    	StringExtension
// Version:       	$V1.0.0.0
// Create By:   	maobo
// Email:           renmaobo@outlook.com
// Create Time:  	2022/9/20 下午10:10
//
// Description:
//
// ============================================================
// Modify Mark
// Modify Time:  2022/9/20 下午10:10
// Modify By:    maobo
// Version:      V1.0.0.0
// Description:
//
// ============================================================
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace System
{
    /// <summary>
    /// 字符串扩展
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// 空或空值
        /// </summary>
        /// <param name="value">待判定字符串</param>
        /// <returns>结果</returns>
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);

        /// <summary>
        /// 不会空或空值
        /// </summary>
        /// <param name="value">待判定字符串</param>
        /// <returns>结果</returns>
        public static bool IsNotNullOrEmpty(this string value) => !value.IsNullOrEmpty();

        /// <summary>
        /// 空或空白空间
        /// </summary>
        /// <param name="value">待判定字符串</param>
        /// <returns>结果</returns>
        public static bool IsNullOrWhiteSpace(this string value) => string.IsNullOrWhiteSpace(value);

        /// <summary>
        /// 转换成布尔值
        /// </summary>
        /// <param name="value">待转换字符串</param>
        /// <returns>布尔值结果</returns>
        public static bool ToBoolean(this string value) => !Regex.IsMatch(value, "(false)|0", RegexOptions.IgnoreCase);

        /// <summary>
        /// 转换为字节数组
        /// </summary>
        /// <param name="value">待转换字符串</param>
        /// <param name="encoding">编码类型</param>
        /// <returns>字节字符串</returns>
        public static byte[] ToBytes(this string value, Encoding encoding) => encoding.GetBytes(value);

        /// <summary>
        /// 转换为整型
        /// </summary>
        /// <param name="value">待转换值</param>
        /// <returns>转换结果</returns>
        public static int ToInt(this string value) => int.Parse(value);

        /// <summary>
        /// 转换为整型并判定是否转换成功
        /// </summary>
        /// <param name="value">待转换字符串</param>
        /// <param name="result">结果值</param>
        /// <returns>转换是否成功结果</returns>
        public static bool TryToInt(this string value, out int result) => int.TryParse(value, out result);

        /// <summary>
        /// 转换为长整型
        /// </summary>
        /// <param name="value">待转换字符串</param>
        /// <returns>转换结果</returns>
        public static long ToLong(this string value) => long.Parse(value);

        /// <summary>
        /// 转换为长整型并判定是否转换成功
        /// </summary>
        /// <param name="value">待转换字符串</param>
        /// <param name="result">结果值</param>
        /// <returns>转换是否成功结果</returns>
        public static bool TryToLong(this string value, out long result) => long.TryParse(value, out result);
    }
}

