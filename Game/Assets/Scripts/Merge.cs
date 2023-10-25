using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merge : MonoBehaviour
{
   public Transform[] kueObj;
   static public string spawnedYet = "n";
   static public Vector2 spawnerPos;
   static public Vector2 spawnPos; 
   static public string newKue = "n";
   static public int whichKue=0;
    
   void Start()
   {

   } 


   void Update ()
   {
    spawnKue();
    replaceKue();
   }

   void spawnKue()
   {
        if (spawnedYet=="n")
        {
            StartCoroutine(spawntimer());
            spawnedYet = "w";
        }
   }

   void replaceKue()
   {
    if (newKue=="y")
    {
        newKue="n";
        Instantiate(kueObj[whichKue + 1], spawnPos, kueObj[0].rotation);
    }
   }

   IEnumerator spawntimer()
   {
        yield return new WaitForSeconds(1.0f);
        Instantiate(kueObj[Random.Range(0,5)], transform.position, kueObj[0].rotation);
        spawnedYet = "y";
   }
}
    