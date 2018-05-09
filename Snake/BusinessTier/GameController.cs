using ModelTier;
using System;
using System.Linq;

namespace BusinessTier
{
    /// <summary>
    /// controlls the state of the game, collisions and forwards calls to snake and board controllers
    /// </summary>
    public class GameController : IGameController
    {
        private SnakeController snakeController;
        private BoardController boardController;

        public GameController()
        {
            snakeController = new SnakeController();
            boardController = new BoardController();

        }
        public void MoveSnake()
        {
            snakeController.MoveSnake();
        }

        public Snake GetSnake()
        {
            return snakeController.GetSnake();
        }

        public Board GetBoard()
        {
            return boardController.GetBoard();
        }

        public void SetDir(int d)
        {             
            snakeController.SetDir(d);
        }

        public void AddObstacle(int x, int y, bool type)
        {
            boardController.AddObstacle(x, y, type);
        }

        public void RemoveObstacle(int x, int y)
        {
            boardController.RemoveObstacle(x, y);
        }


        /// <summary>
        /// Checks if snake is coliding with anything
        /// </summary>
        /// <returns> 0 = dead; 1 = alive; 2 = grow; </returns>
        public int CheckCollisions()
        {
            Snake snake = snakeController.GetSnake();
            Piece head = snake.Pieces[0];
            Board board = boardController.GetBoard();
            
            foreach(Piece p in snake.Pieces.Skip(1)) //collision with self
            {
                if (head.X == p.X && head.Y == p.Y)
                    return 0;
            }

            if (head.X < 0 || head.Y < 0 || head.X > 19|| head.Y > 19) //border collision
                return 0;

            foreach (Obstacle o in board.Obstacles) //collision with board's obstacles
            {
                if (head.X == o.X && head.Y == o.Y) //if collision with obstacles
                    if (o.Type) //if food
                    {
                        snakeController.GrowSnake(1);
                        Random r = new Random();
                        boardController.RemoveObstacle(o.X, o.Y); //remove current food
                        boardController.AddObstacle(r.Next(0, board.XSize), r.Next(0, board.YSize), true); //spawn new food at random loc
                        return 2;
                    }
                    else // wall
                        return 0;
            }

            return 1;
        }
    }
}
