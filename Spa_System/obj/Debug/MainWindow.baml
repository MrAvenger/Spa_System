   M S B A M L   `   `   `  ����?  ;Сп, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Spa_System
Spa_System  5   	       Spa_System.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Spa_System     5   	   X TXceed.Wpf.Toolkit, Version=3.7.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   -   5          � Title$!  Спа салон "Fortuna"��5	   	   $	��704��6/   $
��1491��6<    � 
ResizeMode$ CanMinimize=�6I    � Icon$ spa.png��6{   .��5
      � -   5         �Name$ Mai1n��5
      .+�5   
   � -   5        $
 Auth��5      $
��Left=�6   $	��338��68   $	��Top=�6E   $	��365��6]   $��0,0,-0.2,-0.4q�6i   $y�Hidden=�6�   .+�5      �� $��
-5,-12,0,0q�6   $��Auth.jpg��6(   $
��Fill=�6:   � 5      $��	0,0,0,405q�6   ���	#FFD0D0D06&   �� 5      -   5        $"��Авторизоваться��5      $
��Left=�6.   $��
28,263,0,0q�6I   $	��Top=�6]   $	��309��6u   $��43��6�   $��16(�6�   6�   �� 5      -   5         ��Name$ Login��5      $
��Left=�6%   $��32��6@   $��
28,127,0,0q�6L    �� TextWrapping$
 Wrap=�6`   $��Login��6t   $	��Top=�6�   $	��309��6�   $��16(�6�   6�   �� 5      -   5        $ Password��5      $��32��6(   $��28,173,28,0q�64   $
 Wrap=�6I   $��Password��6]   $	��Top=�6m   $��16(�6�   6�   5      � 5   
   -   5        $
 Main��5      .+�5      �� -   5         ��Name$ MainTabControl��5      $
��Left=�61   $	��674��6L   $��10,0,0,0q�6Y   $	��Top=�6k   $
��1053��6�   .@�5      �� -	   5         ��Name$ MainTab_One��5      $?��9Данные о пользователях системы��6/   .��5      � ���	#FFE5E5E5.+�5      �� -
   5        $ Users_System_Tab��5   %   $
��Left=�6?   $	��636��6Z   $	��Top=�6g   $
��1037��6   .@�5      �� -   5        $ Users��5   &   $��Пользователи��65   .��5   "   � -   5        $ Пользователи��5   '   ���	#FFE5E5E5 � ColumnDefinitions 5   &   �� 5   *   $
��149* �6;   �� 5   *   $
��882* �6;   .+�5   &   &   System.Windows.Controls.DataGrid  -   5        	  Name$	 	UsersGrid��5   /   $
��Left=�6B   $	��588��6]   $��	10,10,0,0q�6j   $	��Top=�6}   $
��1021��6�   
   
IsReadOnly
 . $��2��6�   6�   5   #   5      �� 5       -   5        $ 
