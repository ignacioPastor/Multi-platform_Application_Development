   M S B A M L   `   `   `  ����X  TXceed.Wpf.Toolkit, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit  5   	   F BCapaNegocio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:CapaNegocio;assembly=CapaNegocioCapaNegocio 5   	    	TareasWPF   TareasWPF.InsertarTarea   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   NwpfTool:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit     5   	   @local.clr-namespace:CapaNegocio;assembly=CapaNegocio     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5
   	    � Title$ InsertarTarea��5   	   $	��536��6   $
��1000��6,    � 	Resources 5       �� 
TargetType �� Property �� Value �� CornerRadius � ToolTip �� ElementName	 �� Path
 �� Triggers P� Property P� Value �� RelativeSource��%�  '��       '�� t     �� 5   
   " ��6   .�5      ��  � ��$ 5,0,5,0q�6'   �� 5       � ��$ Right=�64   5      �� 5   
   " ��6   .�5      ��  � ��$ Center=�62   �� 5       � ��$ 0,2,40,2q�6'   �� 5       �@=�ErrorTemplate 5      �� 5      .R�5      ]� ��. .+�5      �� 
���  ��$��right=�66   $��5,0,0,0q�6M   $��20��6^   $��20��6i   $ 10��6u    5   %   �� $ customAdorner��$8	 2AdornedElement.(Validation.Errors)[0].ErrorContent�._�5   "   �� $��!��6,   $��center=�65   $��center=�6P   $
��Bold"�6m   
�������5   #   5      �� 5      $��customAdorner��68   $��Center=�6M   .v�5   "   �� 
���  ��$��1q�6;   5       5!      5"      5$      
 5&      P� 5'       �@=�HasError . . �5(      ��  �@�ToolTip 5)      ��  �� *Self+$)	 #(Validation.Errors)[0].ErrorContent�5+      5-      5/      .��51      � -   5         �Name$ MyGridTareas��51      $	��501��6!   $	��Top=�6.    J� CommandBindings 52   
   )  #System.Windows.Input.CommandBinding  53      -   5           Command$	 New��53      6R   .+�56   
   �� -   5         ��Name$ 	textBlock��56      $
��Left=�6'   $��	54,74,0,0q�6B   $
��Wrap=�6U   $��Nombre Tarea:��6i   $	��Top=�6~   �� 57   
   -   5        $ 
textBlock1��57      $
��Left=�6(   $��
53,108,0,0q�6C   $
��Wrap=�6W   $��Descripción:��6k   $	��Top=�6   �� 58   
   -   5        $ 
textBlock2��58      $
��Left=�6(   $��
54,147,0,0q�6C   $
��Wrap=�6W   $��Fecha Alta:��6k   $	��Top=�6~   �� 59   
   -   5        $ 
textBlock3��59      $
��Left=�6(   $��
54,181,0,0q�6C   $
��Wrap=�6W   $��
Duración:��6k   $	��Top=�6|   �� 5:   
   -   5        $ 
textBlock4��5:      $
��Left=�6(   $��	23,32,0,0q�6C   $
��Wrap=�6V   $��Datos Tarea��6j   $	��Top=�6}    J� RenderTransformOrigin$ 0.246,0.338&�6�   �� 5;   
   -	   5        $ 
textBlock5��5;      $
��Left=�6(   $��283,181,0,0q�6C   $
��Wrap=�6X   $��(min)��6l   $	��Top=�6y   �� 5<   
   -
   5        $ 
textBlock6��5<      $
��Left=�6(   $��
357,74,0,0q�6C   $
��Wrap=�6W   $��Tipo Tarea:��6k   $	��Top=�6~   �� 5=   
   -   5        $ 
textBlock7��5=      $
��Left=�6(   $��357,107,0,0q�6C   $
��Wrap=�6X   $��Urgente:��6l   $	��Top=�6|   �� 5>   
   -   5        $ 
textBlock8��5>      $
��Left=�6(   $��357,147,0,0q�6C   $
��Wrap=�6X   $��Duración real:��6l   $	��Top=�6�   �� 5?   
   -   5        $ 
textBlock9��5?      $
��Left=�6(   $��357,180,0,0q�6C   $
��Wrap=�6X   $��
Terminada:��6l   $	��Top=�6~   �� 5@   
   -   5        $ textBlock10��5@      $
��Left=�6)   $��532,145,0,0q�6D   $
��Wrap=�6Y   $��(min)��6m   $	��Top=�6z   �� 5A   
   -   5        $ textBlock11��5A      $
��Left=�6)   $��
627,74,0,0q�6D   $
��Wrap=�6X   $��Aviso:��6l   $	��Top=�6z   �� 5B   
   -   5        $ textBlock12��5B      $
��Left=�6)   $��627,108,0,0q�6D   $
��Wrap=�6Y   $��Cuando Avisar:��6m   $	��Top=�6�   �� 5C   
   -   5        $ textBlock13��5C      $
��Left=�6)   $��627,147,0,0q�6D   $
��Wrap=�6Y   $��Comentarios:��6m   $	��Top=�6�   �� 5F   
   -   5         ��Name$ tbNombreTarea��5F      $
��Left=�6)   $��23��6D   $��
158,73,0,0q�6P    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��152��6�   .��5G   1   ��5H   
   �� 5I      $	 Nombre�6    �� Mode$ TwoWay=�6$    �� ValidatesOnDataErrors .  �� NotifyOnValidationError .  �� UpdateSourceTrigger$ 	LostFocus=�6n    �� ValidationRules 5J      #  CapaNegocio.NotNullValidation  5K      +  %CapaNegocio.StringValidation_Length60  5L      5N      .��5O      5P      �� 5Q   
   -   5        $ tbDescripcion��5Q      $
��Left=�6)   $��23��6D   $��158,107,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��152��6�   .��5R   1   ��5S      �� 5T      $	 Descripcion�6   $ TwoWay=�6-    .  . $ 	LostFocus=�6w    5U      ,  &CapaNegocio.StringValidation_Length255  5V      5X      .��5Y      5Z      &    Xceed.Wpf.Toolkit.DateTimePicker  5[   
   -   5          Name$ dpFechaAlta��5[   !   $
��Left=�66   $��158,143,0,0q�6Q   $	��Top=�6f   $	��152��6~   &    Xceed.Wpf.Toolkit.DateTimeUpDown   Format$ Custom=�6�      FormatString$ dd/MM/yyyy hh:mm��6�   �   �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 5]      �� 5^      $	 	FechaAlta�6   $ TwoWay=�6+    .  . $ 	LostFocus=�6u    5_         CapaNegocio.DateValidation  5`      5b      5d      �� 5e   
   -   5        $ 
