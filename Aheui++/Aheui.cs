using System;
using System.Collections.Generic;

namespace Aheui__
{
    public abstract class Aheui<T>
    {
        protected abstract T StringToType(string val);
        protected abstract string TypeToInt(T val);
        protected abstract string TypeToChar(T val);
        protected abstract T Add(T a, T b);
        protected abstract T Sub(T a, T b);
        protected abstract T Mul(T a, T b);
        protected abstract T Div(T a, T b);
        protected abstract T Per(T a, T b);
        protected abstract bool IsBiggerOrEqual(T a, T b);

        public Letter[,] Script { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public string OriginalScript { get; private set; }

        public event Func<InputType, string> InputNeeded;
        public event Action<string> OutputReleased;

        public Letter CurrentLetter { get { return Script[CurrentLocation.X, CurrentLocation.Y]; } }
        public Location CurrentLocation { get; private set; }

        private Storage<T> _storage;

        public bool IsDebugging { get; private set; }
        public bool IsFinished => CurrentLetter.Chosung == 'ㅎ';

        private Aheui()
        {
            _storage = new Storage<T>();
            Reset();
        }

        public Aheui(string script, bool debug = false) : this()
        {
            ParseScript(script);
            IsDebugging = debug;
        }

        public void Reset()
        {
            _storage.Reset();
            CurrentLocation = new Location(0, 0, Direction.Right, 1);
        }

        private void ParseScript(string script)
        {
            string[] splited = script.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            int width = 0, height = splited.Length;
            foreach (string s in splited)
                width = Math.Max(s.Length, width);

            Script = new Letter[width, height];

            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    if (splited[j].Length <= i)
                        Script[i, j] = new Letter(true);
                    else
                        Script[i, j] = Korean.ParseChar(splited[j][i]);
                }
            OriginalScript = script;

            Width = width;
            Height = height;
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
            while (step-- > 0 && !IsFinished)
            {
                RunChar(CurrentLetter);
                //DO
            }
        }

        public void RunChar(Letter letter)
        {
            Location nextLoc = GetNextDirection(CurrentLocation);

            switch (letter.Chosung)
            {
                case 'ㅎ':
                    break;
                case 'ㄷ':
                    {
                        if (!_storage.CanPop(2))
                        {
                            nextLoc.ReverseDirection();
                            break;
                        }
                        T first = _storage.Pop();
                        T last = _storage.Pop();
                        _storage.Push(Add(last, first));
                        break;
                    }
                case 'ㄸ':
                    {
                        if (!_storage.CanPop(2))
                        {
                            nextLoc.ReverseDirection();
                            break;
                        }
                        T first = _storage.Pop();
                        T last = _storage.Pop();
                        _storage.Push(Mul(last, first));
                        break;
                    }
                case 'ㅌ':
                    {
                        if (!_storage.CanPop(2))
                        {
                            nextLoc.ReverseDirection();
                            break;
                        }
                        T first = _storage.Pop();
                        T last = _storage.Pop();
                        _storage.Push(Sub(last, first));
                        break;
                    }
                case 'ㄴ':
                    {
                        if (!_storage.CanPop(2))
                        {
                            nextLoc.ReverseDirection();
                            break;
                        }
                        T first = _storage.Pop();
                        T last = _storage.Pop();
                        _storage.Push(Div(last, first));
                        break;
                    }
                case 'ㄹ':
                    {
                        if (!_storage.CanPop(2))
                        {
                            nextLoc.ReverseDirection();
                            break;
                        }
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
                        if (!_storage.CanPop(1))
                        {
                            nextLoc.ReverseDirection();
                            break;
                        }
                        if (letter.Jongsung == 'ㅇ' || letter.Jongsung == 'ㅎ')
                            OutputReleased?.Invoke(GetOutput(_storage.Pop(), letter.Jongsung));
                        else
                            _storage.Pop();
                        break;
                    }
                case 'ㅃ':
                    {
                        if (!_storage.CanPop(1))
                        {
                            nextLoc.ReverseDirection();
                            break;
                        }
                        try
                        {
                            _storage.Duplicate();
                        }
                        catch { }
                        break;
                    }
                case 'ㅍ':
                    {
                        if (!_storage.CanPop(2))
                        {
                            nextLoc.ReverseDirection();
                            break;
                        }
                        _storage.Swap();
                        break;
                    }
                case 'ㅅ':
                    {
                        _storage.SelectedStorage = letter.Jongsung;
                        break;
                    }
                case 'ㅆ':
                    {
                        if (!_storage.CanPop(1))
                        {
                            nextLoc.ReverseDirection();
                            break;
                        }
                        _storage.Move(letter.Jongsung);
                        break;
                    }
                case 'ㅈ':
                    {
                        if (!_storage.CanPop(2))
                        {
                            nextLoc.ReverseDirection();
                            break;
                        }
                        T first = _storage.Pop();
                        T last = _storage.Pop();
                        if (IsBiggerOrEqual(first, last))
                            _storage.Push(StringToType("1"));
                        else
                            _storage.Push(StringToType("0"));
                        break;
                    }
                case 'ㅊ':
                    {
                        if (!_storage.CanPop(1))
                        {
                            nextLoc.ReverseDirection();
                            break;
                        }
                        if (_storage.Pop().ToString() == "0")
                        {
                            nextLoc.ReverseDirection();
                            break;
                        }
                        else
                            break;
                    }
            }

            CurrentLocation = GetNextLoc(nextLoc);
        }

        public Location GetNextDirection(Location loc, bool reversed = false)
        {
            char jwung = CurrentLetter.Jwungsung;
            Location res = loc;

            // Direction
            switch (jwung)
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
                    res.ReverseDirection();
                    break;
                default:
                    break;
            }

            //Power
            switch (jwung)
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

            if (reversed)
            {
                res.ReverseDirection();
            }
            return res;
        }
        private Location GetNextLoc(Location loc)
        {
            switch (loc.Direction)
            {
                case Direction.Left:
                    if (loc.X - loc.Power < 0)
                        loc.X = Width - 1;
                    else
                        loc.X -= loc.Power;
                    break;
                case Direction.Right:
                    if (loc.X + loc.Power >= Width)
                        loc.X = 0;
                    else
                        loc.X += loc.Power;
                    break;
                case Direction.Up:
                    if (loc.Y - loc.Power < 0)
                        loc.Y = Height - 1;
                    else
                        loc.Y -= loc.Power;
                    break;
                case Direction.Down:
                    if (loc.Y + loc.Power >= Height)
                        loc.Y = 0;
                    else
                        loc.Y += loc.Power;
                    break;
            }
            return loc;
        }
        public Letter GetNextLetter()
        {
            Location nextLoc = GetNextLoc(GetNextDirection(CurrentLocation));
            return Script[nextLoc.X, nextLoc.Y];
        }

        private T GetInput(char arg)
        {
            if (arg == 'ㅇ')
            {
                return StringToType(InputNeeded?.Invoke(InputType.Number));
            }
            else if (arg == 'ㅎ')
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
                return TypeToInt(val);
            }
            else if (arg == 'ㅎ')
            {
                return TypeToChar(val);
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

        public void ReverseDirection()
        {
            if (Direction == Direction.Left)
                Direction = Direction.Right;
            else if (Direction == Direction.Right)
                Direction = Direction.Left;
            else if (Direction == Direction.Up)
                Direction = Direction.Down;
            else if (Direction == Direction.Down)
                Direction = Direction.Up;
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