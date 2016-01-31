using HotelBookingSystem.Core;
using System;
using System.Threading;
using System.Globalization;
using System.Reflection;

public class HotelBookingSystemMain
{
    public static void Main()
    {
        Engine engine = new Engine();
        engine.StartOperation();
    }
}
