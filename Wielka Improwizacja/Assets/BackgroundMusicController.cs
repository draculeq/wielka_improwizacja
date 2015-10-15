using UnityEngine;
using System.Collections;

public class BackgroundMusicController : MonoBehaviour {

	[SerializeField] AudioClip[] clips;

	void Start () {
		if ( clips.Length == 0 ) throw new UnityException("must be at least 1 audio clip");
		StartCoroutine(Start2());
	}

	IEnumerator Start2 () {
		var s = GameObject.FindObjectsOfType<AudioSpecTest>();
		if( s == null ) throw new UnityException("shit happens");
		if( s.Length == 0 ) throw new UnityException("shit happens x2");
		AudioController.Instance.IntroSound();
		yield return new WaitForSeconds(2f);
		var au = GetComponent<AudioSource>();
		au.clip = clips[Random.Range(0,clips.Length)];
		au.Play();
		foreach ( var k in s ) k.StartGen();
	}
}
