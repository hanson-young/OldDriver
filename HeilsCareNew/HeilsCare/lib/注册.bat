@echo 开始注册
copy D:\项目\HeilsCare\lib\AxInterop.WMPLib.dll %windir%\system32\
regsvr32 %windir%\system32\AxInterop.WMPLib.dll /s
@echo AxInterop.WMPLib.dll注册成功
@pause