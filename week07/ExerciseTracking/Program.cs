using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Activity> activityList = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),
            new Cycling(new DateTime(2022, 11, 3), 30, 12.0),
            new Swimming(new DateTime(2022, 11, 3), 30, 20)
        };

        foreach (var activity in activityList)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
