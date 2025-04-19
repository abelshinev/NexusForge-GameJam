using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroScript : MonoBehaviour
{
    public GameObject CutScene;
    public VideoPlayer videoPlayer;
    public string nextSceneName = "MainGameScene";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        videoPlayer.Play();
        videoPlayer.loopPointReached += OnVideoEnd; 
    }

    // Update is called once per frame
    void OnVideoEnd(VideoPlayer vidPlayer)
    {
        CutScene.SetActive(false);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            videoPlayer.Stop();
            CutScene.SetActive(false);
        }
    }
}
