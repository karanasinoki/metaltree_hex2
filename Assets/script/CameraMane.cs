using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMane : MonoBehaviour
{
    Transform tf; //Main CameraのTransform
    Camera cam; //Main CameraのCamera
    public float cameraSpeed;
    public float zoomSpeed;
    public float cam_min;
    public float cam_max;

    void Start()
    {
        tf = this.gameObject.GetComponent<Transform>(); //Main CameraのTransformを取得する。
        cam = this.gameObject.GetComponent<Camera>(); //Main CameraのCameraを取得する。
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







        if (Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.W)) //上キーが押されていれば
        {
            tf.position = tf.position + new Vector3(0.0f, cameraSpeed, 0.0f); //カメラを上へ移動。
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) //下キーが押されていれば
        {
            tf.position = tf.position + new Vector3(0.0f, -cameraSpeed, 0.0f); //カメラを下へ移動。
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) //左キーが押されていれば
        {
            tf.position = tf.position + new Vector3(-cameraSpeed, 0.0f, 0.0f); //カメラを左へ移動。
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) //右キーが押されていれば
        {
            tf.position = tf.position + new Vector3(cameraSpeed, 0.0f, 0.0f); //カメラを右へ移動。
        }
    }
}
