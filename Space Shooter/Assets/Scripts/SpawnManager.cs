using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject _tripleShot;
    private bool _stopSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy(5));
        StartCoroutine(SpawnPowerUp());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }

    private IEnumerator SpawnEnemy(float time)
    {

        while (!_stopSpawning)
        {
            Vector3 positionToSpawn = new Vector3(Random.Range(-9f, -9f), 7f, 0);
            GameObject prefab = Instantiate(_enemyPrefab,positionToSpawn, Quaternion.identity);
            prefab.transform.SetParent(_enemyContainer.transform);
            yield return new WaitForSeconds(time);
        }        
    }

    private IEnumerator SpawnPowerUp()
    {
        while (!_stopSpawning)
        {           
            Vector3 positionToSpawn = new Vector3(Random.Range(-8f, -8f), 7f, 0);
            Debug.Log(positionToSpawn);
            Instantiate(_tripleShot, positionToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3, 8));
           

        }
    }
}
