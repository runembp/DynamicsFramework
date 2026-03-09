using System;
using System.Runtime.Serialization;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace DynamicsFramework.Entities.ManuallyGenerated
{
    [DataContract]
    [EntityLogicalName(EntityLogicalName)]
    public class Contact : BaseEntity
    {
        public const string EntityLogicalName = "contact";

        public static class Fields
        {
            public const string ContactId = "contactid";
            public const string FirstName = "firstname";
            public const string LastName = "lastname";
            public const string EmailAddress1 = "emailaddress1";
            public const string ParentCustomerId = "parentcustomerid";
        }

        [AttributeLogicalName(Fields.ContactId)]
        public virtual Guid? ContactId
        {
            get => Get<Guid?>();
            set => SetId(value);
        }

        [AttributeLogicalName(Fields.ContactId)]
        public override Guid Id
        {
            get => base.Id;
            set => ContactId = value;
        }

        [AttributeLogicalName(Fields.FirstName)]
        public string FirstName
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(Fields.LastName)]
        public string LastName
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(Fields.EmailAddress1)]
        public string EmailAddress1
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(Fields.ParentCustomerId)]
        public EntityReference ParentCustomerId
        {
            get => Get<EntityReference>();
            set => Set(value);
        }
    }
}
