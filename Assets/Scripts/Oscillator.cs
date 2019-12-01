using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [Range(0, 1)] [SerializeField] float movementFactor;
    [SerializeField] float period = 2f;

    Vector3 startingPoint;
    // Start is called before the first frame update
    void Start()
    {
        startingPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        float cycles = Time.time / period; //grows continually from 0

        const float tau = Mathf.PI * 2; // about 6.28
        float rawSinWav = Mathf.Sin(cycles * tau);
        print(rawSinWav);
        //var value = Mathf.Sin()
        movementFactor = rawSinWav / 2 + 0.5f;
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPoint + offset;
    }
}
