using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomData 
{
    
    public bool isLeftSpawnViable { get; set; }
    public bool isRightSpawnViable { get; set; }
    public GameObject roomObject { get; set; }



    public roomData(GameObject room, bool LeftSpawnViable, bool rightSpawnViable)
    {

        roomObject = room;
        isLeftSpawnViable = LeftSpawnViable;
        isRightSpawnViable = rightSpawnViable;

    }

}
