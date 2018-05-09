using ModelTier;

namespace BusinessTier
{
    public class BoardController
    {
        private Board board;

        public BoardController()
        {
            board = new Board
            {
                XSize = 20,
                YSize = 20
            };
            board.Obstacles.Add(new Obstacle { X = 15, Y =15, Type = true});
            board.Obstacles.Add(new Obstacle { X = 18, Y = 19, Type = false });
            board.Obstacles.Add(new Obstacle { X = 19, Y = 19, Type = false });
            board.Obstacles.Add(new Obstacle { X = 20, Y = 19, Type = false });
        }
        

        public void SetXSize(int x)
        {
            board.XSize = x;
        }

        public void SetYSize(int y)
        {
            board.YSize = y;
        }

        public void AddObstacle(int x, int y, bool type)
        {
            board.Obstacles.Add(new Obstacle { X = x, Y = y, Type = type });
        }

        public void RemoveObstacle(int x, int y)
        {
            foreach(Obstacle o in board.Obstacles)
            {
                if (o.X == x && o.Y == y)
                {
                    board.Obstacles.Remove(o);
                    break;
                }
            }
        }

        public Board GetBoard()
        {
            return board;
        }
    }
}
