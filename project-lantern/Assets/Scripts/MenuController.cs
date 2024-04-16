using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class MenuController : MonoBehaviour
{
    
    [Header("Main Menu")]
    [SerializeField] private string start_scene;
    [SerializeField] private GameObject  mainFirst, settingsFirst, settingsClose, creditsFirst, creditsClose;
    [SerializeField] private AudioSource pressSound, selectSound, backGroundMusic;
    
    [Header("Secondary Menu")]
    [SerializeField] private GameObject settingsMenu, creditsMenu;
    
    [Header("Audio Menu")]
    [SerializeField] private GameObject  audioMenu;
    [SerializeField] private GameObject audioFirst, audioClose;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TMP_Text volumeText;
    [SerializeField] private float volume, defaultVolume = 0.5f;
    // private Dictionary<string, (GameObject, GameObject)> buttonMap = new Dictionary<string, (GameObject, GameObject)>();
    

    public void Start()
    {
        backGroundMusic.Play();
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(mainFirst);
    }
    public void Play()
    {    
        selectSound.Stop();
        pressSound.Play();
        Wait(1);
        SceneManager.LoadScene(start_scene);
    }
    public IEnumerator Wait(int n) {
        yield return new WaitForSeconds(n);
    }
    public void Exit()
    {
        Application.Quit();
    }


    // make a generalized function for the following methods
    public void OpenSettings() {
        selectSound.Stop();
        pressSound.Play();
        settingsMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(settingsFirst);
    }

    public void CloseSettings() {
        selectSound.Stop();
        pressSound.Play();
        settingsMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(settingsClose);
    }

    public void OpenAudioSettings() {
        selectSound.Stop();
        pressSound.Play();
        audioMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(audioFirst);
    }

    public void CloseAudioSettings() {
        selectSound.Stop();
        pressSound.Play();
        audioMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(audioClose);
    }

    // 
    public void SetVolume() {
        AudioListener.volume = volumeSlider.value;
        volumeText.text = (volume*100).ToString("0") + "%";
    }

    public void ApplyVolume() {
        selectSound.Stop();
        pressSound.Play();
        PlayerPrefs.SetFloat("master_volume", AudioListener.volume);
    }

    public void ResetAudioToDefault() {
        selectSound.Stop();
        pressSound.Play();
        AudioListener.volume = defaultVolume;
        volumeText.text = (volume*100).ToString("0") + "%";
    }

    public void OnPointerEnter(PointerEventData ped) {
        selectSound.Play();
    }
}

