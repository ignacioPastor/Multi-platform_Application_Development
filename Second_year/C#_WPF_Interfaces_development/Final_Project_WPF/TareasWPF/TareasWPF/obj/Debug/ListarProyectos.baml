   M S B A M L   `   `   `  ����D  @TareasWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TareasWPF	TareasWPF  5   	       TareasWPF.ListarProyectos   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:TareasWPF     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   	    � Title$ ListarProyectos��5
   	   $��397.5��6!   $	��575��60    � 	Resources 5         MisProyectos �� Source  bordeProduct �� 
TargetType �� Property �� Value��%�   &	        &	      �� 5   
    66   �� �� 5   
   " ��6%   .�5      ��  � �� �#2100f26,   �� 5       � ��$ 2q�60   �� 5       �@��CornerRadius$ 3��6-   �� 5       �@��Padding$ 5q�6(   5      5      .��5      � $	��348��6   $	��Top=�6    5   
     ProductTemplate � ColumnDefinitions � RowDefinitions	 �� Path��%�  &	       7  �� 5      .R�5      �� 8��  ._�5      �  5      �� 5      $	��100 �6/   �� 5      $	��140 �6/   �� 5      $	��110 �6/   �� 5      $	��142 �6/    5      �� 5       �� 5!      .+�5$      �� $��0��6$   $��0��64   $��Id Proyecto:��6A   �� 5%      $��1��6$   $��0��64   ��6A   �� $	 
IdProyecto��� 5'      $��0��6$   $��1��64   $��Descripción:��6A   �� 5(      $��1��6$   $��3��64   $��1��6H   ��6U   �� $	 Descripcion��� 5*      $��2��6$   $��0��64   $��Nombre:��6A   �� 5+      $��3��6$   $��0��64   ��6A   �� $	 Nombre�5-      5.      5/      50      .+�51   
   �� -   5        
 ��Name$
 
MyListview��52   N   $��10,10,10,132q�51      
�������$
��Auto��6=   #��[ 53      ��52      ��  �� Source# [  54      �� 55   
   -   5         ��Name$ tbIdProyecto��55      $��1��6(   $
��Left=�6\   $��23��6w   $��123,253,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 56   
   -   5         ��Name$ 	textBlock��56      $
��Left=�6'   $��
51,254,0,0q�6B   $
��Wrap=�6V   $��Id Proyecto:��6j   $	��Top=�6~   �� 57   
   -   5        $ 
textBlock1��57      $
��Left=�6(   $��281,254,0,0q�6C   $
��Wrap=�6X   $��Nombre:��6l   $	��Top=�6{   �� 58   
   -   5        $ tbNombre��58      $��2��6$   $
��Left=�6T   $��23��6o   $��345,253,0,0q�6{   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 59   
   -   5         ��Name$ bSeleccionar��59      $��3��6'   $��
Sleccionar��6O   $
��Left=�6d   $��426,313,0,0q�6   $	��Top=�6�   $��75��6�   5:      5;      