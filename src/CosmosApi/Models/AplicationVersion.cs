using Newtonsoft.Json;

namespace CosmosApi.Models
{
    public class AplicationVersion
    {
        /// <summary>
        /// Initializes a new instance of the Get200ApplicationJsonProperties
        /// class.
        /// </summary>
        public AplicationVersion()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Get200ApplicationJsonProperties
        /// class.
        /// </summary>
        public AplicationVersion(string buildTags, string appName, string commit, string go, string name, string version, string sdkversion, BuildDep buildDep)
        {
            Name = name;
            AppName = appName;
            Version = version;
            Commit = commit;
            BuildTags = buildTags;
            Go = go;
            BuildDep = buildDep;
            CosmosSDKVersion = sdkversion;
    }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "build_tags")]
        public string BuildTags { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "app_name")]
        public string AppName { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "git_commit")]
        public string Commit { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "go_version")]
        public string Go { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; } = null!;
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cosmos_sdk_version")]
        public string CosmosSDKVersion { get; set; }

        [JsonProperty(PropertyName = "build_deps")]
        public BuildDep BuildDep { get; internal set; }       

    }
}
