﻿using UnityEngine;
using System.Collections;

public class EndGameController : MonoBehaviour {
	public Animator p1,p2;
    public GameObject LoseSprite;
    public GameObject Win1Sprite;
    public GameObject Win2Sprite;
	void Start () {
		crowdBoo = true;
		int winner = PlayerPrefs.GetInt("winner");
		if ( winner == 0 ) {
			p1.Play("lose");
			p2.Play("lose");
			StartCoroutine(CrowdBoo());
			AudioController.Instance.BothFailed();
		    StartCoroutine(Lose());
		}
		else if ( winner == 1 ) {
			p1.Play("win");
			p2.Play("lose");
			AudioController.Instance.Win();
			StartCoroutine(Win1());
        }
        else
        {
            p1.Play("lose");
            p2.Play("win");
            AudioController.Instance.Win();
            StartCoroutine(Win2());
        }
	    //}else if ( winner == 3 ) {
            //	p1.Play("win");
            //	p2.Play("win");
            //	AudioController.Instance.Win();
            //    StartCoroutine(Win2());
            //} else
            //      {
            //          throw new UnityException("wuut? available : 0 / 1 / 2 / 3");
            //}
            //
        }

	bool crowdBoo;
    IEnumerator CrowdBoo () {
		while (crowdBoo ) {
			VisualTextControl.Instance.RandomBoo(6);
			yield return new WaitForSeconds(1);
			Spawner.Instance.ThrowPomidorAt(p1.transform.position,4);
			Spawner.Instance.ThrowPomidorAt(p2.transform.position,4);
		}
	}
    IEnumerator Lose()
    {
        yield return new WaitForSeconds(3);
        LoseSprite.SetActive(true);
		crowdBoo = false;

    }
    IEnumerator Win1()
    {
        yield return new WaitForSeconds(3);
		Win1Sprite.SetActive(true);
		crowdBoo = false;
    }
    IEnumerator Win2()
    {
        yield return new WaitForSeconds(3);
		Win2Sprite.SetActive(true);
		crowdBoo = false;
    }
}
