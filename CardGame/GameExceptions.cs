using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class GameExceptions : Exception { }
    public class NotValidPlayerException : GameExceptions { }
    public class NotValidBotException : GameExceptions { }
    public class NullNameException : GameExceptions { }
    public class NotEnoughCardException : GameExceptions { }
    public class WrongAttributeException : GameExceptions { }
}