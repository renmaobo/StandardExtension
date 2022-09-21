// ============================================================
// Copyright (C) 2022 RenMaoBo All Rights Reserved.
// FileName:    	Pipeline
// Version:       	$V1.0.0.0
// Create By:   	maobo
// Email:           renmaobo@outlook.com
// Create Time:  	2022/9/21 下午10:51
//
// Description:
//
// ============================================================
// Modify Mark
// Modify Time:  2022/9/21 下午10:51
// Modify By:    maobo
// Version:      V1.0.0.0
// Description:
//
// ============================================================
using System;
namespace DesignPatterns.PipelinePattern
{
    /// <summary>
    /// 管道
    /// </summary>
    public abstract class Pipeline : IPipeline
    {
        /// <summary>
        /// 下一管道
        /// </summary>
        protected Pipeline next;

        /// <summary>
        /// 设置下一管道
        /// </summary>
        /// <param name="next">下一管道</param>
        /// <returns></returns>
        public Pipeline SetNextPipeline(Pipeline next) {
            this.next = next;
            return this;
        }

        /// <summary>
        /// 执行过程
        /// </summary>
        /// <param name="input">环境运行参数</param>
        /// <returns></returns>
        public abstract IPipelineResult Proccess(PipelineContext context);
    }
}

