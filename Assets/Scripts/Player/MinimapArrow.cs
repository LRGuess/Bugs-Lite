using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapArrow : MonoBehaviour
{
    private GameObject portal;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        portal = GameObject.FindWithTag("Portal"); // Find the GameObject with the "Portal" tag
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        Vector3 direction = portal.transform.position - transform.position;
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
