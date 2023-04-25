using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class supportClasses
{
   abstract class Shape
    {
        public abstract GameObject getshape();
        public abstract void setShapeDefinition(string value);
           
   }
    class triangle : Shape
    {
        int percentage;
        string definition;
        public override GameObject getshape()
        {
            GameObject triangle = new GameObject();
            triangle.AddComponent<MeshRenderer>();
            //make verts
            Vector3[] Vertices = new Vector3[2];
            Vertices[0] = Vector3.zero;
            Vertices[1] = Vector3.up;
            Vertices[2] = Vector3.down;
            //set uv / make mesh, mesh filter
            Vector2[] uvs = new Vector2[Vertices.Length];
           
            MeshFilter filter = triangle.AddComponent<MeshFilter>();
            //assign vertices to mesh
            Mesh mesh = filter.mesh;
            mesh.vertices = Vertices;
            //assign mesh to filter
            filter.mesh = mesh;
            for (int i = 0; i < uvs.Length; i++)
            {
                uvs[i] = new Vector2(Vertices[i].x, Vertices[i].z);
            }
            mesh.uv = uvs;

            mesh.triangles = new int[] { 0, 1, 2 };

            //triangle.AddComponent<MeshFilter>(); //<MeshFilter>() = filter;

            return triangle;
        }
        public override void setShapeDefinition(string value)
        {
            definition = value;
        }
    }
}
/*
 *  //<summary>
        //triangle mesh with
        //</summary>
        Mesh Triangle()
        {
            Vector3[] Vertices = new Vector3[2];
            Vertices[0] = Vector3.zero;
            Vertices[1] = Vector3.up;
            Vertices[2] = Vector3.down;
            //Vector3[] vertices = mesh.vertices;

            Vector2[] uvs = new Vector2[Vertices.Length];

           // int[] newTriangles = ;
            Mesh mesh = new Mesh();
            MeshFilter filter = new MeshFilter();
            filter.mesh = mesh;
            mesh.vertices = Vertices;
            //   mesh.uv = newUV;
            for (int i = 0; i < uvs.Length; i++)
            {
                uvs[i] = new Vector2(Vertices[i].x, Vertices[i].z);
            }
            mesh.uv = uvs;
            mesh.triangles = new int[] { 0, 1, 2 };

            return mesh;
        }

    */