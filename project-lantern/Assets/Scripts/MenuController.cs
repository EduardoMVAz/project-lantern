using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class MenuController : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject settingsFirst, settingsClose, mainFirst, creditsFirst, creditsClose;
    [SerializeField] private string start_scene;
    public void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(mainFirst);
    }
    public void Play()
    {   
        SceneManager.LoadScene(start_scene);
    }

    public void OpenSettings() {
        settingsMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(settingsFirst);
    }
    public void CloseSettings() {
        settingsMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(settingsClose);
    }
}
