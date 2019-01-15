using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSound : MonoBehaviour
{
    [SerializeField] AudioClip loadingSound;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(loadingSound, Camera.main.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
