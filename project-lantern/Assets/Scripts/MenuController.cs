using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class MenuController : MonoBehaviour
{
    
    [Header("Main Menu")]
    [SerializeField] private string start_scene;
    [SerializeField] private GameObject  mainFirst, settingsFirst, settingsClose, creditsFirst, creditsClose;
    
    [Header("Secondary Menu")]
    [SerializeField] private GameObject settingsMenu, creditsMenu;
    
    [Header("Audio Menu")]
    [SerializeField] private GameObject  audioMenu;
    [SerializeField] private GameObject audioFirst, audioClose;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TMP_Text volumeText;
    [SerializeField] private float volume, defaultVolume = 0.5f;
    

    public void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(mainFirst);
    }
    public void Play()
    {   
        SceneManager.LoadScene(start_scene);
    }
    public void Exit()
    {
        Application.Quit();
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

    public void OpenAudioSettings() {
        audioMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(audioFirst);
    }

    public void CloseAudioSettings() {
        audioMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(audioClose);
    }

    public void SetVolume() {
        AudioListener.volume = volumeSlider.value;
        volumeText.text = (volume*100).ToString("0") + "%";
    }

    public void ApplyVolume() {
        PlayerPrefs.SetFloat("master_volume", AudioListener.volume);
    }

    public void ResetAudioToDefault() {
        AudioListener.volume = defaultVolume;
        volumeText.text = (volume*100).ToString("0") + "%";
    }
}
