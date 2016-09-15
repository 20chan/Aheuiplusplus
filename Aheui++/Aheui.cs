using System;
using System.Collections.Generic;

namespace Aheui__
{
    public class Aheui<T>
    {
        #region static
        public static string Execute(string script)
        {
            System.Text.StringBuilder result = new System.Text.StringBuilder();
            var a = new Aheui<T>(script);
            a.OutputReleased += (output) => result.Append(output);

            return result.ToString();
        }
        #endregion

        public string[] Script { get; private set; }
        public string OriginalScript { get; }

        public event Func<string, InputType> InputNeeded;
        public event Action<string> OutputReleased;

        public Char CurrentChar { get { return Script[CurrentLocation.Y][CurrentLocation.X]; } }
        public Location CurrentLocation { get; private set; }

        private Storage<T> _storage;

        public bool IsDebugging { get; private set; }
        public bool IsFinished => Korean.ParseChar(CurrentChar).Chosung == 'ㅎ';

        private Aheui()
        {
            _storage = new Storage<T>();
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
                this.CurrentLocation = GetNextLoc();
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
                        dynamic first = _storage.Pop();
                        dynamic last = _storage.Pop();
                        _storage.Push(first + last);
                        break;
                    }
                case 'ㄸ':
                    {
                        dynamic first = _storage.Pop();
                        dynamic last = _storage.Pop();
                        _storage.Push(first * last);
                        break;
                    }
                case 'ㅌ':
                    {
                        dynamic first = _storage.Pop();
                        dynamic last = _storage.Pop();
                        _storage.Push(first - last);
                        break;
                    }
                case 'ㄴ':
                    {
                        dynamic first = _storage.Pop();
                        dynamic last = _storage.Pop();
                        _storage.Push(first / last);
                        break;
                    }
                case 'ㄹ':
                    {
                        dynamic first = _storage.Pop();
                        dynamic last = _storage.Pop();
                        _storage.Push(first % last);
                        break;
                    }

                case 'ㅂ':
                    {
                        _storage.Push(GetInput(letter.Jongsung));
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

            return res;
        }
        public char GetNextChar()
        {
            Location nextLoc = GetNextLoc();
            return Script[nextLoc.Y][nextLoc.X];
        }

        private T GetInput(char arg)
        {
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
