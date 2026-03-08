using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace DynamicsFramework.Entities
{
    [DataContract()]
    public abstract class BaseEntity : Entity
    {
        public static class BaseFields
        {
            public const string CreatedOn = "createdon";
            public const string ModifiedOn = "modifiedon";
            public const string CreatedBy = "createdby";
            public const string ModifiedBy = "modifiedby";
        }

        protected BaseEntity() : base(GetEntityLogicalName(null)) { }

        protected BaseEntity(string entityLogicalName) : base(entityLogicalName) { }

        [AttributeLogicalName(BaseFields.CreatedOn)]
        public DateTime? CreatedOn
        {
            get => Get<DateTime?>();
            set => Set(value);
        }

        [AttributeLogicalName(BaseFields.ModifiedOn)]
        public DateTime? ModifiedOn
        {
            get => Get<DateTime?>();
            set => Set(value);
        }

        [AttributeLogicalName(BaseFields.CreatedBy)]
        public EntityReference CreatedBy
        {
            get => Get<EntityReference>();
            set => Set(value);
        }

        [AttributeLogicalName(BaseFields.ModifiedBy)]
        public EntityReference ModifiedBy
        {
            get => Get<EntityReference>();
            set => Set(value);
        }

        /// <summary>
        /// Gets the value for a property by looking up the [AttributeLogicalName] using reflection.
        /// </summary>
        protected T Get<T>([CallerMemberName] string propertyName = null)
        {
            var attributeName = GetAttributeName(propertyName);
            return GetAttributeValue<T>(attributeName);
        }

        /// <summary>
        /// Sets the value for a property by finding the [AttributeLogicalName] via reflection.
        /// </summary>
        protected void Set(object value, [CallerMemberName] string propertyName = null)
        {
            var attributeName = GetAttributeName(propertyName);
            SetAttributeValue(attributeName, value);
        }

        /// <summary>
        /// Sets the record ID and keeps it in sync with the base Entity.Id.
        /// </summary>
        protected void SetId(Guid? value, [CallerMemberName] string propertyName = null)
        {
            Set(value, propertyName);
            base.Id = value ?? Guid.Empty;
        }

        /// <summary>
        /// Automatically finds the CRM logical name (like "account") by using reflection to find the [EntityLogicalName] attribute on the class.
        /// </summary>
        private static string GetEntityLogicalName(Type type)
        {
            var targetType = type ?? new System.Diagnostics.StackTrace().GetFrame(2).GetMethod().DeclaringType;
            var attribute = targetType?.GetCustomAttributes(typeof(EntityLogicalNameAttribute), true)
                                .FirstOrDefault() as EntityLogicalNameAttribute;
            return attribute?.LogicalName;
        }

        /// <summary>
        /// Finds the CRM field name by using reflection to read the [AttributeLogicalName] attribute from the property.
        /// </summary>
        private string GetAttributeName(string propertyName)
        {
            if (Attributes == null) { } // Safety check to ensure instance usage is detected
            var prop = GetType().GetProperty(propertyName);
            var attribute = prop?.GetCustomAttributes(typeof(AttributeLogicalNameAttribute), true)
                                .FirstOrDefault() as AttributeLogicalNameAttribute;
            return attribute?.LogicalName ?? propertyName.ToLower();
        }
    }
}
