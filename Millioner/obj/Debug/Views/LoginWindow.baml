   M S B A M L   `   `   `  ����D  @Millioner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Millioner.ViewsMillioner.Views  5   	   9!clr-namespace:Millioner.UtilitiesMillioner.Utilities  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	   !    Millioner.Views.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Millioner.Views     5   	   7	Utilities!clr-namespace:Millioner.Utilities     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	     � Title$  LoginWindow��5
   	   $	��400��6   $	��700��6*   $	��300��66   $	��450��6F    � WindowStartupLocation$ CenterScreen=�6U   ��5      �� 5   
    �� ImageSource$&  /Resources/images/back_color.png��6    � 	Resources 5       �� MergedDictionaries �� Source   ButtonStyle �� 
TargetType �� Property �� Value	 �� Triggers
 P� Property P� Value�� 5   
    5      �� 5      $' !/WindowResources\Dictionary1.xaml?�6%   %	  &	        �� 5      " ��6(   .�5      ��  � ��
 ���� 6/   �� 5       �@�Cursor$
 Hand��6+   �� 5       � ��
 ���� 60   �� 5       � ��$ 0q�64   	 5      P� 5      
 �@J�IsMouseOver . 5      5      5!      .��5$      �� $��Center=�6   $��Center=�6,   .+�5&   
   �� $%��Login or password entered wrong��6   $
��0,10q�6;   
���  ��$��20(�6^   $��DemiBold"�6l   $��Center=�6�   y�6�   �� *UserCheckVisibility+%   Millioner.Utilities.Placeholder  5(   
      PlaceholderText$ Enter login��6;   $��10q�6Y   $	��400��6e   $��35��6q     VariantStyle#��[ 6}   ��6    �� *	UserLogin+6}     5*   
   $ Enter password��6>   $��10q�6_   $	��400��6k   $��35��6w   #��[ 6�   ��6    �� *UserPassword+6�   �� 5,   
   $��10q�6   $	��200��6     ButtonTemplate#��[ 6K   ��6*   �� *LoginCommand+.��6v   Login6}   �� 5.   
   $��Center=�6    �� Orientation$ 
Horizontal=�62   .+�5/      �� $��5q�6   $��20(�6#   
�������New User here?6U   �� 50      $��5q�6   #��[  6D   ��6    �� *RegisterCommand+.��51      �� $��20(�6   
�����_�$��DemiBold"�6;    �� TextDecorations$ 	Underline{�6Q   .�6m   
Register6w   52      53      55      57      