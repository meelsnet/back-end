
namespace Dashboard.Api.Core.Attribute
{
    public class JsonPropertyNameBasedOnItemClassAttribute : System.Attribute
    {
    }

    public class JsonPluralNameAttribute : System.Attribute
    {
        public string PluralName { get; set; }
        public JsonPluralNameAttribute(string pluralName)
        {
            PluralName = pluralName;
        }
    }
}