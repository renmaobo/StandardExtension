// ============================================================
// Copyright (C) 2022 RenMaoBo All Rights Reserved.
// FileName:    	PathExtension
// Version:       	$V1.0.0.0
// Create By:   	maobo
// Email:           renmaobo@outlook.com
// Create Time:  	2022/9/26 下午10:48
//
// Description:
//
// ============================================================
// Modify Mark
// Modify Time:  2022/9/26 下午10:48
// Modify By:    maobo
// Version:      V1.0.0.0
// Description:
//
// ============================================================
using System;
namespace System.IO
{
    /// <summary>
    /// 路径扩展
    /// </summary>
    public static class PathExtension
    {
        /// <summary>
        /// 获取完全路径
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static string GetFullPath(this string path) => Path.GetFullPath(path);

        /// <summary>
        /// 获取文件名称
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string GetFileName(this string path) => Path.GetFileName(path);

        /// <summary>
        /// 获取文件名称并不包含文件后缀名称
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string GetFileNameWithoutExtension(this string path) => Path.GetFileNameWithoutExtension(path);

        /// <summary>
        /// 获取文件后缀
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string GetExtension(this string path) => Path.GetExtension(path);

        /// <summary>
        /// 获取目录名称
        /// </summary>
        /// <param name="path">目录路径</param>
        /// <returns></returns>
        public static string GetDirectoryName(this string path) => Path.GetDirectoryName(path);
    }
}

