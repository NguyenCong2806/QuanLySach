   M S B A M L   `   `   `  ����b  ^PresentationFramework.Aero2, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes  5       BookManagement   BookManagement.App   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ]themeKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2     5        �� 	Resources  5       �� MergedDictionaries �� Source   dataGridRowStyle1 �� 
TargetType)  #System.Windows.Controls.DataGridRow �� Property �� Value �� 
TargetType ��Name �� Padding	 �� CornerRadius
 J� SnapsToDevicePixels?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid � ColumnDefinitions � RowDefinitions?  9System.Windows.Controls.Primitives.DataGridCellsPresenter   
ItemsPanelA  ;System.Windows.Controls.Primitives.DataGridDetailsPresenter   DetailsVisibility$   SelectiveScrollingOrientation;  5System.Windows.Controls.SelectiveScrollingOrientation   Vertical �� ConverterParameter&   System.Windows.Controls.DataGrid#   RowDetailsScrollingConverter �� 	Converter �� RelativeSource �� AncestorType:  4System.Windows.Controls.Primitives.DataGridRowHeader7  1System.Windows.Controls.DataGridHeadersVisibility
   Row!   HeadersVisibilityConverter �� Triggers P� Property P� Value ]� 
Conditions �� Property �� Value  ColumnHeaderGripperStyle1  dataGridColumnHeaderStyle1=	  7System.Windows.Controls.Primitives.DataGridColumnHeader3
   -Microsoft.Windows.Themes.DataGridHeaderBorder 
  	IsPressed J� IsMouseOver  
  	IsHovered! 	  CanUserSort" 
  IsClickable# 	  SortDirection$ 
  SortDirection% 	  SeparatorVisibility& 
  SeparatorVisibility' 	  SeparatorBrush( 
  SeparatorBrush) n�Name  dataGridCellStyle*  $System.Windows.Controls.DataGridCell  dataGridStyle5  /System.Windows.Controls.DataGridLengthConverter* ��Name+   SelectAllCommand, �� 
ResourceId- �� TypeInTargetAssembly
.   AllG  ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter/  Name0   Column1 ��Name2 �� CanContentScroll3 ��Name4 �� ScrollableHeight5 � Maximum6 �� Orientation7 �� ViewportHeight8 �� ViewportSize*9 �� #ComputedVerticalScrollBarVisibility: � Value; �� Mode< �� Mode= �� ScrollableWidth> �� ViewportWidth,? �� %ComputedHorizontalScrollBarVisibility�� 5   
    5      �� 5	      $V Ppack://application:,,,/ToastNotifications.Messages;component/Themes/Default.xaml?�6%   �� 5
      $ Style/MainStyle.xaml?�6%   �� 5      $* $Resources/Datatemple/Datatemple.xaml?�6%   %f  &	        &	 j    &	 |    7  7  &	 
    &	 �    �� 5      "  6.   .�5      ��  � �� �#F0F0F06/   �� 5       � ��$ 0 4 0 0q�6+   �� 5       �@J�SnapsToDevicePixels . 68   �� 5       �@=�ErrorTemplate 6=   Z� �� 5       �@ ValidationErrorTemplate 5      �� 5      .R�5      �� 
���  ��$��2,0,0,0q�69   $��!��6J   $��Center=�6S   5      5      �� 5       � �� 5      �� 5      "  6*   .R�5      �� $ 
DGR_Border��6%   #��z��69   $	 0 8q�5      $	 5��5      $��0q�5       
 . ._�5!   "      5"   &   �� 5#   *   $
��Auto �6;   �� 5$   *   $��* �6;    5&   &   �� 5'   *   $��* �68   �� 5(   *   $
��Auto �68   .+�5*   &     $��1��6=   #��z 6M   #
 z
 6w     5+   &   $��1��6?   $��1��6O   #y�z 6s   6\   �� *AreRowDetailsFrozen+# Z # Z  �� "  6s    5,   &   $��2��68   $ Vertical=�6I   y�6�   �� *HeadersVisibility+# Z # Z  �� "  5-   #   5.      5/      51       52      P� 53       �@J�IsMouseOver . . �54      ��  � �� �#623ed067   �� 55       � �� �#ffffff67   �� 56       �@�Cursor$
 Hand��63   57      P� 58       �@ 
IsSelected . . �59      ��  � �� �#623ed067   �� 5:       � �� �#ffffff67   �� 5;       �@�Cursor$
 Hand��63   5<      ]� 5=       5>      �� 5?       �@ 
IsSelected . 6>   �� 5@       �@��IsSelectionActive .  6N   ./�5B      ��  � �� �#dfdfdf67   �� 5C       �@�Cursor$
 Hand��63   5D      5F      �� 5G      " n�66   .�5H      ��  � ��$ 8��6*   �� 5I       � ��
 ���� 6/   �� 5J       �@�Cursor$ SizeWE��6+   �� 5K       � �� 5L      �� 5M      " n�6*   .R�5N      �� #��z��6%   # z��6O   5O      5Q      5R      �� 5S      " 	 67   .�5T      ��  � ��$ Center=�6=   �� 5U       � ��
 ���� 6/   �� 5V       � �� �#69717d6/   �� 5W       � ��$ 15 0  15 10q�6+   �� 5X       � �� 5Y      �� 5Z      " 	 6*   .R�5[      � .+�5\   "   
  #��z��6=   #��z��6g   #��z��6�   # z��6�   #  z 6�   #" z! 6  # z��6E  #$ z# 6i  #& z% 6�  #( z' 6�  ._�5]   &   �� #��z��67   ��. #
 z
 6�   #��z��6�   5^   #   n� 5_   "   $) PART_LeftHeaderGripper��6(   $
��Left=�6H   8��  6c   n� 5`   "   $) PART_RightHeaderGripper��6(   $��Right=�6I   8�� 6e   5a      5b      5d      5e      �� 5h      "  6.   .�5i      ��  � ��
 ���� 6/   �� 5j       � ��$ Center=�66   �� 5k       �@�FocusVisualStyle 65   Z� �� 5l       � ��$
 15 0q�6+   �� 5m       � �� 5n      �� 5o      "  6*   .R�5p      �� #��z��6%   $��0q�5q      
 . ._�5r   "   �� #
 z
 63   5s      5t      5v      5w      �� 5z      "  6*   .�5{      ��  � ��
 ���� 6/   �� 5|       � �� �#2225286/   �� 5}       � ��$ 0q�64   �� 5~       �@ GridLinesVisibility$
 None=�68   �� 5        �@ RowDetailsVisibilityMode$ VisibleWhenSelected=�6=   �� 5�       � �� . 6B   �� 5�       �@��PanningMode$
 Both=�6=   �� 5�       �@��IsFlicksEnabled .  6;   �� 5�       �@ AutoGenerateColumns .  68   �� 5�       �@ HeadersVisibility$ Column=�66   �� 5�       � ��$ 0 10 0 0q�6+   �� 5�       �@ SelectionMode$ Single=�62   �� 5�       �@ SelectionUnit$ FullRow=�62   �� 5�       �@ CanUserAddRows .  63   �� 5�       �@ CanUserDeleteRows .  66   �� 5�       �@ CanUserResizeColumns .  69   �� 5�       �@ CanUserReorderColumns .  6:   �� 5�       � ��$ 14(�6-   �� 5�       �@ ColumnWidth$ * 60   �� 5�       � �� 5�      �� 5�      "  6*   .R�5�      �� #��z��6%   #��z��6O   #��z��6{   # z��6�   
 . ._�5�   "   �� $* DG_ScrollViewer��6/   |�.  ��5�   &   �� 5�   *   " ��6:   .R�5�   .   �  5�   2   �� 5�   6   $
��Auto �6G   �� 5�   6   $��* �6G   �� 5�   6   $
��Auto �6G    5�   2   �� 5�   6   $
��Auto �6D   �� 5�   6   $��* �6D   �� 5�   6   $
��Auto �6D   .+�5�   2   �� #��Z+ 69   |�.  ��6z   C� *�� $", DataGridSelectAllButtonStyle��"-  +y�6�   �� *HeadersVisibility+# Z. # Z  �� "  ��6�  �� *CellsPanelHorizontalOffset+ �� "    5�   2   $!/ PART_ColumnHeadersPresenter��6Q   $��1��6v   y�6�   �� *HeadersVisibility+# Z0 # Z  �� "  �� 5�   2   $!1 PART_ScrollContentPresenter��6I   #2 z��6n   $��2��6�   $��1��6�   �� 5�   2   $3 PART_VerticalScrollBar��6<   $��2��6\   #5 z4 6l   $6 Vertical=�6�   $��1��6�   #8 z7 6!  #y�z9 6Q  : 6�   �� *VerticalOffset+$; OneWay=� �� $< TemplatedParent=�6Q  � 5�   2   $��1��67   $��2��6G    5�   6   �� 5�   :   ��6K   �� **(NonFrozenColumnsViewportHorizontalOffset+ �� "  �� 5�   :   $��* �6K   .+�5�   6   �� $3 PART_HorizontalScrollBar��6@   $��1��6b   #5 z= 6r   $6 
Horizontal=�6�   #8 z> 6  #y�z? 6L  : 6�   �� *HorizontalOffset+$; OneWay=� �� $< TemplatedParent=�6L  5�   3   5�   /   5�   +   .��5�   &   �� #
 z
 65   5�   #   5�      5�      5�       5�      ]� 5�       5�      �� 5�       �@��
IsGrouping . 6>   �� 5�      " �@%�IsVirtualizingWhenGrouping .  6`   ./�5�      ��  � �� .  6J   5�      5�      5�      5�      