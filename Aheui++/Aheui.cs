using System;
using System.Collections.Generic;

namespace Aheui__
{
    public abstract class Aheui<T>
    {
        protected abstract T StringToType(string val);
        protected abstract T Add(T a, T b);
        protected abstract T Sub(T a, T b);
        protected abstract T Mul(T a, T b);
        protected abstract T Div(T a, T b);
        protected abstract T Per(T a, T b);

        public string[] Script { get; private set; }
        public string OriginalScript { get; }

        public event Func<InputType, string> InputNeeded;
        public event Action<string> OutputReleased;

        public Char CurrentChar { get { return Script[CurrentLocation.Y][CurrentLocation.X]; } }
        public Location CurrentLocation { get; private set; }

        private Storage<T> _storage;

        public bool IsDebugging { get; private set; }
        public bool IsFinished => Korean.ParseChar(CurrentChar).Chosung == 'ㅎ';

        private Aheui()
        {
            _storage = new Storage<T>();
            Reset();
        }

        public Aheui(string script, bool debug = false) : this()
        {
            Script = script.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            OriginalScript = script;

            IsDebugging = debug;
        }
        public Aheui(string[] script, bool debug = false) : this()
        {
            Script = script;
            OriginalScript = string.Join("\r\n", script);

            IsDebugging = debug;
        }

        public void Reset()
        {
            _storage.Reset();
            CurrentLocation = new Location(0, 0, Direction.Right, 1);
        }

        public void RunAll()
        {
            while (!IsFinished)
                RunStep();
        }
        public void RunStep()
        {
            RunStep(1);
        }
        public void RunStep(int step)
        {
            while(step-- > 0 && !IsFinished)
            {
                RunChar(CurrentChar);
                //DO
            }
        }
        
        public void RunChar(char c)
        {
            Letter letter = Korean.ParseChar(c);
            Location nextLoc = GetNextLoc();

            switch(letter.Chosung)
            {
                case 'ㅎ':
                    break;
                case 'ㄷ':
                    {
                        T first = _storage.Pop();
                        T last = _storage.Pop();
                        _storage.Push(Add(last, first));
                        break;
                    }
                case 'ㄸ':
                    {
                        T first = _storage.Pop();
                        T last = _storage.Pop();
                        _storage.Push(Mul(last, first));
                        break;
                    }
                case 'ㅌ':
                    {
                        T first = _storage.Pop();
                        T last = _storage.Pop();
                        _storage.Push(Sub(last, first));
                        break;
                    }
                case 'ㄴ':
                    {
                        T first = _storage.Pop();
                        T last = _storage.Pop();
                        _storage.Push(Div(last, first));
                        break;
                    }
                case 'ㄹ':
                    {
                        T first = _storage.Pop();
                        T last = _storage.Pop();
                        _storage.Push(Per(last, first));
                        break;
                    }

                case 'ㅂ':
                    {
                        _storage.Push(GetInput(letter.Jongsung));
                        break;
                    }
                case 'ㅁ':
                    {
                        OutputReleased?.Invoke(GetOutput(_storage.Pop(), letter.Jongsung));
                        break;
                    }
            }

            CurrentLocation = nextLoc;
        }

        public Location GetNextLoc(bool reversed = false)
        {
            char jwung = Korean.ParseChar(CurrentChar).Jwungsung;
            Location res = CurrentLocation;

            // Direction
            switch(jwung)
            {
                case 'ㅏ':
                case 'ㅑ':
                    res.Direction = Direction.Right;
                    break;
                case 'ㅓ':
                case 'ㅕ':
                    res.Direction = Direction.Left;
                    break;
                case 'ㅗ':
                case 'ㅛ':
                    res.Direction = Direction.Up;
                    break;
                case 'ㅜ':
                case 'ㅠ':
                    res.Direction = Direction.Down;
                    break;

                case 'ㅣ':
                    if (res.Direction == Direction.Left)
                        res.Direction = Direction.Right;
                    else if (res.Direction == Direction.Right)
                        res.Direction = Direction.Left;
                    break;
                case 'ㅡ':
                    if (res.Direction == Direction.Up)
                        res.Direction = Direction.Down;
                    else if (res.Direction == Direction.Down)
                        res.Direction = Direction.Up;
                    break;
                case 'ㅢ':
                    if (res.Direction == Direction.Left)
                        res.Direction = Direction.Right;
                    else if (res.Direction == Direction.Right)
                        res.Direction = Direction.Left;
                    else if (res.Direction == Direction.Up)
                        res.Direction = Direction.Down;
                    else if (res.Direction == Direction.Down)
                        res.Direction = Direction.Up;
                    break;
                default:
                    throw new AheuiException();
            }

            //Power
            switch(jwung)
            {
                case 'ㅏ':
                case 'ㅓ':
                case 'ㅗ':
                case 'ㅜ':
                    res.Power = 1;
                    break;
                case 'ㅑ':
                case 'ㅕ':
                case 'ㅛ':
                case 'ㅠ':
                    res.Power = 2;
                    break;
                default:
                    break;
            }

            if(reversed)
            {
                if (res.Direction == Direction.Left)
                    res.Direction = Direction.Right;
                else if (res.Direction == Direction.Right)
                    res.Direction = Direction.Left;
                else if (res.Direction == Direction.Up)
                    res.Direction = Direction.Down;
                else if (res.Direction == Direction.Down)
                    res.Direction = Direction.Up;
            }

            switch(res.Direction)
            {
                case Direction.Left:
                    res.X -= res.Power;
                    break;
                case Direction.Right:
                    res.X += res.Power;
                    break;
                case Direction.Up:
                    res.Y -= res.Power;
                    break;
                case Direction.Down:
                    res.Y += res.Power;
                    break;
            }

            return res;
        }
        public char GetNextChar()
        {
            Location nextLoc = GetNextLoc();
            return Script[nextLoc.Y][nextLoc.X];
        }

        private T GetInput(char arg)
        {
            if(arg == 'ㅇ')
            {
                return StringToType(InputNeeded?.Invoke(InputType.Number));
            }
            else if(arg == 'ㅎ')
            {
                int i = (InputNeeded?.Invoke(InputType.Char))[0];
                return StringToType(i.ToString());
            }
            else
            {
                return StringToType(Korean.GetStrokeCount(arg).ToString());
            }
        }

        private string GetOutput(T val, char arg)
        {
            if (arg == 'ㅇ')
            {
                dynamic d = val;
                return ((int)d).ToString();
            }
            else if (arg == 'ㅎ')
            {
                dynamic d = val;
                return ((char)d).ToString();
            }
            else
                throw new NotImplementedException();
        }

        private void Push(T val)
        {
            _storage.Push(val);
        }

        private T Pop()
        {
            return _storage.Pop();
        }
    }

    public struct Location
    {
        public int X, Y;
        public Direction Direction;
        public int Power;

        public Location(int x, int y, Direction direct, int power)
        {
            X = x;
            Y = y;
            Direction = direct;
            Power = power;
        }
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public enum InputType
    {
        None,
        Number,
        Char
    }
}
