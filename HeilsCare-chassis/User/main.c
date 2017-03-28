/**
  ******************************************************************************
  * @file    _main.c
  * @author  flysnow
  * @version V1.0
  * @date    2016-8-6
  * @brief   
  ******************************************************************************
  * @attention
  *
  ******************************************************************************
  */
#include "includes.h"
#include "../System/sys.h" 	
#include "../Driver/_delay.h"	
#include "../Task/_task.h" 
#include "../Driver/_delay.h"
#include "../Driver/_can.h"
#include "../Algorithm/_mecanum.h"
#include "../Driver/_pwm.h"
#include "../Driver/_uart.h"
#include "../Driver/_lcd.h"
#include "../Driver/_io_status.h"

#include "../Driver/_tim.h"
#include "../Driver/_ps2.h"
#include "../Algorithm/_pid.h"
#include "_ctiic.h"
#include "_touch.h"
#include "_24cxx.h"
#include "_myiic.h"
#include "_ott2001a.h"
#include "_lcd.h"
#include "_lcdio.h"

//#define TASK
void MainTask(void);
void adcinit(void);
void AutoTask(void *pdata);
void QEI_Init(void);
 int main(void)
 {	
	SysTick_init();
	System_Clock_Init();
	TIM_Config();
	delay_init();	    //延时函数初始化	
	//Can1_Init();
  PWM_Init();
	Usart_Init();
	// QEI_Init();
 	IO_Init();
	PS2_Init();
	PID_Clear();
	//NVIC_PriorityGroupConfig(NVIC_PriorityGroup_2);//设置中断优先级分组为组2：2位抢占优先级，2位响应优先级
	LCD_Init();	

 	tp_dev.init();
	LCD_Clear(WHITE);//清屏
 	POINT_COLOR=RED;//设置字体为红色 
	LCD_ShowString(60,50,200,16,16,"HeilsCar");	
	LCD_ShowString(60,110,200,16,16,"2016-8-7");
	adcinit();
	delay_ms(1500);
LCD_Clear(WHITE);	
//	SetSpeed(0,0,100);
#ifdef TASK
	OSInit();   
 	OSTaskCreate(TaskStructs[0].FunTask,
							(void *)0,
							(OS_STK*)&TaskStructs[0].task_stack[STK_SIZE - 1],
							TaskStructs[0].task_prio);				   
	OSStart();
#else
	MainTask();
#endif
}

/******************* (C) COPYRIGHT 2016 Heils *****END OF FILE****/
