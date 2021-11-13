using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 offset;

    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerTransform = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        offset.x = playerTransform.forward.x * 2.5f;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerTransform.position.x + offset.x,
           playerTransform.position.y + offset.y, playerTransform.position.z + offset.z), 50 * Time.deltaTime);
    }
}
