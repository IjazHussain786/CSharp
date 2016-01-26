using Huy_Phuong.Interfaces;

namespace Huy_Phuong.Engine.Commands
{
    public abstract class Command
    {
        protected Command(IAppEngine appEngine)
        {
            this.AppEngine = appEngine;
        }

        public IAppEngine AppEngine { get; set; }

        public abstract string Execute(string[] commandArgs);
    }
}
