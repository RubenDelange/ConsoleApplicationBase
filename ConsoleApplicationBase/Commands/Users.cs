using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplicationBase.Models;

namespace ConsoleApplicationBase.Commands
{
    public static class Users
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

        public static string Create(string firstName, string lastName)
        {
            return ExecuteCommand(() =>
            {
                Nullable<int> maxId = (from u in SampleData.Users
                                       select u.Id).Max();
                int newId = 0;
                if (maxId.HasValue)
                {
                    newId = maxId.Value + 1;
                }

                var newUser = new User { Id = newId, FirstName = firstName, LastName = lastName };
                SampleData.Users.Add(newUser);

                return string.Format("Created a new user '{0} {1}'", firstName, lastName);
            });
        }


        public static string Get()
        {
            return ExecuteCommand(() =>
            {
                var sb = new StringBuilder();

                foreach (var user in SampleData.Users)
                {
                    sb.AppendLine(ConsoleFormatting.Indent(2) + string.Format("Id:{0} {1} {2}", user.Id, user.FirstName, user.LastName));
                }

                return sb.ToString();
            });
        }
    }
}
