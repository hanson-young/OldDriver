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

#define ADC1_DR_Address    ((uint32_t)0x4001244C)
#define ADC2_DR_Address    ((uint32_t)0x4001284C)

volatile u32 AdData[6]; 

 /*******************************************************************************
* Function Name  : AD_Average
* Description    : 选择通道对采样值进行平均滤波
* Input          : average_count：采集次数   	channel：通道选择
* Return         : sum/average_count：采样平均值
*******************************************************************************/

u16 AD_Average(int average_count,int channel)	 
{
	int i = 0;
	u16 temp;
	float sum=0;
	for(i=0;i<average_count;i++)
	{
		temp=AdData[channel];
		sum+=temp;
	}
	sum = sum/(float)average_count; 
	return (u16)sum;
}

/*******************************************************************************
* Function Name  : adcinit
* Description    : ADC设置（包括ADC模块配置和自校准）
                   DMA设置：从ADC模块自动读转换结果至内存
* Input          : None
* Return         : None
*******************************************************************************/
void adcinit(void)
{
	ADC_InitTypeDef ADC_InitStructure;
	DMA_InitTypeDef DMA_InitStructure;
	GPIO_InitTypeDef GPIO_InitStructure;/* ADCCLK = PCLK2/4 */
	RCC_ADCCLKConfig(RCC_PCLK2_Div4); 
  /* Enable peripheral clocks ------------------------------------------------*/
	/* Enable DMA1 clock */
	RCC_AHBPeriphClockCmd(RCC_AHBPeriph_DMA1, ENABLE);/*开启时钟*/
	/* Enable ADC1 and GPIOA clock */
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_ADC1| RCC_APB2Periph_GPIOA, ENABLE);/* Configure PC.04 (ADC Channel0/1/2/3/4/5) as analog input -------------------------*/	
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_7|GPIO_Pin_5|GPIO_Pin_6|GPIO_Pin_4;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AIN;
	GPIO_Init(GPIOA, &GPIO_InitStructure);
// 	RCC_APB2PeriphClockCmd(RCC_APB2Periph_ADC1| RCC_APB2Periph_GPIOB, ENABLE);/* Configure PC.04 (ADC Channel0/1/2/3/4/5) as analog input -------------------------*/	
// 	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_0;
// 	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AIN;
// 	GPIO_Init(GPIOB, &GPIO_InitStructure);
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_ADC1| RCC_APB2Periph_GPIOC, ENABLE);/* Configure PC.04 (ADC Channel0/1/2/3/4/5) as analog input -------------------------*/	
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_4|GPIO_Pin_5;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AIN;
	GPIO_Init(GPIOC, &GPIO_InitStructure);
	/* DMA1 channel1 configuration ----------------------------------------------*/
	DMA_DeInit(DMA1_Channel1);
	DMA_InitStructure.DMA_PeripheralBaseAddr = ADC1_DR_Address;/*ADC地址*/
	DMA_InitStructure.DMA_MemoryBaseAddr = (uint32_t)AdData;/*内存基地址*/
	DMA_InitStructure.DMA_DIR = DMA_DIR_PeripheralSRC;/*DMA传输方向*/
	DMA_InitStructure.DMA_BufferSize = 6;//DMA传输地的数据总大小
	DMA_InitStructure.DMA_PeripheralInc = DMA_PeripheralInc_Disable;/*外设地址是否自增*/
	DMA_InitStructure.DMA_MemoryInc =DMA_MemoryInc_Enable;/*内设地址是否自增*/
	DMA_InitStructure.DMA_PeripheralDataSize = DMA_PeripheralDataSize_Word;//外设数据单元大小
	DMA_InitStructure.DMA_MemoryDataSize = DMA_MemoryDataSize_Word;//内存数据单元大小
	DMA_InitStructure.DMA_Mode = DMA_Mode_Circular;//循环传输
	DMA_InitStructure.DMA_Priority = DMA_Priority_High;//优先级
	DMA_InitStructure.DMA_M2M = DMA_M2M_Disable;//是否内存到内存的DMA传输
	DMA_Init(DMA1_Channel1, &DMA_InitStructure);
	
	/* Enable DMA1 channel1 */
	DMA_Cmd(DMA1_Channel1, ENABLE);
		
	/* ADC1 configuration ------------------------------------------------------*/
	ADC_InitStructure.ADC_Mode = ADC_Mode_Independent;//ADC独立模式
	ADC_InitStructure.ADC_ScanConvMode = ENABLE;//扫描
	ADC_InitStructure.ADC_ContinuousConvMode = ENABLE;//连续转换模式
	ADC_InitStructure.ADC_ExternalTrigConv = ADC_ExternalTrigConv_None;//不使用外部触发转化
	ADC_InitStructure.ADC_DataAlign = ADC_DataAlign_Right;//数据右对齐
	ADC_InitStructure.ADC_NbrOfChannel = 6;//要转换的通道数目
	ADC_Init(ADC1, &ADC_InitStructure);
	
	ADC_RegularChannelConfig(ADC1, ADC_Channel_4, 1, ADC_SampleTime_1Cycles5);
	ADC_RegularChannelConfig(ADC1, ADC_Channel_5, 2, ADC_SampleTime_1Cycles5);
	ADC_RegularChannelConfig(ADC1, ADC_Channel_6, 3, ADC_SampleTime_1Cycles5);
	ADC_RegularChannelConfig(ADC1, ADC_Channel_7, 4, ADC_SampleTime_1Cycles5);
	ADC_RegularChannelConfig(ADC1, ADC_Channel_14, 5, ADC_SampleTime_1Cycles5);
	ADC_RegularChannelConfig(ADC1, ADC_Channel_15,6, ADC_SampleTime_1Cycles5);//周期和需要配置的ADC通道
	
	
	ADC_DMACmd(ADC1, ENABLE);
		
	/* Enable ADC1 */
	ADC_Cmd(ADC1,ENABLE); 	
	
	/* Enable ADC1 reset calibaration register */   
	ADC_ResetCalibration(ADC1);
	/* Check the end of ADC1 reset calibration register */
	while(ADC_GetResetCalibrationStatus(ADC1));
	
	/* Start ADC1 calibaration */
	ADC_StartCalibration(ADC1);
	/* Check the end of ADC1 calibration */
	while(ADC_GetCalibrationStatus(ADC1));
	
	/* Start ADC1 Software Conversion */ 
	ADC_SoftwareStartConvCmd(ADC1, ENABLE);
	
	/* Test on DMA1 channel1 transfer complete flag */
	while(!DMA_GetFlagStatus(DMA1_FLAG_TC1));
	/* Clear DMA1 channel1 transfer complete flag */
    DMA_ClearFlag(DMA1_FLAG_TC1);

}


