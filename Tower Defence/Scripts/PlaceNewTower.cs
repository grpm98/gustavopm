using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceNewTower : MonoBehaviour
{
    [SerializeField] private GameObject firstTurret;

    [SerializeField] private Camera myCamera;
    [SerializeField] private GameObject myPointer;

    private Ray rayo;


    // Start is called before the first frame update
    void Start()
    {
        myCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePositionInWorld();


        Physics.Raycast(rayo, out RaycastHit golpe);


        if (Input.GetKeyDown(KeyCode.T))
            {
            GameObject torreta;
            
            torreta = Instantiate(firstTurret, golpe.point, Quaternion.identity);
            torreta.transform.position = golpe.point;
        }
       
    }

    private void GetMousePositionInWorld()
    {
        rayo = myCamera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(rayo, out RaycastHit golpe);
        myPointer.transform.position = new Vector3(golpe.point.x, 0.25f, golpe.point.z);
    }
}
