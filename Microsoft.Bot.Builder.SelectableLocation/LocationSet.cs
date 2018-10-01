namespace Microsoft.Bot.Builder.SelectableLocation
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a set of locations returned by the <see>
    ///         <cref>IGeoSpatialService</cref>
    ///     </see>
    /// </summary>
    [Serializable]
    public class LocationSet
    {
        /// <summary>
        /// The total estimated results.
        /// </summary>
        [JsonProperty(PropertyName = "estimatedTotal")]
        public int EstimatedTotal { get; set; }

        /// <summary>
        /// The location list.
        /// </summary>
        [JsonProperty(PropertyName = "resources")]
        public List<Location> Locations { get; set; }
    }
}