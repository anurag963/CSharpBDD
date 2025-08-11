using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automationCSharp.Model
{

    public partial class Config
    {
        [JsonProperty("grid")]
        public Grid Grid { get; set; }

        [JsonProperty("driver")]
        public Driver Driver { get; set; }

        [JsonProperty("test")]
        public Test Test { get; set; }

        [JsonProperty("apiBaseURI")]
        public ApiBaseUri ApiBaseUri { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }

    public partial class ApiBaseUri
    {
        [JsonProperty("intgBaseURI")]
        public string IntgBaseUri { get; set; }

        [JsonProperty("devBaseURI")]
        public string DevBaseUri { get; set; }
    }

    public partial class Driver
    {
        [JsonProperty("browser")]
        public string Browser { get; set; }

        [JsonProperty("waitSeconds")]
        public long WaitSeconds { get; set; }

        [JsonProperty("implicitWait")]
        public long ImplicitWait { get; set; }
    }

    public partial class Grid
    {
        [JsonProperty("runOnGrid")]
        public string RunOnGrid { get; set; }

        [JsonProperty("gridUrl")]
        public string GridUrl { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }
    }

    public partial class Test
    {
        [JsonProperty("env")]
        public string Env { get; set; }

        [JsonProperty("stageUrl")]
        public string StageUrl { get; set; }

        [JsonProperty("devUrl")]
        public string DevUrl { get; set; }

        [JsonProperty("prodUrl")]
        public string ProdUrl { get; set; }
    }
    public partial class User
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }



}
