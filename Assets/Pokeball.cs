using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokeball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Move the Pokeball forward at 2 units per second
        transform.position += Time.deltaTime * transform.forward * 2f;
    }
}
