using UnityEngine;
using System.Collections;

public class MusicSelector : MonoBehaviour {

	public AudioClip[] musicFiles;
	private AudioSource mainMusic;
	private int currentFile;

	// Use this for initialization
	void Start () 
	{
		mainMusic = this.gameObject.GetComponent<AudioSource>();
		currentFile = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*
		if(Input.GetMouseButtonDown(0))
	    {
	        mainMusic.Stop();
	    }
	    */

		if(!mainMusic.isPlaying)
		{
			currentFile = getNewClip();
			mainMusic.clip = musicFiles[currentFile];
			mainMusic.Play();
		}
	}

	private int getNewClip()
	{
		int newFile;
		do
		{
			newFile = Random.Range(0, musicFiles.Length);
		} while(newFile == currentFile);
		return newFile;
	}

}
