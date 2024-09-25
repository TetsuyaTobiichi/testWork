using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endLvl : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera camera;
    public GameObject lvl;
    public Vector3 vector;
    public GameObject nextLvl;
    void Awake()
    {
        nextLvl.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            Debug.Log(PlayerPrefs.GetInt("Level1score", 0));
            PlayerPrefs.SetInt("Level1score", PlayerPrefs.GetInt("score",0));
            PlayerPrefs.Save();
        }
        nextLvl.SetActive(true);
        col.gameObject.transform.position = new Vector2(10, -33);
        camera.transform.position = vector;
        lvl.SetActive(false);
    }
}
