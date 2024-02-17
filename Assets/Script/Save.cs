using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        float x = PlayerPrefs.GetFloat("PPX");
        float y = PlayerPrefs.GetFloat("PPY");
        float z = PlayerPrefs.GetFloat("PPZ");

        Player.position = new Vector3(x, y, z);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("PPX", Player.position.x);
        PlayerPrefs.SetFloat("PPY", Player.position.y);
        PlayerPrefs.SetFloat("PPZ", Player.position.z);
    }
}
