using UnityEngine;

public class TumbleweedContainer : MonoBehaviour
{
    [SerializeField] private Transform _tumbleweed;

    [SerializeField] private float _speed;

    [SerializeField] private Transform[] _pointToMoveTo;
    [SerializeField] private int _currentPoint;

    private void Start()
    {
        _tumbleweed.position = _pointToMoveTo[_currentPoint].position;
    }

    void Update()
    {
        if (Vector2.Distance(_tumbleweed.position, _pointToMoveTo[_currentPoint].position) < .1f)
        {
            _currentPoint++;
        }

        if (_currentPoint >= _pointToMoveTo.Length)
        {
            _currentPoint = 0;
            _tumbleweed.position = _pointToMoveTo[_currentPoint].position;
        }

        var step = _speed * Time.deltaTime;
        _tumbleweed.position = Vector3.MoveTowards(_tumbleweed.position, _pointToMoveTo[_currentPoint].position, step);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        for (int i = 0; i < _pointToMoveTo.Length - 1; i++)
        {
            Gizmos.DrawLine(_pointToMoveTo[i].position, _pointToMoveTo[i + 1].position);
            Gizmos.DrawSphere(_pointToMoveTo[i].position, 0.5f);
        }
        Gizmos.DrawSphere(_pointToMoveTo[_pointToMoveTo.Length - 1].position, 0.5f);
    }
}
