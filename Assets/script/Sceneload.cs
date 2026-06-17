using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneload : MonoBehaviour
{
    public void LoadSceneBaru(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }

}
