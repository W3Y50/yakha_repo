   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	       WpfApp.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfApp     5   	     � Title$  
MainWindow��5   	   $	��850��6   $
��1000��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      -   5         ��Name$ Header��5      $��50 �6,   6:   �� 5      -   5        $ 
LifeTicker��5      $	��150 �60   6?   �� 5      -   5        $
 Data��5      $	��550 �6*   69   �� 5      -   5        $ Footer��5      $��80 �6,   6:   .+�5   
   � $��0��6   .+�5      �� -   5         ��Name$ Headline��5       �� TextAlignment$ Center=�5      $��19(�5      $
��Bold"�5      $��10q�5      $��Seismic Activity Monitor��5      5      � 5   
   $��1��6   .+�5      �� -   5        $ Alerts��5      $ Center=�5      $��16(�5      $��20q�6&   $��Alerts��5      $
��Bold"�5      �� 5      $��Highest Magnitude:��5      $��14(�5       $��20,65,840,51q�5!      �� 5#      -   5        $ TBX_HighestMagnitude��5#      $��180,75,20,51q�5$      $��14(�5%      $��Highest��5&      �� 5'      -   5        $ TBX_LowestMagnitude��5'      $��180,104,76,20q�5(      $��14(�5)      $��Lowest��5*      �� 5-      $��Lowest Magnitude:��5.      $��14(�5/      $��20,100,840,16q�50      �� 52      -	   5        $��	derButton��52      $��Button��6&   $
��Left=�67   $��
807,75,0,0q�6R   $	��Top=�6f   6~   54      � 55   
   $��2��6   .+�56      �� -
   5        $ EventListHeader��56      $ center=�57      $��16(�58       �� Padding$ 10q�6&   $
��Bold"�59      $��Seismic Events��5:      �� 5;      $
��Auto=�6   $
��auto=�6@   .��5<      �� -   5         ��Name$ SeismicEventListView��5<      $��35q�6_   ��69   �� *SeismicEvents+ �� View 5=      �� 5>      .P�5?      �� -   5        Time��$
��Time��5?   ;    �� Width$
 auto��6I   	 �� DisplayMemberBinding	 6V   �� *Time+�� 5@      -   5        
Region��$��Region��5@   =   $
 auto��6M   	 6Z   �� *Flynn_region+�� 5A      -   5        Latitude��$��Latitude��5A   ?   $
 auto��6Q   	 6^   �� *Lat+�� 5B      -   5        	Longitude��$��	Longitude��5B   @   $
 auto��6S   	 6`   �� *Lon+�� 5C      -   5        	Depth��$��Depth��5C   <   $
 auto��6K   	 6X   �� *Depth+�� 5D      -   5        	Magnitude��$��	Magnitude��5D   @   $
 auto��6S   	 6`   �� *Mag+5E      5G      5H      5I      � 5K   
   $��3��6   .+�5M      �� -   5        
 ��Name$
 BtnStartRecording��5M   ^   $��Start Recording��6   $��40��6/   $	��200��6;   $��268,15,532,25q�6G   6^   �� 5N      -   5        $
 BtnStopRecording��5N   ]   $��Stop Recording��6   $��40��6.   $	��200��6:   $��487,15,313,25q�6F   6]   5O      5Q      5R      