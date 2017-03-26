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
#include "../Algorithm/_diff.h"

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
int switchStatus[4] = {1,0,1,0};
extern volatile u32 AdData[6]; 
extern int timeStamp;
void sendStr2Pc(void)
{
	int motorSpeed[2] = {0,0};
	int collisionSwitch[4] = {1000000,0,0,0};
	int InfraredRanging[6] = {0,0,0,0,0,0};
	int UltrasonicRanging[8] = {0,0,0,0,0,0,0,0};
	int robotPower = 96;
	char sendCharBuff[100];
	u8 iCount = 0;

	motorSpeed[0] = leftSpeed;
	motorSpeed[1] = rightSpeed;
	for(iCount = 0; iCount < 4; iCount++)
	{
		collisionSwitch[iCount] = switchStatus[iCount];
	}
	
	for(iCount = 0; iCount < 6; iCount++)
	{
		InfraredRanging[iCount] = AdData[iCount];
	}
	
	for(iCount = 0; iCount < 8; iCount++)
	{
		UltrasonicRanging[iCount] = Ultrasonic[iCount].filterdistance;
	}
	
	sprintf(sendCharBuff, "(%d %d,%d,%d,%d,%d,%d,%d,%d,%d,%d,%d,%d,%d,%d,%d,%d,%d,%d,%d,%d,%d)\r\n", \
	motorSpeed[0], motorSpeed[1], \
	collisionSwitch[0], collisionSwitch[1], collisionSwitch[2], collisionSwitch[3],\
	InfraredRanging[0], InfraredRanging[1], InfraredRanging[2], InfraredRanging[3], InfraredRanging[4], InfraredRanging[5],\
	UltrasonicRanging[0], UltrasonicRanging[1], UltrasonicRanging[2], UltrasonicRanging[3], UltrasonicRanging[4], UltrasonicRanging[5], UltrasonicRanging[6], UltrasonicRanging[7],
	robotPower,\
	timeStamp);
	Com_Puts(1, sendCharBuff);
}

extern u32 pc_cnt;
u32 last_pc_cnt = 0;
u32 time_count = 0;
u8 time_out = 0;
void MainTask(void)
{

	Ultrasonic[0].ClcUtralData(0);
 	Ultrasonic[1].ClcUtralData(1);
 	Ultrasonic[2].ClcUtralData(2);
 	Ultrasonic[3].ClcUtralData(3);
	while(1)
	{
		GPS.position.x += 1;
		GPS.position.y += 1;
		GPS.radian += 1;
		SetCursor(0,0);
		LCD_WriteString("speedy:");		
		LCD_WriteFloat(PcData.speed_y.fl32);
		SetCursor(0,20);
		LCD_WriteString("speedz:");		
		LCD_WriteFloat(PcData.speed_rot.fl32);

		
		if(pc_cnt == last_pc_cnt)
		{
			time_count++;
			if(time_count > 20)
				time_out = 1;
		}
		else
		{
			time_count = 0;
			time_out = 0;
		}
		if(time_out)
		{
			setDiffSpeed(0,0);
		}
		else
		{
			sendStr2Pc();
			setDiffSpeed(PcData.speed_y.fl32,PcData.speed_rot.fl32);
		}
		last_pc_cnt = pc_cnt;
		delay_ms(10);
	};
}

