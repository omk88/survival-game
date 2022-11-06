using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTrees : MonoBehaviour
{
    public Terrain terrain;
    public GameObject tree;
    public GameObject rock;
    public TreeController treeCon;
    public GameObject instanceObj;
    public List<GameObject> trees = new List<GameObject>();
    public List<GameObject> rocks = new List<GameObject>();
    public GameObject currentTree;


    void Start()
    {

        for(int i = 0; i < 200; i++)
        {
            int x = Random.Range(400, 900);
            int z = Random.Range(200, 600);
            Vector3 vector = new Vector3(x,0,z);
            float y = terrain.SampleHeight(vector);
            Vector3 vector2 = new Vector3(x,y+3,z);
            instanceObj = (GameObject) Instantiate(tree, vector2, Quaternion.identity);
            instanceObj.name = (Random.Range(-100.0f, 100.0f)).ToString();
            trees.Add(instanceObj);

        }

        for(int i = 0; i < 100; i++)
        {
            int x = Random.Range(400, 900);
            int z = Random.Range(200, 600);
            Vector3 vector = new Vector3(x,0,z);
            float y = terrain.SampleHeight(vector);
            Vector3 vector2 = new Vector3(x,y,z);
            instanceObj = (GameObject) Instantiate(rock, vector2, Quaternion.identity);
            instanceObj.name = (Random.Range(-100.0f, 100.0f)).ToString();
            trees.Add(instanceObj);

        }






    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
