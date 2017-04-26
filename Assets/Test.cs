using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;
using UBootstrap;

public class Test : MonoBehaviour
{

    // Use this for initialization
    void Start ()
    {
//        CUSTOM_ASSERT.Fail ("Fail");

        GameObject go = null;
        CUSTOM_ASSERT.IsNotNull (go, "go is null {0} {1}", 1,2);
    }
	
    // Update is called once per frame
    void Update ()
    {
	
    }
}
