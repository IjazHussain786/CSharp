using System.Text;
using Buls.Infrastructure;

namespace Buls.Views.Shared
{
    public class Error : View
    {
        public Error(string message)
            : base(message)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var message = this.Model as string;
            viewResult.AppendLine(message);
        }
    }
}
