using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class StartUIManager : MonoBehaviour
{
    [SerializeField] TMP_Text highScoretext;
    [SerializeField] AudioMixer audioMixer;
    readonly int mute = -80, unmute = 0;
    bool musicActive;
    bool sfxActive;
    void Start()
    {
        HighScore();
    }
    void Update()
    {
        
    }
    void HighScore()
    {
        highScoretext.text = Mathf.FloorToInt(GameManager.instance.highScore).ToString();
    }
    public void StartButton()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    public void Quit()
    {
        if(Application.isPlaying)
        {
            Application.Quit();
        }
    }

    public void TargetFPS(int amount)
    {
        Application.targetFrameRate = amount;
    }

    public void Quality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void Music()
    {
        if (musicActive)
        {
            audioMixer.SetFloat("MusicVolume", unmute);
            musicActive = false;
        }
        else
        {
            audioMixer.SetFloat("MusicVolume", mute);
            musicActive = true;
        }
    }
    public void SFX()
    {
        if (sfxActive)
        {
            audioMixer.SetFloat("SFXVolume", unmute);
            sfxActive = false;
        }
        else
        {
            audioMixer.SetFloat("SFXVolume", mute);
            sfxActive = true;
        }
    }
}
