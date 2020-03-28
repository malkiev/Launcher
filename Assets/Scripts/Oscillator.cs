using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f;

    Vector3 startingPoint;
    float movementFactor;
    // Start is called before the first frame update
    void Start()
    {
        startingPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon)
            return;

        float cycles = Time.time / period; //grows continually from 0

        const float tau = Mathf.PI * 2; // about 6.28
        float rawSinWav = Mathf.Sin(cycles * tau); // goes from -1 to 0
        
        movementFactor = rawSinWav / 2 + 0.5f;
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPoint + offset;
    }
}
