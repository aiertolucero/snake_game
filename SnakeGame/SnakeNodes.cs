using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class SnakeNodes
    {
        public SnakeNode headNode;

        public SnakeNodes()
        {
            headNode = null;
        }

        public void AddToEnd(int x, int y)
        {
            if(headNode == null)
            {
                headNode = new SnakeNode(x,y);
            }
            else
            {
                headNode.AddToEnd(x, y);
            }
        }
    }
}
