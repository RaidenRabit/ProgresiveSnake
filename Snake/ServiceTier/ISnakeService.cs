using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ModelTier;

namespace ServiceTier
{
    [ServiceContract(CallbackContract = typeof(ISnakeCallback))]
    public interface ISnakeService
    {
        /// <summary>
        /// Start the game, it will callback to update snake and board
        /// </summary>
        /// <param name="interval"> how fast the game should run</param>
        [OperationContract(IsOneWay = true)]
        void StartGame(int interval);

        /// <summary>
        /// Change snake's direction
        /// </summary>
        /// <param name="d"></param>
        [OperationContract(IsOneWay = true)]
        void SetDirection(int d);
    }

    public interface ISnakeCallback
    {
        /// <summary>
        /// callback to client to update the snake
        /// </summary>
        /// <param name="snake"></param>
        [OperationContract(IsOneWay = true)]
        void UpdateSnake(Snake snake);

        /// <summary>
        /// callback to client to update the board
        /// </summary>
        /// <param name="board"></param>
        [OperationContract(IsOneWay = true)]
        void UpdateBoard(Board board);
    }
}
