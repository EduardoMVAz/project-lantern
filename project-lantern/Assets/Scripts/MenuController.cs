using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string start_scene;
    public void Start()
    {
    }
    public void Play()
    {   
        SceneManager.LoadScene(start_scene);
    }
}
