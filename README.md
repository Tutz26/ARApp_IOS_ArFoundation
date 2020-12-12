# ARApp_IOS_ArFoundation
This is a basic AR app for IOS to project some meshs with information in a device, using Unity and AR Foundation


How it works:

It uses a touch/raytracing function to spawn the selected objects in the tracked planes.


Instructions:

*	In the main menu, you can change the scene by selecting what kind of "Theme" do you want to use.

*	Then move your camera around until you se an orange plane appear, touch the screen where you want to place the model selected.

*	If you want to remove planes and model you can touch the button that says "Clear".

*	Now if you want to go back to the main menu touch "Touch".


Notes:

if you want to create your own scene, you can copy ""Mushrooms" or "Trees" scene as it is, and change the prefabs in the UIController script component assigned to the main canvas, and also change the prefabs
in the same order in the session origin object.

Then in the main menu, just add to the Scenes array the name of your new scene and voila!.
