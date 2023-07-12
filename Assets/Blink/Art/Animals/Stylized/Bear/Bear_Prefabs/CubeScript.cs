using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CubeScript : MonoBehaviour
{
    private NavMeshAgent nma = null;
    private GameObject[] randomPoints;
    private int currentRandom;
    private RandomPositionManager positionManager;
    private Transform player;

    private void Start()
    {
        nma = GetComponent<NavMeshAgent>();
        randomPoints = GameObject.FindGameObjectsWithTag("RandomPosition");
        positionManager = RandomPositionManager.GetInstance();
        Debug.Log("RandomPosition = " + randomPoints.Length.ToString());
    }

    private void Update()
    {
        if (player == null) {
            if (!nma.pathPending && !nma.hasPath)
            {
                currentRandom = GetAvailableRandomPosition();
                if (currentRandom != -1)
                {
                    Vector3 destPos = randomPoints[currentRandom].transform.position;
                    nma.SetDestination(randomPoints[currentRandom].transform.position);
                    Debug.Log("Moving to Random position " + currentRandom.ToString());
                    positionManager.OccupyPosition(currentRandom); // Mark the position as occupied
                }
            }
        }
        else {
            nma.SetDestination(player.position);
        }

    }

    private int GetAvailableRandomPosition()
    {
        List<int> availablePositions = new List<int>();

        for (int i = 0; i < randomPoints.Length; i++)
        {
            if (!positionManager.IsPositionOccupied(i)) // Check if the position is not already occupied
            {
                availablePositions.Add(i);
            }
            else if (positionManager.IsPositionTimedOut(i)) // Check if the position has timed out
            {
                positionManager.ReleasePosition(i); // Release the position if it has timed out
                availablePositions.Add(i);
            }
        }

        if (availablePositions.Count > 0)
        {
            int randomIndex = Random.Range(0, availablePositions.Count);
            return availablePositions[randomIndex];
        }

        return -1; // No available positions
    }

    private void OnDestroy()
    {
        positionManager.ReleasePosition(currentRandom); // Release the occupied position
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            player = other.transform;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            player = null;
        }
    }
}

