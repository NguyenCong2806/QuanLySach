   M S B A M L   `   `   `  ���� b  ^PresentationFramework.Aero2, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes   BookManagement   BookManagement.App   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ]themeKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2       �� 	Resources   �� MergedDictionaries �� Source   FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  TextBox.Static.Background �� Color  ComboBoxEditableTextBox �� 
TargetType	 �� 
TargetType
 ��Name  ComboBox.Static.Background �� EndPoint �� 
StartPoint � Color � Offset  ComboBox.Static.Border  ComboBox.Static.Glyph ' #ComboBox.Static.Editable.Background # ComboBox.Static.Editable.Border . *ComboBox.Static.Editable.Button.Background *	 &ComboBox.Static.Editable.Button.Border !
 ComboBox.MouseOver.Background  ComboBox.MouseOver.Border  ComboBox.MouseOver.Glyph * &ComboBox.MouseOver.Editable.Background & "ComboBox.MouseOver.Editable.Border 1 -ComboBox.MouseOver.Editable.Button.Background - )ComboBox.MouseOver.Editable.Button.Border  ComboBox.Pressed.Background  ComboBox.Pressed.Border  ComboBox.Pressed.Glyph ( $ComboBox.Pressed.Editable.Background $  ComboBox.Pressed.Editable.Border / +ComboBox.Pressed.Editable.Button.Background + 'ComboBox.Pressed.Editable.Button.Border   ComboBox.Disabled.Background  ComboBox.Disabled.Border  ComboBox.Disabled.Glyph ) %ComboBox.Disabled.Editable.Background % !ComboBox.Disabled.Editable.Border 0 ,ComboBox.Disabled.Editable.Button.Background , (ComboBox.Disabled.Editable.Button.Border  ComboBoxToggleButton ��Name F�Name �� Triggers ^� 
Conditions �� Binding �� RelativeSource �� AncestorType �� Value �� Mode �� 
TargetName P� Property P� Value   ComboBoxEditableTemplate �Name � ColumnDefinitions �Name � AllowsTransparency5   /Microsoft.Windows.Themes.SystemDropShadowChrome  Name    Color! �� MaxDropDownHeight" �� ElementName# �� ClearTypeHint$ ��Name% ��Name& ��Name-  'System.Windows.Input.KeyboardNavigation'   DirectionalNavigation( d�Name) d� 	IsChecked* �� Mode+ ��Name, �� 
IsReadOnly- P� 
SourceName. ]� 
Conditions/ �� Property ! ComboBoxTemplate0 �� CornerRadius1 ��Name#2 �� SelectionBoxItemStringFormat3 �� ContentStringFormat4 �� SelectionBoxItemTemplate5 �� SelectionBoxItem6 J� IsHitTestVisible " comboBoxStyle7 �� Triggers # dataGridRowStyle1)  #System.Windows.Controls.DataGridRow8 �� Padding?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid9 � RowDefinitions?  9System.Windows.Controls.Primitives.DataGridCellsPresenter:   
ItemsPanelA  ;System.Windows.Controls.Primitives.DataGridDetailsPresenter;   DetailsVisibility$<   SelectiveScrollingOrientation;  5System.Windows.Controls.SelectiveScrollingOrientation=   Vertical> �� ConverterParameter&   System.Windows.Controls.DataGrid#?   RowDetailsScrollingConverter@ �� 	Converter:	  4System.Windows.Controls.Primitives.DataGridRowHeader7
  1System.Windows.Controls.DataGridHeadersVisibility
A 
  Row!B   HeadersVisibilityConverter $ ColumnHeaderGripperStyle1 % dataGridColumnHeaderStyle1=  7System.Windows.Controls.Primitives.DataGridColumnHeader3   -Microsoft.Windows.Themes.DataGridHeaderBorderC   	IsPressedD J� IsMouseOverE   	IsHoveredF   CanUserSortG   IsClickableH   SortDirectionI   SortDirectionJ   SeparatorVisibilityK   SeparatorVisibilityL   SeparatorBrushM   SeparatorBrushN n�Name & dataGridCellStyle*  $System.Windows.Controls.DataGridCell ' dataGridStyle5  /System.Windows.Controls.DataGridLengthConverterO   SelectAllCommandP �� 
ResourceIdQ �� TypeInTargetAssembly
R 
  AllG  ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenterS  NameT 
  ColumnU ��NameV �� CanContentScrollW ��NameX �� ScrollableHeightY � MaximumZ �� Orientation[ �� ViewportHeight\ �� ViewportSize*] �� #ComputedVerticalScrollBarVisibility^ � Value_ �� ScrollableWidth` �� ViewportWidth,a �� %ComputedHorizontalScrollBarVisibility��  �� $V Ppack://application:,,,/ToastNotifications.Messages;component/Themes/Default.xaml?��� $ Style/MainStyle.xaml?��� $* $Resources/Datatemple/Datatemple.xaml?��� $4 .Resources/ControlTemplate/Controltemplate.xaml?�%�,  &	        &	 N     &	 c     &	 �    &	     &	 /    &	 D    &	 Y    &	 n    &		 �    &	
 �    &	 �    &	     &	      &	 5    &	 J    &	 �    &	 �    &	     &	 (    &	 =    &	 R    &	 g    &	 �    &	 �    &	 �    &	      &	     &	 *    &	 ?    &	 V    &	 m    7  7  7  7  7  7  7 	 7  7 
 7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  &	  �    7  7  7  &	! '    7  &	" �    7   7  7  7 ! 7   &	# �    &	$ ~     &	% 
!    7 $ 7 $ &	& "    &	' E#    �� .���  � �� �� .R��� $��2q�$	 1 2R�#��� �� . $��1���� $ 	#FFFFFFFF���� " ��.���  �@�OverridesDefaultStyle . ��  �@J�	AllowDrop . ��  � ��$ 0����  � ��$ 0����  �@�FocusVisualStyle Z� ��  �@��PanningMode$ VerticalFirst=���  �@��IsFlicksEnabled .  ��  � �� �� "	 ��.R��� $
 PART_ContentHost��
������ |�.  $��Hidden=�$��Hidden=��� $	 0,1&�$	 0,0&�.��� $ 	#FFF0F0F0��$	 0.0Q�� $ 	#FFE5E5E5��$	 1.0Q��� $ 	#FFACACAC���� $ 	#FF606060���� $ 	#FFFFFFFF���� $ 	#FFABADB3���� $ Transparent���� $ Transparent���� $	 0,1&�$	 0,0&�.��� $ 	#FFECF4FC��$	 0.0Q�� $ 	#FFDCECFC��$	 1.0Q��� $ 	#FF7EB4EA���� $ 	#FF000000���� $ 	#FFFFFFFF���� $ 	#FF7EB4EA���� $	 0,1&�$	 0,0&�.��� $ 	#FFEBF4FC��$	 0.0Q�� $ 	#FFDCECFC��$	 1.0Q��� $ 	#FF7EB4EA���� $	 0,1&�$	 0,0&�.��� $ 	#FFDAECFC��$	 0.0Q�� $ 	#FFC4E0FC��$	 1.0Q��� $ 	#FF569DE5���� $ 	#FF000000���� $ 	#FFFFFFFF���� $ 	#FF569DE5���� $	 0,1&�$	 0,0&�.��� $ 	#FFDAEBFC��$	 0.0Q�� $ 	#FFC4E0FC��$	 1.0Q��� $ 	#FF569DE5���� $ 	#FFF0F0F0���� $ 	#FFD9D9D9���� $ 	#FFBFBFBF���� $ 	#FFFFFFFF���� $ 	#FFBFBFBF���� $ Transparent���� $ Transparent���� " d�.���  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  �@��	ClickMode$ Press=���  � �� �� "	 d�.R��� $ templateRoot��8��  8�� #��z�� . ._��� $ splitBorder��
������ $��1q�$��Right=�$��0q� . #��� r�._�F� $ arrow��F����        ���( ��( јaQ     јaQ P����̰( � �    P����        8�� $��Center=�$��0q�$��Center=� ^�  ��  �� *
IsEditable+ �� " �� true��  �� *IsMouseOver+ �� $
 Self=�	 false��  �� *	IsPressed+ �� $
 Self=�	 false��  �� *	IsEnabled+ �� $
 Self=� true.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ���� $ splitBorder��8   � ���� $ splitBorder��8   � ��P�  �@J�IsMouseOver . . ��� $ arrow��8   � ��^�  ��  �� *IsMouseOver+ �� $
 Self=� true��  �� *
IsEditable+ �� " ��	 false.0��� $ templateRoot��8   � ���� $ templateRoot��8 	  � ��^�  ��  �� *IsMouseOver+ �� $
 Self=� true��  �� *
IsEditable+ �� " �� true.0��� $ templateRoot��8 
  � ���� $ templateRoot��8   � ���� $ splitBorder��8   � ���� $ splitBorder��8   � ��P�  � �� . . ��� $ arrow��8   � ��^�  ��  �� *	IsPressed+ �� $
 Self=� true��  �� *
IsEditable+ �� " ��	 false.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ��^�  ��  �� *	IsPressed+ �� $
 Self=� true��  �� *
IsEditable+ �� " �� true.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ���� $ splitBorder��8   � ���� $ splitBorder��8   � ��P�  � {� .  . ��� $ arrow��8   � ��^�  ��  �� *	IsEnabled+ �� $
 Self=�	 false��  �� *
IsEditable+ �� " ��	 false.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ��^�  ��  �� *	IsEnabled+ �� $
 Self=�	 false��  �� *
IsEditable+ �� " �� true.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ���� $ splitBorder��8   � ���� $ splitBorder��8   � ���� "	 ��.R�� $ templateRoot�� .  �� $��* ��� #��� r�$��0 �.+�� $ 
PART_Popup�� . $��2��$��Bottom=�#��� .����� *IsDropDownOpen+ �� $ TemplatedParent=�.��  $ shadow��$  Transparent��#��z! ���� *ActualWidth+$" templateRoot��._��� $ dropDownBorder��#��� ��#��� ��$��1q�._��� $
 DropDownScrollViewer��.��� $
 grid��$# Enabled=�.+��� $$ canvas��$
��Left=�$��0��$	��Top=�$��0��.+��� $% 
opaqueRect������ *
Background+$" dropDownBorder������ *ActualHeight+$" dropDownBorder������ *ActualWidth+$" dropDownBorder���� $& ItemsPresenter��$' 	Contained=�# z d� $( toggleButton��#��z��#��z��#��z��$��2��8��  ) �� *IsDropDownOpen+$* TwoWay=� �� $ TemplatedParent=��� $ border��8�� #��z��._��� $+ PART_EditableTextBox��#��z��#��z��8�� #��z��, �� *
IsReadOnly+ �� $ TemplatedParent=� P�  � {� .  . ��� $ border�� �@J�Opacity$
 0.56Q�P�  �@J�IsKeyboardFocusWithin . . ���  � ��
 �   �P� $- 
PART_Popup�� �@�HasDropShadow . . ��� $ shadow�� � ��$ 0,0,5,5q��� $ shadow�� �@ Color$ 	#71000000��P�  �@��HasItems .  . ��� $ dropDownBorder�� � ��$ 95��]� . �� / �@��
IsGrouping . �� "/ �@%�IsVirtualizingWhenGrouping .  ./���  � �� .  P� $- DropDownScrollViewer�� � �� .  . ��� $ 
opaqueRect�� �� *VerticalOffset+$" DropDownScrollViewer�� �@��Top�� $ 
opaqueRect�� �� *HorizontalOffset+$" DropDownScrollViewer�� �@��Left�� "	 ��.R�� $ templateRoot�� .  �� $��* ��� #��� r�$��0 �.+�� $ 
PART_Popup�� . $��2��$��1q�$��Bottom=�#��� .����� *IsDropDownOpen+$* TwoWay=� �� $ TemplatedParent=�.��  $ shadow��$  Transparent��#��z! ���� *ActualWidth+$" templateRoot��._��� $ dropDownBorder��#��� ��$0 5��#��� ��$��0q�._��� $
 DropDownScrollViewer��.��� $
 grid��$# Enabled=�.+��� $$ canvas��$
��Left=�$��0��$	��Top=�$��0��.+��� $% 
opaqueRect������ *
Background+$" dropDownBorder������ *ActualHeight+$" dropDownBorder������ *ActualWidth+$" dropDownBorder���� $& ItemsPresenter��$' 	Contained=�# z d� $( toggleButton��#��z��#��z��#��z��$��2��8��  ) �� *IsDropDownOpen+$* TwoWay=� �� $ TemplatedParent=��� $1 contentPresenter��#3 z2 #��z4 #��z5 #��z��#��z��6 .  #��z��# z #��z�� P� $- 
PART_Popup�� �@�HasDropShadow . . ��� $ shadow�� � ��$ 0,0,5,5q��� $ shadow�� �@ Color$ 	#71000000��P�  �@��HasItems .  . ��� $ dropDownBorder�� � ��$ 95��]� . �� / �@��
IsGrouping . �� "/ �@%�IsVirtualizingWhenGrouping .  ./���  � �� .  P� $- DropDownScrollViewer�� � �� .  . ��� $ 
opaqueRect�� �� *VerticalOffset+$" DropDownScrollViewer�� �@��Top�� $ 
opaqueRect�� �� *HorizontalOffset+$" DropDownScrollViewer�� �@��Left�� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��# � ����  � ��$ 0q���  � ��$
 Auto=���  � ��$
 Auto=���  � ��$ 	6,10,6,10q���  � �� . ��  �@��PanningMode$
 Both=���  �@��IsFlicksEnabled .  ��  � ��8  7 P�  �@��
IsEditable . . ���  � �� .  ��  � ��$ 2q���  � ��8  �� "  .���  � �� �#F0F0F0��  � ��$ 0 4 0 0q���  �@J�SnapsToDevicePixels . ��  �@=�ErrorTemplate Z� ��  �@ ValidationErrorTemplate �� .R��� 
���  ��$��2,0,0,0q�$��!��$��Center=���  � �� �� "	  .R��� $ 
DGR_Border��#��z��$	8 0 8q�$0 5��$��0q� . ._�   �� $
��Auto ��� $��* �9 �� $��* ��� $
��Auto �.+�  $��1��#��z: # z   $��1��$��1��#y�z; < �� *AreRowDetailsFrozen+#> Z= #@ Z?  �� "  	  $��2��$< Vertical=�y��� *HeadersVisibility+#> ZA #@ ZB  �� "  7 P�  �@J�IsMouseOver . . ���  � �� �#623ed0��  � �� �#ffffff��  �@�Cursor$
 Hand��P�  �@ 
IsSelected . . ���  � �� �#623ed0��  � �� �#ffffff��  �@�Cursor$
 Hand��]� . �� / �@ 
IsSelected . �� / �@��IsSelectionActive .  ./���  � �� �#F0F0F0��  �@�Cursor$
 Hand���� " n�.���  � ��$ 8����  � ��
 ���� ��  �@�Cursor$ SizeWE����  � �� �� "	 n�.R��� #��z��#8 z���� "  .���  � ��$ Center=���  � ��
 ���� ��  � �� �#69717d��  � ��$ 15 0  15 10q���  � �� �� "	  .R�� .+�  #��z��#��z��#��z��#C z��#E zD #G zF #8 z��#I zH #K zJ #M zL ._��� #��z����. # z #��z��n� $N PART_LeftHeaderGripper��$
��Left=�8��  n� $N PART_RightHeaderGripper��$��Right=�8�� �� "  .���  � ��
 ���� ��  � ��$ Center=���  �@�FocusVisualStyle Z� ��  � ��$
 15 0q���  � �� �� "	  .R��� #��z��$��0q� . ._��� # z �� "  .���  � ��
 ���� ��  � �� �#222528��  � ��$ 0q���  �@ GridLinesVisibility$
 None=���   �@ RowDetailsVisibilityMode$ VisibleWhenSelected=���  � �� . ��  �@��PanningMode$
 Both=���  �@��IsFlicksEnabled .  ��  �@ AutoGenerateColumns .  ��  �@ HeadersVisibility$ Column=���  � ��$ 0 10 0 0q���  �@ SelectionMode$ Single=���  �@ SelectionUnit$ FullRow=���  �@ CanUserAddRows .  ��  �@ CanUserDeleteRows .  ��  �@ CanUserResizeColumns .  ��  �@ CanUserReorderColumns .  ��  � ��$ 14(���  �@ ColumnWidth$ * ��  � �� �� "	  .R��� #��z��#��z��#��z��#8 z�� . ._��� $
 DG_ScrollViewer��|�.  ���� "	 ��.R��  �� $
��Auto ��� $��* ��� $
��Auto �9 �� $
��Auto ��� $��* ��� $
��Auto �.+��� #��ZO |�.  ��C� *�� $"P DataGridSelectAllButtonStyle��"Q  +y��� *HeadersVisibility+#> ZR #@ ZB  �� "  ���� *CellsPanelHorizontalOffset+ �� "    $!S PART_ColumnHeadersPresenter��$��1��y��� *HeadersVisibility+#> ZT #@ ZB  �� "  �� $!U PART_ScrollContentPresenter��#V z��$��2��$��1���� $W PART_VerticalScrollBar��$��2��#Y zX $Z Vertical=�$��1��#\ z[ #y�z] ^ �� *VerticalOffset+$* OneWay=� �� $ TemplatedParent=�� $��1��$��2�� �� ���� **(NonFrozenColumnsViewportHorizontalOffset+ �� "  �� $��* �.+��� $W PART_HorizontalScrollBar��$��1��#Y z_ $Z 
Horizontal=�#\ z` #y�za ^ �� *HorizontalOffset+$* OneWay=� �� $ TemplatedParent=�.���� # z 7 ]� . �� / �@��
IsGrouping . �� "/ �@%�IsVirtualizingWhenGrouping .  ./���  � �� .  