   M S B A M L   `   `   `  ����@  <learn, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:learn.papkalearn.papka  5          learn.papka.TimeSheetPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:learn.papka     5      -   5          N� Title$  TimeSheetPage��5	      .��5      � ���#e7fabf � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��30 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridVisits��5      $��0��6+      AutoGenerateColumns .     
IsReadOnly .    	RowHeight$ 30Q�6f      SelectionMode$ Single=�6u   $��2��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$  ��6K   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6U   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� *uslugi.код_услуги+6a     5      $+ %Наименование услуги��6T   $		 150 6q   
 6%   �� *.,uslugi.Наименование_услуги+6q     5      $ Фамилия��6H   $		 100 6Y   
 6%   �� *client.Фамилия+6Y     5      $ Имя��6D   $		 130 6Q   
 6%   �� *client.Имя+6Q     5      $ Отчество��6I   $		 100 6[   
 6%   �� *client.Отчество+6[     5      $ Дата��6Q   $		 100 6_   
 6%   �� *(&client.Дата_регистрации+6_   4  .System.Windows.Controls.DataGridTemplateColumn  5      $		 100 6)   $  Редактировать��65      CellTemplate 5      �� 5      .R�5      ��  ��Name$ BtnEdit��6%   -   5        $	��...��5   6   $��0q�6Z   5      5      5"      �� 5#   
   -   5        $ BtnAdd��5#      $��2��6!   $��Right=�6.   $��3q�6J   $	��100��6U   $��Добавить��6a   6t   �� 5$   
   -   5        $ 	BtnDelete��5$      $��2��6$   $��Удалить��61   $
��Left=�6C   $��3q�6^   $	��100��6i   6u   5(      5)      