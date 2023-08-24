using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb; 
    public GameObject topObstacleRaycast;
    public GameObject bottomObstacleRaycast;
    public float raycastDistance;
    private float GetVerticalSpeed() => rb.velocity.y;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D topHit = Physics2D.Raycast(topObstacleRaycast.transform.position, transform.TransformDirection(Vector2.right) * raycastDistance);
        RaycastHit2D bottomHit = Physics2D.Raycast(bottomObstacleRaycast.transform.position, transform.TransformDirection(Vector2.right) * raycastDistance);
        
        if(topHit){
            Debug.Log(topHit.collider.name);
            Debug.DrawRay(topObstacleRaycast.transform.position, transform.TransformDirection(Vector2.right) * raycastDistance, Color.red);
            
            if (GetVerticalSpeed() == 0){
                rb.velocity = new Vector2(speed*5, -10f).normalized;
            }
        }

        else if(bottomHit){
            Debug.Log(bottomHit.collider.name);
            Debug.DrawRay(bottomObstacleRaycast.transform.position, transform.TransformDirection(Vector2.right) * raycastDistance, Color.red);

            if (GetVerticalSpeed() == 0){
                rb.velocity = new Vector2(speed*5, -10f).normalized;
            }
        }

        else{
            if(!topHit){
                Debug.Log("All Clear Up Above!");
                Debug.DrawRay(topObstacleRaycast.transform.position, transform.TransformDirection(Vector2.right) * raycastDistance, Color.blue);
            }
            if(!bottomHit){
                Debug.Log("All Clear Up Below!");
                Debug.DrawRay(bottomObstacleRaycast.transform.position, transform.TransformDirection(Vector2.right) * raycastDistance, Color.blue);
            }

            rb.velocity = new Vector2(speed, 0f);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("hit");
        Destroy(other.gameObject);
        this.gameObject.SetActive(false);
    }
}
