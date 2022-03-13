using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse3dPosition : MonoBehaviour
{
    [SerializeField] private Camera myCamera;

    // Start is called before the first frame update
    void Start()
    {
        myCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Ray rayo = myCamera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(rayo, out RaycastHit golpe);
        transform.position = new Vector3(golpe.point.x,0.25f,golpe.point.z );
    }
}
