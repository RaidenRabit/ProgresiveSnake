using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ModelTier
{
    /// <summary>
    /// holds all info about snake
    /// </summary>
    [DataContract]
    public class Snake
    {
        [DataMember]
        public List<Piece> Pieces { get; set; }

        [DataMember]
        public int Dir { get; set; }

        public Snake()
        {
            Pieces = new List<Piece>();
            Pieces.Clear();
        }
    }

    [DataContract]
    public class Piece
    {
        [DataMember]
        public int X { get; set; }
        [DataMember]
        public int Y { get; set; }
    }
}
