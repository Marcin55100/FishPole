   M S B A M L   `   `   `  ����C  ?Fishpole, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:FishpoleFishpole  5   	       Fishpole.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Fishpole     5   	     � Title$  FishPole��5   	   $	��350��6   $	��525��6'   ���	#FF70CBC7.��5
      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� -   5        $��addStack��5       � DataContext$ 
MainWindow��6%   $��0��6>   $y�Visible=�6N   .+�5      �� $
 Fish��6   .+�5      �� -   5        $��	wordLabel��5      $��Dodaj Słówko��6%   $
��Left=�6<   $	��Top=�6W   �� 5      -   5        $��wordBox��5      $��0,10,5,0q�6;   ���	#FF70CBC7$
��Left=�6d   $	��100��6   ��6%   �� *Word+6   5      �� 5      $
 Fish��6   .+�5      �� -   5        $��translatedLabel��5      $��Tłumaczenie��6+   $
��Left=�6A   �� 5      -   5        $��translatedBox��5      $��0,10,5,0q�6K   ���	#FF70CBC7$
��Left=�6t   $	��100��6�   ��6/   �� *
Translated+6�   5      �� 5       �� Orientation$ 
Horizontal=�6   .+�5      �� -   5        $��	addButton��5      $��Dodaj��6*   $��50��6:   $��0,10,5,0q�6E   $
��Left=�6W   6r   �� 5      -   5        $��removeButton��5      $��Usuń��6-   $��50��6<   $��0,10,5,0q�6G   6Y   5      �� 5      -   5        $��
loadButton��5      $��0,20,0,0q�6'   $��Wczytaj plik��69   $��Center=�6P   6m   �� 5      -	   5        $��startButton��5      $��Start��6(   $	��120��68   $��35��6D   $��0,45,5,0q�6P   $��Center=�6b   6   5       �� 5#   
   -
   5        $��listView��5#      $��1��6#   ���	#FF70CBC7 �� View 5$      �� 5%      .P�5&      �� $��Słówko��6%    �� DisplayMemberBinding 65   �� *Word+�� 5'      $��Tłumaczenie��6%    6:   �� *
Translated+�� 5(      $��Id��6%    61   �� *Id+5)      5,      5.      5/      