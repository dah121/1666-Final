using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	public void LoadByIndex(int sceneIndex)
    {
        

        if(sceneIndex == 0 || sceneIndex == 2 || sceneIndex == 3)
        {
            Destroy(GameObject.Find("Audio Source"));
        }

        //put into OnClick of the button, choose the function and scene number to load
        SceneManager.LoadScene(sceneIndex);
    }
}