   M S B A M L   `   `   `  ����?  ;Lexy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:SixPackApps.LexySixPackApps.Lexy  5          SixPackApps.Lexy.App   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      /lexyclr-namespace:SixPackApps.Lexy     5        �� 	Resources  5      .   (SixPackApps.Lexy.InverseBooleanConverter   BoolInverter �� 
TargetType �� Property �� Value  PageHeaderLabelStyle3  -System.Windows.Media.Effects.DropShadowEffect  DropShadowEffect   ShadowDepth   
BlurRadius   Opacity   Color  DropShadowMandatoryInput  DropShadowValidInput  TextBoxStyle �� Triggers	 P� Property
 P� Value  MetroButton �� 
TargetType � 	Resources  Key ��Name �� Padding �� CornerRadius ��Name  ShadowStyle T� X T� Y �� Triggers �� 
TargetName 	 MetroCheckBoxStyle 
 CheckBoxFocusVisual �� 
Background �� Bullet �� Color �� 
StartPoint �� EndPoint � Color � Offset F�Name J� SnapsToDevicePixels'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState    
Storyboard! �� TargetProperty" �� 
TargetName# R� KeyTime$ R� Value  System.Windows.Visibility%   Visible	& �� To' g� Duration��%b  &	        '��      &	 �     &	 �     &	 ;    &	 �    &	 �    7  &	     7  &		 	    7    5   
   6'   �� 5	   
   " ��6   .�5
      ��  � ��$ Segoe)�6+   �� 5       � ��$ 14(�6)   �� 5       � ��$ Center=�62   5      �� 5   
   " ��6-   .�5      ��  � ��$ 32(�6)   5        5   
   $ 0Q�64   $ 10Q�6D   $	 0.6Q�6T   $ Black��6b     5   
   $ 0Q�6<   $ 5Q�6L   $
 0.75Q�6[   $	 Red��6j     5   
   $ 0Q�68   $ 10Q�6H   $	 0.9Q�6X   $ 
LightGreen��6f   �� 5   
    5      P� 5      	 �@J�	IsFocused
 . . �5      ��  �@J�Effect8   67   5      .�5      ��  � ��$ 14(�61   �� 5       � ��$
 Auto��6/   �� 5       � ��$ Stretch=�6:   �� 5        � ��$ Stretch=�6<   �� 5!       � ��$
 Auto��6.   5"      �� 5%   
   " ��6   .�5&      ��  � ��$ Segoe)�6+   �� 5'       � ��$ 24(�6)   �� 5(       � ��$
 Auto��6&   �� 5)       � ��$
 Auto��6'   �� 5*       � ��$ 100,10,10,10q�6(   �� 5+       � ��$ Center=�62   �� 5,       � ��
 ��+��6+   �� 5-       �@�OverridesDefaultStyle . 66   �� 5.       � ��$ Center=�64   �� 5/       �@J�Effect 50        51      $ 0Q�6'   $ 10Q�67   $ White��6G   53      �� 55       � �� 56      �� 57      " ��6&    58      ���� 59      ShadowStyle .�5:   "   ��  � ��
 �����6G   5;      5<      .R�5=      �� $ MetroButtonBorder��6!   $	 2,2q�6<   $��1q�6J   
�������$ 0��5>   %   #��z��66   ._�5?      � .+�5@   "   �� $! MetroButtonContentPresenter��63   $��Center=�6X   $��Center=�6u   $
��Auto��5A   7   $
��Auto��6D   $��	10,0,10,5q�6R   8��  z�5B   &   T� 5C   *   $	 1.0Q�6=   $	 1.0Q�6E   5E   #   5F      5G       5J      P� 5K      	 � ��
 . . �5L   "   �� $ MetroButtonBorder��6*    � ��
 �   �6_   5M      P� 5O      	 �@J�IsMouseOver
 . . �5P   "   ��  �@J�Effect 5Q   &     5R   *   $ 0Q�6;   $ 10Q�6K   $ Tomato��6[   5T   #   �� 5U   "    �@�Cursor$
 Hand��6;   5V      P� 5W      	 � {�
 .  . �5X   "   ��  �@J�Opacity$	 0.2Q�6<   �� 5Y   "    � ��
 �����6?   5Z      5\      5^      5_      �� 5c   
   " ��6+   .�5d      ��  �@J�SnapsToDevicePixels . 64   �� 5e       �@�OverridesDefaultStyle . 66   �� 5f       �@�FocusVisualStyle# � 
 61   �� 5g       � ��$ 5,5,5,5q�6'   �� 5h       � ��$ Center=�62   6C   �� 5i       � �� 5j      �� 5k      " ��6&   .R�5l      �� 
 ����  5m      �� 5n   "   $ MetroCheckBoxBorder��6)   $��25��6F   $��25��6Q   $ 0��5o   )   $��3q�6:   ��5p   &   �� 5q   *   $ DarkRed��6:   ��5s   &   �� 5t   *   $	 0,0&�6>   $	 0,1&�6O   ��5v   2   � � 5w   6   $ White��6C   � 5x   6   $ 	LightGray��6C   $	 4.0Q�6U   5y   3   5{   +   ._�5}   &   F� $ 	CheckMark��6W   $y�	Collapsed=�6+   $��7��6B   $��7��6L    .  $��2��5~   G   +����    @B �@B ��j �    ��j � z     	��5   *   �� 5�   .   $ Black��6>   5�   '   5�   #    5�        5�   "   CommonStates��. 5�   &     
Normal��62     5�   &   	MouseOver��.  5�   *   �� .��5�   .   T� $! (Border.Effect)�6L   $" MetroCheckBoxBorder��5�   2   ..�5�   2   i� $# 0��6I   8$   6U   5�   /   5�   +   5�   '   5�   #     5�   "   CheckStates��. 5�   &     Checked��.  5�   *   �� .��5�   .   T� $! (UIElement.Visibility)�6L   $" 	CheckMark��5�   2   ..�5�   2   i� $# 0��6I   #$ Z% 6U   5�   /   �� 5�   .   $" MetroCheckBoxBorder��6=   $"! (Border.BorderBrush).(Color)�6i   $& GreenX�5�   =   $' 00:00:01D�6H   5�   +   5�   '     5�   &   	Unchecked��62   5�   #   ._�5�      �� $��4,0,0,0q�6/   $��Center=�5�      $
��Left=�5�      ��. 5�      5�      5�      5�      �� 5�       � ��$ 14(�6)   �� 5�       � ��$ Segoe)�6+   5�      5�      5�      