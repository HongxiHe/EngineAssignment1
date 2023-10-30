using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class PluginTester : MonoBehaviour
{
    public GameObject target;
    private const string DLL_NAME = "Week4dll";

    [DllImport(DLL_NAME)]
    private static extern int GetID();

    [DllImport(DLL_NAME)]
    private static extern int SetID(int id);

    [StructLayout(LayoutKind.Sequential)]

    struct Vector2D
    {
        public float x;
        public float y;
    }

    [DllImport(DLL_NAME)]
    private static extern Vector2D GetPosition();

    [DllImport(DLL_NAME)]

    private static extern void SetPosition(float x, float y);
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SetID(33);

            Debug.Log(GetID());

            SetPosition(3.3f, 5.7f);
            target.transform.position = new Vector3(GetPosition().x, GetPosition().y, 0);
            Debug.Log(GetPosition().x);
            Debug.Log(GetPosition().y);
        
        }
    }
}
