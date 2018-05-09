using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ModelTier
{
    /// <summary>
    /// holds all info about baord
    /// </summary>
    [DataContract]
    public class Board
    {
        [DataMember]
        public int XSize { get; set; }
        [DataMember]
        public int YSize { get; set; }
        [DataMember]
        public List<Obstacle> Obstacles { get; set; }

        public Board()
        {
            Obstacles = new List<Obstacle>();
            Obstacles.Clear();
        }
    }

    [DataContract]
    public class Obstacle
    {
        [DataMember]
        public int X { get; set; }
        [DataMember]
        public int Y { get; set; }
        [DataMember]
        public bool Type { get; set; } //true = food; false = wall
    }
}
