// <auto-generated>
// Code generated by luis:generate:cs
// Tool github: https://github.com/microsoft/botframwork-cli
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.AI.Luis;
namespace Luis
{
    public partial class GeneralLuis : IRecognizerConvert
    {
        [JsonProperty("text")]
        public string Text;

        [JsonProperty("alteredText")]
        public string AlteredText;

        public enum Intent
        {
            Cancel,
            Confirm,
            Escalate,
            ExtractName,
            FinishTask,
            GoBack,
            Help,
            Logout,
            None,
            ReadAloud,
            Reject,
            Repeat,
            SelectAny,
            SelectItem,
            SelectNone,
            ShowNext,
            ShowPrevious,
            StartOver,
            Stop
        };
        [JsonProperty("intents")]
        public Dictionary<Intent, IntentScore> Intents;

        public class _Entities
        {
            // Simple entities
            public string[] DirectionalReference;

            // Built-in entities
            public double[] number;
            public double[] ordinal;
            public string[] personName;

            // Pattern.any
            public string[] PersonName_Any;


            // Instance
            public class _Instance
            {
                public InstanceData[] DirectionalReference;
                public InstanceData[] PersonName_Any;
                public InstanceData[] number;
                public InstanceData[] ordinal;
                public InstanceData[] personName;
            }
            [JsonProperty("$instance")]
            public _Instance _instance;
        }
        [JsonProperty("entities")]
        public _Entities Entities;

        [JsonExtensionData(ReadData = true, WriteData = true)]
        public IDictionary<string, object> Properties { get; set; }

        public void Convert(dynamic result)
        {
            var app = JsonConvert.DeserializeObject<GeneralLuis>(JsonConvert.SerializeObject(result, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            Text = app.Text;
            AlteredText = app.AlteredText;
            Intents = app.Intents;
            Entities = app.Entities;
            Properties = app.Properties;
        }

        public (Intent intent, double score) TopIntent()
        {
            Intent maxIntent = Intent.None;
            var max = 0.0;
            foreach (var entry in Intents)
            {
                if (entry.Value.Score > max)
                {
                    maxIntent = entry.Key;
                    max = entry.Value.Score.Value;
                }
            }
            return (maxIntent, max);
        }
    }
}
