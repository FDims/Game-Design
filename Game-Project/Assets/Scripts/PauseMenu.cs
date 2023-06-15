using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenuUI;
    [SerializeField] GameObject Campos;
    [SerializeField] private GameObject SettingUI;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Text VolumeText;


    public bool isPaused;
    private GameObject Player;
    // Update is called once per frame
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        isPaused = false;
        ActivateMenu();
        PauseMenuUI.SetActive(false);
        LoadValues();
        SettingUI.SetActive(false);

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            if (!isPaused)
            {
                ActivateMenu();
            }
            else
            {
                DeactivateMenu();
                SettingUI.SetActive(false);
            }
        }
    }
    public void ActivateMenu()
    {
        isPaused = true;
        Time.timeScale = 0f;
        AudioListener.pause = true;
        PauseMenuUI.SetActive(true);
        Player.GetComponent<Player>().enabled = false;
        Campos.SetActive(false);
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        PauseMenuUI.SetActive(false);
        isPaused = false;
        Player.GetComponent<Player>().enabled = true;
        Campos.SetActive(true);
    }

    public void MainMenu()
    {
        DeactivateMenu();
        SceneManager.LoadScene(0);
    }
    public void VolumeSlider(float volume)
    {
        VolumeText.text = volume.ToString("0.0");
        volumeSlider.value = volume;
    }
    public void saveVolumeButton()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();
        DeactivateSetting();
    }
    public void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
    public void ActivateSetting()
    {
        PauseMenuUI.SetActive(false);
        SettingUI.SetActive(true);
    }
    public void DeactivateSetting()
    {
        PauseMenuUI.SetActive(true);
        SettingUI.SetActive(false);
    }
}
