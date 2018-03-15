using UnityEngine;

public class HeroineBow : MonoBehaviour
{
    private PoolingSystem _poolingSystem;
    private float _nextShot;

    [SerializeField]
    private float _shotRate;

    private void Start()
    {
        _poolingSystem = FindObjectOfType<PoolingSystem>();
    }

    public bool Shoot(Vector2 position)
    {
        if (Time.time > _nextShot) {
            _nextShot = Time.time + _shotRate;

            GameObject obj = _poolingSystem.Dequeue("Arrow", position);

            var arrow = obj.GetComponent<Arrow>();
            if (arrow) {
                arrow.OnAfterArrowHit += OnAfterArrowHit;
            }

            return true;
        }

        return false;
    }

    private void OnAfterArrowHit(bool hit)
    {
        Debug.LogFormat("Hit: {0}", hit);
    }
}