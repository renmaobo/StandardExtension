// ============================================================
// Copyright (C) 2022 RenMaoBo All Rights Reserved.
// FileName:    	WebClientExtension
// Version:       	$V1.0.0.0
// Create By:   	maobo
// Email:           renmaobo@outlook.com
// Create Time:  	2022/9/20 下午11:17
//
// Description:
//
// ============================================================
// Modify Mark
// Modify Time:  2022/9/20 下午11:17
// Modify By:    maobo
// Version:      V1.0.0.0
// Description:
//
// ============================================================
using System;
namespace System.Net.Extensions.WebClientPacks
{
    /// <summary>
    /// web客户端扩展
    /// </summary>
    public static class WebClientExtension
    {
        /// <summary>
        /// 基本http请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="requestType">请求类型</param>
        /// <param name="data">提交参数</param>
        /// <param name="headers">报文头设置</param>
        /// <returns></returns>
        private static byte[] BaseHttpRequest(this string url, HttpRequestType requestType, byte[] data, Action<object> headers)
        {
            using (WebClient webClient = new WebClient())
            {
                if (headers != null)
                    headers(webClient.Headers);
                else
                    webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");

                byte[] responseValue = null;

                switch (requestType)
                {
                    case HttpRequestType.HttpPost:
                    case HttpRequestType.HttpDelete:
                    case HttpRequestType.HttpPut:
                        responseValue = webClient.UploadData(url, data);
                        break;
                    case HttpRequestType.HttpGet:
                    default:
                        responseValue = webClient.DownloadData(url);
                        break;
                }
                return responseValue;
            }
        }
    }
}

