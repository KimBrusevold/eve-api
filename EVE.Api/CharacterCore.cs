using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EVE.Api
{
    public class CharacterCore
    {
        public string Name { get; set; }
        [JsonPropertyName("alliance_id")]
        public int? AllianceId { get; set; }
        public string Birthday { get; set; }
        [JsonPropertyName("bloodline_id")]
        public int BloodlineId { get; set; }
        [JsonPropertyName("corporation_id")]
        public int CorporationId { get; set; }
        public string Description { get; set; }
        [JsonPropertyName("faction_id")]
        public int? FactionId { get; set; }
        public string Gender { get; set; }
        [JsonPropertyName("race_id")]
        public int RaceId { get; set; }
        [JsonPropertyName("security_status")]
        public float SecurityStatus { get; set; }
        public string Title { get; set; }


    }

}