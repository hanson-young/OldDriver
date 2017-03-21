/**********************************************************************
 *	@file: _gps.c
 *  @description: 全场定位算法
 *   
 *  @create: 2016-12-1
 *  @author: flysnow
 *  @explain: 
 *   
 *  @modification: 
 *  @author: 
 *  @explain: 
 *********************************************************************/  
 
 
#include "stm32f10x.h"
#include "stm32f10x_tim.h"
#include "../Driver/_delay.h"
#include <math.h>
#include "_math.h"

#define ENCODER_NUM 2
#define LEFT_TAG 0
#define RIGHT_TAG 1

#define GPS_NUM 2
#define NOW 0
#define LAST 1
#define CAR_WIDTH 20

typedef struct 
{
	float x;
	float y;
}tPoint;

typedef struct 
{   
	tPoint  						position;	  	  //当前坐标	
	float				        stepLeft; 	//码盘1本次前进距离
	float				        stepRight;  //码盘2本次前进距离
	float			          disLeft;	  	//码盘1前进距离
	float			        	disRight;		  //码盘2前进距离
	float  	        		angle;        	//当前角度 		
	float				        radian;			    //当前弧度
	float				        speed;			    //当前速度
	float				        acceleration;	  //当前加速度
	float			         	rotationspeed;	//当前自转速度
	float				        rotationacc;	  //当前自转加速度
}tGps;


struct sEncoder
{
	float lastCount;			//上一次的脉冲计数
	float totalCount;			//总共脉冲计数
	float realDis;				//实际距离
	float convertFactor[2];		//[0]正转系数[1]反转系数
	float r;				//车身自转时码盘的旋转半径
	float dir;			//方向
	float radian;			//码盘与车身坐标系Y轴正方向的夹角
};

//全场定位信息结构体
struct sGps
{
	tPoint position;	//
	float radian;			//弧度
};

tGps gpsList[2];

struct sEncoder Encoders[2]=
{
	
	{0, 0, 0, {1, 1}, 0, -1, 0.0},
	{0, 0, 0, {1, 1}, 0, -1, 0.0},
};

void gpsUpdate(void)
{
	
	float x_deta = 0;
	float y_deta = 0;
	float theta_deta = 0;
	float R = 0;
	float L = 0;
 	float radian = 0;

	gpsList[1] = gpsList[0];
	gpsList[0].disLeft = Encoders[0].realDis;
	gpsList[0].disRight = Encoders[1].realDis;
	
 	gpsList[0].stepLeft = gpsList[0].disLeft - gpsList[1].disLeft;
 	gpsList[0].stepRight = gpsList[0].disRight - gpsList[1].disRight; 
	
	if(gpsList[0].stepLeft == gpsList[0].stepRight )
	{
		theta_deta = 0;
		x_deta = (gpsList[0].stepLeft + gpsList[0].stepRight) / 2 * cos(pi / 2 - gpsList[0].radian);			
		y_deta = (gpsList[0].stepLeft + gpsList[0].stepRight) / 2 * sin(pi / 2 - gpsList[0].radian);
	}
	else
	{
		theta_deta = (gpsList[0].stepLeft - gpsList[0].stepRight) / CAR_WIDTH;
		R = (gpsList[0].stepLeft + gpsList[0].stepRight) / (2 * theta_deta) ; 
		L = sin(theta_deta / 2) * R * 2;
	// 			x_deta=cos(pi/2-gpsList[0].radian-theta_deta/2)*L;
		x_deta = R * cos(-gpsList[0].radian) - R * cos(-(gpsList[0].radian + theta_deta));
		y_deta = sin(pi / 2 - gpsList[0].radian - theta_deta / 2) * L;
	}
	gpsList[0].radian += theta_deta;
	if(gpsList[0].radian > 2*pi)
		gpsList[0].radian -= 2*pi;
	if(gpsList[0].radian < -2*pi)
		gpsList[0].radian += 2*pi;
	gpsList[0].angle = 180*gpsList[0].radian / pi;

	gpsList[0].position.x += x_deta;
	gpsList[0].position.y += y_deta;

}


void Encoder_Clear(u8 index)
{
	Encoders[index].lastCount = 0;	
	Encoders[index].totalCount = 0;
	Encoders[index].realDis=0.0;

}

void gpsInit(tPoint position,float radian)
{
	int iCount;
	Encoder_Clear(0);
	Encoder_Clear(1);
	for(iCount = 0;iCount < GPS_NUM;iCount++)
	{
		gpsList[iCount].disLeft = 0.0;
		gpsList[iCount].disRight = 0.0;
		gpsList[iCount].stepLeft = 0.0;
		gpsList[iCount].stepRight = 0.0;
		gpsList[iCount].position = position;
		gpsList[iCount].angle = radian / pi * 180.0;
		gpsList[iCount].radian = radian;
		gpsList[iCount].speed = 0.0;
		gpsList[iCount].acceleration = 0.0;
	}
}
