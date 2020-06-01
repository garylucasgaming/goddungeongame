using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PartyManager partyManager;
    public DungeonManager dungeonManager;

    private void Awake()
    {
        #region DontDestroyOnLoad
        //Prexisting GameManager check
        //if (GameObject.FindGameObjectWithTag("GameManager") != null)
        //{
        //    Destroy(this);
        //}
        //else
        //{
        //    DontDestroyOnLoad(this);
        //}
        #endregion

        partyManager = FindOrCreateObjectWithTagAndType("PartyManager", typeof(PartyManager))
            .GetComponent<PartyManager>();
        dungeonManager = FindOrCreateObjectWithTagAndType("DungeonManager", typeof(DungeonManager))
            .GetComponent<DungeonManager>();
    }

    private GameObject FindOrCreateObjectWithTagAndType(string tag, Type type)
    {
        GameObject GO = GameObject.FindGameObjectWithTag(tag);
        if (GO == null)
        {
            Debug.Log($"Creating {tag}");
            GO = new GameObject(tag, type);
            GO.tag = tag;
        }
        return GO;
    }
}
