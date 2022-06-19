using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockControl : MonoBehaviour
{
    [SerializeField] PlayerControl player;
    private ParticleSystem particleExplosion;
    private MeshRenderer rockMesh;


    // Start is called before the first frame update
    void Start()
    {
        rockMesh = GetComponent<MeshRenderer>();
        particleExplosion = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player.RockCollision();
            this.particleExplosion.Play();
            this.rockMesh.enabled = false;
        }
    }
}
