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
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.PipelinePattern
{
    /// <summary>
    /// 管道构建器
    /// </summary>
    public class PipelineBuilder
    {
        /// <summary>
        /// 管道列表
        /// </summary>
        IList<Pipeline> Pipelines { get; set; }

        public PipelineBuilder() => this.Pipelines = new List<Pipeline>();

        public PipelineBuilder(IEnumerable[] pipelines) => this.Pipelines = Pipelines.ToList();

        /// <summary>
        /// 注入管道
        /// </summary>
        /// <param name="pipeline"></param>
        public void Use(Pipeline pipeline)
        {
            this.Pipelines.Add(pipeline);
        }

        /// <summary>
        /// 构建管道
        /// </summary>
        /// <param name="pipelines">需要构建的管道列表</param>
        /// <returns>管道链</returns>
        public IPipeline Builder(Pipeline[] pipelines)
        {
            this.Pipelines = pipelines.ToList();

            return this.Builder();
        }

        /// <summary>
        /// 构建管道
        /// </summary>
        /// <returns>管道链</returns>
        public IPipeline Builder()
        {
            Pipeline prevPipeline = null;
            // 设置管道链
            for (int i = 0; i < this.Pipelines.Count; i++)
            {
                if (prevPipeline != null)
                {
                    prevPipeline.SetNextPipeline(this.Pipelines[i]);
                }
                prevPipeline = this.Pipelines[i];
            }
            return this.Pipelines[0];
        }

        /// <summary>
        /// 构建管道
        /// </summary>
        /// <param name="pipelines">需要构建的管道列表</param>
        /// <returns>管道链</returns>
        public static IPipeline Builder(IEnumerable<Pipeline> pipelines)
        {
            Pipeline[] _pipelines = pipelines.ToArray();
            Pipeline prevPipeline = null;
            // 设置管道链
            for (int i = 0; i < pipelines.Count(); i++)
            {
                if (prevPipeline != null)
                {
                    prevPipeline.SetNextPipeline(_pipelines[i]);
                }
                prevPipeline = _pipelines[i];
            }
            return _pipelines[0];

        }
    }
}

