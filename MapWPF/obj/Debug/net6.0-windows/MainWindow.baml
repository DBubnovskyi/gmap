   M S B A M L   `   `   `  ����c  _GMap.NET.WindowsPresentation, Version=2.1.6.0, Culture=neutral, PublicKeyToken=b85b9027b614afefqPclr-namespace:GMap.NET.WindowsPresentation;assembly=GMap.NET.WindowsPresentationGMap.NET.WindowsPresentation  5   	   A =MapWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MapWPFMapWPF 5   	   A%clr-namespace:MapWPF.Controls.ButtonsMapWPF.Controls.Buttons 5   	      MapWPF.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   bgmapsPclr-namespace:GMap.NET.WindowsPresentation;assembly=GMap.NET.WindowsPresentation     5   	   &localclr-namespace:MapWPF     5   	   5btn%clr-namespace:MapWPF.Controls.Buttons     5   	     � Title$  
MainWindow��5
   	   $
��1200��6   $
��1500��6*   .��5      �  � ColumnDefinitions 5   
   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��1* �6   �� 5      $��50 �6   .+�5   
   � -   5         �Name$ TopGrid��5      $��0��6   
�������6-   � 5   
   $��1��6    5      �� 5      -   5         ��Name$ 
PanelRight��5   0   $	��400 �6#   60   �� 5      $��* �6#   �� 5      $	��400 �6#   .+�5      � $��0��6   .+�5      %  MapWPF.Controls.Buttons.IconBtn  $��50��6   $��50��6*      Text$ Test1��65   5      � 5      $��1��6   .+�5      .   (GMap.NET.WindowsPresentation.GMapControl  -   5          Name$ mapView��5   $   $
��Left=�6M   $	��700��6h   -  'MapWPF.Controls.Buttons.ShowHideButtons  5!      -   5          Name$ ToggleRight��5!   &   $��30��6;   $��20��6G   $��Right=�5"   "   $��Center=�5#   "   5$      � 5%      -   5        $ 
RightPanel��5%   #   $��2��6   
����ح�5&      5'      � 5(   
   -   5        $ 
BottomGrid��5(      
���iii�6:   5)      5*      