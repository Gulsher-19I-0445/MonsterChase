using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    private Rigidbody2D mybody;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        mybody.velocity = new Vector2(speed, mybody.velocity.y);
    }




}///Class
