   M S B A M L   `   `   `  ����J  FCapaControlador, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullJ6clr-namespace:CapaControlador;assembly=CapaControladorCapaControlador  5   	     Pastor_Ignacio_DellStore2WPF;   5Pastor_Ignacio_DellStore2WPF.AltaModificacionProducto   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Hlocal6clr-namespace:CapaControlador;assembly=CapaControlador     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ AltaModificacionProducto��5
   	   $	��257��6*   $	��568��67    � 	Resources 5       �� 
TargetType �� Property �� Value �� CornerRadius � ToolTip �� ElementName	 �� Path
 �� Triggers P� Property P� Value �� RelativeSource��%�  '��       '�� t     �� 5   
   " ��6   .�5      ��  � ��$ 5,0,5,0q�6'   �� 5       � ��$ Right=�64   5      �� 5   
   " ��6   .�5      ��  � ��$ Center=�62   �� 5       � ��$ 0,2,40,2q�6'   �� 5       �@=�ErrorTemplate 5      �� 5      .R�5      ]� ��. .+�5      �� 
���  ��$��right=�66   $��5,0,0,0q�6M   $��20��6^   $��20��6i   $ 10��6u    5   %   �� $ customAdorner��$8	 2AdornedElement.(Validation.Errors)[0].ErrorContent�._�5   "   �� $��!��6,   $��center=�65   $��center=�6P   $
��Bold"�6m   
�������5   #   5      �� 5      $��customAdorner��68   $��Center=�6M   .v�5   "   �� 
���  ��$��1q�6;   5      5       5!      5#      
 5%      P� 5&       �@=�HasError . . �5'      ��  �@�ToolTip 5(      ��  �� *Self+$)	 #(Validation.Errors)[0].ErrorContent�5*      5,      5H      .��5R      � -   5         �Name$ myGridProduct��5R       J� CommandBindings 5S   
   )  #System.Windows.Input.CommandBinding  5T      -   5           Command$	 New��5T      6R   .+�5Z   
   �� -   5         ��Name$ tbTitle��5Z      $
��Left=�6#   $��23��6>   $��	96,26,0,0q�6J    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��207��6�   .��5[   1   ��5\      �� 5]      $	 Title�6    �� Mode$ TwoWay=�6'    �� ValidatesOnDataErrors .  �� NotifyOnValidationError .  �� UpdateSourceTrigger$ 	LostFocus=�6q    �� ValidationRules 5^      '   !CapaControlador.NotNullValidation  5_      /   )CapaControlador.StringValidation_Length50  5`      5b      .��5c      5d      �� 5i   
   -   5        $ tbActor��5i      $
��Left=�6#   $��23��6>   $��	96,65,0,0q�6J   $
 Wrap=�6]   $	��Top=�6q   $	��207��6�   .��5j   1   ��5k      �� 5l      $	 Actor�6   $ TwoWay=�6'    .  . $ 	LostFocus=�6q    5m        5n        5o      5q      .��5r      5s      �� 5x   
   -   5        $ tbPrice��5x      $
��Left=�6#   $��23��6>   $��434,106,0,0q�6J   $
 Wrap=�6_   $	��Top=�6s   $��92��6�   .��5y   1   ��5z      �� 5{      $	 Price�6   $ TwoWay=�6'    .  . $ 	LostFocus=�6q    5|        5}      1   +CapaControlador.DecimalValidation_2Decimals  5~      5�      .��5�      5�      �� 5�   
   -   5         ��Name$ tbProdId��5�      $
��Left=�6&   $��23��6A   $��
434,24,0,0q�6M   $
��Wrap=�6a   $	��Top=�6u   $��92��6�   $B <La asignación de este valor se realiza de forma automática��5�   1   ��5�      �� 5�      $	 ProdId�6   $ TwoWay=�6(    .  . $ 	LostFocus=�6r   5�      5�      �� 5�   
   -   5        $ tbCommon��5�      $
��Left=�6$   $��23��6?   $��
434,62,0,0q�6K   $
 Wrap=�6_   $	��Top=�6s   $��92��6�   .��5�   2   ��5�      �� 5�      $	 CommonProdId�6   $ TwoWay=�6.    .  . $ 	LostFocus=�6x    5�        5�      '   !CapaControlador.IntegerValidation  5�      5�      .��5�      5�      �� 5�   
   -	   5        $ 	tbSpecial��5�      $
��Left=�6%   $��23��6@   $��244,106,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $��59��6�   .��5�   1   ��5�      �� 5�      $	 Special�6   $ TwoWay=�6)    .  . $ 	LostFocus=�6s    5�      '   !CapaControlador.SpecialValidation  5�      5�      .��5�      5�      �� 5�   
   -
   5        $ tbCategorias��5�      $
��Left=�6(   $��23��6C   $��
96,106,0,0q�6O   $
 Wrap=�6c   $	��Top=�6w   $��68��6�   .��5�   1   ��5�      �� 5�      $	 Category�6   $ TwoWay=�6*    .  . $ 	LostFocus=�6t    5�        5�        5�      5�      .��5�      5�      �� 5�   
   -   5        $ 	textBlock��5�      $
��Left=�6'   $��	26,26,0,0q�6B   $
��Wrap=�6U   $��Título:��6i   $	��Top=�6x   �� 5�   
   -   5        $ 
textBlock1��5�      $
��Left=�6(   $��	26,66,0,0q�6C   $
��Wrap=�6V   $��Actor:��6j   $	��Top=�6x   �� 5�   
   -   5        $ 
textBlock2��5�      $
��Left=�6(   $��
26,106,0,0q�6C   $
��Wrap=�6W   $��Categoría:��6k   $	��Top=�6}   �� 5�   
   -   5        $ 
textBlock3��5�      $
��Left=�6(   $��322,109,0,0q�6C   $
��Wrap=�6X   $��Precio:��6l   $	��Top=�6{   �� 5�   
   -   5        $ 
textBlock4��5�      $B <La asignación de este valor se realiza de forma automática��6(   $
��Left=�6m   $��
322,25,0,0q�6�   $
��Wrap=�6�   $��Id Producto:��6�   $	��Top=�6�   �� 5�   
   -   5        $ 
textBlock5��5�      $
��Left=�6(   $��
322,65,0,0q�6C   $
��Wrap=�6W   $��Common Prod Id:��6k   $	��Top=�6�   �� 5�   
   -   5        $ 
textBlock6��5�      $
��Left=�6(   $��182,109,0,0q�6C   $
��Wrap=�6X   $��Special:��6l   $	��Top=�6|   �� 5�   
   -   5         ��Name$ 
bFinalizar��5�      $��	Finalizar��6%   $
��Left=�69   $��244,157,0,0q�6T   $	��Top=�6i   $��75��6�   $	��New��6�   �� 5�   
   -   5        $ 
tbInfoAuto��5�      $B <La asignación de este valor se realiza de forma automática��6(   $
��Left=�6m   $��
434,25,0,0q�6�   $
��Wrap=�6�   $�� ��6�   $	��Top=�6�   $��52��6�   $��18��6�   �� 5�   
   $��	0,189,0,0q�6   .@�5�      �� -   5        $ tbStatusInfo��5�      $�� ��6.   $��5,2,2,2q�66   5�      5�      5�      