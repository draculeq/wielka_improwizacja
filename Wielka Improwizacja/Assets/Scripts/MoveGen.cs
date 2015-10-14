﻿using System;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public enum MOVE : int { UP, DOWN, LEFT, RIGHT }

public class MoveGen : MonoBehaviour
{
    public event Action<Move> NewMoveGenerated;
    public float lifeTime;
    public float timetolerance = 0.3f;

    static MOVE[] tableMut = { MOVE.UP, MOVE.DOWN, MOVE.LEFT, MOVE.RIGHT };

    public Move[] moves;
    public Move currentMove
    {
        get
        {
            var a = moves.FirstOrDefault(b => b.IsCurrent());
            return a;
        }
    }

    int currentIndex;

    void Awake()
    {
        var s = GetComponent<AudioSpecTest>();
        s.onMoveBeingGenerated = OnMoveBeingGenerated;
        s.StartGen();
    }

    private void OnMoveBeingGenerated(MOVE m)
    {
        currentIndex = (currentIndex + 1)%moves.Length;
        moves[currentIndex] = new Move(tableMut[Random.Range(0, tableMut.Length)], lifeTime, timetolerance,transform);
        if (NewMoveGenerated != null) NewMoveGenerated(moves[currentIndex]);
    }


    [Serializable]
    public class Move
    {
        [SerializeField]
        private MOVE _direction;

        private bool _used;
        private bool _skipped;
        private float _spawnedTime;
        public float _time;
        private float _timeTolerance;
        private Transform _player;
        public MOVE Direction { get { return _direction; } }
        public float Progress
        {
            get
            {
                return (Time.time - _spawnedTime) / _lifeTime;
            }
        }

        public float _lifeTime;
        public event Action<bool> Used;

        public Move(MOVE direction, float lifeTime, float timeTolerance, Transform player)
        {
            _lifeTime = lifeTime;
            _spawnedTime = Time.time;
            _direction = direction;
            _time = _spawnedTime + _lifeTime/2;
            _timeTolerance = timeTolerance;
            _player = player;
        }

        public bool IsCurrent()
        {
            if (_used || _skipped) return false;
            if (Time.time > _time - _timeTolerance && Time.time < _time + _timeTolerance)
            {
                return true;
            }
            if (Time.time > _time + _timeTolerance)
            {
                Fail();
            }
            return false;
        }

        public bool Check(MOVE direction)
        {
            if (_used)
            {
                return false;
            }
            if (_direction == direction)
            {
                _used = true;
                if (Used != null) Used(true);
            }
            return _direction == direction;
        }

        public void Fail()
        {
            _skipped = true;
            if (Used != null) Used(false);
            if (Spawner.Instance != null) if (_player != null) Spawner.Instance.ThrowPomidorAt(_player.position);
        }
    }
}
