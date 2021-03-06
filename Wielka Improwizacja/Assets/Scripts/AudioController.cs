﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    AudioSource au_source;
    [SerializeField]
    AudioClip gwizd, slash, kompromitacja, mistrz, kombo, znakomicie, nieslychanie, intro;

	Crowd _crowd;
	Crowd crowd { 
		get {
			if ( _crowd == null ) 
				_crowd = GameObject.FindObjectOfType<Crowd>();
			return _crowd;
		}
		set {
			_crowd = value;
		}
	}

    void Awake()
    {
        if (GameObject.FindObjectsOfType(typeof(AudioController)).Length <= 1)
        {
            au_source = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else DestroyObject(gameObject);
    }

	public void IntroSound () {
		au_source.PlayOneShot(intro);
	}

    public void PomidorCrashed()
    {
        au_source.PlayOneShot(slash, 0.05f);
    }

    public void KwiatekCaptured()
    {
        au_source.PlayOneShot(gwizd, 0.02f);
    }

    public void BothFailed()
    {
        au_source.PlayOneShot(kompromitacja,1f);
    }

    public void RandomComboSound(int r)
    {
        if (r == 0) au_source.PlayOneShot(kombo);
		if (r == 1) au_source.PlayOneShot(nieslychanie);
        if (r == 2) au_source.PlayOneShot(mistrz);

    }

	public void RandomBoo () {
		crowd.RandomBooSound();
	}

    public void Win()
    {

        StartCoroutine(Win2());
    }

    IEnumerator Win2()
    {
        au_source.PlayOneShot(znakomicie,1f);
        yield return new WaitForSeconds(1f);
		au_source.PlayOneShot(znakomicie,1f);
	}
	public void MegaWin()
    {
        StartCoroutine(MegaWin2());
    }

    IEnumerator MegaWin2()
    {
		au_source.PlayOneShot(znakomicie,1f);
		yield return new WaitForSeconds(1f);
		au_source.PlayOneShot(znakomicie,1f);
		yield return new WaitForSeconds(1f);
		au_source.PlayOneShot(znakomicie,1f);
		yield return new WaitForSeconds(1f);
		au_source.PlayOneShot(znakomicie,1f);
		
	}

    #region hide
    private static AudioController _instance;
    public static AudioController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType(typeof(AudioController)) as AudioController;
            }
            return _instance;
        }
    }
    #endregion
}
