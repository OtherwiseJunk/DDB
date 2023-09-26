using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartsDiscordBots.Modules.Indecision.Models
{
    public class DiceRollingParameters
    {
        public int DiceFaceCount { get; init; }
        public int NumberOfDice { get; init;  }
        public Operation Operation { get; set; }
        public int Operand { get; set; }
    }

    public enum Operation
    {
        None,
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
}
