using BusinessTier;
using System.ServiceModel;
using System.Timers;

namespace ServiceTier
{

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)] //since there is only 1 user, there is no need for more than 1 service instance or concurrency issues
    public class SnakeService : ISnakeService
    {
        private Timer timer; //controls how fast the game will paly
        private IGameController gameController;
        private object callbackObj;
        private ISnakeCallback callback;

        /// <summary>
        /// starts the game
        /// </summary>
        public void StartGame(int interval)
        {
            //initialize callback object to client
            callbackObj = OperationContext.Current.GetCallbackChannel<ISnakeCallback>();
            callback = (ISnakeCallback)callbackObj;
            //initialize controller object
            gameController = new GameController();
            //make sure timer is not running from previouse run
            if(timer != null)
                timer.Stop();
            ///initialize timer
            timer = new Timer
            {
                Interval = interval, //make timer perform action 5 times per second 
                AutoReset = true, //make sure timer will reset
            };
            timer.Elapsed += new ElapsedEventHandler(Move); //when interval is done, call MOVE function
            timer.Start();

            callback.UpdateSnake(gameController.GetSnake()); //give client the snake to draw on screen
            callback.UpdateBoard(gameController.GetBoard()); //give client the board to draw on screen
        }

        /// <summary>
        /// Timer event action
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void Move(object source, ElapsedEventArgs e)
        {
            gameController.MoveSnake(); //move the snake
            switch (gameController.CheckCollisions())
            {
                case 0: //dead
                    timer.Stop();
                    callback.UpdateSnake(null);
                    break;
                case 2: //grow
                    callback.UpdateSnake(gameController.GetSnake());
                    callback.UpdateBoard(gameController.GetBoard());
                    break;
                default: //go on
                    callback.UpdateSnake(gameController.GetSnake());
                    break;
            }
        }

        /// <summary>
        /// Forward user's request to change direction
        /// </summary>
        /// <param name="d"></param>
        public void SetDirection(int d)
        {
            gameController.SetDir(d);
        }
    }
    
}
