using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public Text selection;
    int sceneCount; 
    string [] scenes;
    int selectedScene;


    void Start()
    {
       
        sceneCount = SceneManager.sceneCountInBuildSettings - 1;
        selectedScene = 0; 
        scenes = new string[sceneCount];

        for(int i = 0; i < sceneCount; i++)
        {
            if (scenes[i] != "MainMenu" && scenes[i] != "Credits")
            {
            
            scenes[i] = System.IO.Path.GetFileNameWithoutExtension( UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex( i ) );
            
            }
        }
    }

    public void onSelectionRightClick()
    {
          if (selectedScene + 1 > scenes.Length)
        {
            selectedScene = 0;
        }
        else
        {
            selectedScene = selectedScene + 1;
        }
    }

    public void onSelectionLeftClick()
    {
          if (selectedScene - 1 < 0)
        {
            selectedScene = scenes.Length;
        }
        else
        {
            selectedScene = selectedScene - 1;
        }
    }



    public void OnClickStartButton()
    {
        SceneManager.LoadScene(scenes[selectedScene]); 
    }

        // Update is called once per frame
    void Update()
    {
         if (selection.text != scenes[selectedScene])
        {
            selection.text = scenes[selectedScene];
        }
    }

}
