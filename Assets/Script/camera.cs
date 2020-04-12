using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null){
            Vector3 pos = transform.position;
            pos.x = player.position.x;
            pos.y = player.position.y;
            transform.position = pos;
        }
    }
}
