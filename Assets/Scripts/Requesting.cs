using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Requesting : MonoBehaviour
{
    [SerializeField] GameObject[] cars = new GameObject[5];
    private Data posiciones;
    private int carPrefab;
    private Vector3 spawnPos;
 void Start() {
        StartCoroutine(GetText());
        StartCoroutine(Spawn());
    }
 

    IEnumerator Spawn(){
        while(Application.isPlaying)
        {
            yield return new WaitForSeconds(3);
            carPrefab = Random.Range(0,5);
            int index = Random.Range(0,2);
            Position pos = posiciones.data[index];
            spawnPos = new Vector3(pos.x, pos.y, pos.z);
            Instantiate(cars[carPrefab], spawnPos, Quaternion.Euler(0,pos.r,0));
        }
    }
    IEnumerator GetText() {

        UnityWebRequest www = UnityWebRequest.Get("http://localhost:8000/");
        yield return www.SendWebRequest();
 
        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
        }

        posiciones = JsonUtility.FromJson<Data>(www.downloadHandler.text);

    }
}
