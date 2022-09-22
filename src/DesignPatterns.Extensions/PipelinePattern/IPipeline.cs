// ============================================================
// Copyright (C) 2022 RenMaoBo All Rights Reserved.
// FileName:    	IPipeline
// Version:       	$V1.0.0.0
// Create By:   	maobo
// Email:           renmaobo@outlook.com
// Create Time:  	2022/9/21 下午10:26
//
// Description:
//
// ============================================================
// Modify Mark
// Modify Time:  2022/9/21 下午10:26
// Modify By:    maobo
// Version:      V1.0.0.0
// Description:
//
// ============================================================
using System;
using DesignPatterns.PipelinePattern;

namespace DesignPatterns.PipelinePattern
{
    /// <summary>
    /// 管道接口
    /// </summary>
    public interface IPipeline
    {
        /// <summary>
        /// 过程
        /// </summary>
        /// <param name="input">环境运行参数</param>
        /// <returns></returns>
        void Proccess(PipelineContext context);
    }
}

