using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemaforoManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool turno1, turno2;
    public static SemaforoManager Instance;
    [SerializeField] private GameObject[] semaforosBox = new GameObject[2];

    void Awake(){
        if(!Instance){
            Instance = this;
        }
    }
    void Start()
    {
        turno1 = true;
        turno2 = false;
        StartCoroutine(luces());
    }

    IEnumerator luces(){
        while(true){
            yield return new WaitForSeconds(5);
            turno1= !turno1;
            turno2 = !turno2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
