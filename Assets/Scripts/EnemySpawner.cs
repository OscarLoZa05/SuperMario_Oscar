using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [Header("Spawn Enemigos")]
    [Tooltip("Prefabs de enemeigos")]
    [SerializeField] private GameObject[] _enemiesPrefab;
    
    [Tooltip("Numeros de enemigos que vana a spawnear")]
    [SerializeField] private int _enemiesToSpawn;
    [SerializeField] private Transform[] _spawnPoint;
    [SerializeField] private int _enemyIndex;



    private BoxCollider2D _boxCollider2D;
    
    void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        /*if(_enemiesToSpawn <= 0)
        {
            CancelInvoke();
        }*/
    }

    IEnumerator SpawnEnemy()
    {
        
        for (int i = 0; i < _enemiesToSpawn; i++)
        {
            foreach (Transform spawn in _spawnPoint)
            {
                _enemyIndex = Random.Range(0, _enemiesPrefab.Length);
                Instantiate(_enemiesPrefab[_enemyIndex], spawn.position, spawn.rotation);

                yield return new WaitForSeconds(1);
            }

            yield return new WaitForSeconds(1);
        }
        
        //Instantiate(_enemiesPrefab[_enemyIndex], _spawnPoint.position, _spawnPoint.rotation);
        _enemiesToSpawn --;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            //Invoke("SpawnEnemy", 5) --> Llama la funcion enemy despues de 5 segundos
            /*InvokeRepeating("SpawnEnemy", 0, 5); //--> El segundo valor es cada cuanto quiero que llame a la funcion, el primer nuneri es para el tiempo en 
            que tarda la primera vez en llamarse*/
            
            _boxCollider2D.enabled = false;
            StartCoroutine(SpawnEnemy());
        }
    }


}
