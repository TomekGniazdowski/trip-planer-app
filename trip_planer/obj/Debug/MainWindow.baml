   M S B A M L   `   `   `  ����F  Btrip_planer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:trip_planertrip_planer  5   	   &     trip_planer.DispatcherTimersetup   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:trip_planer     5   	     � Title$  Trip planner��5   	   $	��697��6   $
��1064��6+    � 
ResizeMode$ CanMinimize=�68   .��5	      � ���	#FF1D1F1D$��0,0,0,-6q�6"    J� RenderTransformOrigin$ 0.5,0.5&�64   z�5
   
   V� 5      .~�5      �� �� 5      �� 5       �� Angle$ 0Q�6"   T� 5      5       � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $	��226 �6   �� 5      $	��227 �6   �� 5      $��* �6   �� 5      $��20 �6    � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $��20 �6   �� 5      $
��325* �6   �� 5      $	��18* �6   �� 5      $
��333* �6   �� 5       $��20 �6   .+�5"   
   �� $��1q�6   
�������$��3��69   $��2��6I   $��5,5,1.667,4.667q�6V   �� 5#   
   $��Center=�6   $	��628��61   
�������$��Center=�6M   $	��328��6h   ���	#FF131513$��1��6�   $��4��6�    J� OpacityMask
 �����$��0,19,0,8.333q�6�   �� 5%   
   -   5        $��Browse��5%      $
��Left=�6:   $��14,110.667,0,0q�6U   $	��Top=�6m   $��52��6�   $	��116��6�   $��Microsoft New Tai Lue)�6�   $��17(�6�   ���	#FF95AF80���	#FF1D1F1D$��1��6�   $��3��6  �� 5&   
   -   5        $��	Favourite��5&      $��Right=�6A   $��0,110.667,14,0q�6]   $	��Top=�6u   $��52��6�   $	��118��6�   $��Microsoft New Tai Lue)�6�   $��17(�6�   ���	#FF95AF80���	#FF1D1F1D$y�Visible=�6  $��1��6  $��3��6)  �� 5'   
   -   5         ��Name$ 
start_city��5'      $��Center=�6&   $��beginning of the trip��6C    �� TextWrapping$
 Wrap=�6`   $��Center=�6t   $	��300��6�   $��45��6�   $��Microsoft New Tai Lue)�6�   $��20(�6�   
�������$��1��6  $��1��6  $��14,90,14,91q�6@  ��6�   Z� 6@  �� 5(   
   -   5        $ 	stop_city��5(      $��Center=�6%   $��destination of the trip��6B   $
 Wrap=�6a   $��Center=�6u   $	��300��6�   $��44��6�   $��Microsoft New Tai Lue)�6�   $��20(�6�   
�������$��1��6  $��1��6  $��14,136,14,46q�6  ��6�   Z� 6  (  "System.Windows.Controls.DatePicker  5)   
   -   5        	  Name$
	 data��5)      $��Center=�6#   $��Center=�6@   $��45��6[   $	��300��6g   $��20(�6s   $��Microsoft New Tai Lue)�6�   
���   ����	#FF95AF80$��1��6�   $��1��6�   $��14,181,14,0q�6�   ��5*      �� 5+      
 �� EndPoint$
 0.5,0&�6&    �� 
StartPoint$ 0.5,1&�67   .��5,      �  � Color$ 	#FFA3AEB9��6#   � 5-      $ 	#FF8399A9��6#    � Offset$ 0.375Q�65   � 5.      $ 	#FF718597��6#   $ 0.375Q�65   � 5/      $ White��6#   $ 1Q�61   50      52      �� 53   
   -   5         ��Name$ Obraz_pokaz_slajdow��53      $��Center=�6-   $	��156��6J   $��Center=�6W   $	��300��6r   $��/img_window_1/1.jpg��6~   $
��Fill=�6�   $��1��6�   $��2��6�   $��14,35,14,36.333q�6�   �� 54   
   $��Center=�6   $
��Wrap=�61   $	��Top=�6E   $��47��6]   $	��300��6i   $��Microsoft New Tai Lue)�6u   $��41(�6�   ���	#FF95AF80$��1��6�   $��
14,23,14,0q�6�   $��1��6�   �� 6�    � Language$ pl-pl�6�   $�TRIP PLANNER��6  6  �� 55   
   $��3��6   $
��Left=�6$   $��90��6?   $��1��6K   
�������$��Center=�6g   $	��671��6�   ���	#FF131513$��4��6�   $��	0,0,0,136q�6�   �� 56   
   -   5         ��Name$ 
start_opis��56      $
��Left=�6(   $
��Wrap=�6C   $	��Top=�6W   $��27��6o   $	��646��6{   $��Microsoft New Tai Lue)�6�   $��20(�6�   ���	#FF95AF80$��3��6�   $��1��6�   $��3��6�   $��15,0,0,0q�6   �� 6  $ pl-pl�6  $�beginning of the trip: ��6(  6J  �� 57   
   -   5        $ 	stop_opis��57      $
��Left=�6'   $
��Wrap=�6B   $	��Top=�6V   $��27��6n   $	��646��6z   $��Microsoft New Tai Lue)�6�   $��20(�6�   ���	#FF95AF80$��3��6�   $��	15,27,0,0q�6�   $��1��6�   $��3��6�   �� 6  $ pl-pl�6  $�destination of the trip: ��6(  6L  �� 58   
   -	   5        $ 	data_opis��58      $
��Left=�6'   $
��Wrap=�6B   $	��Top=�6V   $��27��6n   $	��646��6z   $��Microsoft New Tai Lue)�6�   $��20(�6�   ���	#FF95AF80$��3��6�   $��	15,54,0,0q�6�   $��1��6�   $��3��6�   �� 6  $ pl-pl�6  $�date of the trip: ��6(  6E  �� 5:   
   -
   5        $��listBoxpogoda��5:      $��3��6'   $��2��67   ���	#FF131513���	#FF131513$��Microsoft New Tai Lue)�6s   $��20(�6�   
�������$
��Auto=�5;      $
��Auto=�5<      $��10,5,9.667,11.667q�6B   �� 5=   
   -   5        $ Obraz_pogoda1��5=      $
��Left=�6'   $	��128��6B   $	��Top=�6O   $	��128��6g   $��/icons/unknown.png��6s   $
��Fill=�6�   $��3��6�   $��1��6�   $��0,94,0,0q�6�   �� 5>   
   -   5        $ Obraz_pogoda2��5>      $
��Left=�6'   $	��128��6B   $	��Top=�6O   $	��128��6g   $��/icons/unknown.png��6s   $
��Fill=�6�   $��3��6�   $��1��6�   $��172,94,25,0q�6�   �� 5?   
   -   5        $ Obraz_pogoda3��5?      $
��Left=�6'   $	��128��6B   $	��Top=�6O   $	��128��6g   $��/icons/unknown.png��6s   $
��Fill=�6�   $��5��6�   $��1��6�   $��0,94,0,0q�6�   �� 5@   
   -   5        $��listBoxhotele��5@      $��5��6'   $��2��67   ���	#FF131513���	#FF131513$��Microsoft New Tai Lue)�6s   $��20(�6�   
�������$
��Auto=�5A      $
��Auto=�5B      $��2��6B   $��0.333,5,19.667,4.667q�6V   �� 5F   
   $��1q�6   
�������$��5��69   $��2��6I   $��5.333,5,4.667,4.667q�6V   &   System.Windows.Controls.DataGrid  5G   
   -   5          Name$ grid_ulubione��5G   #   $��3��6   $
��Left=�6:   $��95��6U   $��3��6a   $	��Top=�6n   $	��316��6�   ���	#FF1D1F1D$��3,32.333,0,0q�6�   ���	#FF95AF80
�������
 �   �   HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����   RowBackground �	#FF131513   HeadersVisibility$ Column=�6�    5H   
   -   5        $ grid_ostatnie��5H   #   $��5��6   $
��Left=�6:   $��95��6U   $��5.333,32.333,0,0q�6a   $��3��6{   $	��Top=�6�   $	��322��6�   ���	#FF1D1F1D
����������	#FF95AF80 �	#FF131513$ Column=�6  
 �����
 �����6D  �� 5I   
   -   5        $��Delete��5I      $
��Left=�68   $��1,140.333,0,0q�6S   $	��Top=�6j   $��32��6�   $��73��6�   $��Microsoft New Tai Lue)�6�   $��17(�6�   ���	#FF95AF80���	#FF1D1F1D$��3��6�   $��3��6  $ 0.893,-0.214&�6  �� 5J   
   -   5        $��Browse��5J      $��Right=�6<   $��0,140.333,1.667,0q�6X   $	��Top=�6s   $��32��6�   $��73��6�   $��Microsoft New Tai Lue)�6�   $��17(�6�   ���	#FF95AF80���	#FF1D1F1D$��3��6  $��3��6  $ 0.514,1.328&�6  �� 5K   
   -   5        $��Delete��5K      $
��Left=�68   $��1.333,140.333,0,0q�6S   $	��Top=�6n   $��32��6�   $��73��6�   $��Microsoft New Tai Lue)�6�   $��17(�6�   ���	#FF95AF80���	#FF1D1F1D$��5��6�   $��3��6  $ 2.148,0.599&�6  �� 5L   
   -   5        $��Browse��5L      $��Right=�6<   $��0,140.333,1.667,0q�6X   $	��Top=�6s   $��32��6�   $��73��6�   $��Microsoft New Tai Lue)�6�   $��17(�6�   ���	#FF95AF80���	#FF1D1F1D$��5��6  $��3��6  $ 0.363,-1.224&�6  �� 5M   
   -   5        $ start_opis_Copy��5M      $
��Left=�6-   $
��Wrap=�6H   $	��Top=�6\   $��27��6t   $	��133��6�   $��Microsoft New Tai Lue)�6�   $��17(�6�   ���	#FF95AF80$��3��6�   $��3��6�   $��6,3.333,0,0q�6�   $��
favourite:��6  �� 5N   
   -   5        $ start_opis_Copy1��5N      $
��Left=�6.   $
��Wrap=�6I   $	��Top=�6]   $��27��6u   $	��133��6�   $��Microsoft New Tai Lue)�6�   $��17(�6�   ���	#FF95AF80$��5��6�   $��3��6�   $��6.333,5.333,0,0q�6�   $��last:��6  �� 5O   
   -   5         ��Name$ Wykres��5O      $��5��6!   $��127.333,100,11.667,14q�61   $��1��6P   $ 0.5,0.5&�6]   z�5P      V� 5Q      .~�5R      �� �� 5S      �� 5T      $	 180Q�6&   T� 5U      5V      .+�5X      �� -   5         ��Name$ Dzien_1��5X      $��45��6)   $��0��64   ���	#FF95AF80 �� Left$	 142��6P   
 �� Top$ 5��6b   �� 5Y      -   5        $ Dzien_2��5Y      $��45��6)   $��0��64   ���	#FF95AF80$ 77��6P   $ 5��6a   �� 5Z      -   5        $ Dzien_3��5Z      $��45��6)   $��0��64   ���	#FF95AF80$ 12��6P   $ 5��6a   5[      �� 5\   
   -   5        $ Temp_Dzien_1��5\      $��5��6*   $
��Left=�6:   $��18��6U   $��130.333,208,0,0q�6a   $��1��6z   $
��Wrap=�6�   $	��Top=�6�   $��49��6�   $��Microsoft New Tai Lue)�6�   
���������6�   Z� 6�   �� 5]   
   -   5        $ Temp_Dzien_2��5]      $��5��6*   $
��Left=�6:   $��17��6U   $��194.333,209,0,0q�6a   $��1��6z   $
��Wrap=�6�   $	��Top=�6�   $��49��6�   $��Microsoft New Tai Lue)�6�   
���������6�   Z� 6�   �� 5^   
   -   5        $ Temp_Dzien_3��5^      $��5��6*   $
��Left=�6:   $��17��6U   $��260.333,209,0,0q�6a   $��1��6z   $
��Wrap=�6�   $	��Top=�6�   $��49��6�   $��Microsoft New Tai Lue)�6�   
���������6�   Z� 6�   5_      5`      