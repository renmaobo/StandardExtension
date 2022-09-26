// ============================================================
// Copyright (C) 2022 RenMaoBo All Rights Reserved.
// FileName:    	DirectoryExtension
// Version:       	$V1.0.0.0
// Create By:   	maobo
// Email:           renmaobo@outlook.com
// Create Time:  	2022/9/26 下午11:06
//
// Description:
//
// ============================================================
// Modify Mark
// Modify Time:  2022/9/26 下午11:06
// Modify By:    maobo
// Version:      V1.0.0.0
// Description:
//
// ============================================================
using System;
namespace System.IO
{
    /// <summary>
    /// 文件目录扩展
    /// </summary>
    public static class DirectoryExtension
    {
        /// <summary>
        /// 判定是否存在目录
        /// </summary>
        /// <param name="directoryPath">目录路径</param>
        /// <returns></returns>
        public static bool ExistDirectory(this string directoryPath) => Directory.Exists(directoryPath);

        /// <summary>
        /// 删除目录
        /// </summary>
        /// <param name="directoryPath">目录路径</param>
        public static void DeleteDirectory(this string directoryPath) => Directory.Delete(directoryPath);

        /// <summary>
        /// 获取当前目录下的文件列表
        /// </summary>
        /// <param name="directoryPath">目录路径</param>
        /// <returns></returns>
        public static string[] GetFiles(this string directoryPath) => Directory.GetFiles(directoryPath);

        /// <summary>
        /// 获取当前目录的父级目录信息
        /// </summary>
        /// <param name="directoryPath">目录路径</param>
        /// <returns></returns>
        public static DirectoryInfo GetParentDirectory(this string directoryPath) => Directory.GetParent(directoryPath);
    }
}

