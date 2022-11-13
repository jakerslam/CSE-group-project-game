using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEditor.SceneManagement;

public class DamagePlayer : MonoBehaviour
{
    //public float countDown = 10;

    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        //if (EditorSceneManager.GetActiveScene().name == "Testing2")
        //{
        //    countDown -= Time.deltaTime;
        //    if (countDown <= 0)
        //    {
        //        EditorSceneManager.LoadScene(sceneName: "Testing");
        //        countDown = 10;

        //    }

        //}

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerHealthController.instance.DealDamage();

            //EditorSceneManager.LoadScene(sceneName: "Testing2");

            
        }
        
    }
}
