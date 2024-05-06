using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float paralaxOffset = -0.15f;

    private Camera cam;
    private Vector2 startPosition;
    private Vector2 travel => (Vector2)cam.transform.position - startPosition;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Start()
    {
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = startPosition + travel * paralaxOffset; 
    }
}
