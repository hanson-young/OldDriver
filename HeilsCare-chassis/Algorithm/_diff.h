
/* Define to prevent recursive inclusion -------------------------------------*/
#ifndef __DIFF_H
#define __DIFF_H

/* Includes ------------------------------------------------------------------*/
#include "stm32f10x.h"
#include "_typedef.h"
/* Exported macro ------------------------------------------------------------*/

/* Exported variables --------------------------------------------------------*/

extern float leftSpeed;
extern float rightSpeed;

/* Exported function prototype -----------------------------------------------*/
void setDiffSpeed(float speedTrans, float speedRot);

#endif 

/**********************************END OF FILE*********************************/

