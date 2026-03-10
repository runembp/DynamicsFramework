using System;
using Microsoft.Xrm.Sdk;

namespace DynamicsFramework.BasePlugin
{
    public class PluginContext
    {
        private const string ImageKeyName = "Image";
        private const string TargetKeyName = "Target";

        public IPluginExecutionContext ExecutionContext { get; set; }
        public IOrganizationService OrganizationService { get; private set; }
        public IOrganizationService SystemOrganizationService { get; private set; }
        public ITracingService TracingService { get; private set; }
        
        private Entity Target { get; set; }

        public TEntity GetTarget<TEntity>() where TEntity : Entity
        {
            return Target.ToEntity<TEntity>();
        }

        public TEntity GetPreImage<TEntity>() where TEntity : Entity
        {
            if (ExecutionContext.PreEntityImages == null || ExecutionContext.PreEntityImages.Count == 0)
            {
                return null;
            }

            try
            {
                var entity = ExecutionContext.PreEntityImages[ImageKeyName];
                if (entity != null)
                {
                    return entity.ToEntity<TEntity>();
                }
            }
            catch
            {
                // Image doesn't exist with this key
            }

            return null;
        }

        public TEntity GetPostImage<TEntity>() where TEntity : Entity
        {
            if (ExecutionContext.PostEntityImages == null || ExecutionContext.PostEntityImages.Count == 0)
            {
                return null;
            }

            try
            {
                var entity = ExecutionContext.PostEntityImages[ImageKeyName];
                if (entity != null)
                {
                    return entity.ToEntity<TEntity>();
                }
            }
            catch
            {
                // Image doesn't exist with this key
            }

            return null;
        }

        public PluginContext(IServiceProvider serviceProvider)
        {
            ExecutionContext = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            TracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            var factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            OrganizationService = factory.CreateOrganizationService(ExecutionContext.UserId);
            SystemOrganizationService = factory.CreateOrganizationService(null);
            Target = (Entity)ExecutionContext.InputParameters[TargetKeyName];
        }
    }
}