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
using System.Text;

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
        private static byte[] BaseHttpRequest(this string url, HttpRequestType requestType, byte[] data = default, Action<WebHeaderCollection> headers = default)
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

        /// <summary>
        /// http get请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="headers">报文头设置</param>
        /// <returns></returns>
        public static byte[] HttpGet(this string url, Action<WebHeaderCollection> headers = default) => url.BaseHttpRequest(HttpRequestType.HttpGet, headers: headers);

        /// <summary>
        /// http get请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="headers">报文头设置</param>
        /// <param name="encoding">返回数据编码格式</param>
        /// <returns></returns>
        public static string HttpGet(this string url, Action<WebHeaderCollection> headers = default, Encoding encoding = default)
        {
            if (encoding == null)
                encoding = Encoding.UTF8;
            return encoding.GetString(url.HttpGet(headers));
        }

        /// <summary>
        /// http post请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="requestBody">请求数据</param>
        /// <param name="headers">报文头设置</param>
        /// <returns></returns>
        public static byte[] HttpPost(this string url, byte[] requestBody, Action<WebHeaderCollection> headers = default) => url.BaseHttpRequest(HttpRequestType.HttpPost, requestBody, headers);

        /// <summary>
        /// http post请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="requestBody">请求数据</param>
        /// <param name="headers">报文头设置</param>
        /// <param name="encoding">返回数据编码格式</param>
        /// <returns></returns>
        public static string HttpPost(this string url, byte[] requestBody, Action<WebHeaderCollection> headers, Encoding encoding = default)
        {
            if (encoding == null)
                encoding = Encoding.UTF8;
            return encoding.GetString(url.HttpPost(requestBody, headers));
        }
    }
}

