namespace Challenge159Easy
{
    using System;
    using System.Collections.Generic;

    public class Move
    {
        private static readonly Dictionary<MoveType, Dictionary<MoveType, string>> BeatMatrix =
            new Dictionary<MoveType, Dictionary<MoveType, string>>
            {
                {
                    MoveType.Rock,
                    new Dictionary<MoveType, string>
                    {
                        { MoveType.Lizard, "crushes" },
                        { MoveType.Scissors, "crushes" }
                    }
                },
                {
                    MoveType.Paper,
                    new Dictionary<MoveType, string> { { MoveType.Rock, "covers" }, { MoveType.Spock, "disproves" } }
                },
                {
                    MoveType.Scissors,
                    new Dictionary<MoveType, string> { { MoveType.Paper, "cut" }, { MoveType.Lizard, "decapitates" } }
                },
                {
                    MoveType.Lizard,
                    new Dictionary<MoveType, string> { { MoveType.Spock, "poisons" }, { MoveType.Paper, "eats" } }
                },
                {
                    MoveType.Spock,
                    new Dictionary<MoveType, string>
                    {
                        { MoveType.Scissors, "smashes" },
                        { MoveType.Rock, "vaporizes" }
                    }
                }
            };

        public Move(MoveType type)
        {
            Type = type;
        }

        public MoveType Type { get; private set; }

        public static Move GetRandom()
        {
            var values = Enum.GetValues(typeof(MoveType));
            var value = (MoveType)values.GetValue(Rng.Random.Next(values.Length));
            return new Move(value);
        }

        public static string GetResultString(Move user, Move cpu, MoveResult result)
        {
            if (result.Result == MoveResultType.Tie)
                return "Tie!";
            const string Format = "{0} {1} {2}";
            bool win = result.Result == MoveResultType.Win;
            return string.Format(Format, win ? user : cpu, result.Action, win ? cpu : user);
        }

        public static bool operator !=(Move left, Move right)
        {
            return !(left == right);
        }

        public static bool operator ==(Move left, Move right)
        {
            if ((object)left == null)
                return (object)right == null;
            return left.Equals(right);
        }

        public static Move Parse(string input)
        {
            MoveType type;
            bool valid = MoveType.TryParse(input, true, out type);
            if (valid)
                return new Move(type);
            throw new ArgumentException("Not a valid move type value", "input");
        }

        public static bool TryParse(string input, out Move move)
        {
            try
            {
                move = Parse(input);
                return true;
            }
            catch (ArgumentException)
            {
                move = null;
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            var move = obj as Move;
            return move != null && Equals(move);
        }

        public override int GetHashCode()
        {
            return (int)Type;
        }

        public MoveResult Play(Move move)
        {
            var result = new MoveResult();
            if (this == move)
            {
                result.Result = MoveResultType.Tie;
                return result;
            }

            var dict = BeatMatrix[Type];
            if (dict.ContainsKey(move.Type))
            {
                result.Result = MoveResultType.Win;
                result.Action = dict[move.Type];
            }
            else // User lost
            {
                result.Result = MoveResultType.Loss;
                result.Action = move.Play(this).Action; // Dirty dirty
            }

            return result;
        }

        public override string ToString()
        {
            return Type.ToString();
        }

        protected bool Equals(Move other)
        {
            return Type == other.Type;
        }
    }
}
