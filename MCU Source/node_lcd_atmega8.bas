$regfile = "m8def.dat"
$crystal = 1000000


'----------------------------------------
Declare Function Check_sum(s$ As String) As Integer
Declare Sub Uart_init()
Declare Sub Uart_send()
Declare Sub Enable_tx()
Declare Sub Disable_tx()
Declare Sub Lcd_init()
Declare Sub Lcd_clear()
Declare Sub Lcd_welcome()
Declare Sub Sensors_init()
Declare Function Sensor_value(byval Pin As Integer) As Word
Declare Function Get_light(byval Pin As Integer) As Word
Declare Function Get_temperature(byval Pin As Integer) As Word
'--------------------------------------



'-------------------------------
Dim I As Integer
Dim Node_id As String * 1

Dim Sensor1 As Word
Dim Sensor2 As Word


Dim Ubfr As String * 50

Dim Chk As Integer
'------------------------------


'------------------
Node_id = "2"
'------------------




Call Sensors_init()
Call Lcd_init()
Call Uart_init()

Call Lcd_welcome()



Do


  Sensor1 = Get_temperature(0)
   Sensor2 = Get_light(1)



    Call Lcd_clear()
    Lcd "Node ID: " ; Node_id
    Lowerline
    Lcd "T: " ; Str(sensor1) ; " C  L: " ; Str(sensor2)



  Ubfr = Node_id + "%" + Str(sensor1) + "-" + Str(sensor2)

 Call Enable_tx()
  Call Uart_send()
  Waitms 20
   Call Uart_send()
  Call Disable_tx()


  Wait 1


Loop


'-----------------------------------
Sub Sensors_init()
Config Adc = Single , Prescaler = Auto
End Sub

'-----------------------
Function Sensor_value(pin As Integer)
Sensor_value = Getadc(pin)
End Function

'-----------------------------------
Function Get_light(pin As Integer)
Get_light = Getadc(pin) / 2
End Function

'------------------------------------
Function Get_temperature(pin As Integer)
Dim Tmpr As Single
Dim Tmpr_word As Word

 Tmpr_word = Getadc(pin)
    Tmpr = Tmpr_word * 5
    Tmpr = Tmpr / 1023
    Tmpr = Tmpr * 100
    Tmpr = Round(tmpr)
Get_temperature = Tmpr
End Function
'------------------------------------
Sub Lcd_init()
Config Lcdmode = Port
Config Lcdpin = Pin , Db7 = Portb.0 , Db6 = Portb.1 , Db5 = Portb.2 , Db4 = Portb.3 , E = Portb.4 , Rs = Portb.5
Config Lcd = 16 * 2
End Sub

'------------------------------------
Sub Lcd_clear()
Cls
End Sub

'------------------------------------
Sub Lcd_welcome()
 Cls
 Locate 1 , 3
   Lcd "WSN Project"

   Locate 2 , 5
   Lcd "Welcome"
       Wait 1
End Sub


'------------------------------------
Sub Uart_init()
Open "comd.1:1200,8,n,1" For Output As #1
Config Portd.2 = Output
End Sub

'------------------------------------
Sub Uart_send()
Dim Xx As Integer

Dim Chksb As String * 2


Xx = Check_sum(ubfr)
Chksb = Chr(xx)


Print #1 , "UU" ; ":" ; Ubfr ; ";" ; Chksb ; "UU"


End Sub


'------------------------------------
Sub Enable_tx()
Set Portd.2
End Sub
'------------------------------------
Sub Disable_tx()
Reset Portd.2
End Sub

'------------------------------------
Function Check_sum(s$ As String * 50)
Dim Chkx As Integer

Dim M As Byte
Dim Bz As String * 10

     Chkx = 0

For M = 1 To Len(s$)
Bz = Mid(s$ , M , 1)
      Chkx = Chkx + Asc(bz)
      If Chkx > 100 Then Chkx = Chkx Mod 100
Next

 Check_sum = Chkx
 End Function
'--------------------------------------


 End