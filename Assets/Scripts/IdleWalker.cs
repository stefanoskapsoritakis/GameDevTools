using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleWalker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dog;

    private float runSpeed = 5f;

    bool jump = false;
    Vector3 temp = new Vector3(-25.91f, -16.18f, -3f);

    // Update is called once per frame
    void Update()
    {
        transform.Translate((Vector3.right * runSpeed) * Time.fixedDeltaTime );
        if(dog.transform.position.x > 25)
        {
            dog.transform.position = temp;

        }


    }

}
