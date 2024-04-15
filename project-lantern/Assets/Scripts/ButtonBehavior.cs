using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSelectionHandler : MonoBehaviour, ISelectHandler
{
    [Header("SFX")]
    [SerializeField] private AudioSource selectSound, pressSound;

    public void OnSelect(BaseEventData eventData)
    {
        if (!pressSound.isPlaying) {
            selectSound.Play();
        }   
        
    }
    public void OnClick(BaseEventData eventData) {
        pressSound.Play();
    }
}
