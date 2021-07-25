using Microsoft.IdentityModel.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinForm
{
    public class GCMonitor
    {
        public static volatile GCMonitor instance;
        public static object SyncRoot = new object();

        private Thread gcMonitorThread;
        private ThreadStart gcMonitorThreadStart;

        private bool isRunning;

        public static GCMonitor getInstance()
        {
            if (instance == null)
            {
                lock (SyncRoot)
                {
                    return new GCMonitor();
                }
            }
            return instance;
        }
        private GCMonitor()
        {
            isRunning = false;
            gcMonitorThreadStart = new ThreadStart(DoGCMonitoring);
            gcMonitorThread = new Thread(gcMonitorThreadStart);
        }

        public void StartGCMonitoring()
        {
            if (!isRunning)
            {
                gcMonitorThread.Start();
                isRunning = true;
                AllocationTest();
            }
        }
        private void DoGCMonitoring()
        {
            long beforeGC = 0;
            long afterGC = 0;

            try
            {

                while (true)
                {
                    // Check for a notification of an approaching collection.
                    GCNotificationStatus s = GC.WaitForFullGCApproach(10000);
                    if (s == GCNotificationStatus.Succeeded)
                    {
                        //Call event
                        beforeGC = GC.GetTotalMemory(false);
                        Console.WriteLine("===> GC <=== " + Environment.NewLine + "GC is about to begin. Memory before GC: %d", beforeGC);
                        GC.Collect();

                    }
                    else if (s == GCNotificationStatus.Canceled)
                    {
                        Console.WriteLine("===> GC <=== " + Environment.NewLine + "GC about to begin event was cancelled");
                    }
                    else if (s == GCNotificationStatus.Timeout)
                    {
                        Console.WriteLine("===> GC <=== " + Environment.NewLine + "GC about to begin event was timeout");
                    }
                    else if (s == GCNotificationStatus.NotApplicable)
                    {
                        Console.WriteLine("===> GC <=== " + Environment.NewLine + "GC about to begin event was not applicable");
                    }
                    else if (s == GCNotificationStatus.Failed)
                    {
                        Console.WriteLine("===> GC <=== " + Environment.NewLine + "GC about to begin event failed");
                    }

                    // Check for a notification of a completed collection.
                    s = GC.WaitForFullGCComplete(10000);
                    if (s == GCNotificationStatus.Succeeded)
                    {
                        //Call event
                        afterGC = GC.GetTotalMemory(false);
                        Console.WriteLine("===> GC <=== " + Environment.NewLine + "GC has ended. Memory after GC: %d", afterGC);

                        long diff = beforeGC - afterGC;

                        if (diff > 0)
                        {
                            Console.WriteLine("===> GC <=== " + Environment.NewLine + "Collected memory: %d", diff);
                        }

                    }
                    else if (s == GCNotificationStatus.Canceled)
                    {
                        Console.WriteLine("===> GC <=== " + Environment.NewLine + "GC finished event was cancelled");
                    }
                    else if (s == GCNotificationStatus.Timeout)
                    {
                        Console.WriteLine("===> GC <=== " + Environment.NewLine + "GC finished event was timeout");
                    }
                    else if (s == GCNotificationStatus.NotApplicable)
                    {
                        Console.WriteLine("===> GC <=== " + Environment.NewLine + "GC finished event was not applicable");
                    }
                    else if (s == GCNotificationStatus.Failed)
                    {
                        Console.WriteLine("===> GC <=== " + Environment.NewLine + "GC finished event failed");
                    }

                    Thread.Sleep(1500);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("  ********************   Garbage Collector Error  ************************ ");
                Console.WriteLine(e);
                Console.WriteLine("  -------------------   Garbage Collector Error  --------------------- ");
            }
        }

        private void AllocationTest()
        {
            // Start a thread using WaitForFullGCProc.
            Thread stress = new Thread(() =>
            {
                while (true)
                {
                    List<char[]> lst = new List<char[]>();

                    try
                    {
                        for (int i = 0; i <= 30; i++)
                        {
                            char[] bbb = new char[900000]; // creates a block of 1000 characters
                            lst.Add(bbb);                // Adding to list ensures that the object doesnt gets out of scope
                        }

                        Thread.Sleep(1000);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("  ********************   Garbage Collector Error  ************************ ");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("  -------------------   Garbage Collector Error  --------------------- ");
                    }
                }


            });
            stress.Start();
        }

    }
}
