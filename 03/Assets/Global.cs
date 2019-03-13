using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global
{
    public static List<randomdoor1> Ldoor;
    public static List<HallwayRandom> Lhallway;

    public static void randomAll()
    {
        foreach (randomdoor1 item in Ldoor)
        {
            item.action();
        }

        foreach (HallwayRandom item in Lhallway)
        {
            item.action();
        }
    }
}
