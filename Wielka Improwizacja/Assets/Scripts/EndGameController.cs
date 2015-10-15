using UnityEngine;
using System.Collections;

public class EndGameController : MonoBehaviour {
	public Animator p1,p2;

	void Start () {
		int winner = PlayerPrefs.GetInt("winner");
		if ( winner == 0 ) {
			p1.Play("lose");
			p2.Play("lose");
			StartCoroutine(CrowdBoo());
			AudioController.Instance.BothFailed();
		}
		else if ( winner == 1 ) {
			p1.Play("win");
			p2.Play("lose");
			AudioController.Instance.Win();
		}
		else if ( winner == 2 ) {
			p1.Play("lose");
			p2.Play("win");
			AudioController.Instance.Win();
		}else if ( winner == 3 ) {
			p1.Play("win");
			p2.Play("win");
			AudioController.Instance.Win();
		} else {
			 throw new UnityException("wuut? available : 0 / 1 / 2 / 3");
		}
	}

	IEnumerator CrowdBoo () {
		while (true ) {
			yield return new WaitForSeconds(1);
			Spawner.Instance.ThrowPomidorAt(p1.transform.position,4);
			Spawner.Instance.ThrowPomidorAt(p2.transform.position,4);
		}
	}
}
