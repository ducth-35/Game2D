using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cnvChuyenDong : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D cnv;

    void Start()
    {
        cnv = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public bool isBottom = false;

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag =="Ground"){
            isBottom=true;
        }else{
            isBottom=false;
        }
    }
    void Update()
    {
        float move = 0f;
        if(isBottom==true){
            move = 2f;
        }
        else{
            move = -2f;
        }
        cnv.velocity = new Vector2(0,transform.localScale.y)*move;

    }
    

}
