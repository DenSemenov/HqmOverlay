using System;
using System.Collections.Generic;
using System.Text;

namespace HockeyOverlay.Models
{
    public class PositionModel
    {
        public string Name { get; set; }
        public PositionType Position { get; set; }

        public PositionModel(string name, PositionType position)
        {
            this.Name = name;
            this.Position = position;
        }
    }
}
