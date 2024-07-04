using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane; // Referensi ke pesawat
    private Vector3 offset;  // Offset antara kamera dan pesawat

    // Start is called before the first frame update
    void Start()
    {
        // Hitung offset awal antara kamera dan pesawat
        offset = transform.position - plane.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Pindahkan kamera untuk mengikuti pesawat
        transform.position = plane.transform.position + offset;
    }
}
