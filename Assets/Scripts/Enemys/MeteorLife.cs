using UnityEngine;
using Random = UnityEngine.Random;

public class MeteorLife : MonoBehaviour, IEnemyLife
{
    private const float MAX_ANGULAR_VELOSITY = 10.0f;
    private const int DAMAGE_MULTIPLIER = 10;
    private const int SCORE_MULTIPLIER = 10;
    
    [SerializeField] private DataMeteor _dataMeteor;

    private int _health;

    private Rigidbody _rigidbody;

    private void OnEnable()
    {
        GameEventManager.OnGameOver += GameOver;
    }

    private void Start()
    {
        _health = _dataMeteor.Health;
        
        transform.localScale = _dataMeteor.Scale;
        
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddTorque(new Vector3(Random.Range(0.0f, 1.0f), 1.0f, 0.0f) * MAX_ANGULAR_VELOSITY - transform.localScale);
        _rigidbody.AddForce(Vector3.left * _dataMeteor.Speed);
    }

    private void OnDisable()
    {
        GameEventManager.OnGameOver -= GameOver;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameEventManager.SendChangeHealth(-(int)transform.localScale.magnitude * DAMAGE_MULTIPLIER);
            GameEventManager.SendDestroyEnemy(this);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Zone"))
        {
            GameEventManager.SendDestroyEnemy(this);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int value)
    {
        _health -= value;

        if (_health <= 0)
        {
            GameEventManager.SendChangeScore((int)transform.localScale.magnitude * SCORE_MULTIPLIER);
            GameEventManager.SendDestroyEnemy(this);
            Destroy(gameObject);
        }
    }

    private void GameOver()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }
}
