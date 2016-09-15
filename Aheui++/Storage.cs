using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aheui__
{
    public class Storage<T>
    {
        public event Action<int, char> StackPushed;
        public event Action<int, char> StackPopped;

        private const int _queueIndex = 21;

        public int SelectedStorage { get; set; }

        private Stack<T>[] _stacks;
        private LinkedList<T> _queue;

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Push(T var)
        {
            throw new NotImplementedException();
        }

        public T Pop()
        {
            throw new NotImplementedException();
        }

        public void Duplicate()
        {
            throw new NotImplementedException();
        }

        public void Swap()
        {
            throw new NotImplementedException();
        }

        public void Move(int storage)
        {
            throw new NotImplementedException();
        }
    }
}
