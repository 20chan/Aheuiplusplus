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

        public Aheui(string script, bool debug = false)
        {
            Script = script.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            OriginalScript = script;

            IsDebugging = debug;
        }
        public Aheui(string[] script, bool debug = false)
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

            switch(letter.Chosung)
            {

            }
        }

        public Location GetNextLoc()
        {
            throw new NotImplementedException();
        }
        public char GetNextChar()
        {
            Location nextLoc = GetNextLoc();
            return Script[nextLoc.Y][nextLoc.X];
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
        String
    }
}
