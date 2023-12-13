using Newtonsoft.Json.Serialization;

namespace SigSpec.Core;

/// <summary>
/// CamelCase property names contract resolver that doesn't share contract cache with other instances.
/// Makes types update after a hot reload.
/// </summary>
/// <seealso cref="CamelCasePropertyNamesContractResolver" />
public class UnsharedCamelCasePropertyNamesContractResolver : DefaultContractResolver
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CamelCasePropertyNamesContractResolver"/> class.
    /// </summary>
    public UnsharedCamelCasePropertyNamesContractResolver()
    {
        NamingStrategy = new CamelCaseNamingStrategy
        {
            ProcessDictionaryKeys = true,
            OverrideSpecifiedNames = true
        };
    }
}
