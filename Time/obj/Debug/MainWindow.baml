   M S B A M L   `   `   `  ?????  ;Time, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TimeTime  5   	       Time.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Time     5   	   -   5        $	??450??5   	   $	??800??6   $	??450??6(   $	??800??68     ? WindowStartupLocation$  CenterScreen=?6G    ? Title$ TimeManagement??5	   	   $??Roboto)?5
   	   .??5      ? ??5   
   ?? 5       ?? 
StartPoint$	 0,0&?6"    ?? EndPoint$	 1,1&?63   .??5      ?  ? Color$ #00ff87??6    ? Offset$	 0.0Q?6/   ? 5      $ #60efff??6   $	 0.5Q?6/   5      .+?5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
dgTodoList??5      $??15(?6'   $
??Bold"?65   $??
10,40,10,5q?6G      AutoGenerateColumns .  
??????    RowBackground
 ???? 	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      
   
FontWeight$

 Bold"?6K   ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .     Header$          Start time??6p      Width5  /System.Windows.Controls.DataGridLengthConverter$	 180 6?   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ??  ?? Path$ 
FinishDate?5      4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $        Done??6K   $	 100 6`    6)   ?? $ isDone?5        5       .  $         Todo??6X   $ * 6n    6%   ?? $
 Text?6z   5      ?? 5   
   -   5         ??Name$ TxtBlochjara??5      $??55 10 10 10q?6*   $
??Bold"?6?   $??20(?6Q   $??	Today is ??5      $
??Left=?6!   $	??Top=?6<   ?? 5   
   -   5        $ TxtNameOfProgram??5      $ ??Your daily time management??6.   $??10q?6P   $
??Bold"?6\   $??20(?6n   $??Right=?5      $	??Top=?60   ?? 5   
   $??/Images/square_clock.png??6   $??
10 0 10 10q?62   $
??Left=?6F   $	??Top=?6a   $??40??6y   $??40??6?   6?   ?? 5    
   $??/Images/calendar.png??6   $??10 0 285 10q?6.   $??Right=?6C   $	??Top=?6_   $??40??6w   $??40??6?   6?   ?? 5!   
   $??/Images/alarm_clock.png??6   $??25??61   $??25??6<   $	??Top=?5"      $
??Left=?6(   $??20 40 10 10q?6C   6Z   ?? 5#   
   $??/Images/checkmark.png??6   $??25??6/   $??25??6:   $??Center=?5$      $	??Top=?6-   $??-325 42 30 30q?6E   6^   ?? 5%   
   $??/Images/list.png??6   $??25??6*   $??25??65   $??Center=?5&      $	??Top=?6-   $??-120 42 30 30q?6E   6^   5(      5*      