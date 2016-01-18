namespace HotelBookingSystem.Views.Shared
{
    using System.Text;
    using Infrastructure;

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