tbDuracion��5e      $
��Left=�6&   $��23��6A   $��158,180,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $	��120��6�   .��5f   1   ��5g      �� 5h      $	 DuracionEstimada�6   $ TwoWay=�62    .  . $ 	LostFocus=�6|    5i        5j      #	  CapaNegocio.IntegerValidation	  5k      5m      .��5n      5o      �� 5q   
   -   5         ��Name$ cbTipoTarea��5q      $
��Left=�6(   $��
458,74,0,0q�6C   $	��Top=�6W   $	��110��6o    �� SelectedValue 5s      �� 5t      $
	 Tipo�6   $ TwoWay=�6&    .  . $ 	LostFocus=�6p    5u      $
  CapaNegocio.ComboBoxValidation
  5v      5x      5z      �� 5{      -   5        $ tbDuracionReal��5{      $
��Left=�6.   $��23��6I   $��458,143,0,0q�6U   $
 Wrap=�6j   $	��Top=�6~   $��63��6�   .��5|   1   ��5}      �� 5~      $	 DuracionReal�6   $ TwoWay=�6.    .  . $ 	LostFocus=�6x    5      '  !CapaNegocio.IntegerNullValidation  5�      5�      .��5�      5�      �� 5�   
   -   5          ��Name$  
chbUrgente��5�      $	��Sí��6W   $
��Left=�6d   $��458,108,0,0q�6�   $	��Top=�6�   ! d� 	IsChecked! 6'   �� $	 Urgente�$ TwoWay=�6�   �� 5�   
   -   5        $  chbTerminada��5�      $	��Sí��6\   $
��Left=�6i   $��458,181,0,0q�6�   $	��Top=�6�   ! 6)   �� $	 	Terminada�$ TwoWay=�6�   �� 5�   
   -   5        $  chbAviso��5�      $	��Sí��6j   $
��Left=�6w   $��
735,74,0,0q�6�   $	��Top=�6�   $ 0.647,0.861&�6�   ! 6<   �� $	 Aviso�$ TwoWay=�6�     5�   
   -   5        $ dpCUandoAvisar��5�   !   $
��Left=�69   $��735,104,0,0q�6T   $	��Top=�6i   $	��160��6�   $ Custom=�6�   $ dd/MM/yyyy hh:mm��6�    5�      �� 5�      $	 CuandoAvisar�6   $ TwoWay=�6.    .  . $ 	LostFocus=�6x   5�      �� 5�   
   -   5        $ tbComentarios��5�      $
��Left=�6)   $��71��6D   $��735,144,0,0q�6P   $
 Wrap=�6e   $	��Top=�6z   $	��218��6�   .��5�   1   ��5�      �� 5�      $	 Comentarios�6   $ TwoWay=�6-    .  . $ 	LostFocus=�6w    5�        5�      5�      .��5�      5�      �� 5�   
   -   5        $ tbNombreUsuario��5�      $
��Left=�6-   $��168,295,0,0q�6H   $
��Wrap=�6]   $	��Top=�6q   ��5�      �� 5�      $	 MyUsuario.Nombre�6   $ TwoWay=�62    .  . $ PropertyChanged=�6|    5�      5�      5�      �� 5�   
   -   5        $ tbApellidosUsuario��5�      $
