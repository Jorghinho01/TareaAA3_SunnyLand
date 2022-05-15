using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{

    AudioSource[] allSources;

    AudioSource landingSource;
    AudioSource jumpSource;
    AudioSource crouchSource;
    AudioSource cherrySource;
    AudioSource stepsSource;

    //mantiene el track mientras salta 
    bool isJumping = false;
    //track movimiento

    Rigidbody2D rb; // note the "2D" prefix 

    bool isPlaying = false;
    
    
    void Start()
    {

	rb = GetComponent<Rigidbody2D>();

	// get the references to your audio sources here !  

    allSources = GetComponents<AudioSource>();

    landingSource = allSources[0];
    jumpSource = allSources[1];
    crouchSource = allSources[2];
    cherrySource = allSources[3];
    stepsSource = allSources[4];

    }

    // FixedUpdate is called whenever the physics engine updates
    void FixedUpdate()
    {
	// Use the ridgidbody instance to find out if the fox is
	// moving, and play the respective sound !
	// Make sure to trigger the movement sound only when
	// the movement begins ...

	// Use a magnitude threshold of 1 to detect whether the
	// fox is moving or not !
	// i.e.
	// if ( ??? > 1 && ???) {
	//    play sound here !
	// } else if ( ??? < 1 &&) {
	//   stop sound here !
	// }	

    float v = rb.velocity.magnitude;

    if (v > 1 && !isPlaying) {
        stepsSource.Play();
        isPlaying = true;
    }
    else if (v < 1 && isPlaying) {
        stepsSource.Stop();
        isPlaying = false;
    }
    if (isJumping) {
        stepsSource.Stop();
    }

    }
    
    // sonido de caer
    public void OnLanding() {

        if (isJumping) {
            landingSource.Play();
        }
        isJumping = false;
        print("the fox has landed");
	// to keep things cleaner, you might want to
	// play this sound only when the fox actually jumoed ...
    
    }

    // sonido agacharse
    public void OnCrouching() {
        print("the fox is crouching");

        crouchSource.Play();
    }
 
    // sonido salto
    public void OnJump() {

        isJumping = true;
        print("the fox has jumped");

        jumpSource.Play();
    
    }

    // recoger cherry sonido
    public void OnCherryCollect() {
        print("the fox has collected a cherry");

        cherrySource.Play();
    }
}
