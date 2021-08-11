#NoEnv  ; Recommended for performance and compatibility with future AutoHotkey releases.
; #Warn  ; Enable warnings to assist with detecting common errors.
SendMode Input  ; Recommended for new scripts due to its superior speed and reliability.
SetWorkingDir %A_ScriptDir%  ; Ensures a consistent starting directory.

$F9::			;killapp
{
	ExitApp
}



InsertDiscord(DiscordText)
{
DetectHiddenWindows, On
SetTitleMatchMode, 2
SetWorkingDir, C:\Users\%A_UserName%\AppData\Local\Discord ; Set working directory
runPath := A_WorkingDir . "\Update.exe --processStart Discord.exe" ; Combine working directory and additional text to create Run parameters
winTitle := "ahk_class Chrome_WidgetWin_1 ahk_exe Discord.exe"
WinGet, DiscordState, MinMax, ahk_exe Discord.exe
If (DiscordState = -1) ; If Discord is minimized, then restore window
	WinRestore, ahk_exe Discord.exe
Else
	Run, % runPath
	sleep, 1000

ControlFocus,, ahk_exe Discord.exe
sleep, 2500
ControlSend,,{LControl down}k{LControl up}, ahk_exe Discord.exe
sleep, 1000
ControlSend,,{SHIFTDOWN}ı{SHIFTUP}, ahk_exe Discord.exe
sleep, 30
ControlSend,,t, ahk_exe Discord.exe
sleep, 30
ControlSend,,e, ahk_exe Discord.exe
sleep, 30
ControlSend,,m, ahk_exe Discord.exe
sleep, 30
ControlSend,,m, ahk_exe Discord.exe
sleep, 30
ControlSend,,a, ahk_exe Discord.exe
sleep, 30
ControlSend,,k, ahk_exe Discord.exe
sleep, 30
ControlSend,,i, ahk_exe Discord.exe
sleep, 30
ControlSend,,n, ahk_exe Discord.exe
sleep, 30
ControlSend,,e, ahk_exe Discord.exe
sleep, 30
ControlSend,,s, ahk_exe Discord.exe
sleep, 30
ControlSend,,{Enter}, ahk_exe Discord.exe
sleep, 1000
ControlSend,,{SHIFTDOWN}1{SHIFTUP}, ahk_exe Discord.exe
ControlSend,,%DiscordText%{Enter}, ahk_exe Discord.exe

If (DiscordState = -1) ; If Discord was previously minimized, return to minimized state
	{
	sleep, 400
	WinMinimize, ahk_exe Discord.exe
	}
else
Send {Alt down}{tab}{Alt up}
Return
}

; ### Hot-key Aliases ###
; Ctrl + Numpad#

$F10::				;dnslot
Loop
{
InsertDiscord("dnslot")
Sleep 5500000
}