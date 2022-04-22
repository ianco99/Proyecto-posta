using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reflectionScript : MonoBehaviour
{
    Animator anim;
    GameObject player;
    Vector3 direction;
    SpriteRenderer sprite;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    private void Update()
    {
        sprite.sprite = player.GetComponentInChildren<SpriteRenderer>().sprite;
    }
    void FixedUpdate()
    {
        //direction = GetComponentInParent<Transform>().position;
        //direction.y = -direction.y;

        direction = player.transform.position;
        direction.y = -direction.y + 1.829992f;
        transform.position = direction;
    }
}
