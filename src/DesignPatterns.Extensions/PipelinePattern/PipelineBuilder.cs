// ============================================================
// Copyright (C) 2022 RenMaoBo All Rights Reserved.
// FileName:    	PipelineBuilder
// Version:       	$V1.0.0.0
// Create By:   	maobo
// Email:           renmaobo@outlook.com
// Create Time:  	2022/9/21 下午11:07
//
// Description:
//
// ============================================================
// Modify Mark
// Modify Time:  2022/9/21 下午11:07
// Modify By:    maobo
// Version:      V1.0.0.0
// Description:
//
// ============================================================
using System;
namespace DesignPatterns.PipelinePattern
{
    /// <summary>
    /// 管道构建器
    /// </summary>
    public static class PipelineBuilder
    {
        /// <summary>
        /// 构建管道
        /// </summary>
        /// <param name="pipelines">管道列表</param>
        /// <returns>管道链</returns>
        public static IPipeline Builder(Pipeline[] pipelines)
        {
            Pipeline prevPipeline = null;
            // 设置管道链
            for (int i = 0; i < pipelines.Length; i++)
            {
                if (prevPipeline != null) {
                    prevPipeline.SetNextPipeline(pipelines[i]);
                }
                prevPipeline = pipelines[i];
            }
            return pipelines[0];
        }
    }
}