Users_Logs��5    &   $��Логи действий��6:    J� RenderTransformOrigin$ 	0.5,0.509&�6Q   .��5!   "   � -   5        $ Users_Logs_Grid��5!   '   ���	#FFE5E5E5.+�5"   &     -   5        $	 UserLog_Grid��5"   /   $
��Left=�6E   $	��573��6`   $��	10,25,0,0q�6m   $	��Top=�6�   $
��1021��6�   
 . 6�   �� 5#   &   -   5         ��Name$ ComboSearch��5#   /   $
��Left=�6D   $��	157,0,0,0q�6_   $	��Top=�6r   $	��240��6�   $��25��6�   6�   �� 5$   &   $.��(Поиск по пользователю��6,   $
��Left=�6L   $��	10,-1,0,0q�6g   $	��Top=�6z   �� 5%   &   -   5        $&�� Показать все логи��5%   -   $
��Left=�6I   $��
798,-1,0,0q�6d   $	��Top=�6x   $	��233��6�   $��24��6�   6�   5&   #   5'      �� 5(      -   5        $ Users_Roles��5(   &   $)��#Роли пользователей��6;   $��0,0,-4.2,-2.2q�6W   .��5)   "   � -   5        $ Users_Roles_Grid��5)   '   ���	#FFE5E5E5.+�5*   &     -   5        $	 UserRoles_Grid��5*   /   $
��Left=�6G   $	��588��6b   $��	10,10,0,0q�6o   $	��Top=�6�   $
��1021��6�   
 . 6�   5+   #   5,      5-      5.      5/      �� 50      -   5        $ MainTab_Two��50      $,��&Данные о сотрудниках��6/   $��0,0,-3.6,-2.2q�6M   .��51      � ���	#FFE5E5E5.+�52      �� -   5        $ Workers_System_Tab��52   %   $
��Left=�6A   $	��636��6\   $	��Top=�6i   $
��1037��6�   .@�53      �� $��Сотрудники��6&   .��54   "   � -   5        $ Workers_Grid��54   '   ���	#FFE5E5E5.+�55   &     -   5        $	 WorkersGrid��55   /   $
��Left=�6D   $	��588��6_   $��	10,10,0,0q�6l   $	��Top=�6   $
��1021��6�   
 . 6�   56   #   57      �� 58      $��Должности��6&   $��0,0,-3.6,-2.2q�69   .��59   "   � -   5        $ Workers_Functions_Grid��59   '   ���	#FFE5E5E5.+�5:   &     -   5        $	 Workers_FunctionsGrid��5:   /   $
��Left=�6N   $	��588��6i   $��	10,10,0,0q�6v   $	��Top=�6�   $
��1021��6�   
 . 6�   5;   #   5<      �� 5=      $��Графики работ��6&   .��5>   "   � -   5        $ Workers_Graphic_Grid��5>   '   ���	#FFE5E5E5.+�5?   &     -   5        $	 WorkersGraphicGrid��5?   /   $
��Left=�6K   $	��588��6f   $��	10,10,0,0q�6s   $	��Top=�6�   $
��1021��6�   
 . 6�   5@   #   5A      5B      5C      5D      �� 5E      -   5        $ MainTab_Three��5E      $8��2Данные о услугах и клиентах��61   $��0,0,-3.6,-3q�6V   .��5F      � ���	#FFE5E5E5.+�5G      �� -   5        $ Services_system_Tab��5G   %   $
��Left=�6B   $	��636��6]   $	��Top=�6j   $
��1037��6�   .@�5H      �� $��Записи��6&   .��5I   "   � -    5        $ Records_Grids��5I   '   ���	#FFE5E5E5.+�5J   &     -!   5        $	 Records_Grid��5J   /   $
��Left=�6E   $	��598��6`   $��0,10,0,0q�6m   $	��Top=�6   $
��1031��6�   
 . 6�   5K   #   5L      �� 5M      $��Услуги��6&   .��5N   "   � ���	#FFE5E5E5.+�5O   &     -"   5        $	 Services_Grid��5O   /   $
��Left=�6F   $	��588��6a   $��	10,10,0,0q�6n   $	��Top=�6�   $
��1021��6�   
 . 6�   5P   #   5Q      �� 5R      $��Клиенты��6&   $��0,0,-4,-2.2q�67   .��5S   "   � -#   5        $ Clients��5S   '   ���	#FFE5E5E5.+�5T   &     -$   5        $	 Clients_Grid��5T   /   $
