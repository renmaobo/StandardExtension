// ============================================================
// Copyright (C) 2022 RenMaoBo All Rights Reserved.
// FileName:    	JsonExtension
// Version:       	$V1.0.0.0
// Create By:   	maobo
// Email:           renmaobo@outlook.com
// Create Time:  	2022/9/20 下午11:06
//
// Description:
//
// ============================================================
// Modify Mark
// Modify Time:  2022/9/20 下午11:06
// Modify By:    maobo
// Version:      V1.0.0.0
// Description:
//
// ============================================================
using System;

namespace Newtonsoft.Json
{
    /// <summary>
    /// json转换器扩展
    /// </summary>
    public static class JsonConvertExtension
    {
        /// <summary>
        /// 转换为指定类型对象
        /// </summary>
        /// <typeparam name="T"><typeparamref name="T"/></typeparam>
        /// <param name="jsonStr">json字符串</param>
        /// <returns><typeparamref name="T"/></returns>
        public static T DeserializeObject<T>(this string jsonStr) => JsonConvert.DeserializeObject<T>(jsonStr);

        /// <summary>
        /// 转换为json字符串
        /// </summary>
        /// <typeparam name="T"><typeparamref name="T"/></typeparam>
        /// <param name="tinput">待序列化对象</param>
        /// <returns>json字符串</returns>
        public static string SerializeObject<T>(this T tinput) => JsonConvert.SerializeObject(tinput);
    }
}

