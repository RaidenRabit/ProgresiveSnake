using ModelTier;

namespace BusinessTier
{
    /// <summary>
    /// makes changes only to the snake object
    /// </summary>
    public class SnakeController
    {
        private Snake snake;

        /// <summary>
        /// initialize snake
        /// </summary>
        public SnakeController()
        {
            snake = new Snake
            {
                Dir = 2
            };
            // add 3 pieces to snake
            snake.Pieces.Add(new Piece { X = 1, Y = 1 }); // head piece
            snake.Pieces.Add(new Piece { X = 1, Y = 2 });
            snake.Pieces.Add(new Piece { X = 1, Y = 3 });
        }

        /// <summary>
        /// change snake direction
        /// </summary>
        /// <param name="d">1=UP; 2=RIGHT; 3=DOWN; 4=LEFT</param>
        public void SetDir(int d)
        {
            switch (d) //chenge direction, only if the requested change is not the oposite one
            {
                case 1:
                    if (snake.Dir != 3)
                        snake.Dir = d;
                    break;
                case 2:
                    if (snake.Dir != 4)
                        snake.Dir = d;
                    break;
                case 3:
                    if (snake.Dir != 1)
                        snake.Dir = d;
                    break;
                case 4:
                    if (snake.Dir != 2)
                        snake.Dir = d;
                    break;
            }
        }

        /// <summary>
        /// Add new Piece to snake's body
        /// </summary>
        /// <param name="x"></param>
        public void GrowSnake(int x)
        {
            for (int i = 0; i < x; i++)
                snake.Pieces.Add(new Piece { X = snake.Pieces[snake.Pieces.Count - 1].X, Y = snake.Pieces[snake.Pieces.Count - 1].Y });
        }


        /// <summary>
        /// Move's snake on board
        /// </summary>
        public void MoveSnake()
        {
            for (int i = snake.Pieces.Count - 2; i >= 0; i--) //move pieces
            { //pieces allways follow the one in front of them
                snake.Pieces[i + 1].X = snake.Pieces[i].X;
                snake.Pieces[i + 1].Y = snake.Pieces[i].Y;
            }

            switch (snake.Dir) //move head
            {
                case 1: //UP
                    snake.Pieces[0].Y--;
                    break;
                case 2: //RIFHT
                    snake.Pieces[0].X++;
                    break;
                case 3: //DOWN
                    snake.Pieces[0].Y++;
                    break;
                case 4: //Left
                    snake.Pieces[0].X--;
                    break;
            }
        }

        /// <summary>
        /// returns snake object
        /// </summary>
        /// <returns></returns>
        public Snake GetSnake()
        {
            return snake;
        }
    }
}
