   M S B A M L   `   `   `  ����D  @TicTacToe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TicTacToe	TicTacToe  5   	       TicTacToe.MenuWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:TicTacToe     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	        � Title$  Tic Tac Toe��5   	   $��407.1��6   $��661.2��6,   .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   .+�5   
   � .+�5      �� $��Black"�5      $	��290��5      $��80��5      $��200,-120,-50, 30q�5      
����+�� $   MaterialDesignHeadline3TextBlock#��[  5      �� 6H   $�	TicTacToe��6L   5      �� 5   
   -   5          MaterialDesignRaisedButton#��[ 5       $��55��5!      $	��150��5"      $��-350, -150, 0, 0q�5#      $��22(�5%      $
��Bold"�5&      
����ح�
����h{�
����h{�$��6,6,8,8q�5*      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 	0,20,20,0��5+      .��5-      �� $��1 VS 1��5.      5/      �� 51   
   -   5        #��[ 52      $��55��53      $	��150��54      $��-350, 30, 0, 20q�55      $��22(�57      $
��Bold"�58      
����ح�
����h{�
����h{�$��6,6,8,8q�5<      $ 	0,20,20,0��5=      .��5?      �� $��	1 VS Com.��5@      5A      �� 5E   
   -   5        #��[ 5F      $��55��5G      $	��150��5H      $��-350, 0, 0, -170q�5I      $��22(�5K      $
��Bold"�5L      
����ح�
����h{�
����h{�$��6,6,8,8q�5P      $ 	0,20,20,0��5Q      .��5S      �� $
��EXIT��5T      5U      5Y      5^      5`      