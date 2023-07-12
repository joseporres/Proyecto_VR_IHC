using System.Collections.Generic;
using UnityEngine;

public class RandomPositionManager : MonoBehaviour
{
    private static RandomPositionManager instance;
    private Dictionary<int, float> occupiedPositions = new Dictionary<int, float>();
    private float maxOccupiedTime = 10f; // Maximum time for a position to be occupied (in seconds)

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static RandomPositionManager GetInstance()
    {
        return instance;
    }

    public void OccupyPosition(int positionIndex)
    {
        if (!occupiedPositions.ContainsKey(positionIndex))
        {
            occupiedPositions.Add(positionIndex, Time.time);
        }
    }

    public void ReleasePosition(int positionIndex)
    {
        if (occupiedPositions.ContainsKey(positionIndex))
        {
            occupiedPositions.Remove(positionIndex);
        }
    }

    public bool IsPositionOccupied(int positionIndex)
    {
        return occupiedPositions.ContainsKey(positionIndex);
    }

    public bool IsPositionTimedOut(int positionIndex)
    {
        if (occupiedPositions.ContainsKey(positionIndex))
        {
            float timeElapsed = Time.time - occupiedPositions[positionIndex];
            return timeElapsed >= maxOccupiedTime;
        }

        return false;
    }
}
