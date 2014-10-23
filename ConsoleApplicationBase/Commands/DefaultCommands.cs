using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// All console commands must be in the sub-namespace Commands:
namespace ConsoleApplicationBase.Commands
{
    // Must be a public static class:
    public static class DefaultCommands
    {
        #region private methods

        private static string ExecuteCommand(Func<string> command)
        {
            var resultAsString = command();

            if (string.IsNullOrEmpty(resultAsString))
            {
                return "Done!";
            }
            else
            {
                return resultAsString;
            }
        }

        /*
        private static string ExecuteCommand(Func<object[], string> command, params object[] parameters)
        {
            var resultAsString = command(parameters);

            if (string.IsNullOrEmpty(resultAsString))
            {
                return "Done!";
            }
            else
            {
                return resultAsString;
            }
        }
         */

        private static string ExecuteVoidCommand(Action voidCommand)
        {
            voidCommand();

            return "Done!";
        }

        #endregion

        // Methods used as console commands must be public and must return a string
        public static string DoSomething(int id, string data)
        {
            return ExecuteCommand(() => string.Format(ConsoleFormatting.Indent(2) + "I did something to the record Id {0} and saved the data '{1}'", id, data));
        }


        public static string DoSomethingElse(DateTime date)
        {
            return ExecuteCommand(() => string.Format(ConsoleFormatting.Indent(2) + "I did something else on {0}", date));
        }


        public static string DoSomethingOptional(int id, string data = "No Data Provided")
        {
            return ExecuteCommand(() =>
                                {
                                    var result = string.Format(ConsoleFormatting.Indent(2) +
                                                                "I did something to the record Id {0} and saved the data {1}", id, data);

                                    if (data == "No Data Provided")
                                    {
                                        result = string.Format(ConsoleFormatting.Indent(2) +
                                                                "I did something to the record Id {0} but the optinal parameter "
                                                                + "was not provided, so I saved the value '{1}'", id, data);
                                    }

                                    return result;
                                });
        }
    }
}
