using UnityEngine;
using UnityEngine.Video;

public class OuttroScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject CutScene;
    public VideoPlayer videoPlayer;
    public string nextSceneName = "MainGameScene";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Begin()
    {
        Debug.Log("Trying to play this video");
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
