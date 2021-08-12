using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menues : MonoBehaviour
{
    public GameObject audioManager;
    public GameObject PauseMenu;
    public GameObject PauseButton;
    public bool isPaused = false;
    public GameObject ConfigurationMenu;
    public GameObject MainMenu;
    public Slider slider;
    public Text VolumeCounter;
    AudioManager script;
    // Start is called before the first frame update
    void Start()
    {
        script = audioManager.GetComponent<AudioManager>();
        slider.onValueChanged.AddListener((v) =>{
            script.setVolume(v);
            float  f = v * 100;
            int percent = (int) f;
            VolumeCounter.text = percent + "%";
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume(float volume){
	    
    }

    public void LoadScene(string nameScene){
    	SceneManager.LoadScene(nameScene);
    }

    public void Quit(){
    	//Application.Quit();
        Debug.Log("Quit");
    }

    public void OnPause(){
    	Time.timeScale = 0f;
	    PauseMenu.SetActive(true);
    	PauseButton.SetActive(false);
        isPaused = true;
    }

    public void DePause(){
    	Time.timeScale = 1f;
    	PauseMenu.SetActive(false);
    	PauseButton.SetActive(true);
    	isPaused = false;
    }

    public void VolverDeMenuConfiguracion(string name){
        switch(name){
            case "Main":
                MainMenu.SetActive(true);
                break;
            case "Pause":
                PauseMenu.SetActive(true);
                break;
        }
        ConfigurationMenu.SetActive(false);
    }

    public void IrMenuConfiguracion(string name){
        slider.value = script.getVolume();
        switch(name){
            case "Main":
                MainMenu.SetActive(false);
                break;
            case "Pause":
                PauseMenu.SetActive(false);
                break;
        }
        ConfigurationMenu.SetActive(true);
    }

}
