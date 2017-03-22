/**********************************************************************
 *	@file: __task.c
 *  @description: 任务入口函数
 *   
 *  @create: 2016-8-2
 *  @author: flysnow
 *  @explain: main分为几个任务
 *   
 *  @modification: 2016-12-1
 *  @author: flysnow
 *  @explain: 修改注释
 *********************************************************************/  
 
#include "includes.h"
#include "../System/sys.h" 	
#include "../Driver/_delay.h"	
#include "../Task/_task.h" 
#include "../Driver/_delay.h"
#include "../Driver/_can.h"
#include "../Algorithm/_mecanum.h"
#include "../Driver/_pwm.h"
#include "../Driver/_uart.h"
#include "../Driver/_io_status.h"

#include "../Driver/_tim.h"
#include "../Driver/_ps2.h"
#include "../Driver/_ultrasonic.h"
#include "../Algorithm/_pid.h"

#include "_ctiic.h"
#include "_touch.h"
#include "_24cxx.h"
#include "_myiic.h"
#include "_ott2001a.h"
#include "_lcd.h"
#include "_lcdio.h"
#include "_keep.h"
#include "stm32f10x_it.h"
#include "../Algorithm/_math.h"
#include "_serial.h"


void Load_Drow_Dialog(void)
{
	LCD_Clear(WHITE);//清屏   
 	POINT_COLOR=RED;//设置字体为蓝色 
	LCD_ShowString(lcddev.width-24,0,200,16,16,"RST");//显示清屏区域
  POINT_COLOR=RED;//设置画笔蓝色 
}

/////////////////////////UCOSII任务设置///////////////////////////////////

void TaskStart(void *para);	
void ManualTask(void *para);
void AutoTask(void *para);
void LcdTask(void *para);

sUcosTask_t TaskStructs[] =
{
	{.task_prio = 0x10,		.task_status = 0,		.FunTask = TaskStart   },
	{.task_prio = 0x08,		.task_status = 0,		.FunTask = LcdTask    },
	{.task_prio = 0x07,		.task_status = 0,		.FunTask = ManualTask  },
	{.task_prio = 0x06,		.task_status = 0,		.FunTask = AutoTask    },
};
	  
const u8 taskNum = sizeof(TaskStructs)/sizeof(TaskStructs[0]);
//开始任务
void TaskStart(void *para)
{
  OS_CPU_SR cpu_sr=0;
  OS_ENTER_CRITICAL();			//进入临界区(无法被中断打断) 
	u8 iCount = 1;
	for(; iCount < taskNum; iCount++)
		OSTaskCreate(TaskStructs[iCount].FunTask,
								(void *)0,
								(OS_STK*)&TaskStructs[iCount].task_stack[STK_SIZE - 1],
								TaskStructs[iCount].task_prio);		
								
	OSTaskSuspend(TaskStructs[0].task_prio);	//挂起起始任务.
	OS_EXIT_CRITICAL();				//退出临界区(可以被中断打断)
}

u8 testflag1 = 0;
u8 testflag2 = 0;
u8 testflag3 = 0;


void test();
	u8 PS2_key;
char SdTPC[64] = {0};
//02 03 00 00 00 1A C4 32
u8 ModbusCtrl[8] = {0x02,0x03,0x00,0x00,0x00,0x1A,0xC4,0x32};
u8 ModbusEnable[8] = {0x02,0x06,0x00,0x00,0x00,0x01,0x48,0x39};
u8 MotorEnable[8] = {0x02,0x06,0x00,0x01,0x00,0x01,0x19,0xf9};
u8 MotorSpeed[8] = {0x02,0x06,0x00,0x02,0x00,0xff,0x68,0x79};
extern PC_Data PcData;
void setDiffSpeed(float speedTrans, float speedRot);
extern int16_t r_now[2];



void ManualTask(void *para)
{	 	
	while(1)
	{
		delay_ms(10);
	};
}

void AutoTask(void *para)
{	  
//	u8 iCount = 0;
//	Load_Drow_Dialog();	 	
	while(1)
	{
//		if(!iCount)
//			KeepTest();
//		iCount++;
		delay_ms(5);
	}

}

