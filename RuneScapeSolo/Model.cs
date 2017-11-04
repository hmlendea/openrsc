using System.Collections.Generic;

namespace RuneScapeSolo
{
    public class Model
    {
        List<Vertex> vertices;
        List<Face> faces;
        float xRot;
        float yRot;
        float zRot;
        float xScale;
        float yScale;
        float zScale;
        float xTranslate;
        float yTranslate;
        float zTranslate;
        int numTextures = 0;

        public Model(List<Vertex> vertices, List<Face> faces)
        {
            this.vertices = vertices;// new ClonableStack<Vertex>();
            this.faces = faces;// new Vector();
            // this.faces = faces;
            // this.vertices = vertices;
            xRot = yRot = zRot = 0.0F;
            xScale = yScale = zScale = 1.0F;
            xTranslate = yTranslate = zTranslate = 0.0F;
        }

        public Model(List<Vertex> vertices, List<Face> faces, List<Vertex> vertices1, List<Face> faces1)
        {
            this.vertices = vertices; //new Vector();
            this.faces = faces;//new Vector();
            //this.faces = faces;
            //this.vertices = vertices;
            xRot = yRot = zRot = 0.0F;
            xScale = yScale = zScale = 1.0F;
            xTranslate = yTranslate = zTranslate = 0.0F;
        }

        public Model()
        {
            vertices = new List<Vertex>();
            faces = new List<Face>();
            // faces = new Vector();
            // vertices = new Vector();
            xRot = yRot = zRot = 0.0F;
            xScale = yScale = zScale = 1.0F;
            xTranslate = yTranslate = zTranslate = 0.0F;
        }

        public void addFace(Face face)
        {
            faces.Add(face);
        }

        public Face getFace(int i)
        {
            return faces[i];
        }

        public Face removeFace(int i)
        {
            var f = faces[i];
            faces.Remove(f);
            return f;
        }

        public List<Face> getFaces()
        {
            return faces;
        }

        public void addVert(Vertex vertex)
        {
            vertices.Add(vertex);
        }

        public Vertex removeVert(int i)
        {
            var f = vertices[i];
            vertices.Remove(f);
            return f;
        }

        public Vertex getVert(int i)
        {
            return vertices[i];
        }

        public List<Vertex> getVertices()
        {
            return vertices;
        }

        public void setVertices(List<Vertex> vertices)
        {
            this.vertices = vertices;
        }

        public void setFaces(List<Face> faces)
        {
            this.faces = faces;
        }

        public float getXRot()
        {
            return xRot;
        }

        public void setXRot(float xRot)
        {
            if (xRot > 360F)
            {
                xRot -= 360F;
            }
            else
                if (xRot < -360F)
            {
                xRot += 360F;
            }
            this.xRot = xRot;
        }

        public float getYRot()
        {
            return yRot;
        }

        public void setYRot(float yRot)
        {
            if (yRot > 360F)
            {
                yRot -= 360F;
            }
            else
                if (yRot < -360F)
            {
                yRot += 360F;
            }
            this.yRot = yRot;
        }

        public float getZRot()
        {
            return zRot;
        }

        public void setZRot(float zRot)
        {
            if (zRot > 360F)
            {
                zRot -= 360F;
            }
            else
                if (zRot < -360F)
            {
                zRot += 360F;
            }
            this.zRot = zRot;
        }

        public float getXScale()
        {
            return xScale;
        }

        public void setXScale(float xScale)
        {
            this.xScale = xScale;
        }

        public float getYScale()
        {
            return yScale;
        }

        public void setYScale(float yScale)
        {
            this.yScale = yScale;
        }

        public float getZScale()
        {
            return zScale;
        }

        public void setZScale(float zScale)
        {
            this.zScale = zScale;
        }

        public void setScale(float scale)
        {
            setXScale(scale);
            setYScale(scale);
            setZScale(scale);
        }

        public float getXTranslate()
        {
            return xTranslate;
        }

        public void setXTranslate(float xTranslate)
        {
            this.xTranslate = xTranslate;
        }

        public float getYTranslate()
        {
            return yTranslate;
        }

        public void setYTranslate(float yTranslate)
        {
            this.yTranslate = yTranslate;
        }

        public float getZTranslate()
        {
            return zTranslate;
        }

        public void setZTranslate(float zTranslate)
        {
            this.zTranslate = zTranslate;
        }

        public void setNumTextures(int numTextures)
        {
            this.numTextures = numTextures;
        }

        public int getNumTextures()
        {
            return numTextures;
        }
    }
}
