$regfile = "m8def.dat"
$crystal = 1000000
'$baud = 1200

$hwstack = 32
$swstack = 8
$framesize = 24

'$sim
Config Adc = Single , Prescaler = Auto , Reference = Avcc
'Now give power to the chip

Start Adc
Config Portd = Output
Config Portd.0 = Input

Declare Sub Check_motors()
Declare Sub Move_right(byval Motor As Integer)
Declare Sub Move_left(byval Motor As Integer)

Declare Function Check_sum(s$ As String) As Integer


Config Lcdmode = Port


Config Lcdpin = Pin , Db7 = Portb.0 , Db6 = Portb.1 , Db5 = Portb.2 , Db4 = Portb.3 , E = Portb.4 , Rs = Portb.5
Config Lcd = 16 * 2



Dim I As Integer
Dim Mv(6) As String * 8
Dim Mvn As Integer
Dim Mvatmp As Single
Dim Mvatmp1 As Integer
Dim C As Integer



Dim Mva(6) As Integer







Dim Motor_ms As Integer

Dim Motor_pin1 As Integer
Dim Motor_pin2 As Integer

Dim Movement_limit As Integer


Dim Z As String * 1
Dim X As String * 50

'Portb.1 = 0

'dim Z As Word


    Dim Adc_pin As Integer
    Dim Chk As Integer


'------- VARS ------------'
Motor_ms = 30
Movement_limit = 1000
'-------------------------'



Open "comd.0:1200,8,n,1" For Input As #1

 Cls
 Lcd "WAITING"



Do


Z = Inkey(#1)


 If Chr(z) = "." Then
 X = ""
 C = 0

 While Z <> ","
Get #1 , Z

If C > 50 Then
Exit While
End If

If Z <> "," Then
X = X + Z
End If

C = C + 1

Wend
Get #1 , Z

Chk = Check_sum(x)

If Asc(z) = Chk Then
'Lcd X
Mvn = Split(x , Mv(1) , "-")

Call Check_motors()
Else
Lcd Asc(z) ; Chk
End If

  End If


 '   Waitms 500
Loop

Close #1


Sub Check_motors()




   For I = 2 To 5
    C = 0
    Do

'--------- get Angels --------'
   Adc_pin = I - 2
    Mvatmp1 = Getadc(adc_pin)
    Mvatmp = Mvatmp1 / 5.67
Mva(i) = Round(mvatmp)
Dim Mx As Integer
Mx = I - 1
'------- Display ------------'
' If I = 4 Then Lowerline
 Cls
 Lcd "M" ; Mx ; ":" ; Mva(i) ; "/" ; Mv(i) ; " "
'---------------------------

If C < Movement_limit Then
C = C + 1
'------- Move Motor ---------'
 If Mva(i) < Val(mv(i)) Then
Call Move_right(mx)
 Elseif Mva(i) > Val(mv(i)) Then
 Call Move_left(mx)
 Else
 Exit Do
 End If
'---------------------------'
 Else
Exit Do
 End If

  Loop

   Next


End Sub





Sub Move_right(motor As Integer)




Select Case Motor
Case 1 :
Motor_pin1 = 3
Motor_pin2 = 4
Case 2 :
Motor_pin1 = 4
Motor_pin2 = 5
Case 3 :
Motor_pin1 = 6
Motor_pin2 = 7
Case 4 :
Motor_pin1 = 6
Motor_pin2 = 7
End Select



 Portd.motor_pin1 = 0
 Portd.motor_pin2 = 0
 Waitms Motor_ms
  Portd.motor_pin1 = 1
  Portd.motor_pin2 = 0
  Waitms Motor_ms
  Portd.motor_pin1 = 0
  Portd.motor_pin2 = 1
  Waitms Motor_ms

   Portd.motor_pin1 = 1
  Portd.motor_pin2 = 1
  Waitms Motor_ms



End Sub

Sub Move_left(motor As Integer)
Select Case Motor
Case 1 :
Motor_pin1 = 3
Motor_pin2 = 4
Case 2 :
Motor_pin1 = 4
Motor_pin2 = 5
Case 3 :
Motor_pin1 = 6
Motor_pin2 = 7
Case 4 :
Motor_pin1 = 6
Motor_pin2 = 7
End Select


Portd.motor_pin1 = 1
 Portd.motor_pin2 = 1
 Waitms Motor_ms
  Portd.motor_pin1 = 0
  Portd.motor_pin2 = 1
  Waitms Motor_ms
  Portd.motor_pin1 = 1
  Portd.motor_pin2 = 0
  Waitms Motor_ms

   Portd.motor_pin1 = 0
  Portd.motor_pin2 = 0
  Waitms Motor_ms


End Sub



Function Check_sum(s$ As String * 50)
Dim Chkx As Integer
Dim Lnx As Byte
Dim M As Byte
Dim Bz As String * 10

     Chkx = 0

For M = 1 To Len(s$)
Bz = Mid(x , M , 1)
      Chkx = Chkx + Asc(bz)
      If Chkx > 100 Then Chkx = Chkx Mod 100
Next

 Check_sum = Chkx
 End Function
'End