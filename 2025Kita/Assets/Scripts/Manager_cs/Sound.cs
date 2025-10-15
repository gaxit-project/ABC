using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    private static Sound instance;
    public static Sound Instance
    {
        get { return instance; }
        private set { instance = value; }
    }

    [Header("AudioSource")]
    [SerializeField] private AudioSource audiosourcePrefab;
    [SerializeField] private int sourceCount = 0;

    private List<AudioSource> audioSources = new List<AudioSource>();

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void CreateSource()
    {
        for(int i = 0; i < sourceCount; i++)
        {

        }
    }
}
