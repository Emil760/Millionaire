   M S B A M L   `   `   `  ����  	Millioner%    Millioner.Views.UsersInfoWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  UsersInfoWindow��5   	   $	��450��6!   $	��800��6.    � WindowStartupLocation$ CenterScreen=�6:    � 
ResizeMode$ NoResize=�6_   ��5      �� 5	   
    �� ImageSource$&  /Resources\images\back_color.png��6    � 	Resources 5       �� Source�� 5   
   $' !/WindowResources\Dictionary3.xaml?�6   %    .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      $
��1.5* �6   .+�5   
   �� $��0��5         UsersDataTemplate#��[  5        ListBoxItemContainerStyle#��[ 5      
������$��5q�5      $��20q�5      $��20(�5      ��5      ��  �� Path$ Users� �� SelectedItem 5      �� $ SelectedUser���5      �� 5       	 �� EndPoint$	 0.5,1&�6&   
 � MappingMode$
 RelativeToBoundingBox=�67    �� 
StartPoint$ 0.5,0&�6[   .��5!      �  � Color$ 	#FFB237C2��6#   � 5"      $ 	#FFB450C0��6#    � Offset$ 1Q�65   � 5#      $ 	#FFBEE05B��6#   $
 0.55Q�65   5$      5&      �� 5(   
   $��1��6   $��	30,30,0,0q�6%   .+�5)      ��   	InfoStyle#��[ 6Z   ��6   �� $ SelectedUser.Login� �� StringFormat$ 
Login: {0}��6Z   �� 5*      #��[ 6Z   ��6   �� $ SelectedUser.Games�$ 
Games: {0}��6Z   �� 5+      #��[ 6i   ��6   �� $ SelectedUser.AverageScore�$ Average score: {0}��6i   �� 5,      #��[ 6a   ��6   �� $ SelectedUser.Money�$ Earned money: {0}��6a   5-      5.      5/      