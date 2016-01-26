using System;

namespace Huy_Phuong.Interfaces
{
    public interface IPerformance
    {
        string Theater { get; }

        string Name { get; }

        DateTime StartDateTime { get; }

        TimeSpan PerformanceDuration { get; }

        decimal TicketPrice { get; }
    }
}
