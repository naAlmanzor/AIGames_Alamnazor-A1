using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb; 
    public GameObject obstacleRaycast;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitObstacle = Physics2D.Raycast(obstacleRaycast.transform.position, transform.TransformDirection(Vector2.right) * 10f);

        if(hitObstacle){
            Debug.Log(hitObstacle.collider.name);
            Debug.DrawRay(obstacleRaycast.transform.position, transform.TransformDirection(Vector2.right) * 10f, Color.red);
        }

        else{
            Debug.Log("All Clear!");
            Debug.DrawRay(obstacleRaycast.transform.position, transform.TransformDirection(Vector2.right) * 10f, Color.red);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Asteroid")
        Debug.Log("hit");
        Destroy(other.gameObject);
        this.gameObject.SetActive(false);
    }
}
