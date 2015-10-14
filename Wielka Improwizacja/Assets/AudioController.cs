using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour {
	AudioSource au_source;
	[SerializeField] AudioClip gwizd,slash,kompromitacja, wspaniale, mistrz, kombo, znakomicie;
	
	void Awake () {
		if ( GameObject.FindObjectOfType (typeof(AudioController)) == null ) {
			au_source = GetComponent<AudioSource>();
		} else DestroyObject(gameObject);
	}	

	public void PomidorCrashed () {
		au_source.PlayOneShot(slash,0.9f);
	}

	public void KwiatekCaptured (){
		au_source.PlayOneShot(gwizd,0.7f);
	}

	public void BothFailed () {
		au_source.PlayOneShot(kompromitacja);
	}

	public void ComboDone1 () {
		au_source.PlayOneShot(kombo);
		
	}

	public void ComboDone2 () {
		au_source.PlayOneShot(wspaniale);
	}

	#region hide
	private static AudioController _instance;
	public static AudioController Instance {
		get {
			if ( _instance == null ) {
				_instance = GameObject.FindObjectOfType(typeof(AudioController)) as AudioController;
			}
			return _instance;
		}
	}
	#endregion
}
