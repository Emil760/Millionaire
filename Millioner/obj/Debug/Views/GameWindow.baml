   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	    	Millioner    Millioner.Views.GameWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   -   5        $��window��5   	     � Title$  
GameWindow��6   $	��600��6*   $
��1000��67   ��5	      �� 5
   
    �� ImageSource$  /Resources/images/hall.png��6    � 	Resources 5       �� Source�� 5   
   $' !/WindowResources\Dictionary2.xaml?�6   %    .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��1.2* �6   �� 5      $��5* �6   �� 5      $
��1.5* �6   �� 5      $
��1.3* �6   �� 5      $
��1.3* �6   .+�5    
   � $��0��6   $��2��6    5!      �� 5"      �� 5#      �� 5$      �� 5%      .+�5(      �� $��0��6      TipTemplate#��[  6L    � DataContext 6%   ��  �� Path$ 	PeopleTip���6t   ��  �� ElementName$ window��$" DataContext.PeopleTipCommand�.��5)      �� $"��/Resources\images\people.png��6   5*      �� 5+      $��1��6   #��[  6K    6%   �� $ PhoneTip���6s   �� $ window��$! DataContext.PhoneTipCommand�.��5,      �� $!��/Resources\images\phone.png��6   5-      �� 5.      $��2��6   #��[  6H    6%   �� $ X2Tip���6p   �� $ window��$ DataContext.X2TipCommand�.��5/      �� $��X2��6     MistakeStyle#��[ 6&   50      �� 51      $��3��6   #��[  6P    6%   �� $ FiftyFiftyTip���6x   �� $ window��$# DataContext.FiftyFiftyCommand�.��52      �� $��50:50��6     FiftyFiftyStyle#��[ 6)   53      54      �� 56   
   $��2��57      $��1��58      $��4��59        ListBoxTemplate#��[ 5=        ListBoxItemStyle#��[ 5>      {�5:      �� $ MoneyIsEnabled���5;      �� $ Moneys�	 �� SelectedItem	 5<      �� $ CurrentMoney�.   (System.Windows.Interactivity.Interaction
   Triggers
 5?      /   )System.Windows.Interactivity.EventTrigger  5@         	EventName$ SelectionChanged��6!   .   (System.Windows.Interactivity.TriggerBase   Actions. 5A      6   0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� *FireNumberChangedCommand+5B      5D      �� 5F   
   $��0��63   $��2��6C   $��2��6P   $��50,10q�6d   $��20(�6s   
�������$
��Wrap=�6�   ��6   �� $ Question�6�   �� 5H   
   $��0��6   $��0��6!   $��
Take money��6.     TakeMoneyTemplate#��[ 5J      {�5I      �� $ TakeMoneyIsEnabled���5K      �� *TakeMoneyCommand+�� 5M   
   -   5         ��Name$ butt1��5M      $��0��6    $��3��60     ButtonTemplate#��[ 5Q       5N      �� $ 
Answers[0]���5O      �� $ window��$# DataContext.GiveAnswerCommand���5P      ��  �� BindsDirectlyToSource . .��5R      � $��5q�6    5S      �� 5T      $��65��6'   �� 5U      .+�5W      �� $��0��6   $	��A: ��6,     VariantStyle#��[ 67   �� 5X      $��1��6     AnswerStyle#��[ 6J   ��6,   �� $ Variant�6J   5Y      5Z      �� 5\   
   -   5        $ butt2��5\      $��1��6    $��3��60   #��[ 5`       5]      �� $ 
Answers[1]���5^      �� $ window��$# DataContext.GiveAnswerCommand���5_      ��  . .��5a      � $��5q�6    5b      �� 5c      $��65��6'   �� 5d      .+�5f      �� $��0��6   $	��B: ��6,   #��[ 67   �� 5g      $��1��6   #��[ 6J   ��6,   �� $ Variant�6J   5h      5i      �� 5k   
   -   5        $ butt3��5k      $��0��6    $��4��60   #��[ 5o       5l      �� $ 
Answers[2]���5m      �� $ window��$# DataContext.GiveAnswerCommand���5n      ��  . .��5p      � $��5q�6    5q      �� 5r      $��65��6'   �� 5s      .+�5u      �� $��0��6   $	��C: ��6,   #��[ 67   �� 5v      $��1��6   #��[ 6J   ��6,   �� $ Variant�6J   5w      5x      �� 5z   
   -   5        $ butt4��5z      $��1��6    $��4��60   #��[ 5~       5{      �� $ 
Answers[3]���5|      �� $ window��$# DataContext.GiveAnswerCommand���5}      ��  . .��5      � $��5q�6    5�      �� 5�      $��65��6'   �� 5�      .+�5�      �� $��0��6   $	��D: ��6,   #��[ 67   �� 5�      $��1��6   #��[ 6J   ��6,   �� $ Variant�6J   5�      5�      5�      5�      