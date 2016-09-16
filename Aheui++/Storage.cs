using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aheui__
{
    public class Storage<T>
    {
        private Dictionary<char, Stack<T>> _stacks;
        public event Action<int, char> StackPushed;
        public event Action<int, char> StackPopped;

        private const int _queueIndex = 21;

        public char SelectedStorage { get; set; }

        //private Stack<T>[] _stacks;
        private LinkedList<T> _queue;

        public Storage()
        {
            Reset();
        }

        public void Reset()
        {
            _stacks = new Dictionary<char, Stack<T>>()
            {
            { ' ',  new Stack<T>() },
            { 'ㄱ', new Stack<T>() },
            { 'ㄴ', new Stack<T>() },
            { 'ㄷ', new Stack<T>() },
            { 'ㄹ', new Stack<T>() },
            { 'ㅁ', new Stack<T>() },
            { 'ㅂ', new Stack<T>() },
            { 'ㅅ', new Stack<T>() },
            { 'ㅈ', new Stack<T>() },
            { 'ㅊ', new Stack<T>() },
            { 'ㅋ', new Stack<T>() },
            { 'ㅌ', new Stack<T>() },
            { 'ㅍ', new Stack<T>() },
            { 'ㄲ', new Stack<T>() },
            { 'ㄳ', new Stack<T>() },
            { 'ㄵ', new Stack<T>() },
            { 'ㄶ', new Stack<T>() },
            { 'ㄺ', new Stack<T>() },
            { 'ㄻ', new Stack<T>() },
            { 'ㄼ', new Stack<T>() },
            { 'ㄽ', new Stack<T>() },
            { 'ㄾ', new Stack<T>() },
            { 'ㄿ', new Stack<T>() },
            { 'ㅀ', new Stack<T>() },
            { 'ㅄ', new Stack<T>() },
            { 'ㅆ', new Stack<T>() },
        };
            SelectedStorage = ' ';
            _queue = new LinkedList<T>();
        }

        public bool CanPop(int count)
        {
            if (SelectedStorage == 'ㅇ')
                return _queue.Count >= count;
            return _stacks[SelectedStorage].Count >= count;
        }

        public void Push(T var)
        {
            if (SelectedStorage == 'ㅇ')
                _queue.AddFirst(var);
            else
                _stacks[SelectedStorage].Push(var);
        }

        public T Pop()
        {
            if (SelectedStorage == 'ㅇ')
            {
                var res = _queue.Last();
                _queue.RemoveLast();
                return res;
            }
            return _stacks[SelectedStorage].Pop();
        }

        public void Duplicate()
        {
            var val = Pop();
            Push(val);
            Push(val);
        }

        public void Swap()
        {
            var first = Pop();
            var last = Pop();
            Push(first);
            Push(last);
        }

        public void Move(char storage)
        {
            _stacks[storage].Push(Pop());
        }
    }
}
