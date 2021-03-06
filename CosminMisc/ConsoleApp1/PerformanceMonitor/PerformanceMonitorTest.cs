﻿using System.Threading;
using ConsoleApp1.Common;

namespace ConsoleApp1.PerformanceMonitor
{
    class PerformanceMonitorTest
    {
        public static void RunTest()
        {
            PerformanceMonitor perfMon = new PerformanceMonitor();

            Call_1(perfMon);
        }

        private static void Call_1(PerformanceMonitor perfMon)
        {
            perfMon.StartCall(Tools.GetCaller());
            Thread.Sleep(300);

            Call_1_1(perfMon);

            Call_1_2(perfMon);

            Thread.Sleep(400);

            Call_1_1(perfMon);
            Call_1_2(perfMon);

            perfMon.EndCall();
        }

        private static void Call_1_1(PerformanceMonitor perfMon)
        {
            perfMon.StartCall(Tools.GetCaller());
            Thread.Sleep(1000);
            Call_1_1_1(perfMon);
            perfMon.EndCall();
        }

        private static void Call_1_2(PerformanceMonitor perfMon)
        {
            perfMon.StartCall(Tools.GetCaller());
            Thread.Sleep(3000);
            perfMon.EndCall();
        }

        private static void Call_1_1_1(PerformanceMonitor perfMon)
        {
            perfMon.StartCall(Tools.GetCaller());
            Thread.Sleep(100);
            perfMon.EndCall();
        }
    }
}
