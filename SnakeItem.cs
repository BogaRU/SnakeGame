namespace SnakeGame
{
    public class SnakeItem
    {
        public Point Place;
        public SnakeItem Next;
        public SnakeItem(Point item, SnakeItem next = null)
        {
            Place = item;
            Next = next;
        }
    }
}
