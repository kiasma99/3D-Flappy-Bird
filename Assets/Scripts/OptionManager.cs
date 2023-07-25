using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    [SerializeField] Slider bgmSlider, sfxSlider;
    [SerializeField] TextMeshProUGUI bgmText, sfxText;
    [SerializeField] GameObject bgmSoundOn, bgmSoundOff, sfxSoundOn, sfxSoundOff;
    // Start is called before the first frame update
    void Start()
    {
        bgmSlider.value = GameManager.Instance.bgmValue;
        sfxSlider.value = GameManager.Instance.sfxValue;
    }

    // Update is called once per frame
    void Update()
    {
        bgmText.text = bgmSlider.value.ToString();
        sfxText.text = sfxSlider.value.ToString();
        GameManager.Instance.bgmValue = bgmSlider.value;
        GameManager.Instance.sfxValue = sfxSlider.value;
        PlayerPrefs.SetFloat("BGMValue", GameManager.Instance.bgmValue);
        PlayerPrefs.SetFloat("SFXValue", GameManager.Instance.sfxValue);
        if(GameManager.Instance.isBGMMute) BGMSoundOff();
        else BGMSoundOn();

        if(GameManager.Instance.isSFXMute) SFXSoundOff();
        else SFXSoundOn();
    }

    public void BGMSoundOff()
    {
        bgmSoundOff.SetActive(true);
        bgmSoundOn.SetActive(false);
        GameManager.Instance.bgmAudio.enabled = false;
        GameManager.Instance.isBGMMute = true;
        PlayerPrefs.SetInt("isBGMMute", 1);
    }

    public void BGMSoundOn()
    {
        bgmSoundOff.SetActive(false);
        bgmSoundOn.SetActive(true);
        GameManager.Instance.bgmAudio.enabled = true;
        GameManager.Instance.isBGMMute = false;
        PlayerPrefs.SetInt("isBGMMute", 0);
    }

    public void SFXSoundOff()
    {
        sfxSoundOff.SetActive(true);
        sfxSoundOn.SetActive(false);
        GameManager.Instance.isSFXMute = true;
        PlayerPrefs.SetInt("isSFXMute", 1);
    }

    public void SFXSoundOn()
    {
        sfxSoundOff.SetActive(false);
        sfxSoundOn.SetActive(true);
        GameManager.Instance.isSFXMute = false;
        PlayerPrefs.SetInt("isSFXMute", 0);
    }
}
