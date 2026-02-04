using UnityEngine;
using System;

public class PlayerSound : MonoBehaviour
{
    [Serializable]
    public class GroundSetting
    {  
        public string groundTag; // Unityエディタで設定したタグ名（Grass, Wood等）
        public AudioClip land;   // 着地音
        public AudioClip roll;   // 転がる音
    }

    [Header("音源の設定")]
    public AudioSource rollSource;
    public AudioSource landSource;

    [Header("地面のリスト")]
    public GroundSetting[] groundSettings;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rollSource != null)
        {
            rollSource.loop = true;
            rollSource.volume = 0; 
            rollSource.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GroundSetting setting = FindSetting(collision.gameObject.tag);
        if (setting != null && setting.land != null)
        {
            landSource.PlayOneShot(setting.land);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        GroundSetting setting = FindSetting(collision.gameObject.tag);
        float speed = rb.velocity.magnitude;

        rollSource.volume = speed > 0.1f ? Mathf.Clamp(speed / 2f, 0, 0.8f) : 0;

        if (setting != null && setting.roll != null)
        {
            if (rollSource.clip != setting.roll)
            {
                rollSource.clip = setting.roll;
                rollSource.Play();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        rollSource.volume = 0;
    }

    private GroundSetting FindSetting(string tagName)
    {
        foreach (var s in groundSettings)
        {
            if (s.groundTag == tagName) return s;
        }
        return null;
    }
}