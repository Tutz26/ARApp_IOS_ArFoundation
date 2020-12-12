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
       
        sceneCount = 3;
        selectedScene = 0; 
        scenes = new string[sceneCount];

        scenes[0] = "Plants";
        scenes[1] = "Mushrooms";
        scenes[2] = "Trees";

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

        public void OnClickCreditsButton()
    {
        SceneManager.LoadScene("Credits"); 
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
