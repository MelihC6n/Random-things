#NoEnv  ; Recommended for performance and compatibility with future AutoHotkey releases.
; #Warn  ; Enable warnings to assist with detecting common errors.
SendMode Input  ; Recommended for new scripts due to its superior speed and reliability.
SetWorkingDir %A_ScriptDir%  ; Ensures a consistent starting directory.
$RButton::                    ;Balık point
    Send {RButton}
    Sleep 1000
    while GetKeyState("RButton","P")
    {
        Send {RButton}
	sleep 40
    }
return

$F3::			;robot hepsi
	var := 0
	Loop 16
	{
	if (GetKeyState("F6","P"))
		break
	Send {LButton}
	Sleep 1100
	if (var>=8)
	{
	Send {s}
	Sleep 60
	}
	Send {Space}
	Sleep 250
	Loop 4
	{
	Send {s}
	Sleep 60
	}
	Loop 10
	{
	Send {Space}
	Sleep 150
	}
	Sleep 400
	Send {Esc}
	Sleep 1100
	var += 1
	}

$F4::				;Robot 1.ler
	Loop 8
	{
	if (GetKeyState("F6","P"))
		break
	Send {LButton}
	Sleep 1100
	Send {Space}
	Sleep 250
	Loop 4
	{
	Send {s}
	Sleep 60
	}
	Loop 10
	{
	Send {Space}
	Sleep 150
	}
	Sleep 400
	Send {Esc}
	Sleep 1100
	}

$F5::				;Robot 2.ler
	Loop 8
	{
	if (GetKeyState("F6","P"))
		break
	Send {LButton}
	Sleep 1100
	Send {s}
	Sleep 60
	Send {Space}
	Sleep 250
	Loop 4
	{
	Send {s}
	Sleep 60
	}
	Loop 10
	{
	Send {Space}
	Sleep 150
	}
	Sleep 400
	Send {Esc}
	Sleep 1100
	}

$F7::			;killapp
{
	ExitApp
}