using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControllerBigCrate : MonoBehaviour
{

    AudioSource[] allSources;

    AudioSource impactSource;
    AudioSource rumbleSource;

    Rigidbody2D rb;

    bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {

    allSources = GetComponents<AudioSource>();

    impactSource = allSources[0];
    rumbleSource = allSources[1];
        
    rb = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate() {
        float v = rb.velocity.magnitude;
        if (v > 0.1 && !isPlaying) {
            rumbleSource.Play();
            isPlaying = true;
        }
        else if (v < 0.1 && isPlaying) {
            rumbleSource.Stop();
            isPlaying = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        impactSource.Play();

    }

}
