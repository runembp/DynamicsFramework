using DynamicsFramework.BasePlugin;
using DynamicsFramework.Entities.ManuallyGenerated;

namespace TestingPlugin.Handlers
{
    public class UpdateAccountHandler : IPluginHandler
    {
        public void Execute(PluginContext context)
        {
            var account = context.GetTarget<Account>();

            context.OrganizationService.Update(new Account
            {
                Id = account.Id,
                Name = "Test Account",
                Telephone1 = "1234567890",
            });
        }
    }
}
