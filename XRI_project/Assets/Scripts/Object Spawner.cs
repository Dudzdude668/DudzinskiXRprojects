using System.Collections;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem.XR; //for communicating with XR controllers


/*
    select object to spawn
    where object spawns
    cooldown period
    input - button
    hand
*/
public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab; //object to spawn
    public Transform spawnPoint; //where it spawns
    public XRNode controllerNode = XRNode.RightHand; //assigning right hand controller
    public float spawnCooldown = 1.0f; //need a coroutine
    private bool canSpawn = true; //Time in seconds between spawns
    
    void Update()
    {
        if (canSpawn && IsAButtonPressed())
        {
            StartCoroutine(SpawnObjectWithCooldown());
        }
    }

   bool IsAButtonPressed()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(controllerNode);
        bool buttonPressed = false;

        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out buttonPressed) && buttonPressed) // primary button is "a" or "x"
        {
            return true;      
        }
        
         return false;
    }
   
    IEnumerator SpawnObjectWithCooldown()
    {
        canSpawn = false; //prevents immediate respawning
        SpawnObject();
        yield return new WaitForSeconds(spawnCooldown);
        canSpawn = true; //allows us to spawn again
    }
    void SpawnObject()
    {
        if (objectPrefab != null && spawnPoint != null)
        {
            GameObject spawnedObject = Instantiate(objectPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogError("assign objectPrefab and spawnPoint in the Inspector");
        }
    }
}
