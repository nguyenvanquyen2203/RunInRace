using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    public Sprite playingImg;
    public Sprite quietImg;
    public Image audioIcon;
    private Slider audioSlider;
    public AudioManager.Audio_Type audioType;
    private float volumn;
    // Start is called before the first frame update
    private void Awake()
    {
        audioSlider = GetComponent<Slider>();
    }
    private void OnEnable()
    {
        volumn = AudioManager.Instance.GetVolumn(audioType);
        audioSlider.value = volumn;
        UpdateUI();
    }
    private void Quiet()
    {
        audioIcon.sprite = quietImg;
    }
    private void Play()
    {
        audioIcon.sprite = playingImg;
    }
    public void ChangeVolumn()
    {
        volumn = audioSlider.value;
        UpdateUI(); 
    }
    private void UpdateUI()
    {
        if (volumn == 0f)
        {
            Quiet();
        }
        else Play();
        AudioManager.Instance.SetVolumn(volumn, audioType);
    }
}
