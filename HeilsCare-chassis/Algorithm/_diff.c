#include "stm32f10x.h"
#include "stm32f10x_conf.h"

#include "math.h"
#include "_typedef.h"
#include "_math.h"
#include "../Driver/_pwm.h"
#include "_mecanum.h"
#include "_delay.h"
struct diffWheel
{
	int port;				//对应的PWM端口
	int arg;				//方向系数
};


struct diffWheel leftWheel={1, 1};		//四轮的状态参数
struct diffWheel rightWheel={2, -1};

static float wheelWidth = 636.6;//差速轮左右轮距
static float wheelLength = 636.2;//前后轮距
static float wheelRadius = 50.0f;//差速轮半径

/*角速度*/
float leftSpeed;
float rightSpeed;

void setDiffSpeed(float speedTrans, float speedRot)
{

	
	float leftDelta;
	float rightDelta;

	float deltaMax = 0.0f;
	static float leftLast=0;	//储存四轮的速度
	static float rightLast=0;


	float delta_max;			//速度变化量最大值
	float PWM_Max;				//生成的PWM后对应的速度最大值
	
	float pwmLeft, pwmRight;
	
	float transFactor = -1.0f;
	float rotFactor = -1.0f;
	
	leftSpeed = speedTrans * transFactor + speedRot * rotFactor * leftWheel.arg;
	rightSpeed = speedTrans * transFactor + speedRot * rotFactor * rightWheel.arg;
	
	leftDelta = leftSpeed - leftLast;
	rightDelta = rightSpeed - rightLast;

	deltaMax=Max(Abs(leftDelta),Abs(rightDelta));
	
	leftLast = leftSpeed;
	rightLast = rightSpeed;
	
	/**************************************************************************/	
	
 	pwmLeft = Abs(leftSpeed) * 66.7;//10000/150
 	pwmRight = Abs(rightSpeed) * 66.7;

	if(pwmLeft > 8000)
		pwmLeft = 8000;
	if(pwmLeft < 500)
		pwmLeft = 0;
		
	if(pwmRight > 8000)
		pwmRight = 8000;
	if(pwmRight < 500)
		pwmRight = 0;

	if(leftSpeed < 0.0)
		GPIOA -> BSRR = GPIO_Pin_2;
	else 
		GPIOA ->BRR = GPIO_Pin_2;

	if(rightSpeed < 0.0)
		GPIOA -> BSRR = GPIO_Pin_3;
	else 
		GPIOA ->BRR = GPIO_Pin_3;
//	delay_us(100);

//PWM_SetDuty(leftWheel.port,50);
//PWM_SetDuty(rightWheel.port,50);
	PWM_SetFreq(leftWheel.port, 50, pwmLeft);
	PWM_SetFreq(rightWheel.port, 50, pwmRight);
}
/******************* (C) COPYRIGHT 2016 Heils *****END OF FILE****/
