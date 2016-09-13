using System;
using System.Collections.Generic;

namespace Aheui__
{
    public class Aheui
    {
        public string[] Script { get; private set; }
        public string OriginalScript { get; }

        public event Func<string, InputType> InputNeeded;
        public event Action<string> OutputReleased;

        public Char CurrentChar { get { return Script[CurrentLocation.Y][CurrentLocation.X]; } }
        public Location CurrentLocation { get; private set; }
        private Stack<int>[] _stacks;
        [DebugOnly]
        public event Action<int, char> StackPushed;
        [DebugOnly]
        public event Action<int, char> StackPopped;


        public bool IsFinished { get { throw new NotImplementedException(); } }

        public Aheui(string script)
        {
            Script = script.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            OriginalScript = script;
        }
        public Aheui(string[] script)
        {
            Script = script;
            OriginalScript = string.Join("\r\n", script);
        }

        public void Reset()
        {
            _stacks = new Stack<int>[28];
        }

        public void RunAll()
        {
            while (IsFinished)
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

        [DebugOnly]
        public void RunChar(char c)
        {

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

    public class DebugOnly : Attribute
    {

    }
}
