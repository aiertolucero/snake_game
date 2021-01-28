using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class SnakeNode
    {
        public int x { get; set; }
        public int y { get; set; }
        public SnakeNode next;

        public SnakeNode()
        {

        }

        public SnakeNode(int X, int Y)
        {
            x = X;
            y = Y;
            next = null;
        }

        public void AddToEnd(int x, int y)
        {
            if(next == null)
            {
                next = new SnakeNode(x, y);
            }
            else
            {
                next.AddToEnd(x, y);
            }
        }
    }
}
