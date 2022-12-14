using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int currentHealth, maxHealth;

    public float invincibleLength;
    private float invincibleCount;

    private SpriteRenderer theSR;

    private void Awake()
    {
        instance = this; //can access from other scripts
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibleCount > 0)
        {
            invincibleCount -= Time.deltaTime;
            
            if(invincibleCount <= 0)
            {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);

            }
        }
    }

    public void DealDamage()
    {
        if (invincibleCount <= 0)
        { 
            currentHealth--;

            if(currentHealth <= 0)
            {
                currentHealth = 0;
                gameObject.SetActive(false);
                //PlayerLife.instance.Die();
                PlayerLife.instance.RestartLevel();
            }
            else
            {
                invincibleCount = invincibleLength;

                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b,  0.5f);

            }
        }
    }
}
