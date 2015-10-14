using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class LoadNextScene : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GetComponent<Image>().color = new Color(1,1,1,0);
        GetComponent<Image>().DOFade(1, 0.5f).OnComplete(() =>
        {
            var seq = DOTween.Sequence();
            seq.Insert(2, GetComponent<Image>().DOFade(0, 0.5f))
                .OnComplete(() => Application.LoadLevel(Application.loadedLevel + 1));
        });
    }
}
