// ConsoleApplication11.cpp : Defines the entry point for the console application.
//

#include <windows.h>
#include "stdafx.h"
#include <stdio.h>
#include <math.h>
#include "glut.h"
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#include <ctype.h>
#include <Windows.h>


struct Vector
{
	float x, y;
};

Vector* v=new Vector[7];
int point=1;
float angle,size,adder=-0.01;

//------------------------------------------------------------------------------------
void resize(int width, int height)
{
	glViewport(0, 0, width, height);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	glOrtho(-5, 5, -5, 5, 4, 12);
	gluLookAt(0, 0, 5, 0, 0, 0, 0, 1, 0);
	glMatrixMode(GL_MODELVIEW);
}

//------------------------------------------------------------------------------------

void init() 
{
	angle = 0;
	v[1].x = 2;  v[1].y = 2; 
	v[2].x = -2; v[2].y = 2;
	v[3].x = -3; v[3].y = 0;
	v[4].x = -2; v[4].y = -2;
	v[5].x = 2;  v[5].y = -2;
	v[6].x = 3;  v[6].y = 0;
}
//------------------------------------------------------------------------------------

void display(void)
{

	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glLoadIdentity();

	glColor3ub(239, 211, 52);
	glBegin(GL_TRIANGLE_FAN);
	glVertex2f(v[1].x, v[1].y);
	glVertex2f(v[2].x, v[2].y);
	glVertex2f(v[3].x, v[3].y);
	glVertex2f(v[4].x, v[4].y);
	glVertex2f(v[5].x, v[5].y);
	glVertex2f(v[6].x, v[6].y);
	glEnd();




	glPushMatrix();

	glColor3f(255, 255, 255);
	glPushMatrix();
	glTranslatef(v[point].x, v[point].y, 0.0f);
	glRotated(angle, 0.0f, 0.0f, 1.0f);
	glScaled(size, size, size);
	glTranslatef(v[point].x, v[point].y, 0.0f);
	glBegin(GL_TRIANGLE_FAN);
	glVertex2f(v[1].x, v[1].y);
	glVertex2f(v[2].x, v[2].y);
	glVertex2f(v[3].x, v[3].y);
	glVertex2f(v[4].x, v[4].y);
	glVertex2f(v[5].x, v[5].y);
	glVertex2f(v[6].x, v[6].y);
	glEnd();
	glPopMatrix();
	glutSwapBuffers();
	glPopMatrix();
	glFlush();
}

//------------------------------------------------------------------------------------


void TimerFunc(int value)
{
	glutPostRedisplay();  
	if (angle < 350)
	{
		angle += 10;
	}
	else
	{
		if (point < 6)
			point++;
		else
			point = 1;
		angle = 0;
	}
	if (size < 0.0 || size>2.0)
		adder = -1 * adder;
	size += adder;
	glutTimerFunc(25, TimerFunc, 0);
}

int main(int argc, char *argv[])
{

	init();
	glutInit(&argc, argv);
	glutInitWindowSize(600, 600);
	glutInitDisplayMode(GLUT_RGB | GLUT_DOUBLE);

	glutCreateWindow("Лабораторна робота №3");

	glutReshapeFunc(resize);
	glutDisplayFunc(display);
	glutTimerFunc(25, TimerFunc, 0);
	glutMainLoop();
}