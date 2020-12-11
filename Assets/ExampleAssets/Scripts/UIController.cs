﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public Text selectedMeshText;

    public GameObject[] gameObjectsAvailable;

    private GameObject currentMeshObject;
    private GameObject nextMeshObject;
    private GameObject previousMeshObject;

    public static int selectionValue;

    // Start is called before the first frame update
    void Start()
    {

        if (gameObjectsAvailable == null)
        {
            selectedMeshText.text = "None Mesh Selected";
        }
        else
        {
            selectedMeshText.text = gameObjectsAvailable[0].name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Give the name of the mesh to the text object
        if (selectedMeshText.text != gameObjectsAvailable[selectionValue].name)
        {
            selectedMeshText.text = gameObjectsAvailable[selectionValue].name;
        }
        else
        {
            return;
        }

    }


    // Add one to the object to loop through objects available:
    public void ChangeToNextObject()
    {

        if (selectionValue > gameObjectsAvailable.Length)
        {
            selectionValue = 0;
        }
        else
        {
            selectionValue = selectionValue + 1;
        }
    }

    // Substract one to the object to loop through objects available:
    public void ChangeToPreviousObject()
    {

        if (selectionValue < 0)
        {
            selectionValue = gameObjectsAvailable.Length;
        }
        else
        {
            selectionValue = selectionValue - 1;
        }
    }

    // Clean everything
    public void ClearButton()
    {

        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name); 

    }


}
