using HockeyEditor;
using System;
using System.Collections.Generic;
using System.Text;

namespace HockeyOverlay.Models
{
    public class GameStatsModel
    {
        public int RedScore { get; set; }
        public int BlueScore { get; set; }
        public int RedTouches { get; set; }
        public int BlueTouches { get; set; }
        public string Period { get; set; }
        public string Time { get; set; }
        public EventType Event { get; set; }
        public int EventTimer { get; set; }
        public string LastScorer { get; set; }
        public int LastScorerGoals { get; set; }
        public string LastAssist { get; set; }
        public int LastAssistAssists { get; set; }
        public List<PlayerItem> Players { get; set; }
        public bool GoalReplay { get; set; }

        public GameStatsModel()
        {
            Event = EventType.Nothing;
            Players = new List<PlayerItem>();
            GoalReplay = false;
        }
    }

    public class PlayerItem
    {
        public string Name { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public HQMTeam Team { get; set; }
    }


    public enum EventType
    {
        Nothing,
        GoalRed,
        GoalBlue,
        Warmup,
        Intermission,
        GameOver
    }
}
