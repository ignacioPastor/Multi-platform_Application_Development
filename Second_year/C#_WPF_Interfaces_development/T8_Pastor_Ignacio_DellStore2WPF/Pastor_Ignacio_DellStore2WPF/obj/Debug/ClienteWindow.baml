   M S B A M L   `   `   `  ����W  SPastor_Ignacio_DellStore2WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Pastor_Ignacio_DellStore2WPFPastor_Ignacio_DellStore2WPF  5   	   0    *Pastor_Ignacio_DellStore2WPF.ClienteWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Pastor_Ignacio_DellStore2WPF     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   	    � Title$ ClienteWindow��5	   	   $	��700��6   $
��1163��6,    � 	Resources 5
         MisClientes �� Source 
 style1 �� 
TargetType �� Property �� Value  bordeCustomer��%P  &	        &	      &	 f     �� 5   
    65   �� �� 5   
   " ��6   .�5      ��  � ��
 �  ��6+   5      �� 5   
   " ��6&   .�5      ��  � �� �#2100f26,   �� 5       � ��$ 2q�60   �� 5       �@��CornerRadius$ 3��6-   �� 5       �@��Padding$ 5q�6(   5      5      .��5      � -   5         �Name$ GridCustomer��5       5   
     CustomerTemplate � ColumnDefinitions	 � RowDefinitions
 �� Path��%�  &	       7  �� 5      .R�5      �� 8��  ._�5      �  5      �� 5       $	��100 �6/   �� 5"      $	��150 �6/   �� 5#      $	��100 �6/   �� 5%      $	��100 �6/   �� 5&      $	��100 �6/   �� 5(      $	��100 �6/   �� 5)      $	��100 �6/   �� 5+      $	��130 �6/   �� 5,      $	��110 �6/   �� 5.      $	��100 �6/   	 50      �� 51      �� 52      �� 53      �� 54      .+�57      �� $��0��6$   $��0��64   $��Id Customer:��6A   �� 58      $��1��6$   $��0��64   ��6A   �� $
 
CustomerId��� 5:      $��2��6$   $��0��64   $��Nombre:��6A   �� 5;      $��3��6$   $��0��64   ��6A   �� $
 	FirstName��� 5=      $��4��6$   $��0��64   $��
Apellidos:��6A   �� 5>      $��5��6$   $��0��64   ��6A   �� $
 LastName��� 5@      $��6��6$   $��0��64   $��Nombre usuario:��6A   �� 5A      $��7��6$   $��0��64   ��6A   �� $
 UserName��� 5C      $��8��6$   $��0��64   $��	Password:��6A   �� 5D      $��9��6$   $��0��64   ��6A   �� $
 Password��� 5G      $��0��6$   $��1��64   $��Dirección 1:��6A   �� 5H      $��1��6$   $��1��64   ��6A   �� $
 Address1��� 5J      $��2��6$   $��1��64   $��Dirección 2:��6A   �� 5K      $��3��6$   $��1��64   ��6A   �� $
 Address2��� 5M      $��4��6$   $��1��64   $��Ciudad:��6A   �� 5N      $��5��6$   $��1��64   ��6A   �� $

 City��� 5P      $��6��6$   $��1��64   $��Estado:��6A   �� 5Q      $��7��6$   $��1��64   ��6A   �� $
 State��� 5S      $��8��6$   $��1��64   $
��Zip:��6A   �� 5T      $��9��6$   $��1��64   ��6A   �� $	
 Zip��� 5W      $��0��6$   $��2��64   $��País:��6A   �� 5X      $��1��6$   $��2��64   ��6A   �� $
 Country��� 5Z      $��2��6$   $��2��64   $��Región:��6A   �� 5[      $��3��6$   $��2��64   ��6A   �� $
 Region��� 5]      $��4��6$   $��2��64   $��Income:��6A   �� 5^      $��5��6$   $��2��64   ��6A   �� $
 Income��� 5`      $��6��6$   $��2��64   $��Género:��6A   �� 5a      $��7��6$   $��2��64   ��6A   �� $
 Gender��� 5c      $��8��6$   $��2��64   $��Edad:��6A   �� 5d      $��9��6$   $��2��64   ��6A   �� $	
 Age��� 5g      $��0��6$   $��3��64   $��Email:��6A   �� 5h      $��1��6$   $��3��64   ��6A   �� $
 Email��� 5j      $��2��6$   $��3��64   $��Phone:��6A   �� 5k      $��3��6$   $��3��64   ��6A   �� $
 Phone��� 5m      $��4��6$   $��3��64   $��Tipo Tarjeta:��6A   �� 5n      $��5��6$   $��3��64   ��6A   �� $
 CreditCardType��� 5p      $��6��6$   $��3��64   $��Tarjeta:��6A   �� 5q      $��7��6$   $��3��64   ��6A   �� $
 
CreditCard��� 5s      $��8��6$   $��3��64   $��Caducidad tarjeta:��6A   �� 5t      $��9��6$   $��3��64   ��6A   �� $
 CreditCardExpiration�5v      5w      5x      5y      .+�5�   
   �� -   5         ��Name$ 
MyListview��5�   M   $��10,10,0,156q�5�      
�������$
��Auto��6<   #��[ 5�      ��5�      ��  �� Source# [  5�      �� 5�   
   -   5         ��Name$ 	textBlock��5�      $
��Left=�6'   $��
61,530,0,0q�6B   $
��Wrap=�6V   $��Nombre:��6j   $	��Top=�6y   �� 5�   
   -   5         ��Name$ tbNombre��5�      $
��Left=�6$   $��23��6?   $��129,530,0,0q�6K    �� TextWrapping$
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��155��6�   �� 5�   
   -   5        $ 
textBlock1��5�      $
��Left=�6(   $��322,533,0,0q�6C   $
��Wrap=�6X   $��
Apellidos:��6l   $	��Top=�6~   �� 5�   
   -   5        $ tbApellidos��5�      $
��Left=�6'   $��23��6B   $��395,530,0,0q�6N   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��212��6�   �� 5�   
   -   5        $ 
textBlock2��5�      $
��Left=�6(   $��658,533,0,0q�6C   $
��Wrap=�6X   $��Ciudad:��6l   $	��Top=�6{   �� 5�   
   -	   5        $ tbCiudad��5�      $
��Left=�6$   $��23��6?   $��728,530,0,0q�6K   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��120��6�   �� 5�   
   -
   5         ��Name$ bFiltrar��5�      $��Filtrar��6#   $
��Left=�65   $��290,592,0,0q�6P   $	��Top=�6e   $	��100��6}   $��25��6�   6�   �� 5�   
   -   5        $ bquitarFiltros��5�      $��Quitar Filtros��6)   $
��Left=�6B   $��592,592,0,0q�6]   $	��Top=�6r   $	��100��6�   $��25��6�   6�   �� 5�   
   -   5        $ tbPais��5�      $
��Left=�6"   $��23��6=   $��943,530,0,0q�6I   $
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $	��120��6�   �� 5�   
   -   5        $ 
textBlock3��5�      $
��Left=�6(   $��887,533,0,0q�6C   $
��Wrap=�6X   $��País:��6l   $	��Top=�6y    J� RenderTransformOrigin$ 0.592,5.438&�6�   �� 5�   
   -   5        $ 
bModificar��5�      $��	Modificar��6%   $
��Left=�69   $��943,600,0,0q�6T   $	��Top=�6i   $	��100��6�   $��25��6�   6�   �� 5�   
   $��	0,630,0,0q�6   .@�5�      �� -   5        $ tbStatusInfo��5�      $�� ��6.   $��5,2,2,2q�66   5�      5�      5�      