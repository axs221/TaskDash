   M S B A M L   `   `   `  ����  TaskDash/    )TaskDash.Notifications.NotificationWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Notification Popup��5   	   $	��300��6$    � SizeToContent$ Height=�60    � WindowStyle$
 None=�5   	    � AllowsTransparency . 
������ .��5      � -   5         �Name$ 
gridWindow��5       J� RenderTransformOrigin$	 0,1&�6   .+�5   
   �� $��1q�6   
�������
���   � �� CornerRadius$ 10��6L   ._�5      �� $��20q�6   .+�5      �� -   5         ��Name$ textBlockTitle��5      $
��Wrap=�64   $��5q�6H   �� 5      -   5        $ textBlockDescription��5      $
��Wrap=�6:   $��5q�6N   �� 5      -   5         ��Name$ comboBoxDelay��5      	 �� 
IsEditable	 . 
 �� SelectedValue
 5      �� *DelayLengthCombo+.@�5      �� .��6#   	5 Minutes6.   �� 5      .��6#   
10 Minutes6/   �� 5      .��6#   
15 Minutes6/   �� 5      .��6#   
30 Minutes6/   �� 5      .��6#   1 Hour6+   �� 5      .��6#   	3 Hours6,   �� 5      .��6#   	5 Hours6,   �� 5      .��6#   1 Day6*   �� 5      .��6#   2 Days6+   �� 5      .��6#   3 Days6+   �� 5      .��6#   1 Week6+   5      �� 5      -   5         ��Name$ stackPanelButtons��5       �� Orientation$ 
Horizontal=�68   .+�5       �� -   5         ��Name$ buttonDismiss��5       $��Center=�6P   .��6m   	Dismiss6v   5!      5"      5#       � Triggers 5&   
   :� 5'       :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5(      �� .��5)      �� -   5         ��Name$ storyBoardFadeWindow��5)   !   .��5*      U�  �� TargetProperty$9 3(UIElement.RenderTransform).(ScaleTransform.ScaleY)�68   .\�5+      ��  O� KeyTime$ 0:0:0��63    O� Value$ 0Q�6C   �� 5,      $ 0:0:0.2��63   $ 1Q�6E   5-      U� 5.      $ (UIElement.Opacity)�68   .\�5/      �� $ 0:0:3��63   $ 1Q�6C   �� 50      $ 0:0:25��63   $ 0Q�6D   51      52      53      54      z�57   
   �� 58       �� ScaleY$ 1Q�6   5;      5<      