﻿using UnityEngine;
using UnityEngine.UI;

public class UIArrow : MonoBehaviour
{
    private MoveGen.Move _move;
    public ParticleSystem Green;
    public ParticleSystem Red;

    public void Init(MoveGen.Move move, Sprite sprite)
    {
        transform.localScale = Vector3.one;
        GetComponent<Image>().sprite = sprite;
        GetComponent<RectTransform>().anchoredPosition = new Vector2(200, 0);
        _move = move;
        _move.Used += _move_Used;
    }

    private void _move_Used(bool used)
    {
        GetComponent<Image>().color = used ? new Color(0, 1, 0) : new Color(1, 0, 0);
        if (used) Green.Play();
        else Red.Play();
    }

    void Update()
    {
        GetComponent<RectTransform>().anchoredPosition = new Vector2(Mathf.Lerp(190, -200, _move.Progress), 0);
        if (_move.Progress >= 1) Destroy(gameObject);
    }
}