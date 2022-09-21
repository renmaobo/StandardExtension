// ============================================================
// Copyright (C) 2022 RenMaoBo All Rights Reserved.
// FileName:    	IloopbackPipeline
// Version:       	$V1.0.0.0
// Create By:   	maobo
// Email:           renmaobo@outlook.com
// Create Time:  	2022/9/21 下午10:42
//
// Description:
//
// ============================================================
// Modify Mark
// Modify Time:  2022/9/21 下午10:42
// Modify By:    maobo
// Version:      V1.0.0.0
// Description:
//
// ============================================================
using System;
namespace DesignPatterns.PipelinePattern.Pipelines
{
    /// <summary>
    /// 回环管道接口
    /// </summary>
    public abstract class LoopbackPipeline : Pipeline
    {
        /// <summary>
        /// 过程
        /// </summary>
        /// <param name="context">环境运行参数</param>
        /// <returns></returns>
        public override IPipelineResult Proccess(PipelineContext context)
        {
            IPipelineResult result;
            result = this.Executing(context);
            result = this.Executed(context);
            return result;
        }

        /// <summary>
        /// 执行中
        /// </summary>
        /// <param name="context">环境运行参数</param>
        /// <returns></returns>
        public abstract IPipelineResult Executing(PipelineContext context);

        /// <summary>
        /// 执行后
        /// </summary>
        /// <param name="context">环境运行参数</param>
        /// <returns></returns>
        public abstract IPipelineResult Executed(PipelineContext context);
    }
}

