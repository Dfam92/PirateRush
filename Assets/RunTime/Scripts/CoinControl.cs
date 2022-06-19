using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoinControl : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] PlayerControl player;
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject coinUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            gameManager.SumCoins();
            player.CoinCollision();
            this.gameObject.GetComponent<Collider>().enabled = false;
            this.transform.DOLocalMove(Camera.main.ViewportToWorldPoint(coinUI.transform.position), 9);
            Destroy(this.gameObject, 10);
            
        }
    }
}
