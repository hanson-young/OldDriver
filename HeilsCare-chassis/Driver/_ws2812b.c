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
u8 RGB_BUF[24];

u8 Led_Tab[]={0xC0,0xF9,0xA4,0xB0,0x99,0x92,0x82,0xF8,0x80,0x90,0x88,0x83,0xC6,0xA1,0x86,0x8E};        
//存储一个转化后的RGB2进制数  共24bits
struct My_24bits                    //结构体
{
       u8 G_VAL;                 //绿色  0-255
       u8 R_VAL;                  //红色 0-255
       u8 B_VAL;                  //蓝色0-255
};
 
 
void callWs()
{
	GPIOA -> BSRR = GPIO_Pin_2;
// 	for(testdelay = 0; testdelay < 1;testdelay++)
// 	{
//  		//__nop();
// 	}
// __nop();__nop();__nop();
// 	testdelay *= testdelay;
	
	GPIOA -> BRR = GPIO_Pin_2;
}

/*写入数据时序*/
void Send_A_bit(u8* VAL)
{
	u8 i;
	u8 testdelay = 0;
//     Send_Dat=0;
	
	for (i=0;i<24;i++)
	{
		if (VAL[i]==1)
		{
			GPIOA -> BSRR = GPIO_Pin_2;
			for(testdelay = 0; testdelay < 4;testdelay++)
			{
				//__nop();
			}
			GPIOA -> BRR = GPIO_Pin_2;
			for(testdelay = 0; testdelay < 2;testdelay++)
			{
				//__nop();
			}
		}
		else
		{			
			GPIOA -> BSRR = GPIO_Pin_2;
			for(testdelay = 0; testdelay < 1;testdelay++)
			{
				//__nop();
			}
			GPIOA -> BRR = GPIO_Pin_2;
			for(testdelay = 0; testdelay < 4;testdelay++)
			{
				//__nop();
			}
		}   
	}
        
      
}
 
 
/*发送24位字符（包含RGB信息各8位）*/
void Send_24bits(struct My_24bits RGB_VAL )                      
{
       u8 i;
       for   (i=0;i<8;i++)
       {
              RGB_BUF[i]=RGB_VAL.R_VAL>>i&0x01;                          //转化R_VAL
       }
              for   (i=8;i<16;i++)
       {
              RGB_BUF[i]=RGB_VAL.G_VAL>>(i-8)&0x01;               //转化G_VAL
       }
              for   (i=16;i<24;i++)                                                       //转化B_VAL
       {
              RGB_BUF[i]=RGB_VAL.B_VAL>>(i-16)&0x01;     
       }
			Send_A_bit(RGB_BUF);
}
 
/*主函数*/
void test()
{
		int j = 0;
       struct My_24bits a,b,c,d,e,f,g;
       a.R_VAL=0x0;
       a.G_VAL=0x0;                      //1                   颜色顺序，下同
       a.B_VAL=0x0;
 
    b.R_VAL=0x00;
       b.G_VAL=0xff;                       //2
       b.B_VAL=0x00;
 
       c.R_VAL=0x00;
       c.G_VAL=0x00;                          //3
       c.B_VAL=0xff;
 
       d.R_VAL=0xff;                           //4
       d.G_VAL=0xff;
       d.B_VAL=0x00;
 
       e.R_VAL=0xff;
       e.G_VAL=0x00;                             //5
       e.B_VAL=0xff;
 
       f.R_VAL=0x00;
       f.G_VAL=0xff;                                  //6
       f.B_VAL=0xff;
 
       g.R_VAL=0xff;                                  //7
       g.G_VAL=0xff;
       g.B_VAL=0xff;
       while(1)
       {
				 for(j = 0;j < 100;j++)
						Send_24bits(a);
				 delay_ms(500);
				 	for(j = 0;j < 100;j++)
							Send_24bits(b);
				 	delay_ms(500);
				 	for(j = 0;j < 100;j++)
							Send_24bits(c);
				 	delay_ms(500);
				 	for(j = 0;j < 100;j++)
							Send_24bits(d);
				 	delay_ms(500);
				 	for(j = 0;j < 100;j++)
							Send_24bits(e);
				  delay_ms(500);
				 	for(j = 0;j < 100;j++)
							Send_24bits(f);
				 				  delay_ms(500);
				 	for(j = 0;j < 100;j++)
							Send_24bits(g);
				 delay_ms(500); 
       }
}
