   M S B A M L   `   `   `  ����  Lexy!    SixPackApps.Lexy.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$
  Lexy��5   	   $
��Auto��6   $
��Auto��6$   .��5      � $��Stretch=�6    � RowDefinitions 5   
   �� 5      $��* �6   $	��300��6'   �� 5      $
��Auto �6    � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $	��350 �6   .+�5   
   � $��0��6   $��0��6    5      �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� $��0��6   $	��Top=�6!   $
��Left=�69      PageHeaderLabelStyle#��[  6T   .��6�   	Library6�   &   System.Windows.Controls.DataGrid  5      -   5          Name$ SongsDataGrid��5         SelectionUnit$ FullRow=�6.   $��1��6F      AutoGenerateColumns .  ��6S   �� *Songs+   Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Title��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells 6<   	   
IsReadOnly	 . 
   SortMemberPath$
 Title��6b      CellTemplate 5      �� 5      .R�5   "   �� ��6,   �� *Title+5      5        5      $ Artist��6-   $ SizeToCells 6=   	 . $
 Artist��6c    5      �� 5       .R�5!   "   �� ��6,   �� *Artist+5"      5$        5%      $ Lyrics Status��6-   $ SizeToCells 6D   	 . $
 LyricsStatus��6j    5&      �� 5'      .R�5(   "   �� ��6,   �� *LyricsStatus+5)      5+      5-      5.      �� 50   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��0��6;   .+�51      �� -   5         ��Name$ GetLyricsButton��51      $
��Left=�52        MetroButton#��[ 60   $��15q�6U   $
��Auto��6a   $��
Get Lyrics��6n   {�51   .   �� *
IsFetching+  BoolInverter �� 	Converter# [ 52   n   �� 53      -   5        $ AddLyricsButton��53      $
��Left=�54      #��[ 60   $��15q�6U   $
��Auto��6a   $��
Add Lyrics��6n   {�53   .   �� *
IsFetching+# [ 54   n   �� 55      .+�56      �� -   5         ��Name$ SelectAllCheckBox��56   A    � Cursor$
 Hand��6\     MetroCheckBoxStyle#��[ 6k   .��6�   
Select All6�   �� 57      -   5        $ SelectMissingCheckBox��57   F   $
 Hand��6e   #��[ 6t   .��6�   Select Missing6�   58      59      � 5<   
   $��0��6   $��1��6    5=      �� 5>      $
��Auto �6    �� 5?      $��* �6    .+�5A      �� $��0��6   $	��Top=�6!   $
��Left=�69   #��[  6T   .��6�   Lyrics6�   �� 5B      $��1��6   .��5C      ��  �� TextWrapping$
 Wrap=�6�   $
��Auto��6�   
���   �
���������.  �� AcceptsReturn . {�6   �� *IsMultiSelect+# [ ��6g   �� *CurrentLyrics+ �� Mode$ TwoWay=�5D   a   5E      5F      � 5G   
   $��1��6   $��1��6    5H      �� 5I      $
��Auto �6    �� 5J      $��* �6    .+�5L      �� $��0��6   $	��Top=�6k   $
��Left=�6�   #��[  6�   {�6!   �� *
IsFetching+# [ ��6�   �� *FetchStatus+6�   5M      5N      5O      