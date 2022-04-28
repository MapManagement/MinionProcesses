using System.Diagnostics;

namespace MinionProcesses.Helpers
{
    public class ProcessRunner
    {
        #region Fields

        private string _command;
        private string _arguments;

        #endregion

        #region Constructor

        public ProcessRunner(string command, string arguments)
        {
            _command = command;
            _arguments = arguments;
        }

        #endregion

        public void Run()
        {
            var process = new Process();
            process.StartInfo.FileName = _command;
            process.StartInfo.Arguments = _arguments;

            process.Start();
        }
    }
}