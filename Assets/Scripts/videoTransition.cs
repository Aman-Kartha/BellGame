using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class videoTransition : MonoBehaviour
{
    public VideoPlayer VideoPlayer; // Drag & Drop the GameObject holding the VideoPlayer component
    public int SceneName;
    public int UnloadSceneNum;
    void Start()
    {
        VideoPlayer.loopPointReached += LoadScene;
    }
    void LoadScene(VideoPlayer vp)
    {
        StartCoroutine(this.GetComponent<combine>().loadlevelAsync(SceneName,UnloadSceneNum));
        //SceneManager.LoadScene(SceneName);
    }
}
