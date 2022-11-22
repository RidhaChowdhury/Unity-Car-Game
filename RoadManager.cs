using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] private RoadData roadData;
    public Vector2[] spawnPoints{get; private set;}

    [SerializeField] private GameObject roadMarkingPrefab;
    // Start is called before the first frame update
    void Start()
    {
        GenerateRoadMarkings();
        GenerateSpawnPoints();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateRoadMarkings() {
        for(int i = 0; i < roadData.laneCount; i++) {
            LineRenderer roadMarking = Instantiate(roadMarkingPrefab, transform).GetComponent<LineRenderer>();
            roadMarking.SetPosition(0, new Vector3(-roadData.roadWidth/2 + roadData.laneWidth * i, 0, 0));
            roadMarking.SetPosition(1, new Vector3(-roadData.roadWidth/2 + roadData.laneWidth * (i), 1000, 0));
        }
    }

    void GenerateSpawnPoints()
    {
        spawnPoints = new Vector2[roadData.laneCount];
        for (int i = 0; i < roadData.laneCount; i++)
        {
            spawnPoints[i] = new Vector2(roadData.laneWidth * i + roadData.laneWidth / 2, 0);
        }
    }

    // Render the spawn points with gizmos
    void OnDrawGizmos()
    {
        if (spawnPoints != null)
        {
            Gizmos.color = Color.red;
            foreach (Vector2 point in spawnPoints)
            {
                Gizmos.DrawSphere(point, 0.5f);
            }
        }
    }
}
