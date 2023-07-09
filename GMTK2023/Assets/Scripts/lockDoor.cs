using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject door;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            door.GetComponent<Door3>().fullyClose();

        }
    }
}
