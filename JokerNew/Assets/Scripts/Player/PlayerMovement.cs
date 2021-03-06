using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float speed = 0.4f;
    Vector2 dest = Vector2.zero;

    //evans code
    Vector2 movement;
    Rigidbody2D rigidbody;

    void Start()
    {
        dest = transform.position;

        //evans code
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        //evans code
        /*
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement.Set(x, y);
        movement = movement.normalized * speed * Time.deltaTime;

        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        rigidbody.MovePosition(pos + movement);
        */
         

        
        // Move closer to Destination
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        GetComponent<Rigidbody2D>().MovePosition(pos + p);
        // Check for Input if not moving
        if ((Vector2)transform.position == dest)
        {
            if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
                dest = (Vector2)transform.position + Vector2.up;
            if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
                dest = (Vector2)transform.position + Vector2.right;
            if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
                dest = (Vector2)transform.position - Vector2.up;
            if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
                dest = (Vector2)transform.position - Vector2.right;
        }
         
        // Animation Parameters
       /* Vector2 dir = dest - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);*/
    }
    bool valid(Vector2 dir)
    {
        // Cast Line from animation to next animation
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }
}
