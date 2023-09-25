//TorchThrow.cs by Joseph Panara for Night Knight

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script handles the torch throw mechanic
public class TorchThrow : MonoBehaviour
{
    private Camera cam;
    [Tooltip("Torch prefab here.")]
    public GameObject torch;
    [Tooltip("Force applied to the torch.")]
    public float throwforce = 5f;
    [Tooltip("The minimum force applied to the torch.")]
    public float minforce = 5f;
    [Tooltip("The maximum force applied to the torch.")]
    public float maxforce = 20f;
    [Tooltip("The speed force is applied to the torch.")]
    public float forcerate = 20f;
    public GameObject currenttorch;
    [Tooltip("How long before another torch can be thrown.")]
    public float cooldown;
    bool canthrow = true;
    [Tooltip("How long the torch lasts before disappearing.")]
    public float lifespan;
    private PlayerAudio audio;
    //torchnum is used if you want the player to have a limited number of torches
    //public int torchnum;

    void Start()
    {
        cam = Camera.main;
        audio = GetComponent<PlayerAudio>();
    }
    //While right-click is held, force increases. On release, a torch prefab is instantiated and launched with the throwforce at the direction of the mouse cursor
    void Update()
    {
        Vector3 screenPoint = cam.WorldToScreenPoint(transform.position);
        Vector3 direction = (Vector3)(Input.mousePosition - screenPoint);
        direction.Normalize();

        if (Input.GetMouseButton(1) /*&& torchnum > 0*/)
        {
            throwforce += forcerate*Time.deltaTime;
            throwforce = Mathf.Clamp(throwforce, minforce, maxforce);
        }
        if (Input.GetMouseButtonUp(1) /*torchnum > 0*/)
        {
            if (canthrow == true)
            {
                StopAllCoroutines();
                Destroy(currenttorch);
                Vector3 spawnpoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                GameObject projectile = Instantiate(torch, spawnpoint, Quaternion.identity);
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                rb.AddForce(direction * throwforce);
                currenttorch = projectile;
                audio.TossAud();
                canthrow = false;
                StartCoroutine(Cooldown());
                StartCoroutine(TorchDecay());
            }
            //torchnum--;
            throwforce = minforce;

        }

    }
    //Applies a cooldown on how fast torches can be thrown
    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        canthrow = true;
    }
    //Destroys the torch after a set time
    private IEnumerator TorchDecay()
    {
        yield return new WaitForSeconds(lifespan);
        Destroy(currenttorch);
    }
}
