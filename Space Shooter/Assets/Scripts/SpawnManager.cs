using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    //[SerializeField]
    //private GameObject _tripleShot;
    //[SerializeField]
    //private GameObject _speedUpPrefab;
    [SerializeField]
    private GameObject[] powerUps;



    private bool _stopSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SpawnEnemy(5));
        //StartCoroutine(SpawnPowerUp());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Calls once the asteroid has been destroyed
    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemy(5));
        StartCoroutine(SpawnPowerUp());
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }

    private IEnumerator SpawnEnemy(float time)
    {
        yield return new WaitForSeconds(3.0f);

        while (!_stopSpawning)
        {
            Vector3 positionToSpawn = new Vector3(Random.Range(-9f, 9f), 7f, 0);
            GameObject prefab = Instantiate(_enemyPrefab,positionToSpawn, Quaternion.identity);
            prefab.transform.SetParent(_enemyContainer.transform);
            yield return new WaitForSeconds(time);
        }        
    }

    private IEnumerator SpawnPowerUp()
    {
        yield return new WaitForSeconds(5.0f);

        while (!_stopSpawning)
        {
            int randNum = Random.Range(0, 3);
            Vector3 positionToSpawn = new Vector3(Random.Range(-8f, 8f), 7f, 0);
            Instantiate(powerUps[randNum], positionToSpawn, Quaternion.identity);
            //if(randNum == 0)
            //{
            //    //Instantiate(_tripleShot, positionToSpawn, Quaternion.identity);
            //}else if(randNum == 1)
            //{
            //    //Instantiate(_speedUpPrefab, positionToSpawn, Quaternion.identity);
            //}
            
            yield return new WaitForSeconds(Random.Range(3, 8));
           

        }
    }
}
