using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    public GameObject party;

    public float partyMoveSpeed;
    public bool partyCanMove = false;

    public float waypointDetectionRange = 0.2f;
    [SerializeField] Transform[] waypoints;
    [SerializeField] Transform[] savedWaypoints;
    [SerializeField] Transform savedCurrentWaypoint;
    [SerializeField] int savedCurrentWaypointIndex;
    [SerializeField] int currentWaypointIndex = 1;
    public Transform currentWaypoint;
    public bool goingBackwards = false;
    public bool inBranch;
    public bool branchEnded = false;

    private void Start()
    {
        currentWaypoint = waypoints[0];
    }

    private void Update()
    {
        if (partyCanMove)
        {
            MovePartyToCurrentWaypoint();
            CheckDistanceToCurrentWaypoint();
        }
    }

    private void MovePartyToCurrentWaypoint()
    {
        party.transform.position = Vector2.MoveTowards(
                party.transform.position,
                currentWaypoint.position,
                partyMoveSpeed * Time.deltaTime);
    }

    private void CheckDistanceToCurrentWaypoint()
    {
        if (Vector2.Distance(party.transform.position, currentWaypoint.position) 
            < waypointDetectionRange)
        {
            SetNextWaypoint();
        }
    }

    private void SetNextWaypoint()
    {
        if (currentWaypoint.childCount > 0 && !branchEnded)
        {
            EnterBranch();
        }
        else
        {
            branchEnded = false;
        }

        if (!goingBackwards && currentWaypointIndex == waypoints.Length) //End of path, not returning from branch
        {
            if (inBranch) //End of branch
            {
                goingBackwards = true;
                currentWaypointIndex--;
            }
            else //No more movement possible
            {
                Debug.Log("End of path");
                currentWaypoint = null;
                partyCanMove = false;
            }
        }
        else if (currentWaypointIndex < 0) //Going backwards, for coming back from end of a branch
        {
            Debug.Log(currentWaypointIndex + " is currentWaypointIndex");
            ExitBranch();
        }
        else //Movement still possible, set next waypoint;
        {
            currentWaypoint = waypoints[currentWaypointIndex];
            if (goingBackwards) currentWaypointIndex--;
            else currentWaypointIndex++;
        }
    }

    private void EnterBranch()
    {
        Debug.Log(currentWaypointIndex + " is currentWaypointIndex");
        Debug.Log("entering branch");
        inBranch = true;

        savedWaypoints = waypoints;
        savedCurrentWaypointIndex = currentWaypointIndex;
        savedCurrentWaypoint = currentWaypoint;

        Transform[] branchWaypoints = new Transform[currentWaypoint.childCount];
        int i = 0;
        foreach(Transform child in currentWaypoint.transform)
        {
            branchWaypoints[i] = child;
            i++;
        }

        waypoints = branchWaypoints;//testList.ToArray();
        currentWaypoint = waypoints[0];
        currentWaypointIndex = 0;
    }

    private void ExitBranch()
    {
        Debug.Log("exiting branch");
        inBranch = false;
        goingBackwards = false;

        //Restore saved waypoint data
        waypoints = savedWaypoints;
        currentWaypointIndex = savedCurrentWaypointIndex;
        currentWaypoint = savedCurrentWaypoint;
        branchEnded = true;
    }
}