void LcdTask(void *para)
{
//	while(1)
//	{
		//LCD_Clear(WHITE);
//		SetCursor(0,40);
//		LCD_WriteString("GPS.y:");
//		LCD_WriteFloat(GPS.position.x);
//		SetCursor(0,70);
//		LCD_WriteString("GPS.x:");
//		LCD_WriteFloat(GPS.position.y);
//		SetCursor(0,100);
//		LCD_WriteString("GPS.a:");
//		LCD_WriteFloat(GPS.radian);
//		delay_ms(300);
//	}
		static struct Point end_point={500,0};
	static double aim_angle=0;
  static double speed_max=500;

	LCD_Clear(WHITE);
	PID_Clear();

	SetKeep(end_point,aim_angle*pi/180,speed_max);
	 
	while(1)
	{
		
		KeepPoint();
		SetCursor(0,130);
// 		LCD_WriteString("now_distance:");
// 		LCD_WriteFloat(GetLength(GPS.position,end_point));//输出实时距离
		if((GetLength(GPS.position,end_point) < 50)&&((GPS.radian-aim_angle*pi/180<0.02)&&(GPS.radian-aim_angle*pi/180>-0.02)))
		{
			SPEED_STOP;
//			SetSpeed(0,0,0);
			break;
		}  
		delay_ms(15);
	}
}


extern u32 pc_cnt;
void MainTask(void)
{
	u32 last_pc_cnt = 0;
	u32 time_count = 0;
	u8 time_out = 0;
	Ultrasonic[0].ClcUtralData(0);
 	Ultrasonic[1].ClcUtralData(1);
 	Ultrasonic[2].ClcUtralData(2);
 	Ultrasonic[3].ClcUtralData(3);
	//test();
	while(1)
	{
// 		USART_SendData(USART1, 0x55);
// 		USART_SendData(USART2, 0x55);
// 		USART_SendData(USART3, 0x55);
		Data[5] = 0;
		Data[6] = 0;
  	//PS2_key=PS2_DataKey();
//		sprintf(SdTPC, "(%d,%d,%d,%d,1)\n\t", (int)10, (int)11, (int)12, 100);
		GPS.position.x += 1;
		GPS.position.y += 1;
		GPS.radian += 1;
   sprintf(SdTPC, "(%d,%d,%d,%d,1)\n", (int)GPS.position.x, (int)GPS.position.y, (int)GPS.radian, 100);
    Com_Puts(1, SdTPC);
		ComMotor(3, ModbusCtrl, 8);
		delay_ms(10);
		ComMotor(3, ModbusEnable, 8);
		delay_ms(10);
		ComMotor(3, MotorEnable, 8);
		delay_ms(10);
		ComMotor(3, MotorSpeed, 8);
    SdTPC[0] = 0;
		Speed_Rotation = (Data[5] - 0x80)* 4;
		Speed_Y = (0x80 - Data[6])* 4;
//		SetSpeed(100,100,100);
 		//SetSpeed(PcData.speed_x.fl32*10,PcData.speed_y.fl32*10,PcData.speed_rot.fl32*10);
				SetCursor(0,0);
		LCD_WriteString("Speed_Y:");		
		LCD_WriteFloat(Speed_Y);
		SetCursor(0,20);
		LCD_WriteString("Speed_Rotation:");		
		LCD_WriteFloat(Speed_Rotation);
		
		SetCursor(0,40);
		LCD_WriteString("speedx:");		
		LCD_WriteFloat(PcData.speed_x.fl32); 
		SetCursor(0,60);
		LCD_WriteString("speedy:");		
		LCD_WriteFloat(PcData.speed_y.fl32);
		SetCursor(0,80);
		LCD_WriteString("speedz:");		
		LCD_WriteFloat(PcData.speed_rot.fl32);

		SetCursor(0,100);
		LCD_WriteString("r_left:");		
		LCD_WriteFloat(r_now[0]);
		SetCursor(0,120);
		LCD_WriteString("r_right:");		
		LCD_WriteFloat(r_now[1]);
		//setDiffSpeed(PcData.speed_y.fl32 * 500,PcData.speed_x.fl32 * 500);
		if(pc_cnt == last_pc_cnt)
		{
			time_count++;
			if(time_count > 50)
				time_out = 1;
		}
		else
		{
			time_count = 0;
		}
		if(time_out)
		{
			setDiffSpeed(0,0);
		}
		else
		{
			setDiffSpeed(0,1000);
		}
		last_pc_cnt = pc_cnt;
		delay_ms(10);
	};
}