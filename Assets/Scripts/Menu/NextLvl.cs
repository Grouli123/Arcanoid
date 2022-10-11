using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLvl : MonoBehaviour
{
    [SerializeField] private int _level;
    public void StartLevl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + _level);
    }
}
