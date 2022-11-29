// ============================================================
// Copyright (C) 2022 RenMaoBo All Rights Reserved.
// FileName:    	MinioConfig
// Version:       	$V1.0.0.0
// Create By:   	maobo
// Email:           renmaobo@outlook.com
// Create Time:  	2022/10/21 下午9:52
//
// Description:
//
// ============================================================
// Modify Mark
// Modify Time:  2022/10/21 下午9:52
// Modify By:    maobo
// Version:      V1.0.0.0
// Description:
//
// ============================================================
using System;
namespace Minio.Extensions
{
    /// <summary>
    /// minIO configuration
    /// </summary>
    public class MinioConfig
    {
        /// <summary>
        /// 终端信息
        /// </summary>
        /// <example>[http|https]://{address:[minio.com]}:{port:[9000]}</example>
        public string Endpoint;

        /// <summary>
        /// 账户
        /// </summary>
        public string AccessKey;

        /// <summary>
        /// 密码
        /// </summary>
        public string SecretKey;

        /// <summary>
        /// 区域
        /// </summary>
        public string Region;

        /// <summary>
        /// 会话密钥
        /// </summary>
        public string sessionToken;

        /// <summary>
        /// minio客户端
        /// </summary>
        public MinioClient MinioClient { get; private set; }


        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="endpoint">终端信息</param>
        /// <param name="accessKey">账户</param>
        /// <param name="secretKey">密码</param>
        /// <param name="region">区域</param>
        /// <param name="sessionToken">会话密钥</param>
        public MinioConfig(string endpoint, string accessKey = default, string secretKey = default, string region = default, string sessionToken = default)
        {
            this.Endpoint = endpoint;
            this.AccessKey = accessKey;
            this.SecretKey = secretKey;
            this.Region = region;
            this.sessionToken = sessionToken;
        }

        /// <summary>
        /// 构建minio客户端
        /// </summary>
        internal MinioClient BuildMinioClient()
        {
            this.MinioClient = new MinioClient();
            this.MinioClient.WithEndpoint(this.Endpoint);
            this.MinioClient.WithCredentials(this.AccessKey, this.SecretKey);
            this.MinioClient.WithRegion(this.Region);
            this.MinioClient.WithSessionToken(this.sessionToken);
            this.MinioClient.WithSSL();
            return this.MinioClient.Build();
        }
    }
}

