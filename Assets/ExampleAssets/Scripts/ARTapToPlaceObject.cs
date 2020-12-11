using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlaceObject : MonoBehaviour
{

    public GameObject canvasObject;
    public GameObject [] gameObjectsAvailable;

    private GameObject spawnedObject;
    private ARRaycastManager _arRaycastManager;
    private Vector2 touchPosition;
    private GameObject objectToInstance;
    private int canvasSelection;
    private int tempIndex;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        canvasSelection = UIController.selectionValue;
        tempIndex = 0;
        objectToInstance = gameObjectsAvailable[canvasSelection];
    }

    private void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
    }

    // Attempt to get touch position when touch on screen
    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
           touchPosition = Input.GetTouch(index: 0).position;
           return true;

        }

        touchPosition = default;
        return false;

    }

    // Update is called once per frame
    void Update()
    {
        //Update the index for object array from the canvas:
        canvasSelection = UIController.selectionValue;

        // IF different from canvas update object to instance
        if(tempIndex != canvasSelection)
        {

        objectToInstance = gameObjectsAvailable[canvasSelection];

        }

        if (!TryGetTouchPosition(out Vector2 touchPosition))
           return;

               if (!IsPointOverUIObject(touchPosition) &&_arRaycastManager.Raycast(touchPosition, hits, trackableTypes: TrackableType.PlaneWithinPolygon))
               {
         
                   var hitPose = hits[0].pose;

                   if (spawnedObject == null)
                   {
                       spawnedObject = Instantiate(objectToInstance, hitPose.position, hitPose.rotation);
                       tempIndex = canvasSelection;
                   }
                   else
                   {
                       Destroy(spawnedObject);
                       spawnedObject = Instantiate(objectToInstance, hitPose.position, hitPose.rotation);
                       tempIndex = canvasSelection;
                   }

               }

        }


    bool IsPointOverUIObject(Vector2 pos)
    {
        if (EventSystem.current.IsPointerOverGameObject())
           return false;

        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(pos.x, pos.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;

    }


}
