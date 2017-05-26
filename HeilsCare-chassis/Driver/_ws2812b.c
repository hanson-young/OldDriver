/**
  ******************************************************************************
  * @file    _ws2812b.c
  * @author  flysnow
  * @version V1.0
  * @date    2017-2-26
  * @brief   
  ******************************************************************************
  * @attention
  *
  ******************************************************************************
  */
#include "includes.h"
#include "../System/sys.h" 	
#include "../Task/_task.h" 
#include "../Driver/_delay.h"
#include "../Driver/_io_status.h"


u8 RGB_BUF[24];

u8 Led_Tab[]={0xC0,0xF9,0xA4,0xB0,0x99,0x92,0x82,0xF8,0x80,0x90,0x88,0x83,0xC6,0xA1,0x86,0x8E};        
//�洢һ��ת�����RGB2������  ��24bits
struct colorStructure                    //�ṹ��
{
   u8 green;                 //��ɫ  0-255
   u8 red;                  //��ɫ 0-255
   u8 blue;                  //��ɫ0-255
};
 
 
void callWs()
{
	GPIOA -> BSRR = GPIO_Pin_1;
// 	for(testdelay = 0; testdelay < 1;testdelay++)
// 	{
//  		//__nop();
// 	}
// __nop();__nop();__nop();
// 	testdelay *= testdelay;
	
	GPIOA -> BRR = GPIO_Pin_1;
}

/*д������ʱ��*/
void sendSingleByte(u8* value)
{
	u8 i;
	u8 mcuDelay = 0;
//     Send_Dat=0;
	
	for (i = 0; i < 24; i++)
	{
		if (value[i]==1)
		{
			GPIOA -> BSRR = GPIO_Pin_1;
			for(mcuDelay = 0; mcuDelay < 4;mcuDelay++)
			{
				//__nop();
			}
			GPIOA -> BRR = GPIO_Pin_1;
			for(mcuDelay = 0; mcuDelay < 2;mcuDelay++)
			{
				//__nop();
			}
		}
		else
		{			
			GPIOA -> BSRR = GPIO_Pin_1;
			for(mcuDelay = 0; mcuDelay < 1;mcuDelay++)
			{
				//__nop();
			}
			GPIOA -> BRR = GPIO_Pin_1;
			for(mcuDelay = 0; mcuDelay < 4;mcuDelay++)
			{
				//__nop();
			}
		}   
	}
        
      
}
 
 
/*����24λ�ַ�������RGB��Ϣ��8λ��*/
void sendColorStructure(struct colorStructure RGB )                      
{
    u8 i;
    for   (i=0;i<8;i++)
    {
        RGB_BUF[i]=RGB.green>>i&0x01;                          //ת��R_VAL
    }
    for   (i=8;i<16;i++)
    {
        RGB_BUF[i]=RGB.red>>(i-8)&0x01;               //ת��G_VAL
    }
    for   (i=16;i<24;i++)                                                       //ת��B_VAL
    {
        RGB_BUF[i]=RGB.blue>>(i-16)&0x01;     
    }
		sendSingleByte(RGB_BUF);
}
 
/*������*/
void ws2812b()
{
		int j = 0;
    struct colorStructure Color;
		Color.red=0x00;
    Color.green=0x00;
    Color.blue=0x7f;
	
		for(j = 0;j < 100;j++)//100����
				sendColorStructure(Color);

}
