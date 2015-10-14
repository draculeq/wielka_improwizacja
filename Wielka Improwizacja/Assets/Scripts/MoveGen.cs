using System;
using UnityEngine;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public enum MOVE { UP, DOWN, LEFT, RIGHT }

public class MoveGen : MonoBehaviour
{

    public event Action<Move> NewMoveGenerated;
    public float genInterval;

    static MOVE[] tableMut = { MOVE.UP, MOVE.DOWN, MOVE.LEFT, MOVE.RIGHT };

    public Move[] moves;//  { get; private set; } 
    public Move currentMove
    {
        get
        {
            return moves.FirstOrDefault(a => a.IsCurrent());
        }
    }

    int currentIndex;

    void Awake()
    {
        StartGen();
    }

    IEnumerator _gen;

    public void StartGen()
    {
        if (_gen == null)
            StartCoroutine(_gen = Gen());
    }

    public void StopGen()
    {
        if (_gen != null)
        {
            StopCoroutine(_gen);
            _gen = null;
        }
    }

    void OnGUI()
    {
        if (GUILayout.Button("Start Gen"))
        {
            StartGen();
        }
        if (GUILayout.Button("Stop Gen"))
        {
            StopGen();
        }
    }

    IEnumerator Gen()
    {
        while (true)
        {
            yield return new WaitForSeconds(genInterval);
            GenMove(1);
        }
    }

    void GenMove(int nb)
    {
        while (nb > 0)
        {
            currentIndex = (currentIndex + 1) % moves.Length;
            moves[currentIndex] = new Move(tableMut[Random.Range(0, tableMut.Length)], Time.time + genInterval / 2, 0.5f);
            if (NewMoveGenerated != null) NewMoveGenerated(moves[currentIndex]);
            nb--;
        }
    }

    [Serializable]
    public class Move
    {
        [SerializeField]
        private MOVE _direction;

        private bool _used;
        private bool _skipped;
        private float _spawnedTime;
        private float _time;
        private float _timeTolerance;
        public MOVE Direction { get { return _direction; } }
        public float Progress
        {
            get
            {
                return (Time.time - _spawnedTime) / lifeTime;
            }
        }
        private float lifeTime { get { return (_time - _spawnedTime) * 2; } }
        public event Action<bool> Used;

        public Move(MOVE direction, float time, float timeTolerance)
        {
            _spawnedTime = Time.time;
            _direction = direction;
            _time = time;
            _timeTolerance = timeTolerance;
        }

        public bool IsCurrent()
        {
            if (_used || _skipped) return false;
            if (Time.time > _time - _timeTolerance && Time.time < _time + _timeTolerance)
                return true;
            if (Time.time > _time + _timeTolerance)
            {
                _skipped = true;
                if (Used != null) Used(false);
            }
            return false;
        }

        public bool Check(MOVE direction)
        {
            if (_used) return false;
            if (_direction == direction)
            {
                _used = true;
                if (Used != null) Used(true);
            }
            return _direction == direction;
        }
    }
}
