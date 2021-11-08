using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{


    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(FadeOut());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadScene(string nameScene){
    	SceneManager.LoadScene(nameScene);
    }

    IEnumerator Fadein(string sceneName){
        GetComponent<Animator>().speed = -1;
        GetComponent<Animator>().Play("New Animation");
        
		yield return new WaitForSeconds(1f);
        image.color = new Color(image.color.r, image.color.g, image.color.b, 255);
        LoadScene(sceneName);
    }

    IEnumerator FadeOut(){
        GetComponent<Animator>().speed = 1;
        GetComponent<Animator>().Play("New Animation");
		yield return new WaitForSeconds(1f);
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        Debug.Log("TERMINA");
    }
}
