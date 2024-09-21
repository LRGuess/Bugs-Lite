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
        portal = GameObject.Find("Portal");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        // Rotate and point the minimap arrow at the portal
        if (portal != null)
        {
            Vector3 direction = portal.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
