using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWallSeeThrough : MonoBehaviour
{
    [SerializeField] private Transform targetObject;

    [SerializeField]
    private LayerMask wallMask;

    [SerializeField] float fade = 0.065f;
    [SerializeField] float cutoutSize = 0.15f;

    private Camera mainCamera;

    RaycastHit[] hitObjects;
    RaycastHit[] pastHits;

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        Vector2 cutoutPos = mainCamera.WorldToViewportPoint(targetObject.position);
        cutoutPos.y /= (Screen.width / Screen.height);
        Vector3 offset = targetObject.position - transform.position;
        hitObjects = Physics.RaycastAll(transform.position, offset, offset.magnitude, wallMask);
        Debug.DrawRay(transform.position, offset, Color.green);
        if(hitObjects.Length > 0)
        {
            pastHits = hitObjects;
            for (int i = 0; i < hitObjects.Length; ++i)
            {
                Material[] materials = hitObjects[i].transform.GetComponent<Renderer>().materials;

                for (int m = 0; m < materials.Length; ++m)
                {
                    materials[m].SetVector("_CutoutPos", cutoutPos);
                    materials[m].SetFloat("_CutoutSize", cutoutSize);
                    materials[m].SetFloat("_FalloffSize", fade);
                }
            }
        } 
        else
        {
            if(pastHits == null)
            {
            }
            else
            {
                for (int i = 0; i < pastHits.Length; ++i)
                {

                    Material[] materials = pastHits[i].transform.GetComponent<Renderer>().materials;

                    for (int m = 0; m < materials.Length; ++m)
                    {
                        materials[m].SetVector("_CutoutPos", Vector2.zero);
                        materials[m].SetFloat("_CutoutSize", 0);
                        materials[m].SetFloat("_FalloffSize", 0);
                    }
                }
            }
            
        }
    }
}
