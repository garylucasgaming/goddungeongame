using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDungeonManager : MonoBehaviour
{


    public int roomCount;
    public GameObject[] RoomMasterArray;
    public List<GameObject> roomList;
    public List<GameObject> visitedList;
    public GameObject room;
    public Dictionary<int, roomData> roomDictionary = new Dictionary<int, roomData>();
    public roomData newRoom;
    public float originOffset;
    public GameObject dungeonExit;
    




    private void Awake()
    {
        
        //generate room zero     
        MakeDungeonRoom(new Vector3(transform.position.x, transform.position.y, 0));
        //generate every other room
        GenerateDungeon();
        GenerateExits();
    }

    private void GenerateExits()
    {
        foreach (KeyValuePair<int, roomData> keyValuePair in roomDictionary)
        {
            if (keyValuePair.Value.isLeftSpawnViable)
            {
                
                var newDungeonExit = Instantiate(dungeonExit, new Vector3(keyValuePair.Value.roomObject.transform.Find("ExitPointLeft").transform.position.x + .5f, keyValuePair.Value.roomObject.transform.Find("ExitPointLeft").transform.position.y + .3f, 0), Quaternion.identity);
                newDungeonExit.transform.SetParent(keyValuePair.Value.roomObject.transform.Find("ExitPointLeft"));
                
            }
            if (keyValuePair.Value.isRightSpawnViable)
            {
                var newDungeonExit = Instantiate(dungeonExit, new Vector3 (keyValuePair.Value.roomObject.transform.Find("ExitPointRight").transform.position.x - .5f, keyValuePair.Value.roomObject.transform.Find("ExitPointRight").transform.position.y + .3f, 0), Quaternion.identity);
                newDungeonExit.transform.SetParent(keyValuePair.Value.roomObject.transform.Find("ExitPointRight"));
                newDungeonExit.transform.rotation = Quaternion.Euler(0, 180f, 0);
            }
            
        }
    }


    //dungeon  generator
    private void GenerateDungeon()
    {



        //generate remaining  rooms
        int i;
        

        for (i = 1; i < roomCount; )
        {

            int y = UnityEngine.Random.Range(0, roomDictionary.Count);
            int x = UnityEngine.Random.Range(0, 10);


            roomData spawningRoom;
            roomData newRoom;
            roomDictionary.TryGetValue(y, out spawningRoom);
            if (x < 6) {
                if (spawningRoom.isLeftSpawnViable)
                {

                    RaycastHit2D hit = CheckRaycast(Vector2.left, spawningRoom.roomObject.transform.Find("ExitPointLeft").transform.position.x - 7, spawningRoom.roomObject.transform.Find("ExitPointLeft").transform.position.y);

                    if (hit.collider != null)
                    {
                        if (hit.collider.gameObject.CompareTag("Room")) { spawningRoom.isLeftSpawnViable = false;  continue; }

                    }
                    else if(hit.collider == null)
                    {
                        MakeDungeonRoom(new Vector3(spawningRoom.roomObject.transform.Find("ExitPointLeft").transform.position.x - 7, spawningRoom.roomObject.transform.Find("ExitPointLeft").transform.position.y + 7 - 1.5f, 0));
                        roomDictionary.TryGetValue(roomDictionary.Count - 1, out newRoom);
                        if (newRoom.roomObject.transform.Find("EntryPointLeft"))
                        {


                            //send out  raycast/sphere     x units away, if hits a collission with tag "Room" continue;


                            newRoom.roomObject.transform.rotation = Quaternion.Euler(0, 180f, 0);
                            newRoom.isLeftSpawnViable = false;
                            newRoom.isRightSpawnViable = false;
                            if (newRoom.roomObject.transform.Find("ExitPointRight") || newRoom.roomObject.transform.Find("ExitPointLeft")) { var right = newRoom.roomObject.transform.Find("ExitPointRight"); var left = newRoom.roomObject.transform.Find("ExitPointLeft"); right.name = "ExitPointLeft"; newRoom.isLeftSpawnViable = true; left.name = "ExitPointRight"; newRoom.isRightSpawnViable = true; }
                            else if (newRoom.roomObject.transform.Find("ExitPointLeft")) { newRoom.roomObject.transform.Find("ExitPointLeft").name = "ExitPointRight"; newRoom.isRightSpawnViable = true; }
                            else if (newRoom.roomObject.transform.Find("ExitPointRight")) { newRoom.roomObject.transform.Find("ExitPointRight").name = "ExitPointLeft"; newRoom.isLeftSpawnViable = true; }
                            if (newRoom.roomObject.transform.Find("EntryPointRight")) { newRoom.roomObject.transform.Find("EntryPointRight").name = "EntryPointLeft"; }
                            else if (newRoom.roomObject.transform.Find("EntryPointLeft")) { newRoom.roomObject.transform.Find("EntryPointLeft").name = "EntryPointRight"; }
                        }
                        i++;
                        spawningRoom.isLeftSpawnViable = false;
                    }




                }
                else { continue; }
            }

            if (x > 5)
            {
                if (spawningRoom.isRightSpawnViable)
                {

                    RaycastHit2D hit = CheckRaycast(Vector2.right, spawningRoom.roomObject.transform.Find("ExitPointRight").transform.position.x + 7, spawningRoom.roomObject.transform.Find("ExitPointRight").transform.position.y);
                    if (hit.collider != null)
                    {
                        if (hit.collider.gameObject.CompareTag("Room")) { spawningRoom.isLeftSpawnViable = false;  continue; }

                    }
                    else if(hit.collider  == null)
                    {
                        MakeDungeonRoom(new Vector3(spawningRoom.roomObject.transform.Find("ExitPointRight").transform.position.x + 7, spawningRoom.roomObject.transform.Find("ExitPointRight").transform.position.y + 7 - 1.5f, 0));
                        roomDictionary.TryGetValue(roomDictionary.Count - 1, out newRoom);
                        if (newRoom.roomObject.transform.Find("EntryPointRight"))
                        {

                            newRoom.roomObject.transform.rotation = Quaternion.Euler(0, 180f, 0);
                            newRoom.isLeftSpawnViable = false;
                            newRoom.isRightSpawnViable = false;
                            if (newRoom.roomObject.transform.Find("ExitPointRight") || newRoom.roomObject.transform.Find("ExitPointLeft")) { var right = newRoom.roomObject.transform.Find("ExitPointRight"); var left = newRoom.roomObject.transform.Find("ExitPointLeft"); newRoom.isLeftSpawnViable = true; right.name = "ExitPointLeft"; left.name = "ExitPointRight"; newRoom.isRightSpawnViable = true; }
                            else if (newRoom.roomObject.transform.Find("ExitPointLeft")) { newRoom.roomObject.transform.Find("ExitPointLeft").name = "ExitPointRight"; newRoom.isRightSpawnViable = true; }
                            else if (newRoom.roomObject.transform.Find("ExitPointRight")) { newRoom.roomObject.transform.Find("ExitPointRight").name = "ExitPointLeft"; newRoom.isLeftSpawnViable = true; }
                            if (newRoom.roomObject.transform.Find("EntryPointRight")) { newRoom.roomObject.transform.Find("EntryPointRight").name = "EntryPointLeft"; }
                            else if (newRoom.roomObject.transform.Find("EntryPointLeft")) { newRoom.roomObject.transform.Find("EntryPointLeft").name = "EntryPointRight"; }
                        }
                        i++;
                        spawningRoom.isRightSpawnViable = false;
                    }



                }
                else { continue; }
            }

           



          


        }





    }



    private RaycastHit2D CheckRaycast(Vector2 direction, float transformPositionX, float transformPositionY)
    {
        

        Vector2 startPosition = new Vector2(transformPositionX , transformPositionY);

        return Physics2D.Raycast(startPosition, direction, 7);
    }



    //room generator
    private void MakeDungeonRoom(Vector3  spawnPosition)
    {
        int i = UnityEngine.Random.Range(0, RoomMasterArray.Length);
        int x = roomDictionary.Count;
        bool isLeftViable = false ;
        bool isRightViable = false;
        var room = Instantiate(RoomMasterArray[i], spawnPosition, Quaternion.identity);

        if (room.transform.Find("ExitPointRight")) { isRightViable = true; }

        if (room.transform.Find("ExitPointLeft")) { isLeftViable = true; }

        roomData newRoom = new roomData (room, isLeftViable, isRightViable);
       
        roomDictionary.Add(x,  newRoom);
        roomList.Add(room);

    }








}
