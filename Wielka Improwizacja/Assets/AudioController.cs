using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour {
	AudioSource au_source;
	[SerializeField] AudioClip gwizd,slash,kompromitacja, wspaniale, mistrz, kombo, znakomicie,nieslychanie;
	
	void Awake () {
		if ( GameObject.FindObjectsOfType (typeof(AudioController)).Length <= 1 ) {
			au_source = GetComponent<AudioSource>();
			DontDestroyOnLoad(gameObject);
		} else DestroyObject(gameObject);
	}	

	public void PomidorCrashed () {
		au_source.PlayOneShot(slash,0.05f);
	}
    
	public void KwiatekCaptured (){
		au_source.PlayOneShot(gwizd,0.02f);
	}

	public void BothFailed () {
		au_source.PlayOneShot(kompromitacja);
	}

	public void RandomComboSound () {
		int r = Random.Range(0,4);
		if ( r == 0) au_source.PlayOneShot(kombo);
		if ( r == 1)  au_source.PlayOneShot(wspaniale);
		if ( r == 2) au_source.PlayOneShot(mistrz);
		if ( r == 3) au_source.PlayOneShot(nieslychanie);
		
	}

	public void Win () {
		
		StartCoroutine(Win2() );
	}

	IEnumerator Win2 () {
		au_source.PlayOneShot(znakomicie);
		yield return new WaitForSeconds(1f);
		au_source.PlayOneShot(znakomicie);
	}
	public void MegaWin () {
		StartCoroutine(MegaWin2() );
	}

	IEnumerator MegaWin2 () {
		au_source.PlayOneShot(znakomicie);
		yield return new WaitForSeconds(0.5f);
		au_source.PlayOneShot(znakomicie);
		yield return new WaitForSeconds(0.5f);
		au_source.PlayOneShot(znakomicie);
		yield return new WaitForSeconds(0.5f);
		au_source.PlayOneShot(znakomicie);

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
