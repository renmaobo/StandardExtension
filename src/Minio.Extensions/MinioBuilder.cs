// ============================================================
// Copyright (C) 2022 RenMaoBo All Rights Reserved.
// FileName:    	MinioBuilder
// Version:       	$V1.0.0.0
// Create By:   	maobo
// Email:           renmaobo@outlook.com
// Create Time:  	2022/10/21 下午10:27
//
// Description:
//
// ============================================================
// Modify Mark
// Modify Time:  2022/10/21 下午10:27
// Modify By:    maobo
// Version:      V1.0.0.0
// Description:
//
// ============================================================
using System;
using Microsoft.Extensions.DependencyInjection;

namespace Minio.Extensions
{
    public class MinioBuilder
    {
        public IServiceCollection Services { get; private set; }

        public MinioBuilder(IServiceCollection services)
        {
            this.Services = services;
        }

        public void UseMinioContext(MinioConfig config) {
            this.Services.AddSingleton(e => { 
                return new MinioContext(config);
            });
        }

        public void UseMinioContext(string endpoint, string accessKey, string secretKey) {
            this.Services.AddSingleton(e => {
                return new MinioContext(endpoint, accessKey, secretKey);
            });
        }
    }
}

