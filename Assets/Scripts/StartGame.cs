using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void StartGamePlay()
    {
        SceneManager.LoadScene("GameplayStage");
    }
}
