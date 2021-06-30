using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{

    public static Vector3 AngleToVector3(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return (new Vector3 (Mathf.Cos(angleRad), Mathf.Sin(angleRad)));
    }

    // Start is called before the first frame update
    void Start()
    {

        Mesh mesh = new Mesh();

        float fov = 90f;
        Vector3 origin = Vector3.zero;
        int rayCount = 5;
        float angle = 0f;
        float angleincrease = fov / rayCount;
        float viewDistance = 3f;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[3 * rayCount];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++) {

            Vector3 vertex  = origin + (AngleToVector3(angle) * viewDistance);

            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, AngleToVector3(angle), viewDistance);

            /*if (raycastHit2D.collider == null) {
                //If the collider DIDN'T hit anything
                vertex = origin + (AngleToVector3(angle) * viewDistance);
            }

            else {
                //If the collider DID hit something
                vertex = raycastHit2D.point;
            }*/
           
            vertices[vertexIndex] = vertex;

            if (i > 0) {

                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;

            }

            vertexIndex++;
            angle -= angleincrease;

        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        GetComponent<MeshFilter>().mesh = mesh;

    }

}
