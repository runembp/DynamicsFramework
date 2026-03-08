using System.Runtime.Serialization;

namespace DynamicsFramework.Entities.OptionSets
{
    [DataContract()]
    public enum ExampleOptionSet
    {
        [EnumMember()]
        FirstOption = 1,

        [EnumMember()]
        SecondOption = 2,

        [EnumMember()]
        ThirdOption = 3,
    }
}
