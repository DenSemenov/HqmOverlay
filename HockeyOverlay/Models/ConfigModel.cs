using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.Json.Serialization;

namespace HockeyOverlay.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ConfigModel
    {
        [JsonProperty]
        public bool ShowScore { get; set; }
        [JsonProperty]
        public int Delay { get; set; }
        public Image LeagueLogo { get; set; }
        [JsonProperty]
        public Color LeagueColor { get; set; }
        [JsonProperty]
        public Color TextColor { get; set; }
        [JsonProperty]
        public Color BorderColor { get; set; }
        [JsonProperty]
        public string Team1Name { get; set; }
        [JsonProperty]
        public string Team2Name { get; set; }
        [JsonProperty]
        public Color Team1Color { get; set; }
        [JsonProperty]
        public Color Team2Color { get; set; }
        public Image Team1Logo { get; set; }
        public Image Team2Logo { get; set; }
        [JsonProperty]
        public List<string> Team1Players { get; set; }
        [JsonProperty]
        public List<string> Team2Players { get; set; }
        [JsonProperty]
        public int ScoreX { get; set; }
        [JsonProperty]
        public int ScoreY { get; set; }
        [JsonProperty]
        public int EventsX { get; set; }
        [JsonProperty]
        public int EventsY { get; set; }
        [JsonProperty]
        public PositionType ScorePosition { get; set; }
        [JsonProperty]
        public PositionType EventPosition { get; set; }
        [JsonProperty]
        public bool ShowStats { get; set; }
        [JsonProperty]
        public bool EnableArenaSound { get; set; }
        [JsonProperty]
        public bool EnableHorn { get; set; }
        [JsonProperty]
        public int Opacity { get; set; }

        public ConfigModel()
        {
            this.Team1Color = Color.Red;
            this.Team2Color = Color.Blue;
            this.ScoreX = 30;
            this.ScoreY = 50;
            this.EventsX = 30;
            this.EventsY = 50;
            this.LeagueLogo = Properties.Resources.puck0;
            this.Team1Logo = Properties.Resources.puck0;
            this.Team2Logo = Properties.Resources.puck0;
            this.ScorePosition = PositionType.TopLeft;
            this.ScorePosition = PositionType.BottomRight;
            this.Team1Players = new List<string>();
            this.Team2Players = new List<string>();
            this.ShowStats = false;
            this.Opacity = 70;
        }
    }

    public enum PositionType
    {
        TopLeft,
        TopCenter,
        TopRight,
        BottomLeft,
        BottomCenter,
        BottomRight,
    }
}
