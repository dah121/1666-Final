using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	public void LoadByIndex(int sceneIndex)
    {
        //put into OnClick of the button, choose the function and scene number to load
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadByName(string name)
    {
        SceneManager.LoadScene(name);
    }
}