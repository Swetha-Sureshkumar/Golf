   M S B A M L   `   `   `  ?????  ;Golf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GolfUIGolfUI  5          GolfUI.editPoints   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:GolfUI     5        ? Title$  Change Points??5      $	??100??5
   	   $	??300??5   	    ? SizeToContent$ WidthAndHeight=?5   	    ? 
ResizeMode$ NoResize=?5   	    ? ShowInTaskbar .   ? WindowStartupLocation$ CenterOwner=?5   	    +? FocusedElement 5   	   ??  ?? ElementName$ leftMarginTextBox??.??5   
   ? $??10q?6    ? 	Resources 5   
    ?? 
TargetType	 ?? Property
 ?? Value??%v  '??       '?? v     '?? ?     ?? 5      " ??6   .?5      ?? 	 ? ??$
 0,3,5,5q?6+   ?? 5      	 ? ??$
 0,0,0,5q?6,   5      ?? 5      " ??6   .?5      ?? 	 ? ??$
 0,0,0,5q?6+   5      ?? 5      " ??6   .?5      ?? 	 ? ??$
 70??6*   ?? 5      	 ? ??$
 25??6+   ?? 5      	 ? ??$
 5,0,0,0q?6+   5       5!       ? ColumnDefinitions 5"   
   ?? 5#      $
??Auto ?6#   ?? 5$       ? RowDefinitions 5'      ?? 5(      $
??Auto ?6    ?? 5)      $
??Auto ?6    ?? 5*      $
??Auto ?6    ?? 5+      .+?5.      ?? $??0??6   $??0??6$   .??61   X:65   ?? 5/   
   -   5        $??TextBoxX??5/      $??1??6"   $??0??62   ??6@   ?? *	NewPointX+?? 50      $??0??6   $??1??6$   .??61   Y:65   ?? 51   
   -   5        $??TextBoxY??51      $??1??6"   $??1??63   ??6A   ?? *	NewPointY+?? 5<      $??0??6   $??2??6)   $??2??6=    ?? Orientation$ 
Horizontal=?6J   $??Right=?6c   .+?5=      ?? -   5        $??okButton??5=       ?? 	IsDefault . .??6U   OK6Y   ?? 5>      -   5        $??cancelButton??5>       ?? IsCancel . .??6=   Cancel6E   5?      5F      5H      