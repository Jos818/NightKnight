using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChandelierRope : MonoBehaviour
{
    private Animator ropeanim;
    private Chandelier chandelier;
    // Start is called before the first frame update
    void Start()
    {
        ropeanim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Torch"))
        {
            ropeanim.enabled = true;
            Destroy(other.gameObject);
        }
    }
}
