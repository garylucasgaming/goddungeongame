using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{

  


    public void NewGame() {
        
       
        gameObject.SetActive(false);
        SceneManager.LoadScene("TownScene", LoadSceneMode.Single);

    }

    public void LoadDungeon() {
        SceneManager.LoadScene("Dungeon", LoadSceneMode.Single);
    }


    public void ExitGame() {
        

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }



  

}
