// ============================================================
// Copyright (C) 2022 RenMaoBo All Rights Reserved.
// FileName:    	FileExtension
// Version:       	$V1.0.0.0
// Create By:   	maobo
// Email:           renmaobo@outlook.com
// Create Time:  	2022/9/26 下午10:56
//
// Description:
//
// ============================================================
// Modify Mark
// Modify Time:  2022/9/26 下午10:56
// Modify By:    maobo
// Version:      V1.0.0.0
// Description:
//
// ============================================================
using System;
using System.Collections.Generic;

namespace System.IO
{
    /// <summary>
    /// 文件扩展
    /// </summary>
    public static class FileExtension
    {
        /// <summary>
        /// 判定是否存在文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static bool ExistFile(this string filePath) => File.Exists(filePath);

        /// <summary>
        /// 根据文件路径创建文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>文件流</returns>
        public static FileStream CreateFile(this string filePath) => File.Create(filePath);

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        public static void DeleteFile(this string filePath) => File.Delete(filePath);

        /// <summary>
        /// 创建文件并且添加内容。适用于记录日志
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="contents">文件内容</param>
        public static void CreateFileWithAppendAllText(this string filePath, string contents) => File.AppendAllText(filePath, contents);

        /// <summary>
        /// 创建文件并添加内容。适用于记录日志
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="contents">文件内容</param>
        public static void CreateFileWithAppendAllLines(this string filePath, IEnumerable<string> contents) => File.AppendAllLines(filePath, contents);
    }
}

