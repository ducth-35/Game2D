using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chuyenDongNgang : MonoBehaviour
{
    // Start is called before the first frame update
   private Rigidbody2D cdn;

    void Start()
    {
        cdn = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public bool isLeft = false;
    //nhân vật sẽ xuyên qua
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag =="Left"){
            isLeft=true;
        }else{
            isLeft=false;
        }
    }
   // nhân vật bị đẩy ngược lại
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag =="Left"){
            isLeft=true;
        }else{
            isLeft=false;
        }
    }
    void Update()
    {
        float move = 0f;
        if(isLeft==true){
            move = 1f;
        }
        else{
            move = -1f;
        }
        cdn.velocity = new Vector2(transform.localScale.x,0)*move;

    }
    
}
