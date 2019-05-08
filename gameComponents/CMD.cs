// This is the command interpreter, to parse whatever is typed by the user
using System;
using System.Collections.Generic;

namespace zuul_core
{

    class CMD
    {
        private static List<string> validCommands = new List<string>(){
            "look", "examine", "int", "pick", "bag", "loot", "use", "help", "history", "quit"
        };

        private Boolean isCommand(string aString)
        {
            return validCommands.Contains(aString);
        }

        //Returns every command possible
        public string showAll()
        {
            string commands = "";
            foreach (string cmd in validCommands)
            {
                commands += $"{cmd} ";
            }
            return commands;
        }

        //Check if the string first word is a valid word, then return the tokens or a string[] with null
        public string[] parse(string astring)
        {
            string[] tokens = astring.Trim().ToLowerInvariant().Split(" ");
            return isCommand(tokens[0]) ? tokens : new string[] { null };
        }
    }
}