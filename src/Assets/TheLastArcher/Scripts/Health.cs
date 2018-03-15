using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Health : MonoBehaviour
{
    private BoxCollider2D _collider;
    private int _maxLives;

    [SerializeField]
    private int _lives;

	private void Start()
	{
        _collider = GetComponent<BoxCollider2D>();
        _maxLives = _lives;
	}

    public void Rise()
    {
        _collider.enabled = true;
        _lives = _maxLives;
    }

    public virtual bool Hit()
    {
        _lives--;

        if (_lives == 0) {
            _collider.enabled = false;

            return false;
        }

        return true;
    }
}