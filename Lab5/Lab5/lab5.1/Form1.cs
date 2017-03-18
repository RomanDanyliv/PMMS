using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Tao.DevIl;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace lab5._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            anTvas.InitializeContexts();
        }


        private int angl = 0;
        private bool textureIsLoad = false;
        
        public int MyPicture = 0;

        public uint Image = 0;

        void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();
            float[] color = new float[4] { 1, 0, 0, 1 };
            float[] color2 = new float[4] { 0, 1, 0, 1 }; 
            float[] shininess = new float[1] { 30 };
            float[] pos = new float[4] {2, 2, 2, 1};


            Gl.glTexEnvi(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_COMBINE);
            Gl.glTexEnvi(Gl.GL_TEXTURE_ENV, Gl.GL_COMBINE_RGB, Gl.GL_ADD);
            Gl.glTexEnvi(Gl.GL_TEXTURE_ENV, Gl.GL_SOURCE0_RGB, Gl.GL_TEXTURE);
            Gl.glTexEnvi(Gl.GL_TEXTURE_ENV, Gl.GL_SOURCE1_RGB, Gl.GL_TEXTURE);

            Gl.glTexEnvi(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_MODULATE);
            Gl.glLightModeli(Gl.GL_LIGHT_MODEL_COLOR_CONTROL, Gl.GL_SEPARATE_SPECULAR_COLOR);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glPushMatrix();
            Gl.glTranslated(0,0,-1);
            Gl.glRotated(-90, 0.5, 0.2, 0);
            Gl.glRotated(angl ,0,0,1);
            Gl.glLightModeli(Gl.GL_LIGHT_MODEL_COLOR_CONTROL, Gl.GL_SEPARATE_SPECULAR_COLOR);
            Gl.glEnable(Gl.GL_TEXTURE_2D);

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, Image);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_NEAREST);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_NEAREST);
            Glu.GLUquadric quadr;
            quadr = Glu.gluNewQuadric();
            Glu.gluQuadricTexture(quadr, Gl.GL_TRUE);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glColor3d(1, 1, 1);
            Glu.gluSphere(quadr, 0.1, 32, 32);
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glLightModeli(Gl.GL_LIGHT_MODEL_COLOR_CONTROL, Gl.GL_SEPARATE_SPECULAR_COLOR);
            Gl.glEnable(Gl.GL_NORMALIZE);
            Gl.glMaterialfv(Gl.GL_FRONT_LEFT, Gl.GL_SPECULAR, color);
            Gl.glMaterialfv(Gl.GL_FRONT_LEFT, Gl.GL_SHININESS, shininess); 
            Gl.glMaterialfv(Gl.GL_FRONT_RIGHT, Gl.GL_SPECULAR, color2); 
            Gl.glMaterialfv(Gl.GL_FRONT_RIGHT, Gl.GL_SHININESS, shininess);

            float[] light0_diffuse = { 1f, 0.0f, 0.0f };
            float[] light0_direction = { 0.4f, 0.8f, 1.0f, -0.0f };

            Gl.glEnable(Gl.GL_LIGHT0); 

            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, light0_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0_direction);

            float[] light0_diffuse2 = { 0f, 1f, 0.0f }; 
            float[] light0_direction2 = { -0.2f, 0.0f, 1.0f, -0.0f };

            Gl.glEnable(Gl.GL_LIGHT1); 

            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_DIFFUSE, light0_diffuse2);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_POSITION, light0_direction2); 

            angl += 2;
            Gl.glPopMatrix();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glFlush();
            anTvas.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);
            Il.ilInit();
            Il.ilEnable(Il.IL_ORIGIN_SET);

            Gl.glEnable(Gl.GL_LIGHTING);

            Gl.glClearColor(255, 255, 255, 1);

            Gl.glViewport(0, 0, anTvas.Width, anTvas.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);

            Gl.glLoadIdentity();

            Glu.gluPerspective(30, anTvas.Width / anTvas.Height, 1, 100);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);

            timerMove.Start();

            EarthTexture();
        }

        void EarthTexture()
        {
            {
                Il.ilGenImages(1, out MyPicture);

                Il.ilBindImage(MyPicture);

                if (Il.ilLoadImage("2222.jpg"))
                {

                    int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                    int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);

                    int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);

                    switch (bitspp)
                    {
                        case 24:
                            Image = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                            break;
                        case 32:
                            Image = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                            break;
                    }

                    textureIsLoad = true;

                    Il.ilDeleteImages(1, ref MyPicture);
                }
            }
        }
        

        private static uint MakeGlTexture(int Format, IntPtr pixels, int w, int h)
        {
            uint texObject;
            Gl.glGenTextures(1, out texObject);
            Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texObject);

            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_REPLACE);

            switch (Format)
            {
                case Gl.GL_RGB:
                     Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB, w, h, 0, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;

                case Gl.GL_RGBA:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, w, h, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;
            }

            return texObject;
        }

        private void timerMove_Tick(object sender, EventArgs e)
        {
            Draw();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timerMove.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timerMove.Start();
        }
    }
}
