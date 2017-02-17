#include "glut.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#include <ctype.h>
#include <Windows.h>

bool draw,change_color,destroy;
int pointer;
int xxx;



void display()
{
	glClear(GL_COLOR_BUFFER_BIT);


	if (xxx<1)
	{
		//дах
		if (!change_color)
		glColor3ub(145, 30, 66);
		else glColor3ub(245, 130, 166);
		glBegin(GL_TRIANGLES);
		glVertex3f(-0.4f, 0.8f, 0.0f); //верх
		glVertex3f(-0.8f, 0.4f, 0.0f); //ліва
		glVertex3f(0.0f, 0.4f, 0.0f); //права
		glEnd();
		//////////////////////////////////

		//стіни
		if (!change_color)
		glColor3ub(239, 211, 52);
		else glColor3ub(139, 111, 152);
		glRectf(-0.8f, 0.4f, 0.0f, 0.0f);

		//двері
		glColor3ub(100, 200, 150);
		glRectf(-0.7f, 0.3f, -0.5f, 0.0f);

		//вікно
		glColor3ub(100, 200, 150);
		glRectf(-0.3f, 0.3f, -0.1f, 0.1f);
		//рамки вікна
		glLineWidth(5);
		glColor3ub(60, 170, 60);
		glBegin(GL_LINES);
		glVertex3f(-0.2, 0.1, 0.0);
		glVertex3f(-0.2, 0.3, 0);
		glVertex3f(-0.3, 0.2, 0.0);
		glVertex3f(-0.1, 0.2, 0);
		glEnd();

		///////////////////////////////////
	}

	if (xxx < 2)
	{

		//земля
		glLineWidth(50); //товщина
		glColor3ub(60, 170, 60);
		glBegin(GL_LINES);
		glVertex3f(-0.9, 0.0, 0.0);
		glVertex3f(0.9, 0, 0);
		glEnd();
	}

	if (xxx < 3)
	{
		//treeeeeee
		if (!change_color)
		glColor3b(60, 170, 0);
		else glColor3b(160, 270, 100);
		glBegin(GL_TRIANGLE_FAN);
		glVertex3f(0.2f, 0.0f, 0.0f);
		glVertex3f(0.4f, 0.0f, 0.0f);
		glVertex3f(0.3f, 0.4f, 0.0f);
		glVertex3f(0.2f, 0.4f, 0.0f);
		glVertex3f(0.3f, 0.6f, 0.0f);
		glVertex3f(0.2f, 0.6f, 0.0f);
		glEnd();

		glColor3b(10, 30, 10);
		glBegin(GL_TRIANGLE_FAN);
		glVertex3f(0.2f, 0.6f, 0.0f);
		glVertex3f(0.4f, 0.6f, 0.0f);
		glVertex3f(0.3f, 1.0f, 0.0f);
		glVertex3f(0.2f, 1.0f, 0.0f);
		glVertex3f(0.1f, 0.6f, 0.0f);
		glEnd();

		//treeeee2

		if (!change_color)
			glColor3b(60, 170, 0);
		else glColor3b(160, 270, 100);
		glBegin(GL_TRIANGLE_FAN);
		glVertex3f(0.6f, 0.0f, 0.0f);
		glVertex3f(0.8f, 0.0f, 0.0f);
		glVertex3f(0.8f, 0.3f, 0.0f);
		glVertex3f(0.6f, 0.6f, 0.0f);
		glVertex3f(0.7f, 0.6f, 0.0f);
		glVertex3f(0.6f, 0.6f, 0.0f);
		glEnd();

		glColor3b(10, 30, 10);
		glBegin(GL_TRIANGLE_FAN);
		glVertex3f(0.6f, 0.6f, 0.0f);
		glVertex3f(0.8f, 0.6f, 0.0f);
		glVertex3f(0.7f, 1.0f, 0.0f);
		glVertex3f(0.6f, 1.0f, 0.0f);
		glVertex3f(0.5f, 0.6f, 0.0f);
		glVertex3f(0.6f, 0.5f, 0.0f);
		glEnd();
	}

	{
		glMatrixMode(GL_PROJECTION);
		glPushMatrix();
		glLoadIdentity();
		gluOrtho2D(0, 1280, 0, 1024);

		glMatrixMode(GL_MODELVIEW);
		glPushMatrix();
		glLoadIdentity();
		if (xxx < 1)
		{
			glRasterPos2f(300, 750);
			char *a;
			a = "House";
			int kkk = strlen(a);
			for (int i = 0; i < kkk; ++i) {
				glutBitmapCharacter(GLUT_BITMAP_TIMES_ROMAN_24, a[i]);
			}
		}
		if (xxx < 3)
		{
			glRasterPos2f(850, 700);
			char *a = "Trees";
			int kkk = strlen(a);
			for (int i = 0; i < kkk; ++i) {
				glutBitmapCharacter(GLUT_BITMAP_TIMES_ROMAN_24, a[i]);
			}
		}
		glPopMatrix();

		glMatrixMode(GL_PROJECTION);
		glPopMatrix();
		glMatrixMode(GL_MODELVIEW);
	}


	
	if (xxx==4) xxx = -1;

	glFlush();
}



void TimerFunc(int value)
{
	glutPostRedisplay();

	if (xxx<0)
		glClearColor(0, 0, 1, 1);
	if (xxx==0)
		glClearColor(0, 0, 0, 0);

	glutTimerFunc(40, TimerFunc, 0);
}

void Keyboard(unsigned char key, int x, int y)
{
//#define ESCAPE '\033'
	if (key == 0x1b) xxx=xxx+1;
	if (key == 0x20) change_color=!change_color;
}

void main()
{
	change_color = false;
	xxx = -1;
	SetConsoleCP(1251);// установка кодовой страницы win-cp 1251 в поток ввода
	SetConsoleOutputCP(1251); // установка кодовой страницы win-cp 1251 в поток вывода
	glutInitWindowSize(500, 500);
	glutInitWindowPosition(100, 140);
	glutCreateWindow("OpenGL window");
	glutTimerFunc(40, TimerFunc, 0);
	glutDisplayFunc(display);
	glutKeyboardFunc(Keyboard);
	glutMainLoop();
}


