using System;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;
using WindowsUI.SnakeServiceReference;

namespace WindowsUI
{
    public partial class Form1 : Form, ISnakeServiceCallback
    {
        private SnakeServiceClient snakeService;
        private Point start = new Point(30, 30);
        private const int SQUARE_SIZE = 15;
        private int i = 0;
        private Snake snake;
        private Board board;

        public Form1()
        {
            InitializeComponent();
            snakeService = new SnakeServiceClient(new InstanceContext(this));

        }

        /// <summary>
        /// Draws the board's grid, walls and food
        /// </summary>
        /// <param name="g"></param>
        private void DrawBoard(Graphics g)
        {
            if (board != null)
            {
                //Draw board grid
                for (int i = 0; i <= board.XSize; i++)
                {
                    //Draw hozontal lines
                    g.DrawLine(new Pen(Brushes.Brown),
                        start.X,
                        start.Y + SQUARE_SIZE * i,
                        start.X + SQUARE_SIZE * board.XSize,
                        start.Y + SQUARE_SIZE * i);
                }

                for (int i = 0; i <= board.YSize; i++)
                {
                    //Draw vertical lines
                    g.DrawLine(new Pen(Brushes.Brown),
                        start.X + SQUARE_SIZE * i,
                        start.Y,
                        start.X + SQUARE_SIZE * i,
                        start.Y + SQUARE_SIZE * board.YSize);
                }

                //Draw obstacles
                foreach (Obstacle o in board.Obstacles)
                {
                    if (o.Type) //if food
                        g.FillRectangle(Brushes.Red,//look better
                                   start.X + o.X * SQUARE_SIZE,
                                   start.Y + o.Y * SQUARE_SIZE,
                                   SQUARE_SIZE, SQUARE_SIZE);
                    else
                        g.FillRectangle(Brushes.Black,//look better
                               start.X + o.X * SQUARE_SIZE,
                               start.Y + o.Y * SQUARE_SIZE,
                               SQUARE_SIZE, SQUARE_SIZE);
                }
            }
            
        }
        
        /// <summary>
        /// callback function to update snake
        /// </summary>
        /// <param name="snake"></param>
        public void UpdateSnake(Snake snake)
        {
            if (snake != null)
            {
                this.snake = snake;
                pbCanvas.Invalidate(); //redraw form
                
                label1.Text = ""+snake.Pieces.Count(); //show score
            }
            else
                label1.Text = "You lost!";
        }

        /// <summary>
        /// callback function to update board
        /// </summary>
        /// <param name="board"></param>
        public void UpdateBoard(Board board)
        {
            if(board != null)
            {
                this.board = board;
                pbCanvas.Invalidate();
            }
        }
        

        /// <summary>
        /// drawing on picture box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (i > 1)
            {
                g.FillRectangle(Brushes.Red, //draw snake's head
                           start.X + snake.Pieces.First().X * SQUARE_SIZE,
                           start.Y + snake.Pieces.First().Y * SQUARE_SIZE,
                           SQUARE_SIZE, SQUARE_SIZE);
                
                foreach (Piece p in snake.Pieces.Skip(1))
                {
                    g.FillRectangle(Brushes.DarkGreen,//draw snake's body
                        start.X + p.X * SQUARE_SIZE,
                        start.Y + p.Y * SQUARE_SIZE,
                        SQUARE_SIZE, SQUARE_SIZE);
                }

                DrawBoard(g); //draw the board
            }
            i++;
        }

        /// <summary>
        /// Input keys
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up && snake.Dir != 3) snakeService.SetDirection(1);
            if (keyData == Keys.Right && snake.Dir != 4) snakeService.SetDirection(2);
            if (keyData == Keys.Down && snake.Dir != 1) snakeService.SetDirection(3);
            if (keyData == Keys.Left && snake.Dir != 2) snakeService.SetDirection(4);
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void eassy_cb_CheckedChanged(object sender, EventArgs e)
        {
            medium_cb.Checked = false;
            medium_cb.Checked = false;
            snakeService.StartGame(300);
        }

        private void medium_cb_CheckedChanged(object sender, EventArgs e)
        {
            eassy_cb.Checked = false;
            hard_cb.Checked = false;
            snakeService.StartGame(200);
        }

        private void hard_cb_CheckedChanged(object sender, EventArgs e)
        {
            eassy_cb.Checked = false;
            medium_cb.Checked = false;
            snakeService.StartGame(100);
        }
    }
}
