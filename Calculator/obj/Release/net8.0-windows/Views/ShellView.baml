   M S B A M L   `   `   `  ���� E  ACalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Calculator.ViewsCalculator.Views       Calculator.Views.ShellView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:Calculator.Views     
���   �  � Title$  
Calculator��$	��300��$	��300�� � WindowStartupLocation$ CenterScreen=�.���  � ColumnDefinitions �� $��30 ��� $
��auto ��� $
��auto ��� $��* ��� $��30 � � RowDefinitions �� $��30 ��� $��20 ��� $��10 ��� $��20 ��� $��10 ��� $��20 ��� $��10 ��� $��20 ��� $��10 ��� $��20 ��� $��10 ��� $��20 ��� $��10 ��� $
��auto �.+��� -    ��Name$	 Num��$��1��$��1��
�������
���   � �� 
IsReadOnly$
 True��$��0,0,0,10q�$��2�� �� TextAlignment$ Right=��� -    ��Name$ PushButtonMPlus��$��3��$��1��$��20��
�������
���   �$��	0,0,210,0q�$	��Top=�.��M+�� -   $ PushButtonMMinus��$��3��$��1��$��20��
�������
���   �$��
46,0,164,0q�$	��Top=�.��M-�� -   $ PushButtonMRC��$��3��$��1��$��20��
�������
���   �$��
90,0,120,0q�$	��Top=�.��MRC�� -   $ PushButtonSeven��$��5��$��1��$��20��
�������
���   �$��	0,0,210,0q�$	��Top=�.��7�� -   $ PushButtonEight��$��5��$��1��$��20��
�������
���   �$��
46,0,164,0q�$	��Top=�.��8�� -   $ PushButtonNine��$��5��$��1��$��20��
�������
���   �$��
90,0,120,0q�$	��Top=�.��9�� -   $ PushButtonC��$��5��$��1��$��20��
�������
���   �$��
135,0,75,0q�$��Center=�.��C�� -	   $ PushButtonAC��$��5��$��1��$��20��
�������
���   �$��	210,0,0,0q�$��Center=�.��AC�� -
   $ PushButtonFour��$��7��$��1��$��20��
�������
���   �$��	0,0,210,0q�$	��Top=�.��4�� -   $ PushButtonFive��$��7��$��1��$��20��
�������
���   �$��
46,0,164,0q�$	��Top=�.��5�� -   $ PushButtonSix��$��7��$��1��$��20��
�������
���   �$��
90,0,120,0q�$	��Top=�.��6�� -   $ PushButtonMulti��$��7��$��1��$��20��
�������
���   �$��
135,0,75,0q�$��Center=�.��x�� -   $ PushButtonDivide��$��7��$��1��$��20��
�������
���   �$��	210,0,0,0q�$��Center=�.��÷�� -   $ PushButtonOne��$��9��$��1��$��20��
�������
���   �$��	0,0,210,0q�$	��Top=�.��1�� -   $ PushButtonTwo��$��9��$��1��$��20��
�������
���   �$��
46,0,164,0q�$	��Top=�.��2�� -   $ PushButtonThree��$��9��$��1��$��20��
�������
���   �$��
90,0,120,0q�$	��Top=�.��3�� -   $ PushButtonPlus��$��9��$��1��
�������
���   �$��
135,0,75,0q�$��3��.��+�� -   $ PushButtonMinus��$��9��$��1��$��20��
�������
���   �$��	210,0,0,0q�$��Center=�.��-�� -   $ PushButtonZero��$��11��$��1��$��20��
�������
���   �$��	0,0,210,0q�$	��Top=�.��0�� -   $ PushButtonDoubleZero��$��11��$��1��$��20��
�������
���   �$��
46,0,164,0q�$	��Top=�.��00�� -   $ PushButtonDot��$��11��$��1��$��20��
�������
���   �$��
90,0,120,0q�$	��Top=�.��.�� -   $ PushButtonEqual��$��11��$��1��$��20��
�������
���   �$��	210,0,0,0q�$��Center=�.��=