using System;
using DynamicsFramework.Entities.ManuallyGenerated;
using DynamicsFramework.Entities.ManuallyGenerated.OptionSets;
using Microsoft.Xrm.Sdk;

namespace TestingPlugin
{
    public class Testing : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            var context = (IPluginExecutionContext) serviceProvider.GetService(typeof(IPluginExecutionContext));
            var tracingService = (ITracingService) serviceProvider.GetService(typeof(ITracingService));
            var organizationServiceFactory = (IOrganizationServiceFactory) serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            var organizationService = organizationServiceFactory.CreateOrganizationService(context.UserId);
            
            tracingService.Trace("Testing plugin executed successfully.");

            MethodThatCallsEarlyBoundAccount(context, organizationService); 
        }

        private void MethodThatCallsEarlyBoundAccount(IPluginExecutionContext context, IOrganizationService organizationService)
        {
            var account = new Account
            {
                Id = context.PrimaryEntityId,
                Name = "Test Account",
                Telephone1 = "1234567890",
            };

            organizationService.Update(account);
        }
    }
}