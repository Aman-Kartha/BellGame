using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class combine : MonoBehaviour
{
    [SerializeField]
    int sceneNum;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator loadlevelAsync(int num,int unloadNum)
    {
        var progress = SceneManager.LoadSceneAsync(num, LoadSceneMode.Additive);

     

        while(progress.isDone ){
            yield return null;
        }

       
        var progress2 = SceneManager.UnloadSceneAsync(unloadNum);

        Debug.Log("level Loaded");



    }
    public IEnumerator loadlevelAsync(int num)
    {
        var progress = SceneManager.LoadSceneAsync(num, LoadSceneMode.Additive);

        

        while (!progress.isDone )
        {
            yield return null;
        }

        Debug.Log("level Loaded");



    }
}
