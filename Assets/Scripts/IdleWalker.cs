using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleWalker : MonoBehaviour
{
    public GameObject dog;
    public float speed = 5f;
    Vector3 temp = new Vector3(-27f, -16f, -3f);
    private void Update()
    {
        transform.Translate(Vector3.right * Time.fixedDeltaTime * speed);
        if (transform.position.x > 25)
        {
            dog.transform.position = temp;
        }
      
    }
    
}
