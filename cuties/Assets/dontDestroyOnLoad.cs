using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroyOnLoadPlayer : MonoBehaviour
{
    // Start is called before the first frame update
   
   public class SceneController : MonoBehaviour
{
    public string sceneToDeactivateDontDestroyOnLoad = "level2";

    private void Start()
    {
        // Subscribe to the scene loaded event
        DontDestroyOnLoad(gameObject);
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the scene loaded event
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // This method will be called whenever a scene is loaded
    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        // Check if the loaded scene is the one where you want to deactivate DontDestroyOnLoad
        if (scene.name == sceneToDeactivateDontDestroyOnLoad)
        {
            // Find objects with DontDestroyOnLoad and destroy them
            GameObject[] dontDestroyObjects = GameObject.FindGameObjectsWithTag("dontDestroy");
            foreach (GameObject obj in dontDestroyObjects)
            {
                Destroy(obj);
            }
        }
    }
}
   
}
