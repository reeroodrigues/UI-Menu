using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
#if UNITY_EDITOR
    [UnityEditor.MenuItem("Ebac/Test")]
    public static void Test()
    {
        Debug.Log("Test");
    }

    [UnityEditor.MenuItem("Ebac/Test2 %g")]
    public static void Test2()
    {
        Debug.Log("Test2");
    }
#endif

    public GameObject carPrefab;

    public int speed = 20;
    public int gear = 5;

    public int TotalSpeed
    {
        get { return speed * gear; }
    }

    public void CreateCar() 
    {
        var a = Instantiate(carPrefab);
        a.transform.position = Vector3.zero;
    }
}
