using Huy_Phuong.Interfaces;

namespace Huy_Phuong.Engine.Commands
{
    public class AddTheatreCommand : Command
    {
        public AddTheatreCommand(IAppEngine appEngine) 
            : base(appEngine)
        {
        }

        public override string Execute(string[] parameters)
        {
            string theatreName = parameters[1];
            this.AppEngine.PerformanceDatabase.AddTheatre(theatreName);

            string actionResult = "Theatre added";

            return actionResult;
        }
    }
}
