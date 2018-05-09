using ModelTier;

namespace BusinessTier
{
    public interface IGameController
    {
        Board GetBoard();
        ModelTier.Snake GetSnake();
        void SetDir(int d);
        void MoveSnake();
        int CheckCollisions();
        void AddObstacle(int x, int y, bool type);
        void RemoveObstacle(int x, int y);
    }
}
