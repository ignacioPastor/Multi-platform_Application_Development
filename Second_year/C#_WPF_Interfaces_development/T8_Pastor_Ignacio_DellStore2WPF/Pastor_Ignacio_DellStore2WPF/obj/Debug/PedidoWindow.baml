   M S B A M L   `   `   `  ����W  SPastor_Ignacio_DellStore2WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Pastor_Ignacio_DellStore2WPFPastor_Ignacio_DellStore2WPF  5   	   /    )Pastor_Ignacio_DellStore2WPF.PedidoWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Pastor_Ignacio_DellStore2WPF     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ PedidoWindow��5
   	   $	��600��6   $	��550��6+    � 	Resources 5         
MisPedidos �� Source 
 style1 �� 
TargetType �� Property �� Value  bordeProduct��%P  &	        &	      &	 f     �� 5   
    64   �� �� 5   
   " ��6   .�5      ��  � ��
 �  ��6+   5      �� 5   
   " ��6%   .�5      ��  � �� �#2100f26,   �� 5       � ��$ 2q�60   �� 5       �@��CornerRadius$ 3��6-   �� 5       �@��Padding$ 5q�6(   5      5      .��5      � -   5         �Name$ 
GridPedido��5       5   
     ProductTemplate � ColumnDefinitions	 � RowDefinitions
 �� Path��%+  &	       7  �� 5      .R�5      �� 8��  ._�5      �  5       �� 5!      $	��100 �6/   �� 5"      $	��140 �6/   �� 5#      $	��110 �6/   �� 5$      $	��130 �6/   	 5&      �� 5'      �� 5(      .+�5+      �� $��0��6$   $��0��64   $��Id Cliente:��6A   �� 5-      $��1��6$   $��0��64   ��6A   �� $
 
CustomerId��� 5/      $��0��6$   $��1��64   $��Total Factura:��6A   �� 51      $��1��6$   $��1��64   ��6A   �� $
 TotalAmount��� 53      $��2��6$   $��0��64   $��Numero Factura:��6A   �� 55      $��3��6$   $��0��64   ��6A   �� $
 OrderId��� 57      $��2��6$   $��1��64   $��Fecha Factura: ��6A   �� 59      $��3��6$   $��1��64   ��6A   �� $
 	OrderDate�5;      5<      5=      5>      .+�5?   
   �� -   5         ��Name$ 
MyListview��5@   L   $��10,10,0,135q�5?      
�������$
��Auto��6<   #��[ 5A      ��5@      ��  �� Source# [  5B      �� 5C   
   -   5         ��Name$ 	textBlock��5C      $
��Left=�6'   $��
97,458,0,0q�6B   $
��Wrap=�6V   $��Id Cliente:��6j   $	��Top=�6}   �� 5D   
   -   5         ��Name$ tbNombre��5D      $
��Left=�6$   $��23��6?   $��153,457,0,0q�6K    �� TextWrapping$
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��120��6�   �� 5E   
   -   5        $ 
textBlock1��5E      $
��Left=�6(   $��305,461,0,0q�6C   $
��Wrap=�6X   $��Nº Factura:��6l   $	��Top=�6   �� 5F   
   -   5        $ 	tbFactura��5F      $
��Left=�6%   $��23��6@   $��372,458,0,0q�6L   $
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $��78��6�   �� 5G   
   -   5         ��Name$ bFiltrar��5G      $��Filtrar��6#   $
��Left=�65   $��
76,504,0,0q�6P   $	��Top=�6d   $��75��6|   6�   �� 5H   
   -	   5        $ bQuitarFiltros��5H      $��Quitar Filtros��6)   $
��Left=�6B   $��206,504,0,0q�6]   $	��Top=�6r   $��83��6�   6�   �� 5I   
   -
   5        $ 
bModificar��5I      $��	Modificar��6%   $
��Left=�69   $��397,504,0,0q�6T   $	��Top=�6i   $��75��6�   6�   �� 5K   
   $��	0,536,0,0q�6   .@�5L      �� -   5        $ tbStatusInfo��5L      $�� ��6.   $��5,2,2,2q�66   5M      5N      5O      