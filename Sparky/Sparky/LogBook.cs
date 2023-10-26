using System.Reflection.Metadata.Ecma335;

namespace Sparky
{
    public interface ILogBook
    {
        public int LogSeverity { get; set; }
        public string LogType { get; set; }
        void Message(string message);
        bool LogToDb(string message);
        bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal);
        string MessageWithReturnString(string message);
        bool LogWithOutputResult(string str, out string outputStr);
        bool LogWithRefObj(ref Customer customer);
    }

    public class LogBook : ILogBook
    {
        public int LogSeverity { get; set; }
        public string LogType { get; set; }

        public bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal)
        {
            if (balanceAfterWithdrawal > 0)
            {
                Console.WriteLine("Success");
                return true;
            }

            Console.WriteLine("Failed");
            return false;
        }

        public bool LogToDb(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public bool LogWithOutputResult(string str, out string outputStr)
        {
            outputStr = "Hello " + str;
            return true;
        }

        public bool LogWithRefObj(ref Customer customer)
        {
            return true;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public string MessageWithReturnString(string message)
        {
            Console.WriteLine(message);
            return message.ToLower();
        }
    }

    public class LogFaker : ILogBook
    {
        public int LogSeverity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LogType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal)
        {
            return true;
        }

        public bool LogToDb(string message)
        {
            return true;
        }

        public bool LogWithOutputResult(string str, out string outputStr)
        {
            outputStr = "";
            return true;
        }

        public bool LogWithRefObj(ref Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Message(string message) { }

        public string MessageWithReturnString(string message)
        {
            return string.Empty;
        }
    }
}
