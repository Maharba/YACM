   M S B A M L   `   `   `  ���� \  XWPFDeveloperTools.Controls, Version=1.0.3936.39669, Culture=neutral, PublicKeyToken=null�\clr-namespace:WPFDeveloperTools.Controls.FilteredTextBox;assembly=WPFDeveloperTools.Controls*WPFDeveloperTools.Controls.FilteredTextBox   MenuPrincipal%   MenuPrincipal.wndAdminPantallas   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     lftx\clr-namespace:WPFDeveloperTools.Controls.FilteredTextBox;assembly=WPFDeveloperTools.Controls     -     � Title$   Administrador de Pantallas��$	��520��$	��760�� � 	Resources  
  Fuente �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect  FondoDegradado �� 
StartPoint �� EndPoint � Color � Offset  ListboxItems �� 
TargetType	 �� 
TargetType
 �� Padding J� SnapsToDevicePixels �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 �     &	      �� .���  �@J�Effect   ��  � ��
 �������  � ��$ 13(���  � ��$ 30����  � ��$	 100����  � ��$ 5q��� .���  � �� �� $	 1,1&�$	 0,0&�.��� $ White��$ 1Q�� $ 	LightGray��$ 0Q��� " ��.���  �@�FocusVisualStyle Z� ��  � �� �� "	 ��.R��� $��Borde��$
 2q� . ._���  P�  �@��
IsSelected . . ��� $ Borde�� � ��
 ��������� $	 1,0&�$	 1,1&�.��� $ #151E19��$ 0Q�� $ #16472A��$	 0.2Q�� $ #165D33��$
 0.85Q�� $ #165D33��$	 0.9Q�� $ #151E19��$ 1Q�.���  � ColumnDefinitions �� ��  � RowDefinitions �� �� .+��� $��5q����� #��[  $��22(�$��80��	Equipos.��� $��5q� �� $
��.25* ��� �� $
��.30* � �� �� .+��� #��[  $
��Left=�$
��Bold"�
Equipo 1�� -   $��
lstEquipo1��#��[ #��[ $��1������ *NombreEquipo+�� #��[  $��1��$
��Left=�$
��Bold"�
Equipo 2�� -   $��
lstEquipo2��#��[ #��[ $��1��$��1������ *NombreEquipo+�� -   $��btnNuevaRonda��$��2��$��2��$��5q�.��Nueva Ronda�� $��1��$��5q����� #��[  $��22(�$��70��Estado.���  �� $��* ��� $
��130* ��� $	��70* ��� $
��113* � �� �� �� �� $
��1.2* �.+��� #��[  $��Bottom=�$��2��$��5,0,1,5q�$��20��$
��Left=�	Nombre:�� -   $��	lbEquipo1��#��[  $
��Left=�$	��130��$��1��$��Center=�$��2��$��5,5,1,5q�
Equipo 1�� -   $��	lbEquipo2��#��[  $
��Left=�$	��130��$��2��$��Center=�$��2��$��5,5,1,5q�
Equipo 2�� #��[  $��20��$��70��$��2��$��Bottom=�Puntuacion:@   :WPFDeveloperTools.Controls.FilteredTextBox.FilteredTextBox  -   $��txtPuntosE1��   Type$ Digits=�#��[ $��2��$��1��$
��0,10q�  -   $��txtPuntosE2��$ Digits=�#��[ $��2��$��2��$
��0,10q�]� $��3��$��3��.+��� #��[  $��3��$��Center=�$��2��$��5,5,1,5q�Pregunta Actual:�� -	   $��lblCantPreg��#��[  $��2��$��70��$��3��$��Center=�$
��Left=�0 de 0�� -
   $��btnDeshacerPuntuacion��$��3��$��5q�$��3��$
��Left=�{�.  .����  �� TextAlignment$ Center=�$
��Wrap=�Deshacer Puntuacion�� -   $��btnModPuntosE1��{�.  $��3��$��10q�$��1��$
��Left=�$��50��.��>>�� -   $��btnModPuntosE2��{�.  $��3��$��10q�$��2��$
��Left=�$��50��.��>>� $��1��$��2�� �� $
��.20* ��� .+��� $��5q����� #��[  $��Presentación��$��17(�.��A�  A� Columns$ 4��.+��� -   $��btnMostrarPantalla��{�.  $
��3, 0q�.��	Mostrar�� -   $��btnOcultarPantalla��{�.  $
��3, 0q�.��	Ocultar�� -   $��btnLimpiarPantalla��$	��3,0q�.��	Limpiar�� -   $��btnMostrarDatosPantalla��$
��3, 0q�.��Mostrar Datos�� $��1��$��5q����� #��[  $��21(�	Preguntas.���� $��5q�.+��� #��[  $
��Left=�$��60��$��20��$��0q�	Pregunta:�� -   $��txtPreguntaPresentador��#��[  �� AcceptsReturn .  �� TextWrapping$
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=�$	��120���� #��[  $
��Left=�$��70��$��20��$��0q�
Respuesta:�� -   $��txtRespuesta��#��[ $��50��$
 Auto=�]� $
��Left=�.+��� $��Center=�#��[  $
��Left=�$��50��$��20��	Puntos:  -   $��txtPuntosPregunta��#��[ $��5q�A� $ 3��.+��� -   $��btnSiguiente��{�.  $
��5,10q�.��	Siguiente�� -   $��btnIniciarTiempo��{�.  $
��5,10q�.��Iniciar Tiempo�� -   $��btnPausarTiempo��{�.  $
��5,10q�.��Pausar TiempoA� $ 3��$��50��.+��� -   $��btnAcertoE1��{�.  $
��25,0q�.���� $
��Wrap=�$ Center=�Acerto EQUIPO 1�� -   $��btnAcertoE2��{�.  $
��25,0q�.���� $
��Wrap=�$ Center=�Acerto EQUIPO 2�� -   $��btnNadieAcerto��{�.  $
��25,0q�.���� $
��Wrap=�$ Center=�NADIE Acerto