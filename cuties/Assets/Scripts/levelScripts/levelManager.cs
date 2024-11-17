
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{

    public static levelManager instance;

    public void Awake()
    {


        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {

            Destroy(gameObject);
        }
    }

    public void NextLevel()
    {

        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void LoadScene(int sceneIndex)
    {

        SceneManager.LoadSceneAsync(sceneIndex);
    }
    
}