��Left=�60   $��168,325,0,0q�6K   $
��Wrap=�6`   $	��Top=�6�   ��6t   �� $	 MyUsuario.Apellidos�$ TwoWay=�6�   �� 5�   
   -   5        $ tbIdUsuario��5�      $
��Left=�6)   $��413,292,0,0q�6D   $
��Wrap=�6Y   $	��Top=�6�   ��6m   �� $	 MyUsuario.IdUsuario�$ OneWay=�6�   �� 5�   
   -    5        $ tbDepartamento��5�      $
��Left=�6,   $��413,325,0,0q�6G   $
��Wrap=�6\   $	��Top=�6�   ��6p   �� $	 MyUsuario.Departamento�$ TwoWay=�6�   �� 5�   
   -!   5        $ tbDatosUsuario��5�      $
��Left=�6,   $��
23,259,0,0q�6G   $
��Wrap=�6[   $��Datos Usuario��6o   $	��Top=�6�   �� 5�   
   -"   5        $ textBlock15��5�      $
��Left=�6)   $��
53,292,0,0q�6D   $
��Wrap=�6X   $��Nombre Usuario:��6l   $	��Top=�6�   �� 5�   
   -#   5        $ textBlock17��5�      $
��Left=�6)   $��
53,325,0,0q�6D   $
��Wrap=�6X   $��Apellidos Usuario:��6l   $	��Top=�6�   �� 5�   
   -$   5        " ��Name$" bSeleccionarUsuario��5�      $��Seleccionar Usuario��6P   $
��Left=�6n   $��209,368,0,0q�6�   $	��Top=�6�   $	��116��6�   �� 5�   
   -%   5        $ textBlock16��5�      $
��Left=�6)   $��312,292,0,0q�6D   $
��Wrap=�6Y   $��Id Usuario:��6m   $	��Top=�6�   �� 5�   
   -&   5        $ textBlock18��5�      $
��Left=�6)   $��312,325,0,0q�6D   $
��Wrap=�6Y   $��Departamento:��6m   $	��Top=�6�   �� 5�   
   -'   5        # ��Name$# bUsuario��5�      
���   �$��1q�67   $
��Left=�6K   $	��129��6f   $��
10,280,0,0q�6s   $	��Top=�6�   $	��558��6�   �� 5�   
   -(   5        $ tbDatosProyecto��5�      $
��Left=�6-   $��598,259,0,0q�6H   $
��Wrap=�6]   $��Datos Proyecto��6q   $	��Top=�6�   �� 5�   
   -)   5        $ textBlock20��5�      $
��Left=�6)   $��627,292,0,0q�6D   $
��Wrap=�6Y   $��Nombre Proyecto:��6m   $	��Top=�6�   �� 5�   
   -*   5        $ textBlock21��5�      $
��Left=�6)   $��627,328,0,0q�6D   $
��Wrap=�6Y   $��Descripción:��6m   $	��Top=�6�   �� 5�   
   -+   5        $ tbNombreProyecto��5�      $
��Left=�6.   $��735,292,0,0q�6I   $
��Wrap=�6^   $	��Top=�6�   ��6r   �� $	 MyProyecto.Nombre�$ TwoWay=�6�   �� 5�   
   -,   5        $ tbDescripcionProyecto��5�      $
��Left=�63   $��735,328,0,0q�6N   $
��Wrap=�6c   $	��Top=�6�   ��6w   �� $	 MyProyecto.Descripcion�$ TwoWay=�6�   �� 5�   
   --   5        $" bSeleccionarProyecto��5�      $��Seleccionar Proyecto��6R   $
��Left=�6q   $��740,368,0,0q�6�   $	��Top=�6�   $	��123��6�   �� 5�   
   -.   5        $# 	bProyecto��5�      
���   �$��1q�68   $
��Left=�6L   $	��129��6g   $��584,280,0,0q�6t   $	��Top=�6�   $	��388��6�   �� 5�   
   -/   5        $" bEnviar��5�      $��Enviar��6"   $
��Left=�63   $��788,465,0,0q�6N   $	��Top=�6c   $��75��6{   $	��New��6�   �� 5�   
   -0   5        $ tbErrorUsuario��5�      $
��Left=�6,   $��102,253,0,0q�6G   $
��Wrap=�6\   $��!��6p   $	��Top=�6y   �� 5�   
   -1   5        $ tbErrorProyecto��5�      $
��Left=�6-   $��684,253,0,0q�6H   $
��Wrap=�6]   $��!��6q   $	��Top=�6z   �� 5�   
   -2   5        $ tbErrorComboTipo��5�      $
��Left=�6.   $��
573,69,0,0q�6I   $
��Wrap=�6]   $��!��6q   $	��Top=�6z   5�      5�      