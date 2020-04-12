using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playScript : MonoBehaviour
{
    private Animator player;

    public float speed=5f;
    public float jumpHeight=5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            player.SetBool("Run",true);//doi trang thai
            player.SetBool("Idle",false);
            //di chuyen
            gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
            if(gameObject.transform.localScale.x<0)
            {
                gameObject.transform.localScale=
                new Vector3(gameObject.transform.localScale.x * -1,
                gameObject.transform.localScale.y,
                gameObject.transform.localScale.z
                );
        }
    }
    else if(Input.GetKey(KeyCode.LeftArrow))
    {
        player.SetBool("Run",true);
        player.SetBool("Idle",false);
        gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
        if(gameObject.transform.localScale.x>0)
        {
            gameObject.transform.localScale=
            new Vector3(gameObject.transform.localScale.x * -1,
            gameObject.transform.localScale.y,
            gameObject.transform.localScale.z
            );
        }
    }
    else if(Input.GetKey(KeyCode.Space))
    {
        player.SetBool("Run",false);
        player.SetBool("Idle",true);
        gameObject.GetComponent<Rigidbody2D>().velocity=
        new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x,jumpHeight);
    }
    else{
        player.SetBool("Run",false);
        player.SetBool("Idle",true);
    }
    }

    
}
