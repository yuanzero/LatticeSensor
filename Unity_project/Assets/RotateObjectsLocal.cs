using UnityEngine;

public class RotateObjectsLocal : MonoBehaviour
{
    // 假设这是你的五个物体的引用
    public GameObject[] objectsToRotate;

    void Start()
    {
       
    }

    public void RotateObject1OnXAxis()
    {
        objectsToRotate[0].transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
    }

    public void RotateObject2OnXAxis()
    {
        objectsToRotate[1].transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
    }

    public void RotateObject3OnXAxis()
    {
        objectsToRotate[2].transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
    }

    public void RotateObject4OnXAxis()
    {
        objectsToRotate[3].transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
    }

    public void RotateObject5OnXAxis()
    {
        objectsToRotate[4].transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
    }

    public void RotateObjectOnXAxis(int i, float angle)
    {
        objectsToRotate[i].transform.localRotation = Quaternion.Euler(angle, 0f, 0f);
    }

}
