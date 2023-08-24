using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb; 
    public GameObject obstacleRaycast;
    public float raycastDistance;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitObstacle = Physics2D.Raycast(obstacleRaycast.transform.position, transform.TransformDirection(Vector2.right) * raycastDistance);

        if(hitObstacle){
            Debug.Log(hitObstacle.collider.name);
            Debug.DrawRay(obstacleRaycast.transform.position, transform.TransformDirection(Vector2.right) * raycastDistance, Color.red);
        }

        else{
            Debug.Log("All Clear!");
            Debug.DrawRay(obstacleRaycast.transform.position, transform.TransformDirection(Vector2.right) * raycastDistance, Color.blue);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("hit");
        Destroy(other.gameObject);
        this.gameObject.SetActive(false);
    }
}
