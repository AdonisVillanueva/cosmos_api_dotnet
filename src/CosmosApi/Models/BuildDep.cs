using Newtonsoft.Json;

namespace CosmosApi.Models
{
    /// <summary>
    /// more information on versions
    /// </summary>
    public class BuildDep
    {
        /// <summary>
        /// Initializes a new instance of the
        /// BuildDep
        /// class.
        /// </summary>
        public BuildDep()
        {
        }
        public BuildDep(string path, string version, string sum)
        {
            Path = path;
            Version = version;
            Sum = sum;            
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; } = null!;

        [JsonProperty(PropertyName = "sum")]
        public string Sum { get; set; } = null!;
    }
}





