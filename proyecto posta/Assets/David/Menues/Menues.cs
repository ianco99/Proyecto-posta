using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menues : MonoBehaviour
{
    public GameObject audioManager;
    public GameObject PauseMenu;
    public bool isPaused = false;
    public GameObject ConfigurationMenu;
    public GameObject MainMenu;
    public Slider slider;
    public Dropdown resDrop;
    public Text VolumeCounter;
    AudioManager script;
    Resolution[] resolutions;
    
    // Start is called before the first frame update
    void Start()
    {
        


        resolutions = Screen.resolutions; 
        //resDrop.ClearOptions();
        List<string> options = new List<string>();
        int currRes = 0;
        int a = 0;
        foreach(Resolution r in resolutions){
            string option = r.width + "x" + r.height;
            options.Add(option);
            if(r.width == Screen.currentResolution.width && r.height == Screen.currentResolution.height){
                currRes =a;
            }
            a++;
        }

      //  resDrop.AddOptions(options);
       // resDrop.value = currRes;
       // resDrop.RefreshShownValue();


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
         if (Input.GetKeyDown(KeyCode.Escape) && isPaused) DePause();
         else if(Input.GetKeyDown(KeyCode.Escape) && !isPaused) OnPause(); 


    }

    public void SetVolume(float volume){
	    
    }

    public void LoadScene(string nameScene){
            	
    	SceneManager.LoadScene(nameScene);
    }

    public void Quit(){
    	//Application.Quit();
        
    }

    public void OnPause(){
    	Time.timeScale = 0f;
	    PauseMenu.SetActive(true);
        isPaused = true;
    }

    public void DePause(){
    	Time.timeScale = 1f;
    	PauseMenu.SetActive(false);
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
        Debug.Log(name);
        switch(name){
            case "Main":
                MainMenu.SetActive(false);
                break;
            case "Pause":
                PauseMenu.SetActive(false);
                break;
        }
        ConfigurationMenu.SetActive(true);
        Debug.Log("LLEGO");
        slider.value = script.getVolume();
    }

    public void SetResolution(int resolutionIndex){
    //    Resolution resolution = resolutions[resolutionIndex];
      //  Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen (bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }

   

}
