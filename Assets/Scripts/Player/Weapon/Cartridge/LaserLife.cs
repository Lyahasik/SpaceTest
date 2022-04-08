using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLife : MonoBehaviour, ICartridge
{
    private const float DELAY_DAMAGE = 0.1f;
    
    private int _damage;

    private List<IEnemyLife> _listEnemys;

    public void Init(int damage)
    {
        _listEnemys = new List<IEnemyLife>();
        _damage = damage;
    }

    private void OnEnable()
    {
        GameEventManager.OnDestroyEnemy += DestroyEnemy;
    }

    private void OnDisable()
    {
        GameEventManager.OnDestroyEnemy -= DestroyEnemy;
    }

    private void Start()
    {
        StartCoroutine(CauseDamage());
    }

    private void Update()
    {
        if (GameplayController.IsPlaying && Input.GetButtonUp("Fire1")) Destroy(gameObject);
    }

    void DestroyEnemy(IEnemyLife enemy)
    {
        _listEnemys.Remove(enemy);
    }

    private IEnumerator CauseDamage()
    {
        while (true)
        {
            if (!GameplayController.IsPlaying) yield break;
                
            yield return new WaitForSeconds(DELAY_DAMAGE);
            
            foreach (IEnemyLife enemy in _listEnemys.ToArray())
            {
                enemy.TakeDamage(_damage);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) _listEnemys.Add(other.GetComponent<IEnemyLife>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy")) _listEnemys.Remove(other.GetComponent<IEnemyLife>());
    }
}
