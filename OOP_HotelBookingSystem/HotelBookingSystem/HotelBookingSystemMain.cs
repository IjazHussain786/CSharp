using HotelBookingSystem.Core;
using System;
using System.Threading;
using System.Globalization;

public class HotelBookingSystemMain
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Engine engine = new Engine();
        engine.StartOperation();
    }
}
