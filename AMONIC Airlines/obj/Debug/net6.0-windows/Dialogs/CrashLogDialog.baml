   M S B A M L   `   `   `  ????J  FAMONIC Airlines, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:AMONIC_Airlines.DialogsAMONIC_Airlines.Dialogs  5   	   ,    &AMONIC_Airlines.Dialogs.CrashLogDialog   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:AMONIC_Airlines.Dialogs     5   	     ? SizeToContent$  WidthAndHeight=?5   	    ? WindowStartupLocation$ CenterOwner=?5	   	   $	??300??5
   	   $	??300??5   	    ? Title$ No logout detected??5   	   .??5      ?  ? DataContext 6   ?? *
BindedData+ ? 	Resources 5   
    ?? 
TargetType ?? Property ?? Value??%?  '?       '?? H     '?? ?     '??     '?? X    '?? ?    ?? 5      " ?6   .?5      ??  ? ??$ 10q?6+   5      ?? 5      " ??6   .?5      ??  ? ??$ 0,3,5,5q?6+   ?? 5       ? ??$ 0,0,0,5q?6,   5      ?? 5      " ??6   .?5      ??  ? ??$ 0,0,0,5q?6+   5      ?? 5      " ??6   .?5      ??  ? ??$ 0,0,0,5q?6+   5      ?? 5      " ??6   .?5      ??  ?@??Orientation$ 
Horizontal=?60   ?? 5       ? ??$ Right=?68   5      ?? 5       " ??6   .?5!      ??  ? ??$ 70??6*   ?? 5"       ? ??$ 25??6+   ?? 5#       ? ??$ 5,5,0,0q?6+   5$      5%       ? RowDefinitions 5&   
   ?? 5'      $??* ?6   ?? 5(      $??* ?6   ?? 5)      $??5* ?6   ?? 5*      $??* ?6   	 ? ColumnDefinitions	 5,   
   ?? 5-      $??* ?6   ?? 5.      $??* ?6   ?? 5/      $??* ?6   .+?51   
   ?? -   5        $??
ErrorBlock??51   E   $??0??6   $??0??6$   $??3??61   $C??=No logout detected for your last login on xx/xx/xxxx at xx:xx??6W   ?? 52   
   $??0??6   $??1??6    .??6-   	Reason:66   ?? 53   
   -   5        $??ErrorBox??53   C   $??0??6   $??2??6"   $??3??6/   6C   ?? 54   
   $??0??6   $??2??6%   $??3??69   
 ?? Orientation$
 
Horizontal=?6F   $??Center=?6_   $??Center=?6z   .+?55      	? -   5         	? 	GroupName$
 Type??55      $??Software Crash??6+    d? 	IsChecked$
 TrueY?6D   $??0,0,10,0q?6U   6g   	? 56      -   5        $
 Type??56      $??System Crash??6+   6B   57      ?? 58   
   -   5         ?? 	IsDefault$
 True??58      $??3??6"   $??2??6/   .??6T   OK6X   59      5:      