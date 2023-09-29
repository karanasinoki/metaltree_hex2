using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMane : MonoBehaviour
{
    public float speed;
    public Vector3 gorlPos;

    private void Update()
    {
        MoveAction();
    }

    public void MoveAction()
    {
        transform.position = Vector3.MoveTowards(transform.position, gorlPos, speed * Time.deltaTime);

    }
}
