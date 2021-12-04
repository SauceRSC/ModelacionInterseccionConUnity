using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars : MonoBehaviour
{
    private float dir = 0;
    [SerializeField] private float maxSpeed=2;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
        dir = transform.rotation.y;
        speed = maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.back*Time.deltaTime*speed);
        
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Deathbox")){
            Destroy(this.gameObject);
        }else if(other.CompareTag("Car")){
            speed=0;
        }
    }

    private void OnTriggerStay(Collider other){
        if(other.CompareTag("Semaforo")){
            if(SemaforoManager.Instance.turno1 == false && dir < 0){
                speed = 0;
            }else if(SemaforoManager.Instance.turno2 == false && dir==0){
                speed = 0;
            }else{
                speed = maxSpeed;
            }
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.CompareTag("Car")){
            speed=maxSpeed/2;
        }
    }
}
