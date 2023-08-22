using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMane : MonoBehaviour
{
    Transform tf; //Main Camera��Transform
    Camera cam; //Main Camera��Camera
    public float cameraSpeed;
    public float zoomSpeed;
    public float cam_min;
    public float cam_max;

    void Start()
    {
        tf = this.gameObject.GetComponent<Transform>(); //Main Camera��Transform���擾����B
        cam = this.gameObject.GetComponent<Camera>(); //Main Camera��Camera���擾����B
    }

    void Update()
    {
        var scroll = Input.mouseScrollDelta.y;

        if (cam.orthographicSize > cam_min && cam.orthographicSize < cam_max)
        { 
            cam.orthographicSize = cam.orthographicSize - scroll*zoomSpeed*Time.deltaTime;

        }
        if (cam.orthographicSize <= cam_min )
        {
            if(scroll>0)
            {
                scroll = 0;
            }
            cam.orthographicSize = cam.orthographicSize - scroll * zoomSpeed * Time.deltaTime;

        }
        if ( cam.orthographicSize >= cam_max)
        {
            if(scroll<0)
            {
                scroll = 0;
            }
            cam.orthographicSize = cam.orthographicSize - scroll * zoomSpeed * Time.deltaTime; 

        }







        if (Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.W)) //��L�[��������Ă����
        {
            tf.position = tf.position + new Vector3(0.0f, cameraSpeed, 0.0f); //�J��������ֈړ��B
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) //���L�[��������Ă����
        {
            tf.position = tf.position + new Vector3(0.0f, -cameraSpeed, 0.0f); //�J���������ֈړ��B
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) //���L�[��������Ă����
        {
            tf.position = tf.position + new Vector3(-cameraSpeed, 0.0f, 0.0f); //�J���������ֈړ��B
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) //�E�L�[��������Ă����
        {
            tf.position = tf.position + new Vector3(cameraSpeed, 0.0f, 0.0f); //�J�������E�ֈړ��B
        }
    }
}
