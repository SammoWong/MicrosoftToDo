using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Interfaces;
using ToDoApp.Service;

namespace ToDoApp.Core
{
    public class AutofacLocator : IAutofacLocator
    {
        IContainer Container;
        public TInterface Get<TInterface>()
        {
            return Container.Resolve<TInterface>();
        }

        /// <summary>
        /// 注册容器映射关系
        /// </summary>
        public void Register()
        {
            var container = new ContainerBuilder();
            //注入ToDo数据层
            container.RegisterType<ToDoService>().As<IToDoService>();
            Container = container.Build();
        }
    }

    /// <summary>
    /// 全局容器管理器
    /// </summary>
    public class ServiceProvider
    {
        public static IAutofacLocator Instance { get; set; }

        public static void RegisterServiceLocator(IAutofacLocator locator)
        {
            Instance = locator;
        }
    }
}
