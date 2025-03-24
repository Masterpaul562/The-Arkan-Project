using UnityEditor; 
using UnityEngine;


[CustomEditor(typeof(Move_Heavy))]

public class ViewAngle : Editor
{
    private void OnSceneGUI()
    {
        Move_Heavy fov = (Move_Heavy)target;
        Vector3 viewAngle001 = DirFromAngle(fov.transform.eulerAngles.y, -fov.angle / 2);
        Vector3 viewAngle002 = DirFromAngle(fov.transform.eulerAngles.y, fov.angle / 2);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle001 * 10);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle002 * 10);
    }

    

    private Vector3 DirFromAngle( float eulerY, float angleInDeg)
    {
        angleInDeg += eulerY;

        return new Vector3(Mathf.Sin(angleInDeg * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDeg * Mathf.Deg2Rad));
    }
}
