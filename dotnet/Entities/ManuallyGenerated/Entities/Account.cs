using System;
using System.Runtime.Serialization;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using DynamicsFramework.Entities.OptionSets;

namespace DynamicsFramework.Entities
{
    [DataContract]
    [EntityLogicalName(EntityLogicalName)]
    public class Account : BaseEntity
    {
        public const string EntityLogicalName = "account";

        public static class Fields
        {
            public const string AccountId = "accountid";
            public const string Name = "name";
            public const string Telephone1 = "telephone1";
            public const string OptionSetExample = "vel_optionsetexample";
        }

        [AttributeLogicalName(Fields.AccountId)]
        public virtual Guid? AccountId
        {
            get => Get<Guid?>();
            set => SetId(value);
        }

        [AttributeLogicalName(Fields.AccountId)]
        public override Guid Id
        {
            get => base.Id;
            set => AccountId = value;
        }

        [AttributeLogicalName(Fields.Name)]
        public string Name
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(Fields.Telephone1)]
        public string Telephone1
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(Fields.OptionSetExample)]
        public ExampleOptionSet? OptionSetExample
        {
            get => Get<ExampleOptionSet?>();
            set => Set(value);
        }
    }
}
