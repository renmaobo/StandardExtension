// ============================================================
// Copyright (C) 2022 RenMaoBo All Rights Reserved.
// FileName:    	SinglePipeline
// Version:       	$V1.0.0.0
// Create By:   	maobo
// Email:           renmaobo@outlook.com
// Create Time:  	2022/9/21 下午10:36
//
// Description:
//
// ============================================================
// Modify Mark
// Modify Time:  2022/9/21 下午10:36
// Modify By:    maobo
// Version:      V1.0.0.0
// Description:
//
// ============================================================
using System;
using DesignPatterns.PipelinePattern;

namespace DesignPatterns.PipelinePattern.Pipelines
{
    /// <summary>
    /// 单项阀管道
    /// </summary>
    public abstract class SingleTrackPipeline<TpipelineContext> : Pipeline where TpipelineContext : PipelineContext
    {
        public override void Proccess(PipelineContext context)
        {
            this.Executing(context as TpipelineContext);
            if (this.next != null)
                this.next.Proccess(context);
        }

        public abstract void Executing(TpipelineContext context);
    }
}

