﻿using UnityEngine;
using System.Collections;

public class EndGameController : MonoBehaviour {
	public Animator p1,p2;
	public Sprite kra_lose;
	public Sprite gor_lose;

	void Start () {
		int winner = PlayerPrefs.GetInt("winner");
		if ( winner == 0 ) {
			p1.enabled = false;
			p1.GetComponent<SpriteRenderer>().sprite = gor_lose;
			p2.enabled = false;
			p2.GetComponent<SpriteRenderer>().sprite = kra_lose;
			StartCoroutine(CrowdBoo());
			AudioController.Instance.BothFailed();
		}
		else if ( winner == 1 ) {
			p1.Play("win");
			p2.enabled = false;
			p2.GetComponent<SpriteRenderer>().sprite = kra_lose;
			AudioController.Instance.Win();
		}
		else if ( winner == 2 ) {
			p2.Play("win");
			p1.enabled = false;
			p1.GetComponent<SpriteRenderer>().sprite = gor_lose;
			AudioController.Instance.Win();
		}else if ( winner == 3 ) {
			p1.Play("win");
			p2.Play("win");
			AudioController.Instance.Win();
		} else {
			 throw new UnityException("wuut? available : 0 / 1 / 2 / 3");
		}
		//
	}

	IEnumerator CrowdBoo () {
		while (true ) {
			yield return new WaitForSeconds(1);
			Spawner.Instance.ThrowPomidorAt(p1.transform.position,4);
			Spawner.Instance.ThrowPomidorAt(p2.transform.position,4);
		}
	}
}
