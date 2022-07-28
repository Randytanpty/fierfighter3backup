using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class FPSShootingControls : MonoBehaviour
{
    private Camera mainCam;
    private float  fireRate = 15f;
    private float nextTimeToFire = 0f;

    [SerializeField]
    private GameObject concrete_Impact;

    private int countingScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot() {
        if (Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire) {
            nextTimeToFire = Time.time + 1f / fireRate;

            RaycastHit hit;

            if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit)) {
                // 1print("We hit" + hit.collider.gameObject.name);
                // print("The position of the object is" + hit.transform.position);
                // print("The point is" + hit.point);
                Instantiate(concrete_Impact, hit.point, Quaternion.LookRotation(hit.normal));

                GameObject hitTarget = hit.collider.gameObject;
                if (hitTarget.name == "cube") {
                    Cube cube = hitTarget.GetComponent<Cube>();
                    hit.collider.gameObject.SetActive(false);
                    cube.getHit(++countingScore);
                }
                
            }
        }
    }


} // class
