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

        public Storage()
        {
            Reset();
        }

        public void Reset()
        {
            _stacks = new Stack<T>[26];
            for (int i = 0; i < 26; i++)
                _stacks[i] = new Stack<T>();
            _queue = new LinkedList<T>();
        }

        public void Push(T var)
        {
            _stacks[SelectedStorage].Push(var);
        }

        public T Pop()
        {
            return _stacks[SelectedStorage].Pop();
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