��Left=�6E   $	��588��6`   $��	10,10,0,0q�6m   $	��Top=�6�   $
��1021��6�   
 . 6�   5U   #   5V      5W      5X      5Y      �� 5Z      -%   5        $ MainTab_Four��5Z      $)��#Заказы организации��60   $��0,0,-3.6,-3q�6L   .��5[      � ���	#FFE5E5E5.+�5\      �� -&   5        $ Orders_System_Tab��5\   %   $
��Left=�6@   $	��636��6[   $	��Top=�6h   $
��1037��6�   .@�5]      �� $��Заказы��6&   .��5^   "   � -'   5        $ Заказы��5^   '   ���	#FFE5E5E5.+�5_   &     -(   5        $	 Orders_Grid��5_   /   $
��Left=�6D   $	��273��6_   $��	10,10,0,0q�6l   $	��Top=�6   $
��1021��6�   
 . 6�     5`   &   -)   5        $	 ListOrdersGrid��5`   /   $
��Left=�6G   $	��294��6b   $��
10,304,0,0q�6o   $	��Top=�6�   $
��1021��6�   6�   �� 5a   &   $5��/Список товаров к заказам |��6,   $
��Left=�6Q   $��
12,280,0,0q�6l   $	��Top=�6�   $	��172��6�   �� 5b   &   -*   5         ��Name$ FillerOrder��5b   -   $L��FСбросить фильтрацию по списку заказов��6B   $
��Left=�6r   $��747,283,0,0q�6�   $	��Top=�6�   $	��284��6�   6�   5c   #   5d      �� 5e      $��Поставщики��6&   .��5f   "   � ���	#FFE5E5E5.+�5g   &     -+   5        $	 Suppliers_Grid��5g   /   $
��Left=�6G   $	��588��6b   $��	10,10,0,0q�6o   $	��Top=�6�   $
��1021��6�   
 . 6�   5h   #   5i      �� 5j      $��Товары��6&   $��0,0,-4,-2.2q�66   .��5k   "   � ���	#FFE5E5E5.+�5l   &     -,   5        $	 
Goods_Grid��5l   /   $
��Left=�6C   $	��588��6^   $��	10,10,0,0q�6k   $	��Top=�6~   $
��1021��6�   
 . 6�   5m   #   5n      5o      5p      5q      5r      �� 5s      --   5        $ Insert��5s      $��Добавить��6%   $
��Left=�68   $��
1310,0,0,0q�6S   $	��Top=�6g   $��80��6   $��25��6�   $ 
0.44,0.492&�6�   �� 5t      -.   5        $ Update��5t      $��Изменить��6%   $
��Left=�68   $��
1395,0,0,0q�6S   $	��Top=�6g   $��80��6   $��25��6�   �� 5u      -/   5        $ Delete��5u      $��Удалить��6%   $
��Left=�67   $��
1203,0,0,0q�6R   $	��Top=�6f   $	��102��6~   $��25��6�   � 5v      -0   5        $ Panel_Add_User��5v      $
��Left=�6+   $	��304��6F   $��1068,66,0,0q�6S   $	��Top=�6h   $	��407��6�   ���	#FFDDF4F4$y�Hidden=�6�   .+�5w      �� $���{Добавление новых пользователей 
и изменения данных о существующих��6   $��	40,0,10,0q�6m   $	��Top=�6�   $��18(�6�   $
��Bold"�6�   �� 5x      -1   5        $ Workers_Combo_Main��5x      $
��Left=�67   $��
137,58,0,0q�6R   $	��Top=�6f   $	��260��6~   $��32��6�   $��14(�6�   �� 5y      $��Сотрудник:��6   $
��Left=�6-   $��	10,58,0,0q�6H   $	��Top=�6[   $��14(�6s   �� 5z      -2   5        $ 
FieldLogin��5z      $
��Left=�6.   $��23��6I   $��137,104,0,0q�6U   $
 Wrap=�6j   $	��Top=�6~   $	��260��6�   $��14(�6�   6�   �� 5{      $��Логин:��6   $
��Left=�6)   $��
10,103,0,0q�6D   $	��Top=�6X   $��14(�6p   �� 5|      $��Пароль:��6   $
��Left=�6*   $��
10,132,0,0q�6E   $	��Top=�6Y   $��14(�6q   �� 5}      -3   5        $ FieldPassword��5}      $
��Left=�61   $��23��6L   $��137,136,0,0q�6X   $
 Wrap=�6m   $	��Top=�6�   $	��260��6�   $��14(�6�   6�   �� 5~      $��	Роль:��6   $
��Left=�6(   $��
10,167,0,0q�6C   $	��Top=�6W   $��14(�6o   �� 5      -4   5        $ Workers_Roles_Combo��5      $
��Left=�68   $��137,164,0,0q�6S   $	��Top=�6h   $	��260��6�   $��32��6�   $��14(�6�   �� 5�      -5   5        $ 	AdderUser��5�      $��Записать��6,   $��108,215,102,0q�6?   $	��Top=�6V   $��37��6n   6z   �� 5�      -6   5        $ 
ClosePanel��5�      $��Закрыть��6-   $
��Left=�6?   $��108,257,0,0q�6Z   $	��Top=�6o   $	��197��6�   $��37��6�   6�   5�      � 5�      -7   5        $ Panel_Add_User_Roles��5�      $
��Left=�61   $	��304��6L   $��1068,66,0,0q�6Y   $	��Top=�6n   $	��407��6�   ���	#FFDDF4F4$y�Hidden=�6�   .+�5�      �� $a��[Добавление новых ролей 
и изменение существующих��6   $��	85,0,43,0q�6\   $	��Top=�6o   $��18(�6�   $
��Bold"�6�   �� 5�      $(��"Наименование роли:��6   $
��Left=�65   $��	10,70,0,0q�6P   $	��Top=�6c   $��14(�6{   �� 5�      -8   5        $ FieldNameRole��5�      $
��Left=�61   $��23��6L   $��
161,76,0,0q�6X   $
 Wrap=�6l   $	��Top=�6�   $	��241��6�   $��14(�6�   6�   �� 5�      -9   5        $ AdderUserRole��5�      $��Записать��60   $��108,215,102,0q�6C   $	��Top=�6Z   $��37��6r   6~   �� 5�      -:   5        $ ClosePanel_Roles��5�      $��Закрыть��63   $
��Left=�6E   $��108,257,0,0q�6`   $	��Top=�6u   $	��197��6�   $��37��6�   6�   �� 5�      -;   5         ��Name$ 
System_One��5�      $U��OДоступ к подсистеме данных о пользователях��6/   $
��Left=�6d   $��
10,111,0,0q�6   $	��Top=�6�   $��14(�6�   �� 5�      -<   5        $ 
System_Two��5�      $Q��KДоступ к подсистеме данных о сотрудниках��6/   $
��Left=�6b   $��
10,134,0,0q�6}   $	��Top=�6�   $��14(�6�   �� 5�      -=   5        $ System_Three��5�      $]��WДоступ к подсистеме данных о услугах и клиентах��61   $
��Left=�6k   $��
10,157,0,0q�6�   $	��Top=�6�   $��14(�6�   �� 5�      ->   5        $ System_Four��5�      $`��ZДоступ к подсистеме данных о заказах организации��60   $
��Left=�6k   $��
10,180,0,0q�6�   $	��Top=�6�   $��14(�6�   5�      � 5�      -?   5        $ Panel_Add_Workers��5�      $
��Left=�6.   $	��559��6I   $��1068,66,0,0q�6V   $	��Top=�6k   $	��407��6�   ���	#FFDDF4F4$y�Hidden=�6�   .+�5�      �� $}��wДобавление новых сотрудников 
и изменение данных о существующих��6   $��	42,0,10,0q�6k   $	��Top=�6~   $��18(�6�   $
��Bold"�6�   �� 5�      $��Имя��6   $
��Left=�6&   $��	10,76,0,0q�6A   $	��Top=�6T   $��14(�6l   �� 5�      -@   5        $ FnameWorker��5�      $
��Left=�6/   $��23��6J   $��	99,82,0,0q�6V   $
 Wrap=�6i   $	��Top=�6}   $	��243��6�   $��14(�6�   6�   �� 5�      -A   5        $ AdderWorker��5�      $��Записать��6.   $��113,470,97,0q�6A   $	��Top=�6W   $��37��6o   6{   �� 5�      -B   5        $ ClosePanel_Workers��5�      $��Закрыть��65   $
��Left=�6G   $��113,512,0,0q�6b   $	��Top=�6w   $	��197��6�   $��37��6�   6�   �� 5�      $��Фамилия��6   $
��Left=�6*   $��
10,104,0,0q�6E   $	��Top=�6Y   $��14(�6q   �� 5�      -C   5        $ LnameWorker��5�      $
��Left=�6/   $��23��6J   $��
99,110,0,0q�6V   $
 Wrap=�6j   $	��Top=�6~   $	��243��6�   $��14(�6�   6�   �� 5�      $��Отчество��6   $
��Left=�6+   $��
10,132,0,0q�6F   $	��Top=�6Z   $��14(�6r   �� 5�      -D   5        $ MnameWorker��5�      $
��Left=�6/   $��23��6J   $��
99,138,0,0q�6V   $
 Wrap=�6j   $	��Top=�6~   $	��243��6�   $��14(�6�   6�   �� 5�      $��Пол��6   $
��Left=�6&   $��
10,160,0,0q�6A   $	��Top=�6U   $��14(�6m   �� 5�      -E   5        $ SexWorkerCombo��5�      $
��Left=�63   $��
99,166,0,0q�6N   $	��Top=�6b   $	��136��6z    �� SelectedIndex$ 0��6�   .@�5�      �� $��Муж��6#   �� 5�      $��Жен��6#   5�      �� 5�      $��Дата рождения��6   $
��Left=�60   $��
12,194,0,0q�6K   $	��Top=�6_   $��14(�6w   (  "System.Windows.Controls.DatePicker  5�      -F   5          Name$ DateOfBirthWorker��5�      $
��Left=�68   $��126,200,0,0q�6S   $	��Top=�6h   $	��146��6�   6�   �� 5�      $��
Адрес��6   $
��Left=�6(   $��
12,228,0,0q�6C   $	��Top=�6W   $��14(�6o   �� 5�      -G   5        $ AdressWorker��5�      $
��Left=�60   $��23��6K   $��
99,233,0,0q�6W   $
 Wrap=�6k   $	��Top=�6   $	��243��6�   $��14(�6�   �� 5�      $!��Номер телефона��6   $
��Left=�61   $��
12,256,0,0q�6L   $	��Top=�6`   $��14(�6x   %  Xceed.Wpf.Toolkit.MaskedTextBox  5�      -H   5          Name$ PhoneNumberWorker��5�   %   $��135,262,65,274q�6@   $��23��6X      Mask$ 7 (999)-999-99-99��6d   �� 5�      $��Должность��6   $
��Left=�6,   $��
12,285,0,0q�6G   $	��Top=�6[   $��14(�6s   �� 5�      -I   5        $ WorkerFunctionCombo��5�      $
��Left=�68   $��
99,291,0,0q�6S   $	��Top=�6g   $	��243��6   5�      � 5�      -J   5        $ Panel_Add_WorkerFunction��5�      $
��Left=�65   $	��304��6P   $��1068,66,0,0q�6]   $	��Top=�6r   $	��407��6�   ���	#FFDDF4F4$y�Hidden=�6�   .+�5�      �� $w��qПанель добавления новых должностей
и изменения существующих��6   $��
36,-5,10,0q�6g   $	��Top=�6{   $��18(�6�   $
��Bold"�6�   �� 5�      $��Наименование:��6   $
��Left=�60   $��	10,58,0,0q�6K   $	��Top=�6^   $��14(�6v   �� 5�      $��График:��6   $
��Left=�6*   $��	10,98,0,0q�6E   $	��Top=�6X   $��14(�6p   �� 5�      $��Оклад:��6   $
��Left=�6)   $��
10,132,0,0q�6D   $	��Top=�6X   $��14(�6p   �� 5�      -K   5        $ AdderWorkerFunction��5�      $��Записать��66   $��108,215,102,0q�6I   $	��Top=�6`   $��37��6x   6�   �� 5�      -L   5        $! ClosePanel_Worker_Functions��5�      $��Закрыть��6>   $
��Left=�6P   $��108,257,0,0q�6k   $	��Top=�6�   $	��197��6�   $��37��6�   6�   �� 5�      -M   5        $ FieldNameWorkerFunction��5�      $
��Left=�6;   $��23��6V   $��
137,64,0,0q�6b   $
 Wrap=�6v   $	��Top=�6�   $	��260��6�   $��14(�6�   6�   �� 5�      -N   5        $ graphic_Combo��5�      $
��Left=�62   $��137,104,0,0q�6M   $	��Top=�6b   $	��260��6z   �� 5�      -O   5        $ Oklad��5�      $
��Left=�6)   $��23��6D   $��137,138,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��260��6�   $��14(�6�   6�   5�      �� 5�      -P   5        $ 	CheckYval��5�      $D��>Отображать уволенных сотрудников��6*   $
��Left=�6U   $��	951,4,0,0q�6p   $	��Top=�6�   $��19��6�   $	��223��6�   $y�Hidden=�6�   �� 5�      -Q   5        $ CheckYval_Users��5�      $V��PОтображать деактивированных пользователей��60   $
��Left=�6d   $��	660,4,0,0q�6   $	��Top=�6�   $��19��6�   $	��286��6�   $y�Hidden=�6  � 5�      -R   5        $&  Panel_Add_WorkerFunction_Graphic��5�      $
��Left=�6=   $	��304��6X   $��1068,66,0,0q�6e   $	��Top=�6z   $	��407��6�   ���	#FFDDF4F4$y�Hidden=�6�   .+�5�      �� $r��lПанель добавления новых графиков
и изменения существующих��6   $��
36,-5,10,0q�6`   $	��Top=�6t   $��18(�6�   $
��Bold"�6�   �� 5�      $��Наименование:��6   $
��Left=�60   $��	10,58,0,0q�6K   $	��Top=�6^   $��14(�6v   �� 5�      $��Время начала:��6   $
��Left=�60   $��	10,98,0,0q�6K   $	��Top=�6^   $��14(�6v   �� 5�      $��Время конца:��6   $
��Left=�6/   $��
10,132,0,0q�6J   $	��Top=�6^   $��14(�6v   "  Xceed.Wpf.Toolkit.TimePicker  5�      -S   5          Name$ 	TimeStart��5�   "   $��137,92,10,183q�65   ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   AllowTextInput .     EndTime$ 20:0:0h�6c   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Maximum$ 12/31/9999 20:00:00X�6t      	StartTime$ 8:0:0h�6�      	AllowSpin .  &   Xceed.Wpf.Toolkit.DateTimeUpDown   Format$ LongTime=�6�   �� 5�      -T   5        $ AdderWorkerGraphic��5�      $��Записать��65   $��108,215,102,0q�6H   $	��Top=�6_   $��37��6w   6�   �� 5�      -U   5        $ ClosePanel_Worker_Craphic��5�      $��Закрыть��6<   $
��Left=�6N   $��108,257,0,0q�6i   $	��Top=�6~   $	��197��6�   $��37��6�   6�   �� 5�      -V   5        $ FieldNameWorkerGraphic��5�      $
��Left=�6:   $��23��6U   $��
137,64,0,0q�6a   $
 Wrap=�6u   $	��Top=�6�   $	��260��6�   $��14(�6�   6�     5�      -W   5        $ TimeEnd��5�   "   $��137,132,10,143q�63    .  $ 20:0:0h�6b   $ 8:0:0h�6s   $ 12/31/9999 20:00:00X�6�    .  $ LongTime=�6�   5�      � 5�      -X   5        $ Panel_Add_Сlients��5�      $
��Left=�6.   $	��386��6I   $��1108,66,0,0q�6V   $	��Top=�6k   $	��367��6�   ���	#FF18E5D3$y�Hidden=�6�   .+�5�      �� -Y   5        $ ClosePanel_Clients��5�      $��Закрыть��65   $
��Left=�6G   $��
72,339,0,0q�6b   $	��Top=�6v   $	��231��6�   $��37��6�   6�   �� 5�      -Z   5        $ AdderClient��5�      $��Записать��6.   $��72,297,64,0q�6A   $	��Top=�6V   $��37��6n   6z   �� 5�      $��Имя��6   $
��Left=�6&   $��1,67,0,0q�6A   $	��Top=�6S   $��14(�6k   �� 5�      -[   5        $ FnameClient��5�      $
��Left=�6/   $��23��6J   $��	90,73,0,0q�6V   $
 Wrap=�6i   $	��Top=�6}   $	��243��6�   $��14(�6�   6�   �� 5�      $��Фамилия��6   $
��Left=�6*   $��1,95,0,0q�6E   $	��Top=�6W   $��14(�6o   �� 5�      -\   5        $ LnameClient��5�      $
��Left=�6/   $��23��6J   $��
90,101,0,0q�6V   $
 Wrap=�6j   $	��Top=�6~   $	��243��6�   $��14(�6�   6�   �� 5�      $��Отчество��6   $
��Left=�6+   $��	1,123,0,0q�6F   $	��Top=�6Y   $��14(�6q   �� 5�      -]   5        $ MnameClient��5�      $
��Left=�6/   $��23��6J   $��
90,129,0,0q�6V   $
 Wrap=�6j   $	��Top=�6~   $	��243��6�   $��14(�6�   6�   �� 5�      $��Пол��6   $
��Left=�6&   $��	1,151,0,0q�6A   $	��Top=�6T   $��14(�6l   �� 5�      -^   5        $ SexClientCombo��5�      $
��Left=�63   $��
90,157,0,0q�6N   $	��Top=�6b   $	��136��6z   $ 0��6�   .@�5�      �� $��Муж��6#   �� 5�      $��Жен��6#   5�      �� 5�      $��Дата рождения��6   $
��Left=�60   $��	3,185,0,0q�6K   $	��Top=�6^   $��14(�6v     5�      -_   5        $ DateOfBirthClient��5�      $
��Left=�68   $��117,191,0,0q�6S   $	��Top=�6h   $	��146��6�   6�   �� 5�      $��Эл. почта��6   $
��Left=�6,   $��	3,219,0,0q�6G   $	��Top=�6Z   $��14(�6r   �� 5�      -`   5        $ EmailClient��5�      $
��Left=�6/   $��23��6J   $��
90,224,0,0q�6V   $
 Wrap=�6j   $	��Top=�6~   $	��243��6�   $��14(�6�   6�   �� 5�      $!��Номер телефона��6   $
��Left=�61   $��	3,247,0,0q�6L   $	��Top=�6_   $��14(�6w     5�      -a   5        $ PhoneNumberClient��5�   %   $��137,253,10,110q�6@   $��23��6X   $ 7 (999)-999-99-99��6d   $	��220��6}   �� 5�      $N��HПанель добавления и изменения клиентов��6   $
��Left=�6I   $��
10,0,0,348q�6d   $��Bottom=�6x   $��16(�6�   $��38��6�   $
��Bold"�6�   5�      � 5�      -b   5        $ Panel_Add_Services��5�      $
��Left=�6/   $	��386��6J   $��1108,66,0,0q�6W   $	��Top=�6l   $	��367��6�   ���	#FF18E5D3$y�Hidden=�6�   .+�5�      �� -c   5        $ ClosePanel_Sevices��5�      $��Закрыть��65   $
��Left=�6G   $��
72,339,0,0q�6b   $	��Top=�6v   $	��231��6�   $��37��6�   6�   �� 5�      -d   5        $ AdderServices��5�      $��Записать��60   $��72,297,64,0q�6C   $	��Top=�6X   $��37��6p   6|   �� 5�      $��Наименование��6   $
��Left=�6/   $��1,67,0,0q�6J   $	��Top=�6\   $��14(�6t   �� 5�      -e   5        $ Name_Services��5�      $
��Left=�61   $��23��6L   $��
107,73,0,0q�6X   $
 Wrap=�6l   $	��Top=�6�   $	��225��6�   $��14(�6�   6�   �� 5�      $��Длительность��6   $
��Left=�6/   $��	1,101,0,0q�6J   $	��Top=�6]   $��14(�6u   �� 5�      $��Описание:��6   $
��Left=�6,   $��	1,123,0,0q�6G   $	��Top=�6Z   $��14(�6r   �� 5�      -f   5        $ Description_Service��5�      $
��Left=�67   $��85��6R   $��
10,152,0,0q�6^   $
 Wrap=�6r   $	��Top=�6�   $	��347��6�   $��14(�6�   �� 5�      $H��BПанель добавления и изменения услуг��6   $
��Left=�6F   $��
29,0,0,348q�6a   $��Bottom=�6u   $��16(�6�   $��38��6�   $
��Bold"�6�   $	��328��6�   �� 5�      -g   5        $��Стоимость��5�      $
��Left=�6,   $��	1,237,0,0q�6G   $	��Top=�6Z   $��14(�6r   6�   �� 5�      -h   5        $ Price_Services��5�      $
��Left=�62   $��23��6M   $��
90,243,0,0q�6Y   $
 Wrap=�6m   $	��Top=�6�   $	��243��6�   $��14(�6�   6�     5�      -i   5        $ Duration_Services��5�   "   $��107,101,10,256q�6=    .  $ 2:0:0h�6l   $ 12/31/9999 02:00:00X�6|   $ LongTime=�6�   5�      � 5�      -j   5        $ Panel_Add_Records��5�      $
��Left=�6.   $	��318��6I   $��1108,66,0,0q�6V   $	��Top=�6k   $	��367��6�   ���	#FF18E5D3$y�Hidden=�6�   .+�5�      �� -k   5        $ ClosePanel_Records��5�      $��Закрыть��65   $
��Left=�6G   $��
84,267,0,0q�6b   $	��Top=�6v   $	��231��6�   $��37��6�   6�   �� 5�      -l   5        $ AdderRecords��5�      $��Записать��6/   $��84,225,52,0q�6B   $	��Top=�6W   $��37��6o   6{   �� 5�      $f��`Панель добавления и изменения
 записей на процедуры��6   $
��Left=�6_   $��
54,0,0,241q�6z   $��Bottom=�6�   $��16(�6�   $��77��6�   $
��Bold"�6�   $	��280��6�   �� 5�      $'��!Процедура (услуга)��6   $
��Left=�65   $��	10,92,0,0q�6P   $	��Top=�6c   �� 5�      -m   5        $ ComboService��5�      $
��Left=�61   $��
132,95,0,0q�6L   $	��Top=�6`   $	��202��6x   �� 5�      $��Клиент��6   $
��Left=�6)   $��
10,127,0,0q�6D   $	��Top=�6X   �� 5�      -n   5        $ ComboClients��5�      $
��Left=�61   $��132,125,0,0q�6L   $	��Top=�6a   $	��202��6y   �� 5�      $��Дата��6   $
��Left=�6'   $��
10,153,0,0q�6B   $	��Top=�6V   �� 5�      $��
Время��6   $
��Left=�6(   $��
10,184,0,0q�6C   $	��Top=�6W     5�      -o   5        $ 
DateRecord��5�      $��132,152,33,140q�61   6K     5�      -p   5        $ 
TimeRecord��5�   "   $��132,183,33,113q�66   $ LongTime=�6N    .  $ 20:0:0h�6w   $ 12/31/9999 20:00:00X�6�   $ 8:0:0h�6�   5�      � 5�      -q   5        $ Panel_Add_Goods��5�      $
��Left=�6,   $	��233��6G   $��1122,66,0,0q�6T   $	��Top=�6i   $	��327��6�   ���	#FFE8A03F$y�Hidden=�6�   .+�5�      �� $L��FПанель добавления и изменения товаров��6   $
��Left=�6H   $��44,0,0,0q�6c   $	��Top=�6u   $	��257��6�   $
��Bold"�6�   �� 5�      $��Наименование��6   $
��Left=�6/   $��	10,31,0,0q�6J   $	��Top=�6]   �� 5�      $��Тип товара��6   $
��Left=�6-   $��	10,57,0,0q�6H   $	��Top=�6[   �� 5�      $��Цена за штуку��6   $
��Left=�60   $��	10,83,0,0q�6K   $	��Top=�6^   �� 5�      -r   5        $ 
Name_Goods��5�      $
��Left=�6.   $��23��6I   $��
122,34,0,0q�6U   $
 Wrap=�6i   $	��Top=�6}   $	��195��6�   6�   �� 5�      -s   5        $ Price_Of_Piece_Goods��5�      $
��Left=�68   $��23��6S   $��
122,85,0,0q�6_   $
 Wrap=�6s   $	��Top=�6�   $	��195��6�   6�   �� 5�      -t   5        $ 
TypesGoods��5�      $
��Left=�6/   $��
122,60,0,0q�6J   $	��Top=�6^   $	��195��6v   $ 0��6�   .@�5�      �� $��Препараты��6#   �� 5�      $��Оборудование��6#   5�      �� 5�      -u   5        $ Adder_Goods��5�      $��Записать��6.   $
��Left=�6A   $��
92,152,0,0q�6\   $	��Top=�6p   $	��172��6�   $��33��6�   6�   �� 5�      -v   5        $ Close_Panel_Goods��5�      $��Закрыть��64   $
��Left=�6F   $��
92,190,0,0q�6a   $	��Top=�6u   $	��172��6�   $��33��6�   6�   5�      � 5�      -w   5        $ Panel_Add_Suppliers��5�      $
��Left=�60   $	��233��6K   $��1122,66,0,0q�6X   $	��Top=�6m   $	��327��6�   ���	#FFE8A03F$y�Hidden=�6�   .+�5�      �� $T��NПанель добавления и изменения поставщиков��6   $
��Left=�6L   $��26,0,0,0q�6g   $	��Top=�6y   $	��291��6�   $
��Bold"�6�   �� 5�      $��Поставщик��6   $
��Left=�6,   $��	10,34,0,0q�6G   $	��Top=�6Z   �� 5�      $��
Адрес��6   $
��Left=�6(   $��	10,57,0,0q�6C   $	��Top=�6V   �� 5      $!��Номер телефона��6   $
��Left=�61   $��	10,83,0,0q�6L   $	��Top=�6_   �� 5     -x   5        $ AdressSuplier��5     $
��Left=�61   $��23��6L   $��
122,61,0,0q�6X   $
 Wrap=�6l   $	��Top=�6�   $	��195��6�   6�   �� 5     -y   5        $ Adder_Suppliers��5     $��Записать��62   $
��Left=�6E   $��
92,152,0,0q�6`   $	��Top=�6t   $	��172��6�   $��33��6�   6�   �� 5     -z   5        $ Close_Panel_Suppliers��5     $��Закрыть��68   $
��Left=�6J   $��
92,190,0,0q�6e   $	��Top=�6y   $	��172��6�   $��33��6�   6�     5     -{   5        $ Phone_Number_Supplier��5  %   $��122,89,10,121q�6D   $��23��6[   $ 7 (999)-999-99-99��6g   �� 5     -|   5        $ Suplier_Name��5     $
��Left=�60   $��23��6K   $��
122,36,0,0q�6W   $
 Wrap=�6k   $	��Top=�6   $	��195��6�   6�   5     � 5     -}   5        $ Panel_Add_FormingOrder��5     $
��Left=�63   $	��185��6N   $��1122,66,0,0q�6[   $	��Top=�6p   $	��327��6�   ���	#FFE8A03F$y�Hidden=�6�   .+�5     �� $M��GПанель формирования заказа (Изменения)��6   $
��Left=�6I   $��30,0,0,0q�6d   $	��Top=�6v   $	��287��6�   $
��Bold"�6�   �� 5	     $��Поставщик��6   $
��Left=�6,   $��	10,34,0,0q�6G   $	��Top=�6Z   �� 5
     -~   5        $ Adder_Order��5
     $��Записать��6.   $
��Left=�6A   $��
92,103,0,0q�6\   $	��Top=�6p   $	��172��6�   $��33��6�   6�   �� 5     -   5        $ Close_Panel_Order��5     $��Закрыть��64   $
��Left=�6F   $��
92,141,0,0q�6a   $	��Top=�6u   $	��172��6�   $��33��6�   6�   �� 5     $Y��S* Остальные данные подставятся автоматически��6   $
��Left=�6O   $��	10,72,0,0q�6j   $	��Top=�6}   $	��307��6�   $
��Bold"�6�   �� 5     -�   5        $ ComboOrderSupplier��5     $
��Left=�67   $��	92,37,0,0q�6R   $	��Top=�6e   $	��225��6}   5     � 5     -�   5        $ Panel_Add_ListGoods��5     $
��Left=�60   $	��304��6K   $��1122,66,0,0q�6X   $	��Top=�6m   $	��327��6�   ���	#FFE8A03F$y�Hidden=�6�   .+�5     �� $X��RПанель добавления (изменения) товара (список)��6   $
��Left=�6P   $��10,0,0,0q�6k   $	��Top=�6}   $	��307��6�   $
��Bold"�6�   �� 5     $��№ Заказа��6   $
��Left=�6+   $��	10,34,0,0q�6F   $	��Top=�6Y   �� 5     -�   5        $ Adder_List_Goods��5     $��Добавить��63   $
��Left=�6F   $��
92,227,0,0q�6a   $	��Top=�6u   $	��172��6�   $��33��6�   6�   �� 5     -�   5        $ Close_Panel_List_Goods��5     $��Закрыть��69   $
��Left=�6K   $��
92,265,0,0q�6f   $	��Top=�6z   $	��172��6�   $��33��6�   6�   �� 5     -�   5        $ NumberOrderCombo��5     $
��Left=�65   $��	92,37,0,0q�6P   $	��Top=�6c   $	��225��6{   6�   �� 5     $��
Товар��6   $
��Left=�6(   $��	10,61,0,0q�6C   $	��Top=�6V   �� 5     -�   5        $ GoodsListCombo��5     $
��Left=�63   $��	92,64,0,0q�6N   $	��Top=�6a   $	��225��6y   6�   �� 5     $��Количество��6   $
��Left=�6-   $��	10,87,0,0q�6H   $	��Top=�6[   �� 5     -�   5        $ CountGoodsInList��5     $
��Left=�64   $��23��6O   $��	92,91,0,0q�6[   $
 Wrap=�6n   $	��Top=�6�   $	��120��6�   6  �� 5     -�   5        $ PriceOfCountGoodsList��5     $
��Left=�69   $��23��6T   $��
92,119,0,0q�6`   $
 Wrap=�6t   $��0��6�   $	��Top=�6�   $	��200��6�   {�.  6  �� 5     $��Стоимость��6   $
��Left=�6,   $��
10,118,0,0q�6G   $	��Top=�6[   5     5     5     5      