using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras;
    private float interval = 2;


    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(SwitchCameras());
    }

    /// <summary>
    /// Deactivates all cameras in an array of cameras.
    /// </summary>
    /// <param name="cameras"></param>
    private void DeactivateAllCameras(Camera[] cameras)
    {
        foreach (Camera camera in cameras)
        {
            camera.gameObject.SetActive(false);
        }

    }

    /// <summary>
    /// IEnumerator to switch cameras in an array of cameras placed in the scene.
    /// </summary>
    /// <returns></returns>
    private IEnumerator SwitchCameras()
    {
        while (true)
            for (int currentCamera = 0; currentCamera < cameras.Length; currentCamera++)
            {
                DeactivateAllCameras(cameras);
                print("SwitchCameras Coroutine - \"currentCamera\": " + currentCamera);
                cameras[currentCamera].gameObject.SetActive(true);
                yield return new WaitForSeconds(interval);

            }


    }
}
