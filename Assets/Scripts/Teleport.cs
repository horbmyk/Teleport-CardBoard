using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    public Image imgTeleport;

    public float totalTime = 2;
    bool gvrStatus;
    float gvrTimer;

    public int distanceOfRay = 10;
    private RaycastHit _hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgTeleport.fillAmount = gvrTimer/totalTime;
        }
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if(Physics.Raycast(ray, out _hit, distanceOfRay))
        {
            if(imgTeleport.fillAmount == 1 && _hit.transform.CompareTag("Teleport"))
            {
                _hit.transform.gameObject.GetComponent<Move>().TeleportRig();
            }
        }


    }

    public void GVROn()
    {
        gvrStatus = true;
    }

    public void GVRoff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgTeleport.fillAmount = 0;
    }
}
