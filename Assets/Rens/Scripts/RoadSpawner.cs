using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public List<GameObject> roads;
    private float offset = 40f;
    private float DistanceDone;

    public GameObject EndPoint;
    public float LenghtRoad;

    // Start is called before the first frame update
    void Start()
    {
        if(roads != null && roads.Count > 0)
        {
            roads = roads.OrderBy(r => r.transform.position.z).ToList();
        }
    }

    public void MoveRoad()
    {
        float newZ = roads[roads.Count - 1].transform.position.z + offset;

        if (DistanceDone<=LenghtRoad)
        {
            GameObject movedRoad = roads[0];
            roads.Remove(movedRoad);
            movedRoad.transform.position = new Vector3(0, 0, newZ);
            roads.Add(movedRoad);
            DistanceDone++;
        }
        else
        {
            EndPoint.transform.position = new Vector3(0, 0, newZ);
        }
        
    }
}
