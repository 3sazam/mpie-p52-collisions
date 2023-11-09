using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    int Ammo = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Ammo > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ammo -= 1;
                Shoot();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "AmmoBox")
        {
            other.gameObject.SetActive(false);
        }
    }

    void Shoot()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));

        RaycastHit result;
        bool hit = Physics.Raycast(ray, out result);

        if (hit)
        {
            if (result.collider.gameObject.name == "Target")
            {
                GameObject g = result.collider.gameObject;
                Animation a = g.transform.parent.GetComponent<Animation>();
                a.Play("LowerBridge");

            }
        }
    }
}
