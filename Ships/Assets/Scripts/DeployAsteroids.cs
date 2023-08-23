using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployAsteroids : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroids());
    }

    private void spawnAsteroid(){
        GameObject asteroid = Instantiate(asteroidPrefab) as GameObject;
        asteroid.transform.position = new Vector2(screenBounds.x * -1, Random.Range(-screenBounds.y, screenBounds.y));
    }

    IEnumerator asteroids(){
        while(true){
            yield return new WaitForSeconds(respawnTime);
            spawnAsteroid();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
