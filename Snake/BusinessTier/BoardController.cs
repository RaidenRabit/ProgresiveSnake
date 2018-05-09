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
           
            board.Obstacles.Add(new Obstacle { X = 10, Y =10, Type = true}); //spawning food

            //making some walls
            board.Obstacles.Add(new Obstacle { X = 14, Y = 19, Type = false });
            board.Obstacles.Add(new Obstacle { X = 15, Y = 19, Type = false });
            board.Obstacles.Add(new Obstacle { X = 16, Y = 19, Type = false });
            board.Obstacles.Add(new Obstacle { X = 17, Y = 19, Type = false });
            board.Obstacles.Add(new Obstacle { X = 18, Y = 19, Type = false });
            board.Obstacles.Add(new Obstacle { X = 19, Y = 19, Type = false });

            board.Obstacles.Add(new Obstacle { Y = 14, X = 19, Type = false });
            board.Obstacles.Add(new Obstacle { Y = 15, X = 19, Type = false });
            board.Obstacles.Add(new Obstacle { Y = 16, X = 19, Type = false });
            board.Obstacles.Add(new Obstacle { Y = 17, X = 19, Type = false });
            board.Obstacles.Add(new Obstacle { Y = 18, X = 19, Type = false });
            board.Obstacles.Add(new Obstacle { Y = 19, X = 19, Type = false });

            board.Obstacles.Add(new Obstacle { X = 14, Y = 15, Type = false });
            board.Obstacles.Add(new Obstacle { X = 15, Y = 15, Type = false });
            board.Obstacles.Add(new Obstacle { X = 16, Y = 15, Type = false });
            board.Obstacles.Add(new Obstacle { X = 17, Y = 15, Type = false });
            board.Obstacles.Add(new Obstacle { X = 18, Y = 15, Type = false });
            board.Obstacles.Add(new Obstacle { X = 19, Y = 15, Type = false });

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
