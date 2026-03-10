using System;
using System.Collections.Generic;
using DynamicsFramework.BasePlugin;
using Microsoft.Xrm.Sdk;
using TestingPlugin.Handlers;

namespace TestingPlugin
{
    public class Testing : IPlugin
    {
        private readonly List<IPluginHandler> _handlers = new List<IPluginHandler>()
        {
            new UpdateAccountHandler(),
        };

        public void Execute(IServiceProvider serviceProvider)
        {
            var context = new PluginContext(serviceProvider);

            foreach (var handler in _handlers)
            {
                handler.Execute(context);
            }
        }
    }
}