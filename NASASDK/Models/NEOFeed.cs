using System;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

namespace NASASDK.Models
{
    public class NEOStats
    {
        [JsonProperty(PropertyName = "near_earth_object_count")]
        public int NearEarthObjectCount { get; set; }

        [JsonProperty(PropertyName = "close_approach_count")]
        public int CloseApproachCount { get; set; }

        [JsonProperty(PropertyName = "last_updated")]
        public DateTime LastUpdated { get; set; }

        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        [JsonProperty(PropertyName = "nasa_jpl_url")]
        public string NasaJplUrl { get; set; }
    }

    public class NEOBrowse
    {
        [JsonProperty(PropertyName = "links")]
        public Links Links { get; set; }

        [JsonProperty(PropertyName = "page")]
        public Page Page { get; set; }

        [JsonProperty(PropertyName = "near_earth_objects")]
        public IList<NearEarthObject> NearEarthObjects { get; set; }
    }

    public class Page
    {
        [JsonProperty(PropertyName = "size")]
        public int Size { get; set; }

        [JsonProperty(PropertyName = "total_elements")]
        public int TotalElements { get; set; }

        [JsonProperty(PropertyName = "total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }
    }

    public class NEOFeed
    {
        [JsonProperty(PropertyName = "links")]
        public Links Links { get; set; }

        [JsonProperty(PropertyName = "element_count")]
        public int ElementCount { get; set; }

        [JsonProperty(PropertyName = "near_earth_objects")]
        public IDictionary<DateTime, IList<NearEarthObject>> NearEarthObjects { get; set; }
    }

    public class Links
    {
        [JsonProperty(PropertyName = "next")]
        public string Next { get; set; }

        [JsonProperty(PropertyName = "prev")]
        public string Prev { get; set; }

        [JsonProperty(PropertyName = "self")]
        public string Self { get; set; }
    }

    public class NearEarthObject
    {
        [JsonProperty(PropertyName = "links")]
        public Links Links { get; set; }

        [JsonProperty(PropertyName = "neo_reference_id")]
        public string NeoReferenceId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "nasa_jpl_url")]
        public string NasaJplUrl { get; set; }

        [JsonProperty(PropertyName = "absolute_magnitude_h")]
        public float AbsoluteMagnitudeH { get; set; }

        [JsonProperty(PropertyName = "estimated_diameter")]
        public EstimatedDiameter EstimatedDiameter { get; set; }

        [JsonProperty(PropertyName = "is_potentially_hazardous_asteroid")]
        public bool IsPotentiallyHazardousAsteroid { get; set; }

        [JsonProperty(PropertyName = "close_approach_data")]
        public List<CloseApproachData> CloseApproachData { get; set; }
    }

    public class EstimatedDiameter
    {
        [JsonProperty(PropertyName = "kilometers")]
        public EstimatedDiameterRange Kilometers { get; set; }

        [JsonProperty(PropertyName = "meters")]
        public EstimatedDiameterRange Meters { get; set; }

        [JsonProperty(PropertyName = "miles")]
        public EstimatedDiameterRange Miles { get; set; }

        [JsonProperty(PropertyName = "feet")]
        public EstimatedDiameterRange Feet { get; set; }
    }

    public class EstimatedDiameterRange
    {
        [JsonProperty(PropertyName = "estimated_diameter_min")]
        public float EstimatedDiameterMin { get; set; }

        [JsonProperty(PropertyName = "estimated_diameter_max")]
        public float EstimatedDiameterMax { get; set; }
    }

    public class CloseApproachData
    {
        [JsonProperty(PropertyName = "close_approach_date")]
        public DateTime CloseApproachDate { get; set; }

        [JsonProperty(PropertyName = "epoch_date_close_approach")]
        public long EpochDateCloseApproach { get; set; }

        [JsonProperty(PropertyName = "relative_velocity")]
        public RelativeVelocity RelativeVelocity { get; set; }

        [JsonProperty(PropertyName = "miss_distance")]
        public MissDistance MissDistance { get; set; }

        [JsonProperty(PropertyName = "orbiting_body")]
        public string OrbitingBody { get; set; }
    }

    public class RelativeVelocity
    {
        [JsonProperty(PropertyName = "kilometers_per_second")]
        public double KilometersPerSecond { get; set; }

        [JsonProperty(PropertyName = "kilometers_per_hour")]
        public double KilometersPerHour { get; set; }

        [JsonProperty(PropertyName = "miles_per_hour")]
        public double MilesPerHour { get; set; }
    }

    public class MissDistance
    {
        [JsonProperty(PropertyName = "astronomical")]
        public double Astronomical { get; set; }

        [JsonProperty(PropertyName = "lunar")]
        public double Lunar { get; set; }

        [JsonProperty(PropertyName = "kilometers")]
        public double Kilometers { get; set; }

        [JsonProperty(PropertyName = "miles")]
        public double Miles { get; set; }
    }
}
