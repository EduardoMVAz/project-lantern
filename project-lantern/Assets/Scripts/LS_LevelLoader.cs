using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.Universal;
public class LevelLoader : MonoBehaviour
{
    public Button[] levelButtons;
    public TextMeshProUGUI levelText;
    public GameObject blocker;

    private string levelSelected = "locked";
    private Light2D lighty;
    [SerializeField] private AudioSource pressSound;
    void Start()
    {
        lighty = GetComponent<Light2D>();
        lighty.enabled = false;
        blocker.SetActive(true);

        for (int i = 0; i < levelButtons.Length; i++) {
            string temp = "Level " + (i + 1).ToString();
            levelButtons[i].onClick.AddListener(() => ChangeLevelSelected(temp));
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (levelSelected != "locked") {
            SceneManager.LoadScene(levelSelected);
        }
    }

    void ChangeLevelSelected(string newLevel) {
        pressSound.Stop();
        pressSound.Play();
        lighty.enabled = true;
        blocker.SetActive(false);
        levelSelected = newLevel;
        levelText.text = newLevel;
        if (levelText.text == "Level 0") {
            levelText.text = "Tutorial";
        }
    }
}
