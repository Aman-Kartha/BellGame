using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int loadScene,unloadScene;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VideoPlayer vp = this.GetComponent<VideoPlayer>();

        if(vp.time > 8.4f && vp.time <= 9)
        {
            vp.time = 4.3f;
            vp.Play();
        }
    }
    public void nextScene()
    {
        StartCoroutine(this.GetComponent<combine>().loadlevelAsync(loadScene, unloadScene));
    }
}
