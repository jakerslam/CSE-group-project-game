using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyMove : MonoBehaviour
{
    bool canFlip = true;
    bool facingRight = false;
    float flipTime = 5f;
    float nextFlipChance = 0f;
    Transform enemyTransform;
    public float enemyAccel;
    public float maxSpeed = 20f;
    public float chargeTime;
    float startChargeTime;
    bool charging = false;
    Rigidbody2D enemyRB;
    Animator enemyAC;
    // Start is called before the first frame update
    void Start()
    {
        enemyTransform = GetComponent<Transform>();
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAC = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextFlipChance)
        {
            if(Random.Range(0,10) >= 5)
            {
                flipFacing();
            }
            nextFlipChance = Time.time + flipTime;
        }
        if(charging && Time.time > startChargeTime && enemyRB.velocity.x < maxSpeed)
        {
            if(!facingRight)
            {
                enemyRB.AddForce(new Vector2(-1f, 0f) * enemyAccel);
            }
            else
            {
                enemyRB.AddForce(new Vector2(1f, 0f) * enemyAccel);
            }
            enemyAC.SetBool("isCharging", charging);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(facingRight && other.transform.position.x < transform.position.x)
            {
                flipFacing();
            }
            else if(!facingRight && other.transform.position.x > transform.position.x)
            {
                flipFacing();
            }
            canFlip = false;
            charging = true;
            startChargeTime = Time.time + chargeTime;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            charging = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            canFlip = true;
            charging = false;
            enemyRB.velocity = new Vector2(0f, 0f);
            enemyAC.SetBool("isCharging", charging);
        }
    }
    void flipFacing()
    {
        if(!canFlip)
        {
            return;
        }
        else
        {
            float facingX = enemyTransform.localScale.x;
            facingX *= -1;
            enemyTransform.localScale = new Vector3(facingX, enemyTransform.localScale.y, enemyTransform.localScale.z);
            facingRight = !facingRight;
        }
    }
}