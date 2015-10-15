using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Crowd : MonoBehaviour {
	public CrowdRow[] rows { get; private set; }
	AudioSource aus;

	void Awake () {
		rows = GetComponentsInChildren<CrowdRow>();
		aus = GetComponent<AudioSource>();
	}

	
	[SerializeField] AudioClip[] buu;

	public void RandomBooSound() {
		aus.clip = buu[Random.Range(0,buu.Length)];
		aus.Play();
	}
}
