using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    public GameObject party;

    #region Party Movement Vars
    public float partyMoveSpeed;
    public bool partyCanMove = false;

    public float waypointDetectionRange = 0.2f;
    public int currentWaypointIndex;
    public Transform[] waypoints;
    #endregion

    private void Start()
    {

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
                waypoints[currentWaypointIndex].position,
                partyMoveSpeed * Time.deltaTime);
    }

    private void CheckDistanceToCurrentWaypoint()
    {
        //If distance to next waypoint is less than a small detection value
        if (Vector2.Distance(party.transform.position, waypoints[currentWaypointIndex].position) 
            < waypointDetectionRange)
        {
            //Set next waypoint and check if at the last one
            currentWaypointIndex++;
            if (currentWaypointIndex == waypoints.Length)
                partyCanMove = false;
        }
    }
}
