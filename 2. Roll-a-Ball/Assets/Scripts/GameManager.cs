using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject completedLevelUI;

    public void CompleteLevel()
    {
        completedLevelUI.SetActive(true);
    }
}
