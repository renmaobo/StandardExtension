// ============================================================
// Copyright (C) 2022 RenMaoBo All Rights Reserved.
// FileName:    	Proxy
// Version:       	$V1.0.0.0
// Create By:   	maobo
// Email:           renmaobo@outlook.com
// Create Time:  	2022/9/26 下午10:17
//
// Description:
//
// ============================================================
// Modify Mark
// Modify Time:  2022/9/26 下午10:17
// Modify By:    maobo
// Version:      V1.0.0.0
// Description:
//
// ============================================================
using System;
using System.Reflection;

namespace DesignPatterns.Extensions.ProxyPattern
{
    /// <summary>
    /// 泛型代理类
    /// </summary>
    /// <typeparam name="Tclass"><typeparamref name="Tclass"/></typeparam>
    public sealed class Proxy<Tclass> : DispatchProxy
    {
        /// <summary>
        /// 服务
        /// </summary>
        internal Tclass Service { get; set; }

        /// <summary>
        /// 调用
        /// </summary>
        /// <param name="targetMethod">调用方法</param>
        /// <param name="args">方法参数</param>
        /// <returns></returns>
        protected override sealed object Invoke(MethodInfo targetMethod, object[] args)
        {
            Type type = Service.GetType();
            InterceptAttribute interceptAttribute = type.GetMethod(targetMethod.Name).GetCustomAttribute<InterceptAttribute>();
            if (interceptAttribute != null)// 检查并执行拦截
            {
                object result = null;
                interceptAttribute.Executing();
                result = targetMethod.Invoke(Service, args);
                interceptAttribute.Executed();
                return result;
            }
            else
                return targetMethod.Invoke(Service, args);
        }

        /// <summary>
        /// 设置代理。多适用于接口和实现类方面的代理
        /// </summary>
        /// <typeparam name="Tinterface">接口</typeparam>
        /// <typeparam name="Tservice">服务</typeparam>
        /// <returns></returns>
        public static Tinterface SetPorxy<Tinterface, Tservice>() where Tservice : Tinterface, new()
        {
            Tinterface proxy = DispatchProxy.Create<Tinterface, Proxy<Tinterface>>();
            Proxy<Tinterface> data = proxy as Proxy<Tinterface>;
            data.Service = new Tservice();
            return proxy;
        }
    }
}

