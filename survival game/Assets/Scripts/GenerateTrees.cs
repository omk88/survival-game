using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTrees : MonoBehaviour
{
    public Terrain terrain;
    public GameObject tree;
    public GameObject rock;
    public GameObject berryPlant;
    public TreeController treeCon;
    public GameObject instanceObj;
    public List<GameObject> trees = new List<GameObject>();
    public List<GameObject> rocks = new List<GameObject>();
    public List<GameObject> berryPlants = new List<GameObject>();
    public GameObject currentTree;


    void Start()
    {

        //float[,] height = new float[100, 220];
        //terrain.terrainData.SetHeights(0, 0, height);

        for(int i = 0; i < 200; i++)
        {
            int x = Random.Range(400, 900);
            int z = Random.Range(200, 600);
            float yRotation = Random.Range(0f, 360f);
            float xRotation = Random.Range(0f, 3f);
            float zRotation = Random.Range(0f, 3f);
            Vector3 vector = new Vector3(x,0,z);
            float y = terrain.SampleHeight(vector);
            Vector3 vector2 = new Vector3(x,y+3,z);
            Vector3 vector3 = new Vector3(xRotation, yRotation, zRotation);
            instanceObj = (GameObject) Instantiate(tree, vector2, Quaternion.Euler(vector3));
            instanceObj.name = (Random.Range(-100.0f, 100.0f)).ToString();
            trees.Add(instanceObj);

        }

        for(int i = 0; i < 100; i++)
        {
            int x = Random.Range(400, 900);
            int z = Random.Range(200, 600);
            float yRotation = Random.Range(0f, 360f);
            float xRotation = Random.Range(0f, 3f);
            float zRotation = Random.Range(0f, 3f);
            Vector3 vector = new Vector3(x,0,z);
            float y = terrain.SampleHeight(vector);
            Vector3 vector2 = new Vector3(x,y,z);
            Vector3 vector3 = new Vector3(xRotation, yRotation, zRotation);
            instanceObj = (GameObject) Instantiate(rock, vector2, Quaternion.Euler(vector3));
            instanceObj.name = (Random.Range(-100.0f, 100.0f)).ToString();
            rocks.Add(instanceObj);
        }

        for(int i = 0; i < 100; i++)
        {
            int x = Random.Range(400, 900);
            int z = Random.Range(200, 600);
            float yRotation = Random.Range(0f, 360f);
            float xRotation = Random.Range(0f, 3f);
            float zRotation = Random.Range(0f, 3f);
            Vector3 vector = new Vector3(x,0,z);
            float y = terrain.SampleHeight(vector);
            Vector3 vector2 = new Vector3(x,y,z);
            Vector3 vector3 = new Vector3(xRotation, yRotation, zRotation);
            instanceObj = (GameObject) Instantiate(berryPlant, vector2, Quaternion.Euler(vector3));
            instanceObj.name = (Random.Range(-100.0f, 100.0f)).ToString();
            berryPlants.Add(instanceObj);
        }






    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
