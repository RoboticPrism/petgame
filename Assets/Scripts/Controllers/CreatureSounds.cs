using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSounds : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip eatingSound;
	public AudioClip ballSound;
	public AudioClip pokeSound;
	public AudioClip petSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void playEatingSound(){
		audioSource.PlayOneShot (eatingSound);
	}

	public void playBallSound(){
		audioSource.PlayOneShot (ballSound);
	}

	public void playPokeSound(){
		audioSource.PlayOneShot (pokeSound);
	}

	public void playPetSound(){
		audioSource.PlayOneShot (petSound);
	}
		
}

