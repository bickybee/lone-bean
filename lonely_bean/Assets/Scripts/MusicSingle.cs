using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//code from http://stackoverflow.com/a/27912788
//added feature to recognize scene where the music is no longer needed

public class MusicSingle : MonoBehaviour
{
    private static MusicSingle _instance;
    public string untilScene;

    public static MusicSingle instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<MusicSingle>();

                //Tell unity not to destroy this object when loading a new scene!
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    void Awake()
    {   if (SceneManager.GetActiveScene().name==untilScene)
        {
            Destroy(this.gameObject);
        }
        else if (_instance == null)
        {
            //If I am the first instance, make me the Singleton
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }

    public void Play()
    {
        //Play some audio!
    }
}