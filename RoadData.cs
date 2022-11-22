using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadData : ScriptableObject
{
    public int laneCount;
    public float laneWidth;
    public float roadWidth {get =>  laneWidth * laneCount;}

    public Color medialLine, laneLine;

}

