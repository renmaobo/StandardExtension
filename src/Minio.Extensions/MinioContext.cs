// ============================================================
// Copyright (C) 2022 RenMaoBo All Rights Reserved.
// FileName:    	MinioContext
// Version:       	$V1.0.0.0
// Create By:   	maobo
// Email:           renmaobo@outlook.com
// Create Time:  	2022/10/21 下午9:53
//
// Description:
//
// ============================================================
// Modify Mark
// Modify Time:  2022/10/21 下午9:53
// Modify By:    maobo
// Version:      V1.0.0.0
// Description:
//
// ============================================================
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Minio.Extensions
{
    /// <summary>
    /// MinIO Context
    /// </summary>
    public class MinioContext
    {
        /// <summary>
        /// 
        /// </summary>
        public MinioConfig MinioConfig { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected MinioClient MinioClient { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="minioConfig"></param>
        public MinioContext(MinioConfig minioConfig)
        {
            this.MinioConfig = minioConfig;
            this.MinioClient = minioConfig.BuildMinioClient();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="accessKey"></param>
        /// <param name="secretKey"></param>
        public MinioContext(string endpoint, string accessKey, string secretKey)
            :this(new MinioConfig(endpoint:endpoint, accessKey:accessKey, secretKey: secretKey)) { }

        /// <summary>
        /// 创建桶
        /// </summary>
        /// <param name="bucketName">桶名称</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public async Task MakeBucketAsync(string bucketName, CancellationToken cancellationToken = default) {
            MakeBucketArgs args = new MakeBucketArgs();
            args.WithBucket(bucketName);

            await this.MinioClient.MakeBucketAsync(args, cancellationToken);
        }

        /// <summary>
        /// 存在桶
        /// </summary>
        /// <param name="bucketName">桶名称</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        public async Task<bool> ExsitBucketAsync(string bucketName, CancellationToken cancellationToken = default)
        {
            BucketExistsArgs args = new BucketExistsArgs();
            args.WithBucket(bucketName);
            return await this.MinioClient.BucketExistsAsync(args, cancellationToken);
        }
    }
}

