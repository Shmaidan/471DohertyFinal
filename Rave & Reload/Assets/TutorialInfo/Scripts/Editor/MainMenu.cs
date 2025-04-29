using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string loadScene = "Menus";
    public GameObject mainMenu;
    public GameObject settingsMenu;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //public Slider volumeSlider;



    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("Volume, 1f");

        SetVolume(savedVolume);

     //   volumeSlider.SetValueWithoutNotify(savedVolume);
       // volume;
    }
    private void StartGame()
    {
       // SceneManager.LoadScene(loadtoScene);
    }
    public void OpenSettings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);

    }

    public void BackToMainMenu()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
       // AudioListener.volume = value;

    }
}
