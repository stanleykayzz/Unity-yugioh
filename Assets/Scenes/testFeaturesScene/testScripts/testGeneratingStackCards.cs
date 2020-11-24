using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testGeneratingStackCards : MonoBehaviour {

    public GameObject blue,jaune;

    public GameObject sphere;
    private Vector3 scaleChange, positionChange;
    private int count = 40;

    void Awake()
    {
//        Camera.main.clearFlags = CameraClearFlags.SolidColor;

        // Create a sphere at the origin.
//        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
//        sphere = (GameObject)Instantiate(sphere);
        //        sphere.transform.position = new Vector3(0, 0, 0);
        //        sphere.transform.position = jaune.transform.position;

        int increment = 0;
        for(int i = 0; i< count; i++)
        {
            sphere = (GameObject)Instantiate(sphere);
            sphere.transform.position = jaune.transform.position;
            sphere.transform.SetPositionAndRotation(new Vector3(sphere.transform.position.x, sphere.transform.position.y, sphere.transform.position.z + increment), new Quaternion());
            increment -= 7;
        }

//        scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);
  //      positionChange = new Vector3(0.0f, -0.005f, 0.0f);
    }

    // Use this for initialization
    void Start () {
        Debug.Log("generate blue instace in yellow div");

        //        Instantiate(prefab, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
        // Instantiate(blue);
        GameObject b = (GameObject)Instantiate(blue);
        // Instantiate(blue);
        b.transform.SetParent(jaune.transform, false);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
