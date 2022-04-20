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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(this.GetComponent<combine>().loadlevelAsync(SceneName, UnloadSceneNum));
        }
    }
    public void LoadScene(VideoPlayer vp)
    {
        StartCoroutine(this.GetComponent<combine>().loadlevelAsync(SceneName,UnloadSceneNum));
        //SceneManager.LoadScene(SceneName);
    }
}
